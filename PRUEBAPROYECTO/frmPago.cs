using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySqlConnector;
using System.Configuration; //Para leer la cadena de conexión desde app.config 

namespace Clave5_Grupo6
{
    public partial class frmPago : Form
    {
        public frmPago()
        {
            InitializeComponent();
            cmbTipoHabitacionfrmPago.SelectedIndexChanged += ActualizarPrecios;
            cmbTipoHotelfrmPago.SelectedIndexChanged += ActualizarPrecios;
        }


        private void ActualizarPrecios(object sender, EventArgs e)
        {
            string tipoHotel = cmbTipoHotelfrmPago.Text;
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
        private void btnAgregarDatosPago_Click(object sender, EventArgs e)
        {
            //Se borra la cadena harcodeada 
           // string cadenaConexion = "database=clave5_grupo6db;server=localhost;user id=root;password=Fernandomysql";

            try
            {
                using (var conexionDB = NuevaConexion())
                {
                    conexionDB.Open();

                    // Crear un comando SQL para la inserción con parámetros
                    string sql = "INSERT INTO tabla_pago (idTablaPago, Tipo_de_hotel, Tipo_de_Habitacion, PrecioBase, PrecioTotalconImpuestos, Formas_de_Pago, id_Habitaciones) " +
                                 "VALUES (@idPago, @TipoHotel, @TipoHabitacion, @PrecioBase, @PrecioTotal, @FormasdePago, @idHabitacion)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conexionDB))
                    {
                        // Agregar parámetros
                        cmd.Parameters.AddWithValue("@idPago", txtIdPagofrmPago.Text);
                        cmd.Parameters.AddWithValue("@TipoHotel", cmbTipoHotelfrmPago.Text);
                        cmd.Parameters.AddWithValue("@TipoHabitacion", cmbTipoHabitacionfrmPago.Text); /*Se establece la conexion con la bd
                                                                                                        * y se pasan los parametros para agregar la 
                                                                                                        * info*/
                        cmd.Parameters.AddWithValue("@PrecioBase", txtPrecioBase.Text);
                        cmd.Parameters.AddWithValue("@PrecioTotal", txtPrecioFinalfrmPago.Text);
                        cmd.Parameters.AddWithValue("@FormasdePago", cmbTipoPagofrmPago.Text);
                        cmd.Parameters.AddWithValue("@idHabitacion", txtIdHabFK.Text);

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