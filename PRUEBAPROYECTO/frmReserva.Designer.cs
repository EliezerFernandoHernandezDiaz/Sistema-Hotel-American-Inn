
namespace Clave5_Grupo6
{
    partial class frmReserva
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtInfoHuespedes = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCantHuespedes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.btnEliminarReserva = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnMostrarReservas = new System.Windows.Forms.Button();
            this.btnAgregarReserva = new System.Windows.Forms.Button();
            this.txtPrecioSinIVA = new System.Windows.Forms.TextBox();
            this.txtPrecioFinal = new System.Windows.Forms.TextBox();
            this.txtHotelSeleccionado = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtEquipoDisponible = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.dtpFechaEntrada = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cmbSeleccionarHuesped = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHabitacionSeleccionada = new System.Windows.Forms.TextBox();
            this.txtMetPagoSeleccionado = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbxReservaInfo = new System.Windows.Forms.GroupBox();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckInn = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscarReserva = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gbxReservaInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo del hotel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtInfoHuespedes);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtCantHuespedes);
            this.groupBox1.Location = new System.Drawing.Point(31, 609);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(351, 154);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion de huespedes";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 89);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(160, 32);
            this.label19.TabIndex = 28;
            this.label19.Text = "Ingrese la informacion de \r\nlos huespedes";
            // 
            // txtInfoHuespedes
            // 
            this.txtInfoHuespedes.Location = new System.Drawing.Point(175, 101);
            this.txtInfoHuespedes.Name = "txtInfoHuespedes";
            this.txtInfoHuespedes.Size = new System.Drawing.Size(136, 22);
            this.txtInfoHuespedes.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 43);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(151, 16);
            this.label13.TabIndex = 25;
            this.label13.Text = "Cantidad de huespedes";
            // 
            // txtCantHuespedes
            // 
            this.txtCantHuespedes.Location = new System.Drawing.Point(174, 40);
            this.txtCantHuespedes.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantHuespedes.Name = "txtCantHuespedes";
            this.txtCantHuespedes.Size = new System.Drawing.Size(136, 22);
            this.txtCantHuespedes.TabIndex = 26;
            this.txtCantHuespedes.TextChanged += new System.EventHandler(this.textBox11_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 101);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tipo de habitacion";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 46);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Fecha de entrada";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 108);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Fecha de salida";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 174);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Hora de entrada";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 237);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 16);
            this.label11.TabIndex = 20;
            this.label11.Text = "Hora de salida";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 157);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 16);
            this.label14.TabIndex = 28;
            this.label14.Text = "Forma de pago";
            // 
            // dgvReservas
            // 
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Location = new System.Drawing.Point(1151, 222);
            this.dgvReservas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.RowHeadersWidth = 51;
            this.dgvReservas.Size = new System.Drawing.Size(890, 396);
            this.dgvReservas.TabIndex = 29;
            // 
            // btnEliminarReserva
            // 
            this.btnEliminarReserva.Location = new System.Drawing.Point(1364, 664);
            this.btnEliminarReserva.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarReserva.Name = "btnEliminarReserva";
            this.btnEliminarReserva.Size = new System.Drawing.Size(120, 64);
            this.btnEliminarReserva.TabIndex = 34;
            this.btnEliminarReserva.Text = "Eliminar";
            this.btnEliminarReserva.UseVisualStyleBackColor = true;
            this.btnEliminarReserva.Click += new System.EventHandler(this.btnEliminarReserva_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1345, 27);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 42);
            this.btnSalir.TabIndex = 35;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.button3_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(737, 11);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(215, 58);
            this.label17.TabIndex = 38;
            this.label17.Text = "Hotel American Inn\r\nFicha de reserva\r\n";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(96, 49);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(268, 20);
            this.label18.TabIndex = 39;
            this.label18.Text = "Huesped a cargo de la reserva";
            // 
            // btnMostrarReservas
            // 
            this.btnMostrarReservas.Location = new System.Drawing.Point(1221, 27);
            this.btnMostrarReservas.Name = "btnMostrarReservas";
            this.btnMostrarReservas.Size = new System.Drawing.Size(97, 42);
            this.btnMostrarReservas.TabIndex = 45;
            this.btnMostrarReservas.Text = "Mostrar Reservas";
            this.btnMostrarReservas.UseVisualStyleBackColor = true;
            this.btnMostrarReservas.Click += new System.EventHandler(this.btnMostrarReservas_Click);
            // 
            // btnAgregarReserva
            // 
            this.btnAgregarReserva.Location = new System.Drawing.Point(951, 665);
            this.btnAgregarReserva.Name = "btnAgregarReserva";
            this.btnAgregarReserva.Size = new System.Drawing.Size(114, 64);
            this.btnAgregarReserva.TabIndex = 46;
            this.btnAgregarReserva.Text = "Agregar Reserva";
            this.btnAgregarReserva.UseVisualStyleBackColor = true;
            this.btnAgregarReserva.Click += new System.EventHandler(this.btnAgregarReserva_Click);
            // 
            // txtPrecioSinIVA
            // 
            this.txtPrecioSinIVA.Enabled = false;
            this.txtPrecioSinIVA.Location = new System.Drawing.Point(201, 204);
            this.txtPrecioSinIVA.Name = "txtPrecioSinIVA";
            this.txtPrecioSinIVA.Size = new System.Drawing.Size(156, 22);
            this.txtPrecioSinIVA.TabIndex = 48;
            // 
            // txtPrecioFinal
            // 
            this.txtPrecioFinal.Enabled = false;
            this.txtPrecioFinal.Location = new System.Drawing.Point(201, 255);
            this.txtPrecioFinal.Name = "txtPrecioFinal";
            this.txtPrecioFinal.Size = new System.Drawing.Size(156, 22);
            this.txtPrecioFinal.TabIndex = 49;
            // 
            // txtHotelSeleccionado
            // 
            this.txtHotelSeleccionado.Enabled = false;
            this.txtHotelSeleccionado.Location = new System.Drawing.Point(147, 37);
            this.txtHotelSeleccionado.Name = "txtHotelSeleccionado";
            this.txtHotelSeleccionado.Size = new System.Drawing.Size(186, 22);
            this.txtHotelSeleccionado.TabIndex = 52;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 207);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(186, 16);
            this.label22.TabIndex = 54;
            this.label22.Text = "Precio Base por la Habitación";
            // 
            // txtEquipoDisponible
            // 
            this.txtEquipoDisponible.Enabled = false;
            this.txtEquipoDisponible.Location = new System.Drawing.Point(160, 296);
            this.txtEquipoDisponible.Name = "txtEquipoDisponible";
            this.txtEquipoDisponible.Size = new System.Drawing.Size(205, 22);
            this.txtEquipoDisponible.TabIndex = 55;
            this.txtEquipoDisponible.Text = "Tv, Cama, Aire Acondicionado";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 299);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(116, 16);
            this.label23.TabIndex = 56;
            this.label23.Text = "Equipo disponible";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(7, 255);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(158, 32);
            this.label25.TabIndex = 58;
            this.label25.Text = "Precio + IVA total a pagar\r\n\r\n";
            // 
            // dtpFechaEntrada
            // 
            this.dtpFechaEntrada.Location = new System.Drawing.Point(160, 46);
            this.dtpFechaEntrada.Name = "dtpFechaEntrada";
            this.dtpFechaEntrada.Size = new System.Drawing.Size(327, 22);
            this.dtpFechaEntrada.TabIndex = 59;
            // 
            // dtpFechaSalida
            // 
            this.dtpFechaSalida.Location = new System.Drawing.Point(160, 103);
            this.dtpFechaSalida.Name = "dtpFechaSalida";
            this.dtpFechaSalida.Size = new System.Drawing.Size(327, 22);
            this.dtpFechaSalida.TabIndex = 60;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(738, 107);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(223, 40);
            this.label20.TabIndex = 61;
            this.label20.Text = "Información de la reserva\r\n\r\n";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(1221, 664);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(120, 64);
            this.btnModificar.TabIndex = 62;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1088, 665);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(114, 64);
            this.btnBuscar.TabIndex = 63;
            this.btnBuscar.Text = "Buscar Reserva";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cmbSeleccionarHuesped
            // 
            this.cmbSeleccionarHuesped.FormattingEnabled = true;
            this.cmbSeleccionarHuesped.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta de credito",
            "Tarjeta de debito",
            "Bitcoin"});
            this.cmbSeleccionarHuesped.Location = new System.Drawing.Point(201, 93);
            this.cmbSeleccionarHuesped.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSeleccionarHuesped.Name = "cmbSeleccionarHuesped";
            this.cmbSeleccionarHuesped.Size = new System.Drawing.Size(223, 24);
            this.cmbSeleccionarHuesped.TabIndex = 65;
            this.cmbSeleccionarHuesped.SelectedIndexChanged += new System.EventHandler(this.cmbSeleccionarHuesped_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 66;
            this.label1.Text = "Seleccione huesped";
            // 
            // txtHabitacionSeleccionada
            // 
            this.txtHabitacionSeleccionada.Enabled = false;
            this.txtHabitacionSeleccionada.Location = new System.Drawing.Point(189, 95);
            this.txtHabitacionSeleccionada.Name = "txtHabitacionSeleccionada";
            this.txtHabitacionSeleccionada.Size = new System.Drawing.Size(155, 22);
            this.txtHabitacionSeleccionada.TabIndex = 67;
            // 
            // txtMetPagoSeleccionado
            // 
            this.txtMetPagoSeleccionado.Enabled = false;
            this.txtMetPagoSeleccionado.Location = new System.Drawing.Point(189, 151);
            this.txtMetPagoSeleccionado.Name = "txtMetPagoSeleccionado";
            this.txtMetPagoSeleccionado.Size = new System.Drawing.Size(155, 22);
            this.txtMetPagoSeleccionado.TabIndex = 68;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtHotelSeleccionado);
            this.groupBox2.Controls.Add(this.txtMetPagoSeleccionado);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtHabitacionSeleccionada);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.txtPrecioSinIVA);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.txtPrecioFinal);
            this.groupBox2.Location = new System.Drawing.Point(20, 217);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(397, 297);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Información Habitaciones y de Pago";
            // 
            // gbxReservaInfo
            // 
            this.gbxReservaInfo.Controls.Add(this.dtpCheckOut);
            this.gbxReservaInfo.Controls.Add(this.dtpCheckInn);
            this.gbxReservaInfo.Controls.Add(this.dtpFechaEntrada);
            this.gbxReservaInfo.Controls.Add(this.label8);
            this.gbxReservaInfo.Controls.Add(this.label9);
            this.gbxReservaInfo.Controls.Add(this.dtpFechaSalida);
            this.gbxReservaInfo.Controls.Add(this.label10);
            this.gbxReservaInfo.Controls.Add(this.label11);
            this.gbxReservaInfo.Controls.Add(this.txtEquipoDisponible);
            this.gbxReservaInfo.Controls.Add(this.label23);
            this.gbxReservaInfo.Location = new System.Drawing.Point(505, 144);
            this.gbxReservaInfo.Margin = new System.Windows.Forms.Padding(4);
            this.gbxReservaInfo.Name = "gbxReservaInfo";
            this.gbxReservaInfo.Padding = new System.Windows.Forms.Padding(4);
            this.gbxReservaInfo.Size = new System.Drawing.Size(592, 447);
            this.gbxReservaInfo.TabIndex = 69;
            this.gbxReservaInfo.TabStop = false;
            this.gbxReservaInfo.Text = "Información de la Reserva";
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.CustomFormat = "\"HH:mm\"";
            this.dtpCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCheckOut.Location = new System.Drawing.Point(160, 231);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(200, 22);
            this.dtpCheckOut.TabIndex = 62;
            // 
            // dtpCheckInn
            // 
            this.dtpCheckInn.CustomFormat = "\"HH:mm\"";
            this.dtpCheckInn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCheckInn.Location = new System.Drawing.Point(160, 168);
            this.dtpCheckInn.Name = "dtpCheckInn";
            this.dtpCheckInn.Size = new System.Drawing.Size(200, 22);
            this.dtpCheckInn.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 60);
            this.label2.TabIndex = 70;
            this.label2.Text = "Información del Pago \r\n\r\n\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(81, 571);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 20);
            this.label4.TabIndex = 71;
            this.label4.Text = "Información de los huespedes";
            // 
            // txtBuscarReserva
            // 
            this.txtBuscarReserva.Enabled = false;
            this.txtBuscarReserva.Location = new System.Drawing.Point(1364, 144);
            this.txtBuscarReserva.Name = "txtBuscarReserva";
            this.txtBuscarReserva.Size = new System.Drawing.Size(186, 22);
            this.txtBuscarReserva.TabIndex = 69;
            // 
            // frmReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1781, 809);
            this.Controls.Add(this.txtBuscarReserva);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbxReservaInfo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSeleccionarHuesped);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnAgregarReserva);
            this.Controls.Add(this.btnMostrarReservas);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminarReserva);
            this.Controls.Add(this.dgvReservas);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReserva";
            this.Text = "Reserva de Huespedes";
            this.Load += new System.EventHandler(this.frmReserva_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxReservaInfo.ResumeLayout(false);
            this.gbxReservaInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCantHuespedes;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.Button btnEliminarReserva;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnMostrarReservas;
        private System.Windows.Forms.Button btnAgregarReserva;
        private System.Windows.Forms.TextBox txtPrecioSinIVA;
        private System.Windows.Forms.TextBox txtPrecioFinal;
        private System.Windows.Forms.TextBox txtHotelSeleccionado;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtEquipoDisponible;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrada;
        private System.Windows.Forms.DateTimePicker dtpFechaSalida;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtInfoHuespedes;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbSeleccionarHuesped;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHabitacionSeleccionada;
        private System.Windows.Forms.TextBox txtMetPagoSeleccionado;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbxReservaInfo;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.DateTimePicker dtpCheckInn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBuscarReserva;
    }
}

