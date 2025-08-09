
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
            this.btnProbarConexfrmPago = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdPagofrmPago = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoHotelfrmPago = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoHabitacionfrmPago = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrecioBase = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecioFinalfrmPago = new System.Windows.Forms.TextBox();
            this.dgvMostrarTablaPago = new System.Windows.Forms.DataGridView();
            this.btnAgregarDatosPago = new System.Windows.Forms.Button();
            this.btnMostrarPagos = new System.Windows.Forms.Button();
            this.btnLimpiarCamposPago = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdHabFK = new System.Windows.Forms.TextBox();
            this.cmbTipoPagofrmPago = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnIrReservas = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrarTablaPago)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProbarConexfrmPago
            // 
            this.btnProbarConexfrmPago.Location = new System.Drawing.Point(1099, 52);
            this.btnProbarConexfrmPago.Name = "btnProbarConexfrmPago";
            this.btnProbarConexfrmPago.Size = new System.Drawing.Size(127, 51);
            this.btnProbarConexfrmPago.TabIndex = 12;
            this.btnProbarConexfrmPago.Text = "Probar la conexion ";
            this.btnProbarConexfrmPago.UseVisualStyleBackColor = true;
            this.btnProbarConexfrmPago.Click += new System.EventHandler(this.btnProbarConexfrmPago_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Ingrese el id del pago";
            // 
            // txtIdPagofrmPago
            // 
            this.txtIdPagofrmPago.Location = new System.Drawing.Point(275, 69);
            this.txtIdPagofrmPago.Name = "txtIdPagofrmPago";
            this.txtIdPagofrmPago.Size = new System.Drawing.Size(212, 22);
            this.txtIdPagofrmPago.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Seleccione el tipo de hotel";
            // 
            // cmbTipoHotelfrmPago
            // 
            this.cmbTipoHotelfrmPago.FormattingEnabled = true;
            this.cmbTipoHotelfrmPago.Items.AddRange(new object[] {
            "Ciudad",
            "Playa ",
            "Montaña"});
            this.cmbTipoHotelfrmPago.Location = new System.Drawing.Point(275, 183);
            this.cmbTipoHotelfrmPago.Name = "cmbTipoHotelfrmPago";
            this.cmbTipoHotelfrmPago.Size = new System.Drawing.Size(212, 24);
            this.cmbTipoHotelfrmPago.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Seleccione el tipo de habitacion";
            // 
            // cmbTipoHabitacionfrmPago
            // 
            this.cmbTipoHabitacionfrmPago.FormattingEnabled = true;
            this.cmbTipoHabitacionfrmPago.Items.AddRange(new object[] {
            "Sencilla",
            "Doble",
            "Deluxe",
            "Suite"});
            this.cmbTipoHabitacionfrmPago.Location = new System.Drawing.Point(321, 298);
            this.cmbTipoHabitacionfrmPago.Name = "cmbTipoHabitacionfrmPago";
            this.cmbTipoHabitacionfrmPago.Size = new System.Drawing.Size(212, 24);
            this.cmbTipoHabitacionfrmPago.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 448);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Precio base";
            // 
            // txtPrecioBase
            // 
            this.txtPrecioBase.Location = new System.Drawing.Point(321, 445);
            this.txtPrecioBase.Name = "txtPrecioBase";
            this.txtPrecioBase.Size = new System.Drawing.Size(212, 22);
            this.txtPrecioBase.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 526);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Precio final";
            // 
            // txtPrecioFinalfrmPago
            // 
            this.txtPrecioFinalfrmPago.Location = new System.Drawing.Point(321, 521);
            this.txtPrecioFinalfrmPago.Name = "txtPrecioFinalfrmPago";
            this.txtPrecioFinalfrmPago.Size = new System.Drawing.Size(212, 22);
            this.txtPrecioFinalfrmPago.TabIndex = 22;
            // 
            // dgvMostrarTablaPago
            // 
            this.dgvMostrarTablaPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostrarTablaPago.Location = new System.Drawing.Point(599, 150);
            this.dgvMostrarTablaPago.Name = "dgvMostrarTablaPago";
            this.dgvMostrarTablaPago.RowHeadersWidth = 51;
            this.dgvMostrarTablaPago.RowTemplate.Height = 24;
            this.dgvMostrarTablaPago.Size = new System.Drawing.Size(793, 322);
            this.dgvMostrarTablaPago.TabIndex = 23;
            // 
            // btnAgregarDatosPago
            // 
            this.btnAgregarDatosPago.Location = new System.Drawing.Point(222, 604);
            this.btnAgregarDatosPago.Name = "btnAgregarDatosPago";
            this.btnAgregarDatosPago.Size = new System.Drawing.Size(140, 84);
            this.btnAgregarDatosPago.TabIndex = 24;
            this.btnAgregarDatosPago.Text = "Agregar los datos del pago";
            this.btnAgregarDatosPago.UseVisualStyleBackColor = true;
            this.btnAgregarDatosPago.Click += new System.EventHandler(this.btnAgregarDatosPago_Click);
            // 
            // btnMostrarPagos
            // 
            this.btnMostrarPagos.Location = new System.Drawing.Point(470, 604);
            this.btnMostrarPagos.Name = "btnMostrarPagos";
            this.btnMostrarPagos.Size = new System.Drawing.Size(115, 84);
            this.btnMostrarPagos.TabIndex = 25;
            this.btnMostrarPagos.Text = "Mostrar pagos";
            this.btnMostrarPagos.UseVisualStyleBackColor = true;
            this.btnMostrarPagos.Click += new System.EventHandler(this.btnMostrarPagos_Click);
            // 
            // btnLimpiarCamposPago
            // 
            this.btnLimpiarCamposPago.Location = new System.Drawing.Point(690, 604);
            this.btnLimpiarCamposPago.Name = "btnLimpiarCamposPago";
            this.btnLimpiarCamposPago.Size = new System.Drawing.Size(126, 84);
            this.btnLimpiarCamposPago.TabIndex = 26;
            this.btnLimpiarCamposPago.Text = "Limpiar campos";
            this.btnLimpiarCamposPago.UseVisualStyleBackColor = true;
            this.btnLimpiarCamposPago.Click += new System.EventHandler(this.btnLimpiarCamposPago_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(922, 604);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(115, 84);
            this.btnCerrar.TabIndex = 27;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "Ingrese el id de la habitación";
            // 
            // txtIdHabFK
            // 
            this.txtIdHabFK.Location = new System.Drawing.Point(293, 128);
            this.txtIdHabFK.Name = "txtIdHabFK";
            this.txtIdHabFK.Size = new System.Drawing.Size(212, 22);
            this.txtIdHabFK.TabIndex = 29;
            // 
            // cmbTipoPagofrmPago
            // 
            this.cmbTipoPagofrmPago.FormattingEnabled = true;
            this.cmbTipoPagofrmPago.Items.AddRange(new object[] {
            "Efectivo ",
            "Tarjeta de crédito ",
            "Bitcoin"});
            this.cmbTipoPagofrmPago.Location = new System.Drawing.Point(321, 369);
            this.cmbTipoPagofrmPago.Name = "cmbTipoPagofrmPago";
            this.cmbTipoPagofrmPago.Size = new System.Drawing.Size(212, 24);
            this.cmbTipoPagofrmPago.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(78, 376);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "Seleccione el tipo de pago";
            // 
            // btnIrReservas
            // 
            this.btnIrReservas.Location = new System.Drawing.Point(866, 50);
            this.btnIrReservas.Name = "btnIrReservas";
            this.btnIrReservas.Size = new System.Drawing.Size(104, 53);
            this.btnIrReservas.TabIndex = 32;
            this.btnIrReservas.Text = "Ir a reservas";
            this.btnIrReservas.UseVisualStyleBackColor = true;
            this.btnIrReservas.Click += new System.EventHandler(this.btnIrReservas_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(1241, 604);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(93, 61);
            this.btnEliminar.TabIndex = 33;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 748);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnIrReservas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbTipoPagofrmPago);
            this.Controls.Add(this.txtIdHabFK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnLimpiarCamposPago);
            this.Controls.Add(this.btnMostrarPagos);
            this.Controls.Add(this.btnAgregarDatosPago);
            this.Controls.Add(this.dgvMostrarTablaPago);
            this.Controls.Add(this.txtPrecioFinalfrmPago);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPrecioBase);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTipoHabitacionfrmPago);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTipoHotelfrmPago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdPagofrmPago);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProbarConexfrmPago);
            this.Name = "frmPago";
            this.Text = "frmPago";
            this.Load += new System.EventHandler(this.frmPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrarTablaPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProbarConexfrmPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdPagofrmPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipoHotelfrmPago;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoHabitacionfrmPago;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrecioBase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrecioFinalfrmPago;
        private System.Windows.Forms.DataGridView dgvMostrarTablaPago;
        private System.Windows.Forms.Button btnAgregarDatosPago;
        private System.Windows.Forms.Button btnMostrarPagos;
        private System.Windows.Forms.Button btnLimpiarCamposPago;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdHabFK;
        private System.Windows.Forms.ComboBox cmbTipoPagofrmPago;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnIrReservas;
        private System.Windows.Forms.Button btnEliminar;
    }
}