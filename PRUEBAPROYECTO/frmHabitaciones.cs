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

        // al declarar:
        private Dictionary<string, Dictionary<string, decimal>> preciosPorHotelYTipoHabitacion =
            new Dictionary<string, Dictionary<string, decimal>>(StringComparer.OrdinalIgnoreCase);
        public frmHabitAciones()
        {
            InitializeComponent();

            // Asegura que se disparen los eventos de recalcular precio
            cmbTipoHotelfrmHab.SelectedIndexChanged += cmbTipoHotelfrmHab_SelectedIndexChanged;
            cmbTipoHabitacion.SelectedIndexChanged += cmbTipoHabitacion_SelectedIndexChanged;

            // Evita que el usuario escriba texto libre en los combos (reduce errores)
            cmbTipoHotelfrmHab.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoHabitacion.DropDownStyle = ComboBoxStyle.DropDownList;

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
            preciosPorHotelYTipoHabitacion["Ciudad"] = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase)
            {
                ["Sencilla"] = 55.00m,
                ["Doble"] = 65.00m,
                ["Deluxe"] = 75.00m,
                ["Suite"] = 85.00m
            };
            preciosPorHotelYTipoHabitacion["Playa"] = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase)
            {
                ["Sencilla"] = 65.00m,
                ["Doble"] = 75.00m,
                ["Deluxe"] = 90.00m,
                ["Suite"] = 100.00m
            };
            preciosPorHotelYTipoHabitacion["Montaña"] = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase)
            {
                ["Sencilla"] = 60.00m,
                ["Doble"] = 70.00m,
                ["Deluxe"] = 80.00m,
                ["Suite"] = 90.00m
            };
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

                    // Genera un código tipo HAB-20250808-001 (ajústalo a tu gusto)
                    string codigo = "HAB-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");

                    // SQL con la nueva columna
                   string sql = @"INSERT INTO tabla_habitaciones
                      (Tipo_de_Habitacion, Precio_Base, Tipo_de_hotel, Equipo_disponible, codigo_habitacion)
                             VALUES (@TipodeHabitacion, @PrecioBase, @Tipodehotel, @EquipoDisponible, @Codigo)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conexionDB))
                    {
                        cmd.Parameters.AddWithValue("@TipodeHabitacion", cmbTipoHabitacion.Text);
                        // Evita problemas regionales al parsear moneda:
                        var raw = txtPrecioBasefrmHabitacion.Text.Replace("$", "").Trim();
                        if (!decimal.TryParse(raw, System.Globalization.NumberStyles.Any,
                            System.Globalization.CultureInfo.InvariantCulture, out var precio))
                        {
                            MessageBox.Show("Precio inválido."); return;
                        }
                        cmd.Parameters.AddWithValue("@PrecioBase", precio);
                        cmd.Parameters.AddWithValue("@Tipodehotel", cmbTipoHotelfrmHab.Text);
                        cmd.Parameters.AddWithValue("@EquipoDisponible", txtEquipoDisponiblefrmHab.Text ?? "");
                        cmd.Parameters.AddWithValue("@Codigo", codigo);

                        cmd.ExecuteNonQuery();
                    }
                }

                // Agregar cualquier lógica adicional después de la inserción, si es necesario
                MessageBox.Show("Datos de la habitación agregados correctamente", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
            
            {
                MessageBox.Show("Error al agregar datos de la habitación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
              
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
            txtEquipoDisponiblefrmHab.Clear();
            txtPrecioBasefrmHabitacion.Clear();
            cmbTipoHabitacion.SelectedIndex = -1;
            cmbTipoHotelfrmHab.SelectedIndex = -1;

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
            // Lee de forma robusta: usa SelectedItem si existe; si no, usa Text; y recorta espacios
            var tipoHotel = (cmbTipoHotelfrmHab.SelectedItem ?? cmbTipoHotelfrmHab.Text)?.ToString().Trim();
            var tipoHabitacion = (cmbTipoHabitacion.SelectedItem ?? cmbTipoHabitacion.Text)?.ToString().Trim();

            if (!string.IsNullOrWhiteSpace(tipoHotel) &&
                !string.IsNullOrWhiteSpace(tipoHabitacion) &&
                preciosPorHotelYTipoHabitacion.TryGetValue(tipoHotel, out var preciosPorTipo) &&
                preciosPorTipo.TryGetValue(tipoHabitacion, out var precio))
            {
                // Muestra el precio con formato moneda
                txtPrecioBasefrmHabitacion.Text = precio.ToString("C2");
            }
            else
            {
                // Si no hay coincidencia, deja vacío o muestra un mensaje amigable
                txtPrecioBasefrmHabitacion.Text = "";
                // Para depurar, puedes activar este mensaje:
                // MessageBox.Show($"No match -> Hotel: '{tipoHotel}' | Hab: '{tipoHabitacion}'");
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
                MessageBox.Show("Por favor, selecciona una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void frmHabitAciones_Load(object sender, EventArgs e)
        {

        }
    }
}


