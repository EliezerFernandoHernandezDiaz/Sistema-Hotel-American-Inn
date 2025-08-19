using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using MySqlConnector;

namespace Clave5_Grupo6
{
    public partial class frmPago : Form
    {
        // Recibimos la habitación seleccionada desde el form anterior
        private readonly int _habitacionId;
        private decimal _precioBase = 0m;
        private readonly int _clienteId;
        private string _clienteNombre;
        private int _hotelId;

        public frmPago(int habitacionId, int clienteId)
        {
            InitializeComponent();
            _habitacionId = habitacionId;
            _clienteId = clienteId;

            // Combos
            cmbTipoPagofrmPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoPagofrmPago.Items.Clear();
            cmbTipoPagofrmPago.Items.AddRange(new[] { "Efectivo", "Tarjeta", "Bitcoin" });

            // Campos calculados
            txtNoches.ReadOnly = true;

            // Eventos para Recalcular automáticamente
            dtpCheckInn.ValueChanged += (_, __) => RecalcularMontos();
            dtpCheckOut.ValueChanged += (_, __) => RecalcularMontos();
            chkIngresoAnticipado.CheckedChanged += (_, __) => RecalcularMontos();
        }

        // ============ Infraestructura de conexión ============
        private MySqlConnection NuevaConexion()
        {
            var cs = ConfigurationManager.ConnectionStrings["MySqlConn"]?.ConnectionString;
            return new MySqlConnection(cs);
        }

        // ============ Load ============
        private void frmPago_Load(object sender, EventArgs e)
        {
            CargarClienteActual();
            CargarPrecioBaseHabitacion();
            // ✅ Valores iniciales de check-in y check-out
            dtpHoraCheckInn.Format = DateTimePickerFormat.Time;
            dtpHoraCheckInn.ShowUpDown = true;
            dtpHoraCheckInn.Value = DateTime.Today.AddHours(16); // 16:00

            dtpHoraCheckOut.Format = DateTimePickerFormat.Time;
            dtpHoraCheckOut.ShowUpDown = true;
            dtpHoraCheckOut.Value = DateTime.Today.AddHours(14).AddDays(1); // siguiente día 14:00

            //para que no se pueda editar las horas en caso de que no se ingrese anticipadamente
            if (!chkIngresoAnticipado.Checked)
            {
                dtpHoraCheckInn.Enabled = false;
                dtpHoraCheckOut.Enabled = false;
            }


            RecalcularMontos();

        }

        // Cargar huesped en el label 
        private void CargarClienteActual()
        {
            using var cn = NuevaConexion();
            cn.Open();

            var sql = @"
        SELECT 
            CONCAT(
                c.dui, ' - ', c.nombre, ' ', c.apellidos,
                ' | ', h.Tipo_de_hotel,
                ' | ', h.Tipo_de_Habitacion,
                ' | Código: ', h.codigo_habitacion
            ) AS TextoCliente,
            h.hotel_id,
            h.id_Habitaciones,
            h.codigo_habitacion,
            h.Tipo_de_hotel,
            h.Tipo_de_Habitacion
        FROM cliente c
        JOIN tabla_habitaciones h ON h.id_Habitaciones = @hab
        WHERE c.id = @cli;";

            using var cmd = new MySqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@cli", _clienteId);
            cmd.Parameters.AddWithValue("@hab", _habitacionId);

            using var rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                var textoCliente = rd["TextoCliente"].ToString();

                // *** MANEJO CORRECTO DE VALORES NULL ***
                var hotelIdValue = rd["hotel_id"];
                if (hotelIdValue == null || hotelIdValue == DBNull.Value)
                {
                    // Si hotel_id es NULL, usar un valor por defecto o el mismo ID de habitación
                    _hotelId = _habitacionId; // O usar 0, o cualquier valor por defecto
                    Console.WriteLine($"WARNING: hotel_id es NULL para habitación {_habitacionId}, usando habitación ID como fallback");
                }
                else
                {
                    _hotelId = Convert.ToInt32(hotelIdValue);
                }

                lblNombreCliente.Text = "Cliente: " + textoCliente;
            }
            else
            {
                MessageBox.Show("No se encontraron datos con los IDs proporcionados", "Error - Sin datos");
            }
        }


        // Leer precio base de la habitación y pintarlo
        private void CargarPrecioBaseHabitacion()
        {
            using var cn = NuevaConexion();
            cn.Open();
            using var cmd = new MySqlCommand(
                "SELECT Precio_Base FROM tabla_habitaciones WHERE id_Habitaciones = @id;", cn);
            cmd.Parameters.AddWithValue("@id", _habitacionId);

            var val = cmd.ExecuteScalar();
            _precioBase = (val == null || val == DBNull.Value) ? 0m : Convert.ToDecimal(val);

            txtPrecioBase.Text = _precioBase.ToString("C2", CultureInfo.CurrentCulture);
        }

        // ============ Cálculos ============
        private void RecalcularMontos()
        {
            DateTime entrada = dtpCheckInn.Value;
            DateTime salida = dtpCheckOut.Value;

            if (salida <= entrada)
            {
                txtNoches.Text = "0";
                txtPrecioFinalfrmPago.Text = 0m.ToString("C2");
                lblDisponibilidad.Text = "Fechas inválidas";
                return;
            }

            int noches = (int)(salida.Date - entrada.Date).TotalDays;
            if (noches < 1) noches = 1;
            txtNoches.Text = noches.ToString();

            decimal subtotal = _precioBase * noches;
            decimal extra = chkIngresoAnticipado.Checked ? 20m : 0m;
            decimal imponible = subtotal + extra;
            decimal iva = Math.Round(imponible * 0.13m, 2);
            decimal total = imponible + iva;

            txtPrecioBase.Text = subtotal.ToString("C2", CultureInfo.CurrentCulture);
            txtPrecioFinalfrmPago.Text = total.ToString("C2", CultureInfo.CurrentCulture);

            // disponibilidad solo de esa habitación
            lblDisponibilidad.Text = EstaDisponible(_habitacionId, _hotelId,entrada, salida)
                ? "Disponible"
                : "Ocupada";
        }

        // Validación de disponibilidad por habitación
        private bool EstaDisponible(int habitacionId, int hotelId, DateTime entrada, DateTime salida)
        {
            using var cn = NuevaConexion();
            cn.Open();
            var sql = @"
        SELECT COUNT(*)
        FROM tabla_reserva r
        JOIN tabla_habitaciones h ON r.habitacion_id = h.id_Habitaciones
        WHERE r.habitacion_id = @hab
          AND h.hotel_id = @hotel
          AND NOT (r.fecha_salida <= @in OR r.fecha_entrada >= @out);";
            using var cmd = new MySqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@hab", habitacionId);
            cmd.Parameters.AddWithValue("@hotel", hotelId);
            cmd.Parameters.AddWithValue("@in", entrada.Date);
            cmd.Parameters.AddWithValue("@out", salida.Date);
            return Convert.ToInt32(cmd.ExecuteScalar()) == 0;
        }


        // ============ Acciones ============
        private void btnAgregarDatosPago_Click(object sender, EventArgs e)
        {
            if (cmbTipoPagofrmPago.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el método de pago.");
                return;
            }

            var entrada = dtpCheckInn.Value.Date;
            var salida = dtpCheckOut.Value.Date;

            if (salida <= entrada)
            {
                MessageBox.Show("La fecha de salida debe ser posterior a la de entrada.");
                return;
            }
            if (!EstaDisponible(_habitacionId, _hotelId, entrada, salida))
            {
                MessageBox.Show("La habitación no está disponible en ese rango.");
                return;
            }


            int noches = int.Parse(txtNoches.Text);
            decimal subtotal = _precioBase * noches;
            decimal extra = chkIngresoAnticipado.Checked ? 20m : 0m;
            decimal imponible = subtotal + extra;
            decimal iva = Math.Round(imponible * 0.13m, 2);
            decimal total = imponible + iva;

            try
            {
                using var cn = NuevaConexion();
                cn.Open();
                using var tx = cn.BeginTransaction();

                // 1) Crear la reserva
                int reservaId;
                using (var insR = new MySqlCommand(@"
            INSERT INTO tabla_reserva
              (cliente_id, habitacion_id, fecha_entrada, fecha_salida, ingreso_anticipado, estado)
            VALUES
              (@cli, @hab, @in, @out, @ant, 'PENDIENTE');
            SELECT LAST_INSERT_ID();", cn, tx))
                {
                    insR.Parameters.AddWithValue("@cli", _clienteId);
                    insR.Parameters.AddWithValue("@hab", _habitacionId);
                    insR.Parameters.AddWithValue("@in", entrada);
                    insR.Parameters.AddWithValue("@out", salida);
                    insR.Parameters.AddWithValue("@ant", chkIngresoAnticipado.Checked ? 1 : 0);
                    reservaId = Convert.ToInt32(insR.ExecuteScalar());
                }

                // 2) Insertar el pago
                using (var insP = new MySqlCommand(@"
            INSERT INTO pagos
              (reserva_id, metodo_pago, precio_base, noches, subtotal, extra_ingreso, iva, total)
            VALUES
              (@res, @met, @base, @noches, @sub, @extra, @iva, @tot);", cn, tx))
                {
                    insP.Parameters.AddWithValue("@res", reservaId);
                    insP.Parameters.AddWithValue("@met", cmbTipoPagofrmPago.Text);
                    insP.Parameters.AddWithValue("@base", _precioBase);
                    insP.Parameters.AddWithValue("@noches", noches);
                    insP.Parameters.AddWithValue("@sub", subtotal);
                    insP.Parameters.AddWithValue("@extra", extra);
                    insP.Parameters.AddWithValue("@iva", iva);
                    insP.Parameters.AddWithValue("@tot", total);
                    insP.ExecuteNonQuery();
                }

                tx.Commit();
                MessageBox.Show("Reserva y pago registrados correctamente.");
                btnMostrarPagos_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message);
            }
        }
    
        private void btnMostrarPagos_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            try
            {
                using var cn = NuevaConexion();
                using var da = new MySqlDataAdapter(@"
                    SELECT 
                      p.id,
                      r.id_reserva,
                      c.dui,
                      CONCAT(c.nombre, ' ', c.apellidos) AS cliente,
                      h.codigo_habitacion,
                      p.metodo_pago,
                      p.precio_base,
                      p.noches,
                      p.subtotal,
                      p.extra_ingreso,
                      p.iva,
                      p.total,
                      p.creado_en
                    FROM pagos p
                    JOIN tabla_reserva r      ON r.id_reserva = p.reserva_id
                    JOIN cliente c            ON c.id = r.cliente_id
                    JOIN tabla_habitaciones h ON h.id_Habitaciones = r.habitacion_id
                    ORDER BY p.id DESC;", cn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar pagos: " + ex.Message);
            }
            dgvMostrarTablaPago.DataSource = dt;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMostrarTablaPago.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un pago en la tabla.");
                return;
            }

            var cell = dgvMostrarTablaPago.SelectedRows[0].Cells["id"];
            if (cell == null)
            {
                MessageBox.Show("No se encontró la columna 'id' en el grid.");
                return;
            }

            var idPago = Convert.ToInt32(cell.Value);

            if (MessageBox.Show("¿Eliminar el pago seleccionado?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using var cn = NuevaConexion();
                cn.Open();
                using var cmd = new MySqlCommand("DELETE FROM pagos WHERE id = @id;", cn);
                cmd.Parameters.AddWithValue("@id", idPago);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Pago eliminado.");
                btnMostrarPagos_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el pago: " + ex.Message);
            }
        }

        private void btnLimpiarCamposPago_Click(object sender, EventArgs e)
        {
            txtNoches.Clear();
            txtPrecioBase.Clear();
            txtPrecioFinalfrmPago.Clear();
            chkIngresoAnticipado.Checked = false;

            if (cmbTipoPagofrmPago.Items.Count > 0) cmbTipoPagofrmPago.SelectedIndex = -1;

            dtpCheckInn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);
        }

        private void btnIrReservas_Click(object sender, EventArgs e)
        {
            var frm = new frmReserva();
            frm.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string obtenerDisponibilidad(int habitacionId, DateTime entrada, DateTime salida)
        {
            using var cn = NuevaConexion();
            cn.Open();

            var sql = @"
            SELECT COUNT(*) AS cantidad,
                   h.codigo_habitacion,
                   h.Tipo_de_hotel
            FROM tabla_reserva r
            JOIN tabla_habitaciones h ON h.id_Habitaciones = r.habitacion_id
            WHERE r.habitacion_id = @hab
              AND h.Tipo_de_hotel = (SELECT Tipo_de_hotel FROM tabla_habitaciones WHERE id_Habitaciones = @hab)
              AND NOT (r.fecha_salida <= @in OR r.fecha_entrada >= @out);";

            using var cmd = new MySqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@hab", habitacionId);
            cmd.Parameters.AddWithValue("@in", entrada.Date);
            cmd.Parameters.AddWithValue("@out", salida.Date);

            using var rd = cmd.ExecuteReader();
            if (rd.Read() && Convert.ToInt32(rd["cantidad"]) > 0)
            {
                string codigo = rd["codigo_habitacion"].ToString();
                string hotel = rd["Tipo_de_hotel"].ToString();
                return $"Ocupada ({hotel} - {codigo})";
            }
            return "Disponible";
        }

        private void chkIngresoAnticipado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIngresoAnticipado.Checked)
            {
                dtpHoraCheckInn.Enabled = true;
                dtpHoraCheckOut.Value = DateTime.Today.AddHours(14);
                dtpHoraCheckOut.Enabled = false;
            }
            else
            {
                dtpHoraCheckInn.Value = DateTime.Today.AddHours(16);
                dtpHoraCheckInn.Enabled = false;

                dtpHoraCheckOut.Value = DateTime.Today.AddHours(14);
                dtpHoraCheckOut.Enabled = false;
            }
            RecalcularMontos();
        }
        private void gbxDetallesPago_Enter(object sender, EventArgs e) { }
        // === HANDLERS QUE EL DISEÑADOR ESPERA ===

        // Evento TextChanged del txtPrecioBase
        private void txtPrecioBase_TextChanged(object sender, EventArgs e)
        {
            // Si no quieres que haga nada, déjalo vacío.
            // Puedes usarlo para forzar a recalcular si quieres:
            // RecalcularMontos();
        }

        // Evento TextChanged del txtPrecioFinalfrmPago
        private void txtPrecioFinalfrmPago_TextChanged(object sender, EventArgs e)
        {
            // Lo mismo: puede estar vacío si no necesitas lógica aquí.
        }

        // Evento Click del lblDisponibilidad
        private void lblDisponible_Click(object sender, EventArgs e)
        {
            // Actualiza el label según disponibilidad actual
            if (EstaDisponible(_habitacionId,_hotelId, dtpCheckInn.Value, dtpCheckOut.Value))
                lblDisponibilidad.Text = "Disponible";
            else
                lblDisponibilidad.Text = "Ocupada";
        }

    }
}
