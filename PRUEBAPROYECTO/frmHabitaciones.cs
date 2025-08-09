using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;
using System.Configuration; //para leer la cadena de conexión desde app.config

namespace Clave5_Grupo6
{
    public partial class frmHabitAciones : Form
    {

        private Dictionary<string, Dictionary<string, decimal>> preciosPorHotelYTipoHabitacion = new Dictionary<string, Dictionary<string, decimal>>();

        public frmHabitAciones()
        {
            InitializeComponent();
            cmbTipoHotelfrmHab.SelectedIndexChanged += cmbTipoHotelfrmHab_SelectedIndexChanged;
            cmbTipoHabitacion.SelectedIndexChanged += cmbTipoHabitacion_SelectedIndexChanged;

            // Inicializa el diccionario con los precios por tipo de hotel y habitación
            InicializarPrecios();
        }
        //Helper privado para obtener una conexión desde app.config 
        private MySqlConnection NuevaConexion()
        {
            //Lee la cadena de conexión desde app.config
            var cs = ConfigurationManager.ConnectionStrings["MySqlConn"]?.ConnectionString;

            return new MySqlConnection(cs);
        
        }
        private void InicializarPrecios()
        {
            preciosPorHotelYTipoHabitacion.Add("Ciudad", new Dictionary<string, decimal>
            {
                {"Sencilla", 55.00m},
                {"Doble", 65.00m},
                {"Deluxe", 75.00m},
                {"Suite", 85.00m}
            });

            preciosPorHotelYTipoHabitacion.Add("Playa", new Dictionary<string, decimal>
            {
                {"Sencilla", 65.00m},
                {"Doble", 75.00m},
                {"Deluxe", 90.00m},
                {"Suite", 100.00m}
            });

            preciosPorHotelYTipoHabitacion.Add("Montaña", new Dictionary<string, decimal>
            {
                {"Sencilla", 60.00m},
                {"Doble", 70.00m},
                {"Deluxe", 80.00m},
                {"Suite", 90.00m}
            });
        }


        private void btnProbarConexfrmHab_Click(object sender, EventArgs e)
        {

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

        private void btnCerrarfrmDatosHab_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnAgregarDatosHabitacion_Click(object sender, EventArgs e)
        {
            //se elimina la cadena harcodeada y se usa app.config mediante nuevaConexion()
          //  string cadenaConexion = "database=clave5_grupo6db;server=localhost;user id=root;password=Fernandomysql";

            try
            {
                using (MySqlConnection conexionDB = NuevaConexion())

                {
                    conexionDB.Open();

                    // Crear un comando SQL para la inserción con parámetros
                    string sql = "INSERT INTO tabla_habitaciones (id_Habitaciones, Tipo_de_Habitacion, Precio_Base, Tipo_de_hotel, Equipo_disponible) " +
                                 "VALUES (@idHabitaciones, @TipodeHabitacion, @PrecioBase, @Tipodehotel, @EquipoDisponible)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conexionDB))
                    {
                        // Agregar parámetros
                        cmd.Parameters.AddWithValue("@idHabitaciones", txtIngreseIdHabitacion.Text);
                        cmd.Parameters.AddWithValue("@TipodeHabitacion", cmbTipoHabitacion.Text);
                        decimal precio = decimal.Parse(txtPrecioBasefrmHabitacion.Text.Replace("$", "").Replace(",", ""));
                        cmd.Parameters.AddWithValue("@PrecioBase", precio);
                        cmd.Parameters.AddWithValue("@Tipodehotel", cmbTipoHotelfrmHab.Text);
                        cmd.Parameters.AddWithValue("@EquipoDisponible", txtEquipoDisponiblefrmHab.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                // Agregar cualquier lógica adicional después de la inserción, si es necesario
                MessageBox.Show("Datos de la habitación agregados correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar datos de la habitación: " + ex.Message);
            }
            btnMostrarDatosHabitacion_Click(sender, e);
        }


        private void btnMostrarDatosHabitacion_Click(object sender, EventArgs e)
        {
            //Lo mismo, se elimina la cadena harcodeada y se usa app.config mediante metodo NuevaConexion()

           // string cadenaConexion = "database= clave5_grupo6db;  server=localhost; user id= root; password= Fernandomysql";

            DataTable dataTable = new DataTable();
            
            try
            {
                using (var conexionDB = NuevaConexion())
                {
                    using (var comando = new MySqlCommand("SELECT * FROM tabla_habitaciones;", conexionDB) )
                    {
                        comando.CommandType = CommandType.Text;
                        conexionDB.Open();
                        using (var resultado = comando.ExecuteReader())
                        {
                            dataTable.Load(resultado);
                        }
                    }    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvTablaHabitacion.DataSource = dataTable;
        }

        private void btnIrATablaPago_Click(object sender, EventArgs e) //Comando para abrir el formulario que va a mostrar la tabla pago 
        {
            frmPago frm = new frmPago();
            frm.Show();
        }

        private void txtLimpiarCamposHabitacion_Click(object sender, EventArgs e)
        {
            txtIngreseIdHabitacion.Text = "";
            txtLimpiarCamposHabitacion.Text = "";
            txtPrecioBasefrmHabitacion.Text = "";
            cmbTipoHabitacion.Text = "";
            cmbTipoHotelfrmHab.Text = "";
        }

        private void cmbTipoHotelfrmHab_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarPrecio();
        }

        private void cmbTipoHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarPrecio();
        }

        private void ActualizarPrecio()
        {
            string tipoHotel = cmbTipoHotelfrmHab.Text;
            string tipoHabitacion = cmbTipoHabitacion.Text;

            if (preciosPorHotelYTipoHabitacion.ContainsKey(tipoHotel) && preciosPorHotelYTipoHabitacion[tipoHotel].ContainsKey(tipoHabitacion))
            {
                decimal precio = preciosPorHotelYTipoHabitacion[tipoHotel][tipoHabitacion];
                txtPrecioBasefrmHabitacion.Text = precio.ToString("C");
            }
            else
            {
                txtPrecioBasefrmHabitacion.Text = "No disponible";
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verifica si se ha seleccionado una fila en el DataGridView
            if (dgvTablaHabitacion.SelectedRows.Count > 0)
            {
                // Obtiene el valor del campo id_Habitaciones de la fila seleccionada
                string idHabitacion = dgvTablaHabitacion.SelectedRows[0].Cells["id_Habitaciones"].Value.ToString();

                // Realiza la eliminación 
                EliminarHabitacion(idHabitacion);

                // Actualiza el DataGridView después de la eliminación aquí usamos el mismo evento de botón mostrar para actualizarlo 
                btnMostrarDatosHabitacion_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.");
            }
        }

        // Método que ayuda a eliminar la habitación
        private void EliminarHabitacion(string idHabitacion)
        {
            // Se establece conexión para eliminarla, se elimina la cadena harcodeada. 
            //string cadenaConexion = "database=clave5_grupo6db;server=localhost;user id=root;password=Fernandomysql";
            try
            {
               using (var conexionDB= NuevaConexion())
                {
                    conexionDB.Open();

                    // Crea un comando para la eliminación con parámetros
                    string sql = "DELETE FROM tabla_habitaciones WHERE id_Habitaciones = @idHabitacion";

                    using (var cmd = new MySqlCommand(sql, conexionDB))
                    {
                        // Agrega el parámetro para el id_Habitacion
                        cmd.Parameters.AddWithValue("@idHabitacion", idHabitacion);

                        // Ejecuta la eliminación
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Habitación eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la habitación: " + ex.Message);
            }
        }
    }
}


