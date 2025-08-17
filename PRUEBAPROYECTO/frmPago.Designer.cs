
namespace Clave5_Grupo6
{
    partial class frmPago
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrecioBase = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecioFinalfrmPago = new System.Windows.Forms.TextBox();
            this.dgvMostrarTablaPago = new System.Windows.Forms.DataGridView();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.btnMostrarPagos = new System.Windows.Forms.Button();
            this.btnLimpiarCamposPago = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTipoPagofrmPago = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnIrReservas = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cmbReserva = new System.Windows.Forms.ComboBox();
            this.gbxDetallesPago = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoches = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpCheckInn = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpHoraCheckInn = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpHoraCheckOut = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.lblIngresoAnticipado = new System.Windows.Forms.Label();
            this.chkIngresoAnticipado = new System.Windows.Forms.CheckBox();
            this.lblDisponibilidad = new System.Windows.Forms.Label();
            this.lblDisponible = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrarTablaPago)).BeginInit();
            this.gbxDetallesPago.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 530);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Precio base";
            // 
            // txtPrecioBase
            // 
            this.txtPrecioBase.Enabled = false;
            this.txtPrecioBase.Location = new System.Drawing.Point(157, 527);
            this.txtPrecioBase.Name = "txtPrecioBase";
            this.txtPrecioBase.Size = new System.Drawing.Size(171, 27);
            this.txtPrecioBase.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(307, 584);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Precio total a pagar";
            // 
            // txtPrecioFinalfrmPago
            // 
            this.txtPrecioFinalfrmPago.Enabled = false;
            this.txtPrecioFinalfrmPago.Location = new System.Drawing.Point(280, 120);
            this.txtPrecioFinalfrmPago.Name = "txtPrecioFinalfrmPago";
            this.txtPrecioFinalfrmPago.Size = new System.Drawing.Size(115, 27);
            this.txtPrecioFinalfrmPago.TabIndex = 22;
            // 
            // dgvMostrarTablaPago
            // 
            this.dgvMostrarTablaPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostrarTablaPago.Location = new System.Drawing.Point(714, 150);
            this.dgvMostrarTablaPago.Name = "dgvMostrarTablaPago";
            this.dgvMostrarTablaPago.RowHeadersWidth = 51;
            this.dgvMostrarTablaPago.RowTemplate.Height = 24;
            this.dgvMostrarTablaPago.Size = new System.Drawing.Size(678, 408);
            this.dgvMostrarTablaPago.TabIndex = 23;
            // 
            // btnRegistrarPago
            // 
            this.btnRegistrarPago.Location = new System.Drawing.Point(772, 660);
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.Size = new System.Drawing.Size(99, 62);
            this.btnRegistrarPago.TabIndex = 24;
            this.btnRegistrarPago.Text = "Registrar pago\r\n";
            this.btnRegistrarPago.UseVisualStyleBackColor = true;
            this.btnRegistrarPago.Click += new System.EventHandler(this.btnAgregarDatosPago_Click);
            // 
            // btnMostrarPagos
            // 
            this.btnMostrarPagos.Location = new System.Drawing.Point(900, 659);
            this.btnMostrarPagos.Name = "btnMostrarPagos";
            this.btnMostrarPagos.Size = new System.Drawing.Size(98, 62);
            this.btnMostrarPagos.TabIndex = 25;
            this.btnMostrarPagos.Text = "Mostrar pagos";
            this.btnMostrarPagos.UseVisualStyleBackColor = true;
            this.btnMostrarPagos.Click += new System.EventHandler(this.btnMostrarPagos_Click);
            // 
            // btnLimpiarCamposPago
            // 
            this.btnLimpiarCamposPago.Location = new System.Drawing.Point(1019, 658);
            this.btnLimpiarCamposPago.Name = "btnLimpiarCamposPago";
            this.btnLimpiarCamposPago.Size = new System.Drawing.Size(94, 64);
            this.btnLimpiarCamposPago.TabIndex = 26;
            this.btnLimpiarCamposPago.Text = "Limpiar campos";
            this.btnLimpiarCamposPago.UseVisualStyleBackColor = true;
            this.btnLimpiarCamposPago.Click += new System.EventHandler(this.btnLimpiarCamposPago_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(1136, 657);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(90, 64);
            this.btnCerrar.TabIndex = 27;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "Seleccione la reserva\r\n";
            // 
            // cmbTipoPagofrmPago
            // 
            this.cmbTipoPagofrmPago.FormattingEnabled = true;
            this.cmbTipoPagofrmPago.Items.AddRange(new object[] {
            "Efectivo ",
            "Tarjeta de crédito ",
            "Bitcoin"});
            this.cmbTipoPagofrmPago.Location = new System.Drawing.Point(280, 51);
            this.cmbTipoPagofrmPago.Name = "cmbTipoPagofrmPago";
            this.cmbTipoPagofrmPago.Size = new System.Drawing.Size(212, 28);
            this.cmbTipoPagofrmPago.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(231, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "Seleccione el tipo de pago";
            // 
            // btnIrReservas
            // 
            this.btnIrReservas.Location = new System.Drawing.Point(1259, 31);
            this.btnIrReservas.Name = "btnIrReservas";
            this.btnIrReservas.Size = new System.Drawing.Size(104, 53);
            this.btnIrReservas.TabIndex = 32;
            this.btnIrReservas.Text = "Ir a reservas =>";
            this.btnIrReservas.UseVisualStyleBackColor = true;
            this.btnIrReservas.Click += new System.EventHandler(this.btnIrReservas_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(1259, 657);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(84, 64);
            this.btnEliminar.TabIndex = 33;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cmbReserva
            // 
            this.cmbReserva.FormattingEnabled = true;
            this.cmbReserva.Location = new System.Drawing.Point(235, 46);
            this.cmbReserva.Name = "cmbReserva";
            this.cmbReserva.Size = new System.Drawing.Size(172, 24);
            this.cmbReserva.TabIndex = 35;
            // 
            // gbxDetallesPago
            // 
            this.gbxDetallesPago.Controls.Add(this.label11);
            this.gbxDetallesPago.Controls.Add(this.lblDisponible);
            this.gbxDetallesPago.Controls.Add(this.lblDisponibilidad);
            this.gbxDetallesPago.Controls.Add(this.chkIngresoAnticipado);
            this.gbxDetallesPago.Controls.Add(this.lblIngresoAnticipado);
            this.gbxDetallesPago.Controls.Add(this.label10);
            this.gbxDetallesPago.Controls.Add(this.dtpHoraCheckOut);
            this.gbxDetallesPago.Controls.Add(this.label9);
            this.gbxDetallesPago.Controls.Add(this.dtpHoraCheckInn);
            this.gbxDetallesPago.Controls.Add(this.label8);
            this.gbxDetallesPago.Controls.Add(this.dtpCheckOut);
            this.gbxDetallesPago.Controls.Add(this.label3);
            this.gbxDetallesPago.Controls.Add(this.dtpCheckInn);
            this.gbxDetallesPago.Controls.Add(this.label2);
            this.gbxDetallesPago.Controls.Add(this.txtNoches);
            this.gbxDetallesPago.Controls.Add(this.label1);
            this.gbxDetallesPago.Controls.Add(this.label7);
            this.gbxDetallesPago.Controls.Add(this.cmbTipoPagofrmPago);
            this.gbxDetallesPago.Controls.Add(this.label4);
            this.gbxDetallesPago.Controls.Add(this.txtPrecioBase);
            this.gbxDetallesPago.Controls.Add(this.label5);
            this.gbxDetallesPago.Controls.Add(this.txtPrecioFinalfrmPago);
            this.gbxDetallesPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDetallesPago.ForeColor = System.Drawing.Color.Black;
            this.gbxDetallesPago.Location = new System.Drawing.Point(12, 108);
            this.gbxDetallesPago.Name = "gbxDetallesPago";
            this.gbxDetallesPago.Size = new System.Drawing.Size(672, 628);
            this.gbxDetallesPago.TabIndex = 36;
            this.gbxDetallesPago.TabStop = false;
            this.gbxDetallesPago.Text = "Detalles del Pago";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Ingresar noches de hospedaje";
            // 
            // txtNoches
            // 
            this.txtNoches.Location = new System.Drawing.Point(488, 581);
            this.txtNoches.Name = "txtNoches";
            this.txtNoches.Size = new System.Drawing.Size(178, 27);
            this.txtNoches.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Fecha de entrada:\r\n";
            // 
            // dtpCheckInn
            // 
            this.dtpCheckInn.Location = new System.Drawing.Point(223, 187);
            this.dtpCheckInn.Name = "dtpCheckInn";
            this.dtpCheckInn.Size = new System.Drawing.Size(200, 27);
            this.dtpCheckInn.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 40);
            this.label3.TabIndex = 36;
            this.label3.Text = "Fecha de salida:\r\n\r\n";
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Location = new System.Drawing.Point(223, 249);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(200, 27);
            this.dtpCheckOut.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 448);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 60);
            this.label8.TabIndex = 38;
            this.label8.Text = "Hora entrada\r\n\r\n\r\n";
            // 
            // dtpHoraCheckInn
            // 
            this.dtpHoraCheckInn.CustomFormat = "\"HH:mm\"";
            this.dtpHoraCheckInn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraCheckInn.Location = new System.Drawing.Point(131, 448);
            this.dtpHoraCheckInn.Name = "dtpHoraCheckInn";
            this.dtpHoraCheckInn.Size = new System.Drawing.Size(170, 27);
            this.dtpHoraCheckInn.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(307, 448);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 20);
            this.label9.TabIndex = 41;
            this.label9.Text = "Hora salida";
            // 
            // dtpHoraCheckOut
            // 
            this.dtpHoraCheckOut.CustomFormat = "\"HH:mm\"";
            this.dtpHoraCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraCheckOut.Location = new System.Drawing.Point(434, 448);
            this.dtpHoraCheckOut.Name = "dtpHoraCheckOut";
            this.dtpHoraCheckOut.Size = new System.Drawing.Size(170, 27);
            this.dtpHoraCheckOut.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 60);
            this.label10.TabIndex = 43;
            this.label10.Text = "Hora entrada\r\n\r\n\r\n";
            // 
            // lblIngresoAnticipado
            // 
            this.lblIngresoAnticipado.AutoSize = true;
            this.lblIngresoAnticipado.Location = new System.Drawing.Point(6, 326);
            this.lblIngresoAnticipado.Name = "lblIngresoAnticipado";
            this.lblIngresoAnticipado.Size = new System.Drawing.Size(241, 20);
            this.lblIngresoAnticipado.TabIndex = 44;
            this.lblIngresoAnticipado.Text = "Realizar Ingreso Anticipado";
            // 
            // chkIngresoAnticipado
            // 
            this.chkIngresoAnticipado.AutoSize = true;
            this.chkIngresoAnticipado.Location = new System.Drawing.Point(280, 326);
            this.chkIngresoAnticipado.Name = "chkIngresoAnticipado";
            this.chkIngresoAnticipado.Size = new System.Drawing.Size(48, 24);
            this.chkIngresoAnticipado.TabIndex = 45;
            this.chkIngresoAnticipado.Text = "Sí";
            this.chkIngresoAnticipado.UseVisualStyleBackColor = true;
            // 
            // lblDisponibilidad
            // 
            this.lblDisponibilidad.AutoSize = true;
            this.lblDisponibilidad.Location = new System.Drawing.Point(6, 387);
            this.lblDisponibilidad.Name = "lblDisponibilidad";
            this.lblDisponibilidad.Size = new System.Drawing.Size(0, 20);
            this.lblDisponibilidad.TabIndex = 46;
            // 
            // lblDisponible
            // 
            this.lblDisponible.AutoSize = true;
            this.lblDisponible.Location = new System.Drawing.Point(267, 387);
            this.lblDisponible.Name = "lblDisponible";
            this.lblDisponible.Size = new System.Drawing.Size(128, 20);
            this.lblDisponible.TabIndex = 47;
            this.lblDisponible.Text = "Disponibilidad\r\n";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 387);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 20);
            this.label11.TabIndex = 48;
            this.label11.Text = "Disponibilidad\r\n";
            // 
            // frmPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1415, 748);
            this.Controls.Add(this.gbxDetallesPago);
            this.Controls.Add(this.cmbReserva);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnIrReservas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnLimpiarCamposPago);
            this.Controls.Add(this.btnMostrarPagos);
            this.Controls.Add(this.btnRegistrarPago);
            this.Controls.Add(this.dgvMostrarTablaPago);
            this.Name = "frmPago";
            this.Text = "frmPago";
            this.Load += new System.EventHandler(this.frmPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrarTablaPago)).EndInit();
            this.gbxDetallesPago.ResumeLayout(false);
            this.gbxDetallesPago.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrecioBase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrecioFinalfrmPago;
        private System.Windows.Forms.DataGridView dgvMostrarTablaPago;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.Button btnMostrarPagos;
        private System.Windows.Forms.Button btnLimpiarCamposPago;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTipoPagofrmPago;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnIrReservas;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox cmbReserva;
        private System.Windows.Forms.GroupBox gbxDetallesPago;
        private System.Windows.Forms.TextBox txtNoches;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpHoraCheckInn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpCheckInn;
        private System.Windows.Forms.Label lblIngresoAnticipado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpHoraCheckOut;
        private System.Windows.Forms.Label lblDisponibilidad;
        private System.Windows.Forms.CheckBox chkIngresoAnticipado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDisponible;
    }
}