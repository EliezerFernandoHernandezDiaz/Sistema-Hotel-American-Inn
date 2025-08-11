using System;
using System.Configuration;     // <-- agregado para leer la cadena de conexión desde App.config
using System.Data;
using System.Text.RegularExpressions; // <-- se agregó para validar el dui 
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;           //libreria necesaria para que funcione correctamente la conexion a la bd 

namespace Clave5_Grupo6
{
    public partial class frmCliente : Form               /*Este formulario se asignó como la segunda pantalla que se va  
                                                          * a presentar en pantalla y fue creado para ingresar datos del cliente, mostrar datos ya existentes en la bd
                                                          * buscarlos o eliminarlos*/
    {
        public frmCliente()
        {
            InitializeComponent();
        }
        private int? _selectedId = null;
        private string _originalDui = null;

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
            if (MessageBox.Show(this, "¿Quiere salir de la aplicación?", "Cerrar aplicacion", MessageBoxButtons.YesNo,
           MessageBoxIcon.Question) == DialogResult.Yes) Application.Exit();

            //Se pregunta si se desea cerrar toda la aplicación o no. 
        }
        private async Task CargarClientesAsync()
        {
            var dt = new DataTable();
            try
            {
                using (var cn = NuevaConexion())
                {
                    await cn.OpenAsync();
                    using (var cmd = new MySqlCommand(
                        "SELECT id, DuiCliente, Nombresdelcliente, Apellidosdelcliente FROM tabla_cliente", cn))
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        dt.Load(r);
                    }
                }
                dgvMostrarTablaCliente.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnMostrarDatosHuesped_Click(object sender, EventArgs e)
        {
            await CargarClientesAsync();

           
        }

        private bool ValidateAll()
        {
            bool ok = true;
            errorProvider1.Clear();
            //Dui completo 
            if (!maskedDui.MaskFull)
            {
                errorProvider1.SetError(maskedDui, "Dui incompleto. Formato: 00000000-0");
                ok = false;
            }

            //Nombre requerido 
            string nombre = txtNombreHuesped.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                errorProvider1.SetError(txtNombreHuesped, "El nombre es obligatorio.");
                ok = false;
            }
            else
            {
                //Para vaidar que el nombre solo sea letras y espacios 
                if (!Regex.IsMatch(nombre, @"^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ\s'-]+$"))
                {
                    errorProvider1.SetError(txtNombreHuesped, "El nombre solo puede contener letras y espacios");
                    ok = false;
                }
            }
            //Apellidos obligatorios 
            //Nombre requerido 
            string apellidos = txtIngresarApellidosHuesped.Text.Trim();
            if (string.IsNullOrWhiteSpace(apellidos))
            {
                errorProvider1.SetError(txtIngresarApellidosHuesped, "Escribe un apellido.");
                ok = false;
            }
            else
            {
                //Para vaidar que el apellido solo sea letras y espacios 
                if (!Regex.IsMatch(apellidos, @"^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ\s'-]+$"))
                {
                    errorProvider1.SetError(txtIngresarApellidosHuesped, "El apellido solo puede contener letras y espacios");
                    ok = false;
                }
            }
            return ok;
        }

        //Evento click del btnagregar, este boton agrega a los huespedes a la bd despues de rellaenar todos los campos 

        private bool IsFormValid() //Se crea este metodo para desactivar el boton de agregar huesped si no se han completado todos los datos 
        {
            //Solo devuelve true/false, sin mostar errores
            if (!maskedDui.MaskFull) return false;
            if (string.IsNullOrWhiteSpace(txtNombreHuesped.Text)) return false;
            if (string.IsNullOrWhiteSpace(txtIngresarApellidosHuesped.Text)) return false;

            var letrasRegex = @"^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ\s'-]+$";
            if (!Regex.IsMatch(txtNombreHuesped.Text.Trim(), letrasRegex)) return false;
            if (!Regex.IsMatch(txtIngresarApellidosHuesped.Text.Trim(), letrasRegex)) return false;

            return true;
        }
        private void btnAgregarDatosHuesped_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateAll()) return;

                var dui = maskedDui.Text.Trim();
                var nombre = txtNombreHuesped.Text.Trim();
                var apellidos = txtIngresarApellidosHuesped.Text.Trim();

                using (var conexionDB = NuevaConexion())
                {
                    conexionDB.Open();

                    string sql = @"INSERT INTO tabla_cliente 
                           (DuiCliente, Nombresdelcliente, Apellidosdelcliente)
                           VALUES (@DUICliente, @NombreHuesped, @ApellidosHuesped)";

                    using (var cmd = new MySqlCommand(sql, conexionDB))
                    {
                        cmd.Parameters.AddWithValue("@DUICliente", dui);
                        cmd.Parameters.AddWithValue("@NombreHuesped", nombre);
                        cmd.Parameters.AddWithValue("@ApellidosHuesped", apellidos);

                        int filas = cmd.ExecuteNonQuery();
                        if (filas > 0)
                        {
                            MessageBox.Show("Huésped agregado con éxito.",
                                "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                // refresca el grid
                btnMostrarDatosHuesped_Click(sender, e);
            }
            catch (MySqlException ex) when (ex.Number == 1062) // clave duplicada
            {
                MessageBox.Show("Ese DUI ya existe. Verifica antes de guardar.",
                    "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Ocurrió un error mientras se guardaba el huésped: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Por favor, selecciona un cliente para eliminar.", "Eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
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
                MessageBox.Show("Huesped eliminado con éxito.", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) //Se utilizó un try que arroje un mensaje en caso de haber excepcion. 
            {
                MessageBox.Show("Error al eliminar al cliente, vuelve a intentarlo.: " + ex.Message);
            }
        }

        //Se limpian los controles de este formulario 
        private void txtLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            maskedDui.Text = "";
            txtIngresarApellidosHuesped.Text = "";
            txtNombreHuesped.Text = "";
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (_selectedId == null)
            {
                MessageBox.Show("Selecciona un cliente en la tabla para modificar", "Modificar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            if (!ValidateAll()) return;

            var dui = maskedDui.Text.Trim();
            var nombre = txtNombreHuesped.Text.Trim();
            var apellidos = txtIngresarApellidosHuesped.Text.Trim();


            /*Se establece conexion 
             * con la bd para que funcione correctamente*/
            DataTable dataTable = new DataTable();
            try
            {
                using (var cn = NuevaConexion())
                {
                    await cn.OpenAsync();

                    //Si se cambia el dui, se valida que no haya otro registro 

                    if (!string.Equals(_originalDui, dui, StringComparison.Ordinal))
                    {
                        using (var chk = new MySqlCommand(
                            "SELECT 1 FROM tabla_cliente WHERE DuiCliente= @dui AND id <> @id LIMIT 1", cn))
                        {
                            chk.Parameters.AddWithValue("@dui", dui);
                            chk.Parameters.AddWithValue("@id", _selectedId);

                            var exists = await chk.ExecuteScalarAsync();
                            if (exists != null)
                            {
                                MessageBox.Show("Ese DUI ya está asignado a otro cliente"
                               , "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    string sql = @"UPDATE tabla_cliente
                           SET DuiCliente = @dui,
                               Nombresdelcliente = @nombres,
                               Apellidosdelcliente = @apellidos
                           WHERE id = @id";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@dui", dui);
                        cmd.Parameters.AddWithValue("@nombres", nombre);
                        cmd.Parameters.AddWithValue("@apellidos", apellidos);
                        cmd.Parameters.AddWithValue("@id", _selectedId);

                        int rows = await cmd.ExecuteNonQueryAsync();
                        if (rows > 0)
                        {
                            MessageBox.Show("Datos del huesped actualizados correctamente",
                                "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _originalDui = dui; //ahora el dui original es el nuevo

                            //refrescar
                            btnMostrarDatosHuesped_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el regisro a actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)           //Manejo de excepciones con un try catch, en caso de haber una manda un mensaje en pantalla
            {
                MessageBox.Show("No se pudo actualizar el dui: El DUI ya existe", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Campos_TextChanged(object sender, EventArgs e)
        {
            btnAgregarDatosHuesped.Enabled = IsFormValid();
        }

        private void dgvMostrarTablaCliente_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMostrarTablaCliente.SelectedRows.Count == 0) return;
            var row = dgvMostrarTablaCliente.SelectedRows[0];

            _selectedId = Convert.ToInt32(row.Cells["id"].Value);
            maskedDui.Text = row.Cells["DuiCliente"].Value?.ToString() ?? "";
            txtNombreHuesped.Text = row.Cells["NombresDelCliente"].Value?.ToString() ?? "";
            txtIngresarApellidosHuesped.Text = row.Cells["Apellidosdelcliente"].Value?.ToString() ?? "";


            _originalDui = maskedDui.Text;

        }
        private void frmCliente_Load(object sender, EventArgs e)
        {
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink; //Se configura el estilo de parpardeo para que no parpadee el error provider
            btnAgregarDatosHuesped.Enabled = false; //Se inicia desactivado

            maskedDui.TextMaskFormat = MaskFormat.IncludeLiterals; //Se establece el formato del dui para que incluya los caracteres de formato
            //Se asignan eventos para que al escribir se valide
            maskedDui.TextChanged += Campos_TextChanged;
            txtNombreHuesped.TextChanged += Campos_TextChanged;
            txtIngresarApellidosHuesped.TextChanged += Campos_TextChanged;


            //para seleccionar filas completas y de a una 
            dgvMostrarTablaCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMostrarTablaCliente.MultiSelect = false;

            dgvMostrarTablaCliente.SelectionChanged += dgvMostrarTablaCliente_SelectionChanged;
        }
    }
}