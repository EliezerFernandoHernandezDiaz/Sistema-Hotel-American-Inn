
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDUI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdHabitacion = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtInfoHuespedes = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCantHuespedes = new System.Windows.Forms.TextBox();
            this.cmbZonaHotel = new System.Windows.Forms.ComboBox();
            this.cmbTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIdReserva = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtHoraEntrada = new System.Windows.Forms.TextBox();
            this.txtHoraSalida = new System.Windows.Forms.TextBox();
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.btnEliminarReserva = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.chkCostoExtra = new System.Windows.Forms.CheckBox();
            this.btnProbandoConex = new System.Windows.Forms.Button();
            this.btnMostrarReservas = new System.Windows.Forms.Button();
            this.btnAgregarReserva = new System.Windows.Forms.Button();
            this.txtDisponible = new System.Windows.Forms.TextBox();
            this.txtPrecioSinIVA = new System.Windows.Forms.TextBox();
            this.txtPrecioFinal = new System.Windows.Forms.TextBox();
            this.txtFechaEntrada = new System.Windows.Forms.TextBox();
            this.txtFechaSalida = new System.Windows.Forms.TextBox();
            this.txtIdPago = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtEquipoDisponible = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.dtpFechaEntrada = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellidos";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(131, 65);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(132, 22);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(131, 113);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(132, 22);
            this.txtApellido.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 416);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo del hotel";
            // 
            // txtDUI
            // 
            this.txtDUI.Location = new System.Drawing.Point(131, 159);
            this.txtDUI.Margin = new System.Windows.Forms.Padding(4);
            this.txtDUI.Name = "txtDUI";
            this.txtDUI.Size = new System.Drawing.Size(132, 22);
            this.txtDUI.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 164);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "DUI";
            // 
            // txtIdHabitacion
            // 
            this.txtIdHabitacion.Location = new System.Drawing.Point(152, 253);
            this.txtIdHabitacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdHabitacion.Name = "txtIdHabitacion";
            this.txtIdHabitacion.Size = new System.Drawing.Size(132, 22);
            this.txtIdHabitacion.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtInfoHuespedes);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtCantHuespedes);
            this.groupBox1.Location = new System.Drawing.Point(27, 575);
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
            this.label19.Size = new System.Drawing.Size(171, 34);
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
            this.label13.Size = new System.Drawing.Size(158, 17);
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
            // cmbZonaHotel
            // 
            this.cmbZonaHotel.FormattingEnabled = true;
            this.cmbZonaHotel.Items.AddRange(new object[] {
            "Ciudad",
            "Playa",
            "Montaña"});
            this.cmbZonaHotel.Location = new System.Drawing.Point(152, 409);
            this.cmbZonaHotel.Margin = new System.Windows.Forms.Padding(4);
            this.cmbZonaHotel.Name = "cmbZonaHotel";
            this.cmbZonaHotel.Size = new System.Drawing.Size(132, 24);
            this.cmbZonaHotel.TabIndex = 9;
            // 
            // cmbTipoHabitacion
            // 
            this.cmbTipoHabitacion.FormattingEnabled = true;
            this.cmbTipoHabitacion.Items.AddRange(new object[] {
            "Sencilla",
            "Doble",
            "Deluxe",
            "Suite"});
            this.cmbTipoHabitacion.Location = new System.Drawing.Point(152, 457);
            this.cmbTipoHabitacion.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipoHabitacion.Name = "cmbTipoHabitacion";
            this.cmbTipoHabitacion.Size = new System.Drawing.Size(132, 24);
            this.cmbTipoHabitacion.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(24, 257);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "ID habitacion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 464);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tipo de habitacion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(25, 303);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "ID reserva";
            // 
            // txtIdReserva
            // 
            this.txtIdReserva.Location = new System.Drawing.Point(152, 303);
            this.txtIdReserva.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdReserva.Name = "txtIdReserva";
            this.txtIdReserva.Size = new System.Drawing.Size(132, 22);
            this.txtIdReserva.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(495, 143);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Fecha de entrada";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(495, 211);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Fecha de salida";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(498, 267);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "Hora de entrada";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(503, 314);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 17);
            this.label11.TabIndex = 20;
            this.label11.Text = "Hora de salida";
            // 
            // txtHoraEntrada
            // 
            this.txtHoraEntrada.Enabled = false;
            this.txtHoraEntrada.Location = new System.Drawing.Point(647, 262);
            this.txtHoraEntrada.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoraEntrada.Name = "txtHoraEntrada";
            this.txtHoraEntrada.Size = new System.Drawing.Size(200, 22);
            this.txtHoraEntrada.TabIndex = 21;
            this.txtHoraEntrada.Text = "15:00";
            // 
            // txtHoraSalida
            // 
            this.txtHoraSalida.Enabled = false;
            this.txtHoraSalida.Location = new System.Drawing.Point(647, 314);
            this.txtHoraSalida.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoraSalida.Name = "txtHoraSalida";
            this.txtHoraSalida.Size = new System.Drawing.Size(200, 22);
            this.txtHoraSalida.TabIndex = 22;
            this.txtHoraSalida.Text = "13:00";
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta de credito",
            "Tarjeta de debito",
            "Bitcoin"});
            this.cmbFormaPago.Location = new System.Drawing.Point(152, 521);
            this.cmbFormaPago.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(132, 24);
            this.cmbFormaPago.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 521);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 17);
            this.label14.TabIndex = 28;
            this.label14.Text = "Forma de pago";
            // 
            // dgvReservas
            // 
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Location = new System.Drawing.Point(878, 206);
            this.dgvReservas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.RowHeadersWidth = 51;
            this.dgvReservas.Size = new System.Drawing.Size(890, 396);
            this.dgvReservas.TabIndex = 29;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(469, 554);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(185, 17);
            this.label15.TabIndex = 32;
            this.label15.Text = "Disponibilidad de habitacion";
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
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1364, 116);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 35;
            this.button3.Text = "Salir";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(737, 11);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(215, 29);
            this.label17.TabIndex = 38;
            this.label17.Text = "Hotel American Inn";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(34, 21);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(261, 20);
            this.label18.TabIndex = 39;
            this.label18.Text = "Ingrese los datos del huesped";
            // 
            // chkCostoExtra
            // 
            this.chkCostoExtra.AutoSize = true;
            this.chkCostoExtra.Location = new System.Drawing.Point(569, 631);
            this.chkCostoExtra.Margin = new System.Windows.Forms.Padding(4);
            this.chkCostoExtra.Name = "chkCostoExtra";
            this.chkCostoExtra.Size = new System.Drawing.Size(250, 21);
            this.chkCostoExtra.TabIndex = 43;
            this.chkCostoExtra.Text = "Desea usar las instalaciones antes";
            this.chkCostoExtra.UseVisualStyleBackColor = true;
            // 
            // btnProbandoConex
            // 
            this.btnProbandoConex.Location = new System.Drawing.Point(20, 759);
            this.btnProbandoConex.Name = "btnProbandoConex";
            this.btnProbandoConex.Size = new System.Drawing.Size(121, 38);
            this.btnProbandoConex.TabIndex = 44;
            this.btnProbandoConex.Text = "Probar conexion";
            this.btnProbandoConex.UseVisualStyleBackColor = true;
            this.btnProbandoConex.Click += new System.EventHandler(this.btnProbandoConex_Click);
            // 
            // btnMostrarReservas
            // 
            this.btnMostrarReservas.Location = new System.Drawing.Point(1221, 116);
            this.btnMostrarReservas.Name = "btnMostrarReservas";
            this.btnMostrarReservas.Size = new System.Drawing.Size(97, 31);
            this.btnMostrarReservas.TabIndex = 45;
            this.btnMostrarReservas.Text = "Mostrar";
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
            // txtDisponible
            // 
            this.txtDisponible.Location = new System.Drawing.Point(683, 556);
            this.txtDisponible.Name = "txtDisponible";
            this.txtDisponible.Size = new System.Drawing.Size(164, 22);
            this.txtDisponible.TabIndex = 47;
            // 
            // txtPrecioSinIVA
            // 
            this.txtPrecioSinIVA.Enabled = false;
            this.txtPrecioSinIVA.Location = new System.Drawing.Point(647, 373);
            this.txtPrecioSinIVA.Name = "txtPrecioSinIVA";
            this.txtPrecioSinIVA.Size = new System.Drawing.Size(156, 22);
            this.txtPrecioSinIVA.TabIndex = 48;
            // 
            // txtPrecioFinal
            // 
            this.txtPrecioFinal.Enabled = false;
            this.txtPrecioFinal.Location = new System.Drawing.Point(647, 431);
            this.txtPrecioFinal.Name = "txtPrecioFinal";
            this.txtPrecioFinal.Size = new System.Drawing.Size(156, 22);
            this.txtPrecioFinal.TabIndex = 49;
            // 
            // txtFechaEntrada
            // 
            this.txtFechaEntrada.Location = new System.Drawing.Point(1526, 11);
            this.txtFechaEntrada.Name = "txtFechaEntrada";
            this.txtFechaEntrada.Size = new System.Drawing.Size(100, 22);
            this.txtFechaEntrada.TabIndex = 50;
            // 
            // txtFechaSalida
            // 
            this.txtFechaSalida.Location = new System.Drawing.Point(1420, 11);
            this.txtFechaSalida.Name = "txtFechaSalida";
            this.txtFechaSalida.Size = new System.Drawing.Size(100, 22);
            this.txtFechaSalida.TabIndex = 51;
            // 
            // txtIdPago
            // 
            this.txtIdPago.Location = new System.Drawing.Point(152, 350);
            this.txtIdPago.Name = "txtIdPago";
            this.txtIdPago.Size = new System.Drawing.Size(132, 22);
            this.txtIdPago.TabIndex = 52;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(16, 214);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(312, 20);
            this.label21.TabIndex = 53;
            this.label21.Text = "Información Habitaciones y de Pago";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(503, 373);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 17);
            this.label22.TabIndex = 54;
            this.label22.Text = "Precio Base";
            // 
            // txtEquipoDisponible
            // 
            this.txtEquipoDisponible.Enabled = false;
            this.txtEquipoDisponible.Location = new System.Drawing.Point(642, 492);
            this.txtEquipoDisponible.Name = "txtEquipoDisponible";
            this.txtEquipoDisponible.Size = new System.Drawing.Size(205, 22);
            this.txtEquipoDisponible.TabIndex = 55;
            this.txtEquipoDisponible.Text = "Tv, Cama, Aire Acondicionado";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(483, 497);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(120, 17);
            this.label23.TabIndex = 56;
            this.label23.Text = "Equipo disponible";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(25, 350);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(58, 17);
            this.label24.TabIndex = 57;
            this.label24.Text = "ID Pago";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(402, 436);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(239, 17);
            this.label25.TabIndex = 58;
            this.label25.Text = "Precio Final a pagar con iva del 13%\r\n";
            // 
            // dtpFechaEntrada
            // 
            this.dtpFechaEntrada.Location = new System.Drawing.Point(647, 138);
            this.dtpFechaEntrada.Name = "dtpFechaEntrada";
            this.dtpFechaEntrada.Size = new System.Drawing.Size(200, 22);
            this.dtpFechaEntrada.TabIndex = 59;
            // 
            // dtpFechaSalida
            // 
            this.dtpFechaSalida.Location = new System.Drawing.Point(642, 206);
            this.dtpFechaSalida.Name = "dtpFechaSalida";
            this.dtpFechaSalida.Size = new System.Drawing.Size(200, 22);
            this.dtpFechaSalida.TabIndex = 60;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(624, 80);
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
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1088, 665);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(114, 64);
            this.btnBuscar.TabIndex = 63;
            this.btnBuscar.Text = "Buscar Reserva";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(546, 679);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(358, 17);
            this.label12.TabIndex = 64;
            this.label12.Text = "Nota: Esto tiene un costo extra de $20 a su precio final.";
            // 
            // frmReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1781, 809);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.chkCostoExtra);
            this.Controls.Add(this.dtpFechaSalida);
            this.Controls.Add(this.dtpFechaEntrada);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtEquipoDisponible);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtIdPago);
            this.Controls.Add(this.txtFechaSalida);
            this.Controls.Add(this.txtFechaEntrada);
            this.Controls.Add(this.txtPrecioFinal);
            this.Controls.Add(this.txtPrecioSinIVA);
            this.Controls.Add(this.txtDisponible);
            this.Controls.Add(this.btnAgregarReserva);
            this.Controls.Add(this.btnMostrarReservas);
            this.Controls.Add(this.btnProbandoConex);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnEliminarReserva);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dgvReservas);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbFormaPago);
            this.Controls.Add(this.txtHoraSalida);
            this.Controls.Add(this.txtHoraEntrada);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtIdReserva);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTipoHabitacion);
            this.Controls.Add(this.cmbZonaHotel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtIdHabitacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDUI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReserva";
            this.Text = "Reserva de Huespedes";
            this.Load += new System.EventHandler(this.frmReserva_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDUI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdHabitacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbZonaHotel;
        private System.Windows.Forms.ComboBox cmbTipoHabitacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIdReserva;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtHoraEntrada;
        private System.Windows.Forms.TextBox txtHoraSalida;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCantHuespedes;
        private System.Windows.Forms.ComboBox cmbFormaPago;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnEliminarReserva;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox chkCostoExtra;
        private System.Windows.Forms.Button btnProbandoConex;
        private System.Windows.Forms.Button btnMostrarReservas;
        private System.Windows.Forms.Button btnAgregarReserva;
        private System.Windows.Forms.TextBox txtDisponible;
        private System.Windows.Forms.TextBox txtPrecioSinIVA;
        private System.Windows.Forms.TextBox txtPrecioFinal;
        private System.Windows.Forms.TextBox txtFechaEntrada;
        private System.Windows.Forms.TextBox txtFechaSalida;
        private System.Windows.Forms.TextBox txtIdPago;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtEquipoDisponible;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrada;
        private System.Windows.Forms.DateTimePicker dtpFechaSalida;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtInfoHuespedes;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label12;
    }
}

