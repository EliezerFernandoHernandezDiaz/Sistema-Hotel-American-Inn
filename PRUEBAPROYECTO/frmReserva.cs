    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;
    using MySqlConnector;
    using System.Configuration; // para leer la cadena de conexión desde app.config 

    /*AUTORES: MERCEDES ALESSANDRA FLORES VILLALTA
    * ELIEZER FERNANDO HERNANDEZ DIAZ 
    *EDNILSON OSWALDO MONTES LANDOS 
     FECHA DE ENTREGA : 12 NOV 2023
     PROYECTO DE SOLUCION, MATERIA PROGRAMACION I.  

    /* FORMULARIO PRINCIPAL DEL PROGRAMA */


    namespace Clave5_Grupo6
    {
        /*le hemos puesto de nombre al formulario, frmReserva
         y este es en donde se prensentará toda la información que el programa necesita 
        presentar */


        public partial class frmReserva : Form
        {
            private Dictionary<string, Dictionary<string, decimal>> preciosPorHotelYTipoHabitacion = new Dictionary<string, Dictionary<string, decimal>>();
            private List<Reserva> reservas = new List<Reserva>();
            private decimal iva = 0.13M; // IVA al 13%
            private Dictionary<string, decimal> preciosPorTipoHabitacion = new Dictionary<string, decimal>();
            public frmReserva()
            {
                InitializeComponent();

                cmbTipoHabitacion.SelectedIndexChanged += ActualizarPrecios;

                preciosPorHotelYTipoHabitacion.Add("Ciudad", new Dictionary<string, decimal>
            {
                {"Sencilla", 55.00M},
                {"Doble", 65.00M},
                {"Deluxe", 75.00M},
                {"Suite", 85.00M}
            });

                preciosPorHotelYTipoHabitacion.Add("Playa", new Dictionary<string, decimal>
            {
                {"Sencilla", 65.00M},
                {"Doble", 75.00M},
                {"Deluxe", 90.00M},
                {"Suite", 100.00M}
            });

                preciosPorHotelYTipoHabitacion.Add("Montaña", new Dictionary<string, decimal>
            {
                {"Sencilla", 60.00M},
                {"Doble", 70.00M},
                {"Deluxe", 80.00M},
                {"Suite", 90.00M}
            });
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

            private void button4_Click(object sender, EventArgs e)
            {
                // Verifica si todos los campos obligatorios están completos
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(cmbTipoHabitacion.Text) || string.IsNullOrWhiteSpace(cmbZonaHotel.Text) || cmbFormaPago.SelectedItem == null || string.IsNullOrWhiteSpace(txtCantHuespedes.Text) || string.IsNullOrWhiteSpace(txtIdHabitacion.Text) || string.IsNullOrWhiteSpace(txtIdReserva.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                    return;
                }

                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string tipoHabitacion = cmbTipoHabitacion.Text;
                string hotelSeleccionado = cmbZonaHotel.Text;
                string formaPago = cmbFormaPago.SelectedItem.ToString();
                int idHabitacion = Convert.ToInt32(txtIdHabitacion.Text);
                int idReserva = Convert.ToInt32(txtIdReserva.Text);
                bool costoExtra = chkCostoExtra.Checked;

                // Validar fechas
                DateTime fechaInicio = dtpFechaEntrada.Value;
                DateTime fechaFin = dtpFechaSalida.Value;
                if (fechaInicio >= fechaFin)
                {
                    MessageBox.Show("La fecha de inicio debe ser anterior a la fecha de finalización.");
                    return;
                }

                // Validar y convertir la cantidad de huéspedes
                if (!int.TryParse(txtCantHuespedes.Text, out int cantidadHuespedes))
                {
                    MessageBox.Show("Ingrese un valor válido para la cantidad de huéspedes.");
                    return;
                }

                // Obtén el precio de la habitación según el tipo y el hotel seleccionado
                decimal precioHabitacion = ObtenerPrecioHabitacion(hotelSeleccionado, tipoHabitacion);

                // Calcula el subtotal y el total
                decimal subtotal = CalcularSubtotal(precioHabitacion, fechaInicio, fechaFin);
                decimal total = subtotal + (subtotal * iva);



            }
            // Método para limpiar los campos
            private void LimpiarCampos()
            {
                txtNombre.Text = "";
                txtApellido.Text = "";
                cmbTipoHabitacion.SelectedIndex = -1;
                cmbZonaHotel.SelectedIndex = -1;
                cmbFormaPago.SelectedIndex = -1;
                txtCantHuespedes.Text = "";
                txtIdHabitacion.Text = "";
                txtIdReserva.Text = "";
                chkCostoExtra.Checked = false;
                dtpFechaEntrada.Value = DateTime.Now;
                dtpFechaSalida.Value = DateTime.Now;
            }
            private decimal ObtenerPrecioHabitacion(string hotel, string tipoHabitacion)
            {
                // Obtiene el precio de la habitación según el tipo y el hotel seleccionado
                if (preciosPorHotelYTipoHabitacion.ContainsKey(hotel) && preciosPorHotelYTipoHabitacion[hotel].ContainsKey(tipoHabitacion))
                {
                    return preciosPorHotelYTipoHabitacion[hotel][tipoHabitacion];
                }
                else
                {
                    return 0.00M; // Manejar tipos de habitación o hoteles desconocidos
                }
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

            private void btnProbandoConex_Click(object sender, EventArgs e)
            {
                CConexion objectoConexion = new CConexion();
                objectoConexion.EstablecerConexion();
            }

            private void btnMostrarReservas_Click(object sender, EventArgs e)
            {
            //Se elimina la cadena harcodeada y se usa app.config

          //  string cadenaConexion = "database= clave5_grupo6db;  server=localhost; user id= root; password= Fernandomysql";
                DataTable dataTable = new DataTable();

                try
                {
                using (var conexionDB = NuevaConexion())
                using (var comando = new MySqlCommand("SELECT* FROM tabla_reserva;", conexionDB))
                {
                    comando.CommandType = CommandType.Text;
                    conexionDB.Open();
                    using (var resultado = comando.ExecuteReader())
                    {
                        dataTable.Load(resultado);
                    }

                }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                dgvReservas.DataSource = dataTable;
            }

            private void btnAgregarReserva_Click(object sender, EventArgs e)
            //Se elimina la cadena harcodeada y se usa app.config 
            {
                //string cadenaConexion = "database=clave5_grupo6db;server=localhost;user id=root;password=Fernandomysql";

                try
                {
                using (var conexionDB = NuevaConexion())
                {
                    conexionDB.Open();


                    // Crear un comando SQL para la inserción con parámetros
                    string sql = "INSERT INTO tabla_reserva (id_Habitaciones, idTablaPago, DuiCliente, Fecha_de_entrada, Fecha_de_salida, Hora_de_entrada, Hora_de_salida, Información_de_huespedes, Cantidad_de_huespedes, Disponibilidad, PreciosinIVA, PrecioFinal) " +
                                 "VALUES (@IdHabitacion, @IdTablaPago, @DUI, @FechaEntrada, @FechaSalida, @HoraEntrada, @HoraSalida, @InformacionHuespedes, @CantHuespedes, @Disponibilidad, @PreciosinIVA, @PrecioFinal)";

                    using (var cmd = new MySqlCommand(sql, conexionDB))
                    {
                        // Agregar parámetros
                        cmd.Parameters.AddWithValue("@IdHabitacion", txtIdHabitacion.Text);
                        cmd.Parameters.AddWithValue("@IdTablaPago", txtHotelSeleccionado.Text);
                        cmd.Parameters.AddWithValue("@DUI", txtDUI.Text);
                        cmd.Parameters.AddWithValue("@FechaEntrada", dtpFechaEntrada.Text);
                        cmd.Parameters.AddWithValue("@FechaSalida", dtpFechaSalida.Text);
                        cmd.Parameters.AddWithValue("@HoraEntrada", txtHoraEntrada.Text);
                        cmd.Parameters.AddWithValue("@HoraSalida", txtHoraSalida.Text);
                        cmd.Parameters.AddWithValue("@InformacionHuespedes", txtInfoHuespedes.Text);
                        cmd.Parameters.AddWithValue("@CantHuespedes", txtCantHuespedes.Text);
                        cmd.Parameters.AddWithValue("@Disponibilidad", txtDisponible.Text);
                        cmd.Parameters.AddWithValue("@PreciosinIVA", txtPrecioSinIVA.Text);
                        cmd.Parameters.AddWithValue("@PrecioFinal", txtPrecioFinal.Text);

                        cmd.ExecuteNonQuery();
                    }
                }
                    // Mostrar todas las reservas (incluyendo las recién agregadas) en el DataGridView
                    btnMostrarReservas_Click(sender, e);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }


            }
            private void button3_Click(object sender, EventArgs e) //btnSalir
            {
                if (MessageBox.Show(this, "¿Quiere salir del programa?", "Cerrar aplicacion", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes) Application.Exit();
            }

            private void frmReserva_Load(object sender, EventArgs e)
            {
                //Click por accidente 
            }

            private decimal ObtenerPrecioPorTipoYHotel(string tipoHabitacion, string hotel)
            {
                if (preciosPorHotelYTipoHabitacion.ContainsKey(hotel) && preciosPorHotelYTipoHabitacion[hotel].ContainsKey(tipoHabitacion))
                {
                    return preciosPorHotelYTipoHabitacion[hotel][tipoHabitacion];
                }
                else
                {
                    return 0.00M; // Manejar tipos de habitación o hoteles desconocidos
                }
            }
            private void ActualizarPrecios(object sender, EventArgs e)
            {
                string tipoHotel = cmbZonaHotel.Text;
                string tipoHabitacion = cmbTipoHabitacion.Text;

                decimal precioBase = ObtenerPrecioPorTipoYHotel(tipoHabitacion, tipoHotel);

                // Aplicar recargo si el checkbox está marcado
                decimal recargo = chkCostoExtra.Checked ? 20.00M : 0.00M;

                // Calcular el precio final
                decimal precioFinal = precioBase + (precioBase * iva) + recargo;

                // Mostrar el precio base en el TextBox correspondiente
                txtPrecioSinIVA.Text = precioBase.ToString("0.00");

                // Mostrar el precio final en el TextBox correspondiente
                txtPrecioFinal.Text = precioFinal.ToString("0.00");


            }

            private void txtNombre_TextChanged(object sender, EventArgs e)
            {
                //click accidental
            }
        }
    }

