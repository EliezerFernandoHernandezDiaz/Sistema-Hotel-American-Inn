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

        public frmPago(int habitacionId, int clienteId)
        {
            InitializeComponent();
            _habitacionId = habitacionId;
            _clienteId = clienteId;

            // Combos
            cmbReserva.DropDownStyle = ComboBoxStyle.DropDownList;      // aquí se cargarán CLIENTES
            cmbTipoPagofrmPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoPagofrmPago.Items.Clear();
            cmbTipoPagofrmPago.Items.AddRange(new[] { "Efectivo", "Tarjeta", "Bitcoin" });

            // Campos calculados
            txtNoches.ReadOnly = true;

            // Recalcular automáticamente
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
            CargarClientesEnCombo();
            CargarPrecioBaseHabitacion();
            RecalcularMontos();
        }

        // Cargar CLIENTES en cmbReserva (id + texto legible)
        private void CargarClientesEnCombo()
        {
            using var cn = NuevaConexion();
            using var da = new MySqlDataAdapter(@"
                SELECT id, CONCAT(dui, ' - ', nombre, ' ', apellidos) AS display
                FROM cliente
                ORDER BY nombre, apellidos;", cn);

            var dt = new DataTable();
            da.Fill(dt);

            cmbReserva.DataSource = dt;
            cmbReserva.ValueMember = "id";        // <-- id del cliente
            cmbReserva.DisplayMember = "display";

            cmbReserva.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReserva.AutoCompleteMode = AutoCompleteMode.None;
            cmbReserva.AutoCompleteSource = AutoCompleteSource.None;

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
            var entrada = dtpCheckInn.Value.Date;
            var salida = dtpCheckOut.Value.Date;

            if (salida <= entrada)
            {
                txtNoches.Text = "0";
                txtPrecioFinalfrmPago.Text = 0m.ToString("C2");
                lblDisponibilidad.Text = "Fechas inválidas";
                return;
            }

            int noches = Math.Max(1, (salida - entrada).Days);
            txtNoches.Text = noches.ToString();

            decimal subtotal = _precioBase * noches;
            decimal extra = chkIngresoAnticipado.Checked ? 20m : 0m;
            decimal imponible = subtotal + extra;
            decimal iva = Math.Round(imponible * 0.13m, 2);
            decimal total = imponible + iva;

            txtPrecioFinalfrmPago.Text = total.ToString("C2", CultureInfo.CurrentCulture);
            //Actualiza la disponibilidad
            lblDisponibilidad.Text = EstaDisponible(_habitacionId, entrada, salida) ? "Disponible" : "Ocupada";
        }

        // Disponibilidad simple: no solapa fechas con otras reservas de la misma habitación
        private bool EstaDisponible(int habitacionId, DateTime entrada, DateTime salida)
        {
            using var cn = NuevaConexion();
            cn.Open();
            var sql = @"
                SELECT COUNT(*)
                FROM tabla_reserva
                WHERE habitacion_id = @hab
                  AND NOT (fecha_salida <= @in OR fecha_entrada >= @out);";
            using var cmd = new MySqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@hab", habitacionId);
            cmd.Parameters.AddWithValue("@in", entrada.Date);
            cmd.Parameters.AddWithValue("@out", salida.Date);
            return Convert.ToInt32(cmd.ExecuteScalar()) == 0;
        }

        // ============ Acciones ============
        private void btnAgregarDatosPago_Click(object sender, EventArgs e)
        {
            // Validaciones mínimas
            if (cmbReserva.SelectedValue == null)
            {
                MessageBox.Show("Seleccione el cliente.");
                return;
            }
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
            if (!EstaDisponible(_habitacionId, entrada, salida))
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

                // 1) Crear la reserva (pendiente); se puede confirmar luego en frmReserva
                int reservaId;
                using (var insR = new MySqlCommand(@"
                    INSERT INTO tabla_reserva
                      (cliente_id, habitacion_id, fecha_entrada, fecha_salida, ingreso_anticipado, estado)
                    VALUES
                      (@cli, @hab, @in, @out, @ant, 'PENDIENTE');
                    SELECT LAST_INSERT_ID();", cn, tx))
                {
                    insR.Parameters.AddWithValue("@cli", (int)cmbReserva.SelectedValue); // id cliente
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
                btnMostrarPagos_Click(sender, e); // refrescar grilla
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
            if (cmbReserva.Items.Count > 0) cmbReserva.SelectedIndex = -1;

            // Reestablecer fechas a hoy/mañana por comodidad
            dtpCheckInn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);
        }

        private void btnIrReservas_Click(object sender, EventArgs e)
        {
            // Si necesitas abrir la ficha de reserva final:
            // var frm = new frmReserva(reservaId); // cuando tengas el id
            var frm = new frmReserva(); // ficha general
            frm.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrecioFinalfrmPago_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecioBase_TextChanged(object sender, EventArgs e)
        {
            //Actualizar el precio base segun las noches de hospedaje
            txtPrecioBase.Text = _precioBase.ToString("C2");
        }

        private void lblDisponible_Click(object sender, EventArgs e)
        {
            if (EstaDisponible(_habitacionId, dtpCheckInn.Value, dtpCheckOut.Value))
                lblDisponibilidad.Text = "Disponible";
            else
                lblDisponibilidad.Text = "Ocupada";

        }

        private void chkIngresoAnticipado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIngresoAnticipado.Checked)
            {
                // Permite cambiar solo la hora de entrada
               dtpHoraCheckInn.Enabled = true;

                // Hora de salida fija
                dtpHoraCheckOut.Value = DateTime.Today.AddHours(14);
              dtpHoraCheckOut.Enabled = false;
            }
            else
            {
                // Si no hay ingreso anticipado, fija ambas horas por defecto
               dtpHoraCheckInn.Value = DateTime.Today.AddHours(16);
                dtpHoraCheckInn.Enabled = false;

                dtpHoraCheckOut.Value = DateTime.Today.AddHours(14);
               dtpHoraCheckOut.Enabled = false;
            }
            //Recalcula montos si cambia a ingreso anticpado 
            RecalcularMontos();
        }

        private void gbxDetallesPago_Enter(object sender, EventArgs e)
        {

        }
    }
}
