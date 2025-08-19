    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;
    using MySqlConnector;
    using System.Configuration; // para leer la cadena de conexión desde app.config 

namespace Clave5_Grupo6
{
    public partial class frmReserva : Form
    {
        //Esta ficha muestra / actualiza una reserva ya creada
        private readonly int _idReserva;

        public frmReserva() : this(0)
        {

        }
        public frmReserva(int idReserva)
        {
            InitializeComponent();
        }
        //Helper privado para obtener la conexion desde app.config
        private MySqlConnection NuevaConexion()
        {
            var cs = ConfigurationManager.ConnectionStrings["MySqlConn"]?.ConnectionString;
            return new MySqlConnection(cs);

        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            //click por accidente
        }


        // Método para limpiar los campos
        private void LimpiarCampos()
        {

        }



        private decimal CalcularSubtotal(decimal precioHabitacion, DateTime fechaInicio, DateTime fechaFin)
        {
            // Calcula el número de días de la reserva
            int numeroDias = (int)(fechaFin - fechaInicio).TotalDays;

            // Calcula el subtotal multiplicando el precio de la habitación por día por la cantidad de días
            decimal subtotal = precioHabitacion * numeroDias;

            return subtotal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //No hace nada 
        }

        private void btnMostrarReservas_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            try
            {
                using var cn = NuevaConexion();
                using var da = new MySqlDataAdapter(@"
                    SELECT 
                      r.id_reserva,
                      h.Tipo_de_hotel   AS hotel,
                      h.Tipo_de_Habitacion AS habitacion,
                      r.fecha_entrada,
                      r.fecha_salida,
                      r.num_huespedes,
                      r.estado
                    FROM tabla_reserva r
                    JOIN tabla_habitaciones h ON h.id_Habitaciones = r.habitacion_id
                    ORDER BY r.id_reserva DESC;", cn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar reservas: " + ex.Message);
            }
            dgvReservas.DataSource = dt;
        }

        private void btnAgregarReserva_Click(object sender, EventArgs e)
        {
            if (_idReserva == 0)
            {
                MessageBox.Show("No hay reserva seleccionada.");
                return;
            }

            if (!int.TryParse(txtCantHuespedes.Text, out int n) || n <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida de huéspedes.");
                return;
            }

            using var cn = NuevaConexion();
            cn.Open();

            var up = new MySqlCommand(@"
                UPDATE tabla_reserva
                   SET num_huespedes = @n,
                       notas = @notas,
                       estado = 'CONFIRMADA'
                 WHERE id_reserva = @id;", cn);

            up.Parameters.AddWithValue("@n", n);
            up.Parameters.AddWithValue("@notas", string.IsNullOrWhiteSpace(txtInfoHuespedes.Text) ? (object)DBNull.Value : txtInfoHuespedes.Text);
            up.Parameters.AddWithValue("@id", _idReserva);

            up.ExecuteNonQuery();
            MessageBox.Show("Reserva confirmada.");

            // refresca ficha / listado
            CargarFicha(_idReserva);
            if (dgvReservas?.DataSource != null) btnMostrarReservas_Click(sender, e);
        }
        private void button3_Click(object sender, EventArgs e) //btnSalir
        {
            if (MessageBox.Show(this, "¿Quiere salir del programa?", "Cerrar aplicacion", MessageBoxButtons.YesNo,
           MessageBoxIcon.Question) == DialogResult.Yes) Application.Exit();
        }

        private void frmReserva_Load(object sender, EventArgs e)

        {
            using var cn = NuevaConexion();
            using var da = new MySqlDataAdapter(@"
        SELECT DISTINCT 
            c.id AS cliente_id,
            CONCAT(c.dui, ' - ', c.nombre, ' ', c.apellidos) AS NombreCompleto
        FROM cliente c
        JOIN tabla_reserva r ON c.id = r.cliente_id
        JOIN pagos p ON r.id_reserva = p.reserva_id;", cn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbSeleccionarHuesped.DataSource = dt;
            cmbSeleccionarHuesped.DisplayMember = "NombreCompleto";
            cmbSeleccionarHuesped.ValueMember = "cliente_id";
            cmbSeleccionarHuesped.SelectedIndex = -1;
            // Configurar campos como solo lectura
            txtHotelSeleccionado.ReadOnly = true;
            txtHabitacionSeleccionada.ReadOnly = true;
            txtMetPagoSeleccionado.ReadOnly = true;
            txtPrecioSinIVA.ReadOnly = true;
            txtPrecioFinal.ReadOnly = true;

            // Deshabilitar controles de fecha si es necesario
            dtpFechaEntrada.Enabled = false;
            dtpFechaSalida.Enabled = false;

            // Cargar datos
            if (_idReserva > 0)
                CargarFicha(_idReserva);

            CargarClientesPago();

            // Asignar evento después de cargar los datos
            cmbSeleccionarHuesped.SelectedIndexChanged += cmbSeleccionarHuesped_SelectedIndexChanged;
        }

        private void CargarClientesPago()
        {
            try
            {
                using var cn = NuevaConexion();
                using var da = new MySqlDataAdapter(@"
            SELECT 
                c.id AS cliente_id,
                CONCAT(c.dui, ' - ', c.nombre, ' ', c.apellidos) AS NombreCompleto
            FROM cliente c
            JOIN tabla_reserva r ON c.id = r.cliente_id
            JOIN pagos p ON r.id_reserva = p.reserva_id
            GROUP BY c.id, c.dui, c.nombre, c.apellidos
            ORDER BY c.nombre, c.apellidos;", cn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                // Agregar fila vacía al inicio
                DataRow emptyRow = dt.NewRow();
                emptyRow["cliente_id"] = DBNull.Value;
                emptyRow["NombreCompleto"] = "-- Seleccionar huésped --";
                dt.Rows.InsertAt(emptyRow, 0);

                cmbSeleccionarHuesped.DataSource = dt;
                cmbSeleccionarHuesped.DisplayMember = "NombreCompleto";
                cmbSeleccionarHuesped.ValueMember = "cliente_id";
                cmbSeleccionarHuesped.SelectedIndex = 0; // Selecciona la opción vacía
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar huéspedes: {ex.Message}");
            }
        }
        // Carga y pinta la ficha (JOIN con habitación y, si existe, con el último pago)
        private void CargarFicha(int idReserva)
        {
            using var cn = NuevaConexion();
            cn.Open();

            // Traemos datos de reserva + habitación (precio base) y el método de pago si ya hay pago
            var sql = @"
                SELECT 
                  r.id_reserva, r.fecha_entrada, r.fecha_salida, r.ingreso_anticipado,
                  r.num_huespedes, r.notas, r.estado,
                  h.Tipo_de_hotel, h.Tipo_de_Habitacion, h.Precio_Base,
                  p.metodo_pago, p.subtotal, p.extra_ingreso, p.iva, p.total
                FROM tabla_reserva r
                JOIN tabla_habitaciones h ON h.id_Habitaciones = r.habitacion_id
                LEFT JOIN pagos p ON p.reserva_id = r.id_reserva
                WHERE r.id_reserva = @id
                ORDER BY p.id DESC
                LIMIT 1;";

            using var cmd = new MySqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@id", idReserva);

            using var rd = cmd.ExecuteReader();
            if (!rd.Read())
            {
                MessageBox.Show("No se encontró la reserva.");
                return;
            }

            // Fechas
            if (Controls.ContainsKey("dtpFechaEntrada")) dtpFechaEntrada.Value = rd.GetDateTime("fecha_entrada");
            if (Controls.ContainsKey("dtpFechaSalida")) dtpFechaSalida.Value = rd.GetDateTime("fecha_salida");

            // Resumen de habitación / hotel
            if (Controls.ContainsKey("txtTipoHotel")) txtHotelSeleccionado.Text = rd["Tipo_de_hotel"]?.ToString();
            if (Controls.ContainsKey("txtTipoHabitacion")) txtHabitacionSeleccionada.Text = rd["Tipo_de_Habitacion"]?.ToString();
            if (Controls.ContainsKey("txtPrecioBaseHabitacion"))
                txtPrecioSinIVA.Text = rd.GetDecimal("Precio_Base").ToString("C2");

            // Si ya hay pago, mostramos método y total (si no hay, dejamos vacío)
            if (!rd.IsDBNull(rd.GetOrdinal("metodo_pago")) && Controls.ContainsKey("txtFormaPago"))
                txtMetPagoSeleccionado.Text = rd["metodo_pago"]?.ToString();

            if (!rd.IsDBNull(rd.GetOrdinal("total")) && Controls.ContainsKey("txtPrecioIvaTotal"))
                txtPrecioFinal.Text = rd.GetDecimal("total").ToString("C2");
            else if (Controls.ContainsKey("txtPrecioIvaTotal"))
                txtPrecioFinal.Text = ""; // aún no pagado

            // Si guardaste huéspedes/nota antes, precarga
            if (!rd.IsDBNull(rd.GetOrdinal("num_huespedes")) && Controls.ContainsKey("txtCantidadHuespedes"))
                txtCantHuespedes.Text = rd.GetInt32("num_huespedes").ToString();

            if (!rd.IsDBNull(rd.GetOrdinal("notas")) && Controls.ContainsKey("txtInfoHuespedes"))
                txtInfoHuespedes.Text = rd["notas"]?.ToString();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            //click accidental
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var q = (txtBuscarReserva.Text ?? "").Trim();

            var dt = new DataTable();
            try
            {
                using var cn = NuevaConexion();
                using var da = new MySqlDataAdapter(@"
            SELECT 
              r.id_reserva,
              h.codigo_habitacion,
              h.Tipo_de_hotel   AS hotel,
              h.Tipo_de_Habitacion AS habitacion,
              r.fecha_entrada,
              r.fecha_salida,
              r.num_huespedes,
              r.ingreso_anticipado,
              r.estado
            FROM tabla_reserva r
            JOIN tabla_habitaciones h ON h.id_Habitaciones = r.habitacion_id
            WHERE (@q = '' OR r.id_reserva = @qInt OR h.codigo_habitacion LIKE CONCAT('%', @q, '%'))
            ORDER BY r.id_reserva DESC;", cn);

                // Si el texto es numérico, úsalo como entero
                _ = int.TryParse(q, out var id);
                da.SelectCommand.Parameters.AddWithValue("@q", q);
                da.SelectCommand.Parameters.AddWithValue("@qInt", id);

                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar reservas: " + ex.Message);
            }

            dgvReservas.DataSource = dt;

        }
        private int _reservaSeleccionada = 0;
        private int _habitacionDeLaReserva = 0;

        private void dgvReservas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null) return;
            if (dgvReservas.CurrentRow.Cells["id_reserva"]?.Value == null) return;

            _reservaSeleccionada = Convert.ToInt32(dgvReservas.CurrentRow.Cells["id_reserva"].Value);

            // Trae los detalles para pintar los controles
            using var cn = NuevaConexion();
            cn.Open();
            using var cmd = new MySqlCommand(@"
        SELECT r.id_reserva, r.habitacion_id, r.fecha_entrada, r.fecha_salida,
               r.num_huespedes, r.notas, r.ingreso_anticipado
        FROM tabla_reserva r
        WHERE r.id_reserva = @id;", cn);
            cmd.Parameters.AddWithValue("@id", _reservaSeleccionada);

            using var rd = cmd.ExecuteReader();
            if (!rd.Read()) return;

            _habitacionDeLaReserva = rd.GetInt32("habitacion_id");
            dtpFechaEntrada.Value = rd.GetDateTime("fecha_entrada");
            dtpFechaSalida.Value = rd.GetDateTime("fecha_salida");
            txtCantHuespedes.Text = rd.IsDBNull(rd.GetOrdinal("num_huespedes")) ? "" : rd.GetInt32("num_huespedes").ToString();
            txtInfoHuespedes.Text = rd.IsDBNull(rd.GetOrdinal("notas")) ? "" : rd["notas"].ToString();
            // si tienes un checkbox de ingreso anticipado en este form:
            // chkIngresoAnticipado.Checked = rd.GetBoolean("ingreso_anticipado");
        }

        private bool EstaDisponible(int habitacionId, DateTime entrada, DateTime salida, int? excluirReservaId = null)
        {
            using var cn = NuevaConexion();
            cn.Open();
            var sql = @"
        SELECT COUNT(*)
        FROM tabla_reserva
        WHERE habitacion_id = @hab
          AND (@exc IS NULL OR id_reserva <> @exc)
          AND NOT (fecha_salida <= @in OR fecha_entrada >= @out);";
            using var cmd = new MySqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@hab", habitacionId);
            cmd.Parameters.AddWithValue("@in", entrada.Date);
            cmd.Parameters.AddWithValue("@out", salida.Date);
            cmd.Parameters.AddWithValue("@exc", (object?)excluirReservaId ?? DBNull.Value);
            return Convert.ToInt32(cmd.ExecuteScalar()) == 0;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (_reservaSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una reserva en la tabla.");
                return;
            }
            if (!int.TryParse(txtCantHuespedes.Text, out int numH) || numH <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida de huéspedes.");
                return;
            }
            var inDate = dtpFechaEntrada.Value.Date;
            var outDate = dtpFechaSalida.Value.Date;
            if (outDate <= inDate)
            {
                MessageBox.Show("La fecha de salida debe ser posterior a la fecha de entrada.");
                return;
            }

            // Validar disponibilidad si cambias fechas:
            if (!EstaDisponible(_habitacionDeLaReserva, inDate, outDate, _reservaSeleccionada))
            {
                MessageBox.Show("La habitación no está disponible en esas fechas.");
                return;
            }

            try
            {
                using var cn = NuevaConexion();
                cn.Open();
                using var cmd = new MySqlCommand(@"
            UPDATE tabla_reserva
               SET fecha_entrada = @in,
                   fecha_salida  = @out,
                   num_huespedes = @hues,
                   notas         = @notas
             WHERE id_reserva = @id;", cn);

                cmd.Parameters.AddWithValue("@in", inDate);
                cmd.Parameters.AddWithValue("@out", outDate);
                cmd.Parameters.AddWithValue("@hues", numH);
                cmd.Parameters.AddWithValue("@notas", string.IsNullOrWhiteSpace(txtInfoHuespedes.Text) ? (object)DBNull.Value : txtInfoHuespedes.Text);
                cmd.Parameters.AddWithValue("@id", _reservaSeleccionada);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Reserva actualizada.");
                btnBuscar_Click(sender, e); // refresca el grid según el filtro actual
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la reserva: " + ex.Message);
            }

        }

        private void btnEliminarReserva_Click(object sender, EventArgs e)
        {
            if (_reservaSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una reserva en la tabla.");
                return;
            }

            if (MessageBox.Show("¿Eliminar la reserva seleccionada?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using var cn = NuevaConexion();
                cn.Open();

                // Verifica pagos
                using (var chk = new MySqlCommand("SELECT COUNT(*) FROM pagos WHERE reserva_id = @id;", cn))
                {
                    chk.Parameters.AddWithValue("@id", _reservaSeleccionada);
                    var pagos = Convert.ToInt32(chk.ExecuteScalar());
                    if (pagos > 0)
                    {
                        MessageBox.Show("No se puede eliminar: la reserva tiene pagos asociados.");
                        return;
                    }
                }

                using (var del = new MySqlCommand("DELETE FROM tabla_reserva WHERE id_reserva = @id;", cn))
                {
                    del.Parameters.AddWithValue("@id", _reservaSeleccionada);
                    del.ExecuteNonQuery();
                }

                MessageBox.Show("Reserva eliminada.");
                _reservaSeleccionada = 0;
                btnBuscar_Click(sender, e); // refresca
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                MessageBox.Show("No se puede eliminar: la reserva tiene referencias (pagos u otras dependencias).");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la reserva: " + ex.Message);
            }
        }

        private void cmbSeleccionarHuesped_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar que hay una selección válida
            if (cmbSeleccionarHuesped.SelectedValue == null ||
                cmbSeleccionarHuesped.SelectedValue == DBNull.Value ||
                cmbSeleccionarHuesped.SelectedIndex <= 0)
            {
                LimpiarCamposHuesped();
                return;
            }

            try
            {
                using var cn = NuevaConexion();
                cn.Open();

                var sql = @"
            SELECT 
                h.Tipo_de_hotel,
                h.Tipo_de_habitacion,
                p.metodo_pago,
                p.precio_base,
                p.total,
                h.Equipo_disponible,
                r.fecha_entrada,
                r.fecha_salida
            FROM pagos p
            JOIN tabla_reserva r ON r.id_reserva = p.reserva_id
            JOIN tabla_habitaciones h ON h.id_Habitaciones = r.habitacion_id
            WHERE r.cliente_id = @cli
            ORDER BY p.id DESC
            LIMIT 1;";

                using var cmd = new MySqlCommand(sql, cn);

                // Conversión segura del SelectedValue
                int clienteId;
                if (int.TryParse(cmbSeleccionarHuesped.SelectedValue.ToString(), out clienteId))
                {
                    cmd.Parameters.AddWithValue("@cli", clienteId);
                }
                else
                {
                    MessageBox.Show("Error: ID de cliente no válido.");
                    return;
                }

                using var rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    // Llenar los campos con la información del huésped
                    txtHotelSeleccionado.Text = rd["Tipo_de_hotel"]?.ToString() ?? "";
                    txtHabitacionSeleccionada.Text = rd["Tipo_de_habitacion"]?.ToString() ?? "";
                    txtMetPagoSeleccionado.Text = rd["metodo_pago"]?.ToString() ?? "";

                    // Manejo seguro de valores decimales
                    if (rd["precio_base"] != DBNull.Value)
                        txtPrecioSinIVA.Text = Convert.ToDecimal(rd["precio_base"]).ToString("C2");
                    else
                        txtPrecioSinIVA.Text = "";

                    if (rd["total"] != DBNull.Value)
                        txtPrecioFinal.Text = Convert.ToDecimal(rd["total"]).ToString("C2");
                    else
                        txtPrecioFinal.Text = "";

                    txtEquipoDisponible.Text = rd["Equipo_disponible"]?.ToString() ?? "";

                    // Opcional: mostrar fechas de la reserva
                    if (rd["fecha_entrada"] != DBNull.Value)
                        dtpFechaEntrada.Value = rd.GetDateTime("fecha_entrada");
                    if (rd["fecha_salida"] != DBNull.Value)
                        dtpFechaSalida.Value = rd.GetDateTime("fecha_salida");
                }
                else
                {
                    MessageBox.Show("No se encontraron datos de pago para este huésped.");
                    LimpiarCamposHuesped();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar información del huésped: {ex.Message}");
            }
        }
        private void LimpiarCamposHuesped()
        {
            txtHotelSeleccionado.Text = "";
            txtHabitacionSeleccionada.Text = "";
            txtMetPagoSeleccionado.Text = "";
            txtPrecioSinIVA.Text = "";
            txtPrecioFinal.Text = "";
            txtEquipoDisponible.Text = "";
        }

    }
}