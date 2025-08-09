using System;
using System.Configuration;     // <-- agregado para leer la cadena de conexión desde App.config
using System.Data;
using System.Windows.Forms;
using MySqlConnector;           //libreria necesaria para que funcione correctamente la conexion a la bd 

namespace Clave5_Grupo6
{
    public partial class frmCliente : Form               /*Este formulario se asignó como el primero 
                                                          * a presentar en pantalla y fue creado para ingresar datos del cliente, mostrar datos ya existentes en la bd
                                                          * buscarlos o eliminarlos*/
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        // Helper privado para obtener una conexión basada en App.config (evitamos cadenas hardcodeadas)
        private MySqlConnection NuevaConexion()
        {
            // Lee la cadena "MySqlConn" definida en App.config
            var cs = ConfigurationManager.ConnectionStrings["MySqlConn"]?.ConnectionString;
            return new MySqlConnection(cs);
        }

        //Evento click btnCerrar 
        private void btnCerrarfrmDatosCliente_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Quiere cerrar la aplicación?", "Cerrar aplicacion", MessageBoxButtons.YesNo,
           MessageBoxIcon.Question) == DialogResult.Yes) Application.Exit();

            //Se pregunta si se desea cerrar toda la aplicación o no. 
        }

        //btn que se hizo para probar la conexion a la bd 
        private void btnProbarConex_Click(object sender, EventArgs e)
        {
            CConexion objetConexionfrmDatosCliente = new CConexion();
            objetConexionfrmDatosCliente.EstablecerConexion();                   /*llamada a la clase que se creo para establecer la conexion
                                                                                  * con mysql*/
        }

        /*Evento click del btnMostrar, se creó este boton para que al presionarlo muestre en el dgv
         * los datos de huespedes ya existentes en la bd*/
        private void btnMostrarDatosHuesped_Click(object sender, EventArgs e)
        {
            /*Se establece conexion 
             * con la bd para que funcione correctamente*/
            DataTable dataTable = new DataTable();
            try
            {
                using (var conexionDB = NuevaConexion()) // <-- usamos la conexión desde App.config
                {
                    // Comando en mysql que permite seleccionar todos los datos que se guardaron en la tabla cliente
                    using (var comando = new MySqlCommand("SELECT * FROM tabla_cliente;", conexionDB))
                    {
                        comando.CommandType = CommandType.Text;
                        conexionDB.Open();   /*Este comando abre la conexion*/

                        using (var resultado = comando.ExecuteReader())
                        {
                            dataTable.Load(resultado);
                        }
                    }
                }
            }
            catch (Exception ex)           //Manejo de excepciones con un try catch, en caso de haber una manda un mensaje en pantalla
            {
                MessageBox.Show(ex.Message);
            }

            dgvMostrarTablaCliente.DataSource = dataTable;          /*Se asigna en el dgv los valores que se han guardado en el datatable, 
                                                                     * esto mismo permite presentar los datos de la tabla cliente en el datagridview*/
        }

        //Evento click del btnagregar, este boton agrega a los huespedes a la bd despues de rellaenar todos los campos 
        private void btnAgregarDatosHuesped_Click(object sender, EventArgs e)
        {
            // Se quita la cadena de conexión hardcodeada y se usa la de App.config
            /*Se crea la cadena conexion para conectarse a la base*/
            try
            {
                using (var conexionDB = NuevaConexion())
                {
                    conexionDB.Open();

                    // Creamos un comando para la inserción con parámetros
                    string sql = "INSERT INTO tabla_cliente (DuiCliente, Nombresdelcliente, Apellidosdelcliente) " +
                                 "VALUES (@DUICliente, @NombreHuesped, @ApellidosHuesped)";

                    using (var cmd = new MySqlCommand(sql, conexionDB))
                    {
                        // Agregamos los parámetros
                        cmd.Parameters.AddWithValue("@DUICliente", txtDuiHuesped.Text);
                        cmd.Parameters.AddWithValue("@NombreHuesped", txtNombreHuesped.Text);
                        cmd.Parameters.AddWithValue("@ApellidosHuesped", txtIngresarApellidosHuesped.Text);

                        //el siguiente comando se agrega para que registre los cambios que se hagan como los de agregar huespedes
                        cmd.ExecuteNonQuery();
                    }
                }

                // Muestra todas las reservas (incluyendo las recién agregadas) en el DataGridView
                btnMostrarDatosHuesped_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //Fin del try catch que envia un msj de error en caso de una excepcion 
            }

        }

        //Este botón es para ir al formulario de las habitaciones
        private void btnIrHabitaciones_Click(object sender, EventArgs e)
        {
            frmHabitAciones frm = new frmHabitAciones();
            frm.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            // Verifica si se ingresó un Dui válido
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Por favor, ingresa un Dui válido para buscar la reserva.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Realiza la búsqueda y muestra los resultados en el DataGridView
            BuscarReservaPorDui(txtBuscar.Text);
        }

        private void BuscarReservaPorDui(string duiCliente)
        {
            // Se establece la conexión (sin cadenas hardcodeadas)
            try
            {
                using (var conexionDB = NuevaConexion())
                {
                    conexionDB.Open();

                    // Crea el comando SQL para la búsqueda por DuiCliente
                    string sql = "SELECT * FROM tabla_reserva WHERE DuiCliente = @DUICliente";

                    using (var cmd = new MySqlCommand(sql, conexionDB))
                    {
                        cmd.Parameters.AddWithValue("@DUICliente", duiCliente);

                        // Ejecuta el comando y carga los resultados en el DataGridView
                        DataTable dataTable = new DataTable();
                        using (var resultado = cmd.ExecuteReader())
                        {
                            dataTable.Load(resultado);
                        }
                        dgvMostrarTablaCliente.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*Evento click del boton eliminar, este boton elimina un registro de la tabla cliente
         * siempre y cuando se seleccione una fila*/
        private void btnEliminarDatos_Click(object sender, EventArgs e)
        {
            // Verifica si se ha seleccionado una fila en el DataGridView
            if (dgvMostrarTablaCliente.SelectedRows.Count > 0)
            {
                // Obtiene el valor del campo DuiCliente de la fila seleccionada
                string duiCliente = dgvMostrarTablaCliente.SelectedRows[0].Cells["DuiCliente"].Value.ToString();

                // Realiza la eliminación 
                EliminarHuesped(duiCliente);

                // Actualiza el DataGridView después de la eliminación aqui usamos el mismo evento de boton mostrar para actualizarlo 
                btnMostrarDatosHuesped_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.");
            }
        }

        //Metodo que ayuda a eliminar el huesped 
        private void EliminarHuesped(string duiCliente)
        {
            //Se establece conexión para eliminarlo (usando App.config)
            try
            {
                using (var conexionDB = NuevaConexion())
                {
                    conexionDB.Open();

                    // Crea un comando para la eliminación con parámetros
                    string sql = "DELETE FROM tabla_cliente WHERE DuiCliente = @DUICliente";

                    using (var cmd = new MySqlCommand(sql, conexionDB))
                    {
                        // Agrega el parámetro para el DuiCliente
                        cmd.Parameters.AddWithValue("@DUICliente", duiCliente);

                        // Ejecuta la eliminación
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Huesped eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) //Se utilizó un try que arroje un mensaje en caso de haber excepcion. 
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        //Se limpian los controles de este formulario 
        private void txtLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            txtDuiHuesped.Text = "";
            txtIngresarApellidosHuesped.Text = "";
            txtNombreHuesped.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}
