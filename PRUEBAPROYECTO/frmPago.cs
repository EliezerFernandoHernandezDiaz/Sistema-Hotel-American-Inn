using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySqlConnector;
using System.Configuration;
using System.Security.Cryptography; //Para leer la cadena de conexión desde app.config 

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
            cmbReserva.SelectedIndexChanged += (_, __) =>();


        }

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
                h.Precio_base
                FROM tabla_reserva r
                JOIN tabla_habitaciones h ON h.id_Habitaciones= r.habitacion_id
                WHERE r.id_reserva= @id;", cn);
            cmd.Parameters.AddWithValue("@id", _reservaIdActual);
            using var rd = cmd.ExecuteReader();

        }
        private void ActualizarPrecios(object sender, EventArgs e)
        {
            string tipoHotel = cmb.Text;
            string tipoHabitacion = cmbTipoHabitacionfrmPago.Text;

            Hotel hotel = ObtenerHotel(tipoHotel);
            Habitacion habitacion = ObtenerHabitacion(hotel, tipoHabitacion);

            if (habitacion != null)
            {
                // Mostrar el precio de la habitación en el TextBox correspondiente
                txtPrecioBase.Text = habitacion.Precio.ToString("0.00");

                // Calcular y mostrar el precio final incluyendo el IVA
                decimal iva = 0.13m; // IVA del 13%
                decimal precioFinal = habitacion.Precio + (habitacion.Precio * iva);
                txtPrecioFinalfrmPago.Text = precioFinal.ToString("0.00");
            }
            else
            {
                // Si no se encuentra la habitación, establecer los TextBox a cero
                txtPrecioBase.Text = "0.00";
                txtPrecioFinalfrmPago.Text = "0.00";
            }
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

        // Ejemplo de navegación:
        int idReserva = CrearReservaProvisional(clienteId, habitacionId, dtpEntrada.Value, dtpSalida.Value, chkIngresoAnt.Checked);
        var frm = new frmPago(idReserva);
        frm.Show();

        private void btnAgregarDatosPago_Click(object sender, EventArgs e)
        {
            //Se borra la cadena harcodeada 
            // string cadenaConexion = "database=clave5_grupo6db;server=localhost;user id=root;password=Fernandomysql";
            // asumiendo: cmbReserva (ValueMember=id_reserva), cmbMetodoPago (Efectivo/Tarjeta/Bitcoin)
            int reservaId = (int)cmbReserva.SelectedValue;
            decimal precioBase = /* del dataset de la vista o consulta */;
            int noches = Math.Max(1, (fechaSalida - fechaEntrada).Days);
            decimal subtotal = precioBase * noches;
            decimal extra = chkIngresoAnticipado.Checked ? 20m : 0m;
            decimal iva = Math.Round(subtotal * 0.13m, 2);
            decimal total = subtotal + iva + extra;


            try
            {
                using (var cn = NuevaConexion())
                {
                    cn.Open();
                    string sql = @"INSERT INTO pagos
                   (reserva_id, metodo_pago, precio_base, noches, subtotal, extra_ingreso, iva, total)
                   VALUES (@reserva_id, @metodo, @precio_base, @noches, @subtotal, @extra, @iva, @total)";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@reserva_id", reservaId);
                        cmd.Parameters.AddWithValue("@metodo", cmbTipoPagofrmPago.Text);
                        cmd.Parameters.AddWithValue("@precio_base", precioBase);
                        cmd.Parameters.AddWithValue("@noches", noches);
                        cmd.Parameters.AddWithValue("@subtotal", subtotal);
                        cmd.Parameters.AddWithValue("@extra", extra);
                        cmd.Parameters.AddWithValue("@iva", iva);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.ExecuteNonQuery();
                    }
                }
                /*Uso del try catch para manejar excepciones, y si todo esta bien 
                 * manda un mensaje que nuestros datos se han agregado*/
                MessageBox.Show("Datos de pago agregados correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar datos de pago: " + ex.Message);
            }
            btnMostrarPagos_Click(sender, e);         /*Despues de agregar todo, utilizamos el evento del boton mostrar 
                                                       * para actualizar en el dgv la información nueva*/

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

        private void btnLimpiarCamposPago_Click(object sender, EventArgs e)
        {
            txtIdHabFK.Text = "";
            txtIdPagofrmPago.Text = "";
            txtPrecioBase.Text = "";
            txtPrecioFinalfrmPago.Text = "";
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