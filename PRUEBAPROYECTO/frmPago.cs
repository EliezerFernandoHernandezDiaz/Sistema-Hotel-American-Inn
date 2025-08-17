using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography; //Para leer la cadena de conexión desde app.config 
using System.Windows.Forms;
using MySqlConnector;

namespace Clave5_Grupo6
{
    public partial class frmPago : Form

       
    { 
        //VARIABLES GLOBALES
        private int _reservaIdActual = 0;
        private int _habitacionIdActual=0;
        private decimal _precioBase = 0m;
        public frmPago()
        {
            InitializeComponent();
            // evita que editen el combobox
            cmbReserva.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoPagofrmPago.DropDownStyle = ComboBoxStyle.DropDownList;

            //Metodos de pago 
            cmbTipoPagofrmPago.Items.Clear();
            cmbTipoPagofrmPago.Items.AddRange(new[] { "Efectivo", "Tarjeta", "Bitcoin" });

            //Cuando se cambia la reserva o fechas o ingreso anticipado se actualizan los precios
            cmbReserva.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoPagofrmPago.DropDownStyle = ComboBoxStyle.DropDownList;

            // Métodos de pago del enunciado
            cmbTipoPagofrmPago.Items.Clear();
            cmbTipoPagofrmPago.Items.AddRange(new[] { "Efectivo", "Tarjeta", "Bitcoin" });

            // Eventos: cuando cambia reserva o fechas o ingreso anticipado, recalculamos
            cmbReserva.SelectedIndexChanged += (_, __) => CargarReservaYRecalcular();
           dtpCheckInn.ValueChanged += (_, __) => RecalcularMontos();      // si permites modificar fechas aquí
           dtpCheckOut.ValueChanged += (_, __) => RecalcularMontos();
            chkIngresoAnticipado.CheckedChanged += (_, __) => RecalcularMontos();

        }
        // 1) Cargar reservas en el ComboBox (lo que el usuario va a pagar)
        private void CargarReservasEnCombo()
        {
            using var cn = NuevaConexion();
            using var da = new MySqlDataAdapter(@"
                SELECT 
                    r.id_reserva,
                    r.habitacion_id,
                    r.fecha_entrada,
                    r.fecha_salida,
                    r.ingreso_anticipado,
                    h.codigo_habitacion,
                    h.Precio_Base
                FROM tabla_reserva r
                JOIN tabla_habitaciones h ON h.id_Habitaciones = r.habitacion_id
                ORDER BY r.id_reserva DESC;", cn);

            var dt = new DataTable();
            da.Fill(dt);

            // Armar una columna legible para el display
            dt.Columns.Add("display", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                var codigo = row["codigo_habitacion"]?.ToString();
                var fIn = ((DateTime)row["fecha_entrada"]).ToString("yyyy-MM-dd");
                var fOut = ((DateTime)row["fecha_salida"]).ToString("yyyy-MM-dd");
                row["display"] = $"#{row["id_reserva"]} | {codigo} | {fIn} → {fOut}";
            }

            cmbReserva.DataSource = dt;
            cmbReserva.ValueMember = "id_reserva";
            cmbReserva.DisplayMember = "display";

            if (cmbReserva.Items.Count > 0)
                cmbReserva.SelectedIndex = 0;
        }
        //2 cargar los datos de la reserva y recalcular montos
        private void CargarReservaYRecalcular()
        {
            if (cmbReserva.SelectedValue == null) return;

            _reservaIdActual = Convert.ToInt32(cmbReserva.SelectedValue);

            using var cn = NuevaConexion();
            cn.Open();
            using var cmd = new MySqlCommand(@"
                SELECT 
                    r.habitacion_id,
                    r.fecha_entrada,
                    r.fecha_salida,
                    r.ingreso_anticipado,
                    h.Precio_Base
                FROM tabla_reserva r
                JOIN tabla_habitaciones h ON h.id_Habitaciones = r.habitacion_id
                WHERE r.id_reserva = @id;", cn);
            cmd.Parameters.AddWithValue("@id", _reservaIdActual);

            using var rd = cmd.ExecuteReader();
            if (!rd.Read())
            {
                MessageBox.Show("No se encontró la reserva seleccionada.");
                return;
            }

            _habitacionIdActual = rd.GetInt32("habitacion_id");
            _precioBase = rd.GetDecimal("Precio_Base");

            // Si en Pago quieres mostrar/permitir mover fechas, sincroniza los DTP
           dtpCheckInn.Value = rd.GetDateTime("fecha_entrada");
           dtpCheckOut.Value = rd.GetDateTime("fecha_salida");
            chkIngresoAnticipado.Checked = rd.GetBoolean("ingreso_anticipado");

            // Mostrar precio base
            txtPrecioBase.Text = _precioBase.ToString("C2", CultureInfo.CurrentCulture);

            RecalcularMontos();
        }
        // 3) Recalcular (noches, subtotal, extra, IVA, total)
        private void RecalcularMontos()
        {
            var entrada = dtpCheckInn.Value.Date;
            var salida = dtpCheckOut.Value.Date;

            // Validaciones simples
            if (salida <= entrada)
            {
                txtNoches.Text = "0";
                txtPrecioFinalfrmPago.Text = 0m.ToString("C2");
                return;
            }

            int noches = Math.Max(1, (salida - entrada).Days);  // al menos 1 noche
            txtNoches.ReadOnly = true;                          // Noches no se edita
            txtNoches.Text = noches.ToString();

            decimal subtotal = _precioBase * noches;
            decimal extra = chkIngresoAnticipado.Checked ? 20m : 0m;     // +$20 si ingreso anticipado
            decimal imponible = subtotal + extra;
            decimal iva = Math.Round(imponible * 0.13m, 2);              // IVA 13%
            decimal total = imponible + iva;

            txtPrecioFinalfrmPago.Text = total.ToString("C2", CultureInfo.CurrentCulture);
        }
        private Hotel ObtenerHotel(string tipoHotel)
        {
            switch (tipoHotel)
            {
                case "Ciudad":
                    return new HotelCiudad("Hotel American Inn", "Ciudad");

                case "Montaña":
                    return new HotelMontaña("Hotel montaña", "Montaña");

                case "Playa":
                    return new HotelPlaya("Hotel playa", "Playa");

                default:
                    return null;
            }
        }
        private Habitacion ObtenerHabitacion(Hotel hotel, string tipoHabitacion)
        {
            if (hotel != null)
            {
                return hotel.Habitaciones.FirstOrDefault(h => h.TipoHabitacion == tipoHabitacion);
            }
            return null;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Metodo para establecer conexion desde app.config
        private MySqlConnection NuevaConexion() 
        {
            //Lee la cadena desde app.config 
            var cs = ConfigurationManager.ConnectionStrings["MySqlConn"]?.ConnectionString;
            return new MySqlConnection(cs);
        }
        int CrearReservaProvisional(int clienteId, int habitacionId, DateTime entrada, DateTime salida, bool ingresoAnt)
        {
            using var cn = NuevaConexion();
            cn.Open();
            using var cmd = new MySqlCommand(@"
        INSERT INTO tabla_reserva
          (cliente_id, habitacion_id, fecha_entrada, fecha_salida, ingreso_anticipado, estado)
        VALUES
          (@cli, @hab, @in, @out, @ing, 'PENDIENTE');
        SELECT LAST_INSERT_ID();", cn);
            cmd.Parameters.AddWithValue("@cli", clienteId);
            cmd.Parameters.AddWithValue("@hab", habitacionId);
            cmd.Parameters.AddWithValue("@in", entrada.Date);
            cmd.Parameters.AddWithValue("@out", salida.Date);
            cmd.Parameters.AddWithValue("@ing", ingresoAnt ? 1 : 0);
            return Convert.ToInt32(cmd.ExecuteScalar()); 
        }
        

        private void btnAgregarDatosPago_Click(object sender, EventArgs e)
        {
            if (_reservaIdActual == 0)
            {
                MessageBox.Show("Seleccione una reserva.");
                return;
            }
            if (cmbTipoPagofrmPago.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el método de pago.");
                return;
            }

            // Tomar valores calculados desde los controles
            int noches = int.TryParse(txtNoches.Text, out var n) ? n : 0;
            if (noches <= 0)
            {
                MessageBox.Show("Rango de fechas inválido.");
                return;
            }

            decimal subtotal = _precioBase * noches;
            decimal extra = chkIngresoAnticipado.Checked ? 20m : 0m;
            decimal imponible = subtotal + extra;
            decimal iva = Math.Round(imponible * 0.13m, 2);
            decimal total = imponible + iva;

            try
            {
                using var cn = NuevaConexion();
                cn.Open();

                // Si permitiste cambiar fechas en Pago, opcionalmente actualiza la reserva aquí
                using (var up = new MySqlCommand(
                    "UPDATE tabla_reserva SET fecha_entrada=@in, fecha_salida=@out, ingreso_anticipado=@ant WHERE id_reserva=@id;", cn))
                {
                    up.Parameters.AddWithValue("@in", dtpCheckInn.Value.Date);
                    up.Parameters.AddWithValue("@out", dtpCheckOut.Value.Date);
                    up.Parameters.AddWithValue("@ant", chkIngresoAnticipado.Checked ? 1 : 0);
                    up.Parameters.AddWithValue("@id", _reservaIdActual);
                    up.ExecuteNonQuery();
                }

                // Insertar pago
                using (var cmd = new MySqlCommand(@"
                    INSERT INTO pagos
                      (reserva_id, metodo_pago, precio_base, noches, subtotal, extra_ingreso, iva, total)
                    VALUES
                      (@reserva_id, @metodo_pago, @precio_base, @noches, @subtotal, @extra, @iva, @total);", cn))
                {
                    cmd.Parameters.AddWithValue("@reserva_id", _reservaIdActual);
                    cmd.Parameters.AddWithValue("@metodo_pago", cmbTipoPagofrmPago.Text);
                    cmd.Parameters.AddWithValue("@precio_base", _precioBase);
                    cmd.Parameters.AddWithValue("@noches", noches);
                    cmd.Parameters.AddWithValue("@subtotal", subtotal);
                    cmd.Parameters.AddWithValue("@extra", extra);
                    cmd.Parameters.AddWithValue("@iva", iva);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Pago registrado correctamente.");
                btnMostrarPagos_Click(sender, e); // refresca el grid
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el pago: " + ex.Message);
            }
        }

        private void btnProbarConexfrmPago_Click(object sender, EventArgs e)
        {
            // Código para probar la conexión a la base de datos
            // Crea una instancia de la clase CConexion y utiliza el método EstablecerConexion
            CConexion conexionObj = new CConexion();
            MySqlConnection conexion = conexionObj.EstablecerConexion();

            if (conexion != null)
            {
                MessageBox.Show("Conexión exitosa");

            }
            else
            {
                MessageBox.Show("No se pudo establecer la conexión");
            }

        }

        private void btnMostrarPagos_Click(object sender, EventArgs e)
        {
            //Se elimina la cadena harcodeada 
           // string cadenaConexion = "database= clave5_grupo6db;  server=localhost; user id= root; password= Fernandomysql";
            DataTable dataTable = new DataTable();                     /*Estructura del btnMostrar pagos
                                                                        * este botón al accionarlo muestra la tabla de la bd que contiene
                                                                        * los pagos ya existentes*/

            try
            {
                using (var conexionDB = NuevaConexion())
                using (var comando = new MySqlCommand("SELECT* FROM tabla_pago;", conexionDB))
                {

                      /*Establece conexion con la bd
                                                                                                      * y especificamente con la tabla_pago
                                                                                                      * que es la que queremos mostrar en 
                                                                                               * el dgv de este formulario*/
                    comando.CommandType = CommandType.Text;
                    conexionDB.Open();
                    using (var resultado = comando.ExecuteReader())
                    {
                        dataTable.Load(resultado); /*Carga los datos obtenidos en un datatable*/ 
                    }    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvMostrarTablaPago.DataSource = dataTable;

        }

        private void btnIrReservas_Click(object sender, EventArgs e)
        {
            frmReserva frm = new frmReserva();
            frm.Show();
        }
        // (OPCIONAL) Valida disponibilidad al mover fechas aquí
        private bool EstaDisponible(int habitacionId, DateTime entrada, DateTime salida, int? excluirReserva = null)
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
            cmd.Parameters.AddWithValue("@exc", (object?)excluirReserva ?? DBNull.Value);
            return Convert.ToInt32(cmd.ExecuteScalar()) == 0;
        }

        private void btnLimpiarCamposPago_Click(object sender, EventArgs e)
        {
            txtNoches.Text = "";
            txtPrecioBase.Text = "";
            txtPrecioFinalfrmPago.Text = "";
            chkIngresoAnticipado.Checked = false;

            if (cmbTipoPagofrmPago.Items.Count > 0) cmbTipoPagofrmPago.SelectedIndex = -1;
            if (cmbReserva.Items.Count > 0) cmbReserva.SelectedIndex = -1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verifica si se ha seleccionado una fila en el DataGridView
            if (dgvMostrarTablaPago.SelectedRows.Count > 0)
            {
                // Obtiene el valor del campo idTablaPago de la fila seleccionada
                string idPago = dgvMostrarTablaPago.SelectedRows[0].Cells["idTablaPago"].Value.ToString();

                // Realiza la eliminación
                EliminarPago(idPago);

                // Actualiza el DataGridView después de la eliminación
                btnMostrarPagos_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.");
            }
        }

        // Método que ayuda a eliminar el pago
        private void EliminarPago(string idPago)
        {
            // Se establece conexión para eliminar el pago
            //se elimina la cadena harcodeada
          //  string cadenaConexion = "database=clave5_grupo6db;server=localhost;user id=root;password=Fernandomysql";

            try
            {
                using (var conexionDB = NuevaConexion())
                {
                    conexionDB.Open();

                    // Crea un comando para la eliminación con parámetros
                    string sql = "DELETE FROM tabla_pago WHERE idTablaPago = @idPago";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conexionDB))
                    {
                        // Agrega el parámetro para el idTablaPago
                        cmd.Parameters.AddWithValue("@idPago", idPago);

                        // Ejecuta la eliminación
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Pago eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el pago: " + ex.Message);
            }
        }

        private void frmPago_Load(object sender, EventArgs e)
        {

        }
    }
}