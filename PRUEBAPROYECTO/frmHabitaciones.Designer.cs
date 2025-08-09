
namespace Clave5_Grupo6
{
    partial class frmHabitAciones
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtIngreseIdHabitacion = new System.Windows.Forms.TextBox();
            this.cmbTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrecioBasefrmHabitacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoHotelfrmHab = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEquipoDisponiblefrmHab = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnProbarConexfrmHab = new System.Windows.Forms.Button();
            this.dgvTablaHabitacion = new System.Windows.Forms.DataGridView();
            this.btnAgregarDatosHabitacion = new System.Windows.Forms.Button();
            this.btnMostrarDatosHabitacion = new System.Windows.Forms.Button();
            this.txtLimpiarCamposHabitacion = new System.Windows.Forms.Button();
            this.btnCerrarfrmDatosHab = new System.Windows.Forms.Button();
            this.btnIrATablaPago = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaHabitacion)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el id de la habitacion";
            // 
            // txtIngreseIdHabitacion
            // 
            this.txtIngreseIdHabitacion.Location = new System.Drawing.Point(306, 43);
            this.txtIngreseIdHabitacion.Name = "txtIngreseIdHabitacion";
            this.txtIngreseIdHabitacion.Size = new System.Drawing.Size(251, 22);
            this.txtIngreseIdHabitacion.TabIndex = 1;
            // 
            // cmbTipoHabitacion
            // 
            this.cmbTipoHabitacion.FormattingEnabled = true;
            this.cmbTipoHabitacion.Items.AddRange(new object[] {
            "Sencilla",
            "Doble",
            "Deluxe ",
            "Suite"});
            this.cmbTipoHabitacion.Location = new System.Drawing.Point(306, 207);
            this.cmbTipoHabitacion.Name = "cmbTipoHabitacion";
            this.cmbTipoHabitacion.Size = new System.Drawing.Size(251, 24);
            this.cmbTipoHabitacion.TabIndex = 2;
            this.cmbTipoHabitacion.SelectedIndexChanged += new System.EventHandler(this.cmbTipoHabitacion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seleccione un tipo de habitación";
            // 
            // txtPrecioBasefrmHabitacion
            // 
            this.txtPrecioBasefrmHabitacion.Location = new System.Drawing.Point(306, 281);
            this.txtPrecioBasefrmHabitacion.Name = "txtPrecioBasefrmHabitacion";
            this.txtPrecioBasefrmHabitacion.Size = new System.Drawing.Size(251, 22);
            this.txtPrecioBasefrmHabitacion.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Precio de la habitación";
            // 
            // cmbTipoHotelfrmHab
            // 
            this.cmbTipoHotelfrmHab.FormattingEnabled = true;
            this.cmbTipoHotelfrmHab.Items.AddRange(new object[] {
            "Ciudad ",
            "Playa ",
            "Montaña"});
            this.cmbTipoHotelfrmHab.Location = new System.Drawing.Point(306, 119);
            this.cmbTipoHotelfrmHab.Name = "cmbTipoHotelfrmHab";
            this.cmbTipoHotelfrmHab.Size = new System.Drawing.Size(251, 24);
            this.cmbTipoHotelfrmHab.TabIndex = 6;
            this.cmbTipoHotelfrmHab.SelectedIndexChanged += new System.EventHandler(this.cmbTipoHotelfrmHab_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Seleccione un tipo de hotel\r\n";
            // 
            // txtEquipoDisponiblefrmHab
            // 
            this.txtEquipoDisponiblefrmHab.Enabled = false;
            this.txtEquipoDisponiblefrmHab.Location = new System.Drawing.Point(306, 362);
            this.txtEquipoDisponiblefrmHab.Name = "txtEquipoDisponiblefrmHab";
            this.txtEquipoDisponiblefrmHab.Size = new System.Drawing.Size(251, 22);
            this.txtEquipoDisponiblefrmHab.TabIndex = 8;
            this.txtEquipoDisponiblefrmHab.Text = "Tv, cama, aire acondicionado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 367);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Equipo disponible";
            // 
            // btnProbarConexfrmHab
            // 
            this.btnProbarConexfrmHab.Location = new System.Drawing.Point(1016, 39);
            this.btnProbarConexfrmHab.Name = "btnProbarConexfrmHab";
            this.btnProbarConexfrmHab.Size = new System.Drawing.Size(127, 51);
            this.btnProbarConexfrmHab.TabIndex = 12;
            this.btnProbarConexfrmHab.Text = "Probar la conexion ";
            this.btnProbarConexfrmHab.UseVisualStyleBackColor = true;
            this.btnProbarConexfrmHab.Click += new System.EventHandler(this.btnProbarConexfrmHab_Click);
            // 
            // dgvTablaHabitacion
            // 
            this.dgvTablaHabitacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablaHabitacion.Location = new System.Drawing.Point(633, 138);
            this.dgvTablaHabitacion.Name = "dgvTablaHabitacion";
            this.dgvTablaHabitacion.RowHeadersWidth = 51;
            this.dgvTablaHabitacion.RowTemplate.Height = 24;
            this.dgvTablaHabitacion.Size = new System.Drawing.Size(791, 444);
            this.dgvTablaHabitacion.TabIndex = 13;
            // 
            // btnAgregarDatosHabitacion
            // 
            this.btnAgregarDatosHabitacion.Location = new System.Drawing.Point(234, 639);
            this.btnAgregarDatosHabitacion.Name = "btnAgregarDatosHabitacion";
            this.btnAgregarDatosHabitacion.Size = new System.Drawing.Size(127, 77);
            this.btnAgregarDatosHabitacion.TabIndex = 14;
            this.btnAgregarDatosHabitacion.Text = "Agregar datos de la habitacion";
            this.btnAgregarDatosHabitacion.UseVisualStyleBackColor = true;
            this.btnAgregarDatosHabitacion.Click += new System.EventHandler(this.btnAgregarDatosHabitacion_Click);
            // 
            // btnMostrarDatosHabitacion
            // 
            this.btnMostrarDatosHabitacion.Location = new System.Drawing.Point(430, 639);
            this.btnMostrarDatosHabitacion.Name = "btnMostrarDatosHabitacion";
            this.btnMostrarDatosHabitacion.Size = new System.Drawing.Size(127, 77);
            this.btnMostrarDatosHabitacion.TabIndex = 15;
            this.btnMostrarDatosHabitacion.Text = "Mostrar datos de la habitacion";
            this.btnMostrarDatosHabitacion.UseVisualStyleBackColor = true;
            this.btnMostrarDatosHabitacion.Click += new System.EventHandler(this.btnMostrarDatosHabitacion_Click);
            // 
            // txtLimpiarCamposHabitacion
            // 
            this.txtLimpiarCamposHabitacion.Location = new System.Drawing.Point(72, 467);
            this.txtLimpiarCamposHabitacion.Name = "txtLimpiarCamposHabitacion";
            this.txtLimpiarCamposHabitacion.Size = new System.Drawing.Size(116, 60);
            this.txtLimpiarCamposHabitacion.TabIndex = 16;
            this.txtLimpiarCamposHabitacion.Text = "Limpiar todo";
            this.txtLimpiarCamposHabitacion.UseVisualStyleBackColor = true;
            this.txtLimpiarCamposHabitacion.Click += new System.EventHandler(this.txtLimpiarCamposHabitacion_Click);
            // 
            // btnCerrarfrmDatosHab
            // 
            this.btnCerrarfrmDatosHab.Location = new System.Drawing.Point(817, 639);
            this.btnCerrarfrmDatosHab.Name = "btnCerrarfrmDatosHab";
            this.btnCerrarfrmDatosHab.Size = new System.Drawing.Size(127, 77);
            this.btnCerrarfrmDatosHab.TabIndex = 17;
            this.btnCerrarfrmDatosHab.Text = "Cerrar";
            this.btnCerrarfrmDatosHab.UseVisualStyleBackColor = true;
            this.btnCerrarfrmDatosHab.Click += new System.EventHandler(this.btnCerrarfrmDatosHab_Click);
            // 
            // btnIrATablaPago
            // 
            this.btnIrATablaPago.Location = new System.Drawing.Point(828, 35);
            this.btnIrATablaPago.Name = "btnIrATablaPago";
            this.btnIrATablaPago.Size = new System.Drawing.Size(116, 58);
            this.btnIrATablaPago.TabIndex = 18;
            this.btnIrATablaPago.Text = "Ir a pagos";
            this.btnIrATablaPago.UseVisualStyleBackColor = true;
            this.btnIrATablaPago.Click += new System.EventHandler(this.btnIrATablaPago_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(1025, 639);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(118, 77);
            this.btnEliminar.TabIndex = 19;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmHabitAciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1454, 757);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnIrATablaPago);
            this.Controls.Add(this.btnCerrarfrmDatosHab);
            this.Controls.Add(this.txtLimpiarCamposHabitacion);
            this.Controls.Add(this.btnMostrarDatosHabitacion);
            this.Controls.Add(this.btnAgregarDatosHabitacion);
            this.Controls.Add(this.dgvTablaHabitacion);
            this.Controls.Add(this.btnProbarConexfrmHab);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEquipoDisponiblefrmHab);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTipoHotelfrmHab);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrecioBasefrmHabitacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTipoHabitacion);
            this.Controls.Add(this.txtIngreseIdHabitacion);
            this.Controls.Add(this.label1);
            this.Name = "frmHabitAciones";
            this.Text = "frmHabitaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaHabitacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIngreseIdHabitacion;
        private System.Windows.Forms.ComboBox cmbTipoHabitacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrecioBasefrmHabitacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoHotelfrmHab;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEquipoDisponiblefrmHab;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnProbarConexfrmHab;
        private System.Windows.Forms.DataGridView dgvTablaHabitacion;
        private System.Windows.Forms.Button btnAgregarDatosHabitacion;
        private System.Windows.Forms.Button btnMostrarDatosHabitacion;
        private System.Windows.Forms.Button txtLimpiarCamposHabitacion;
        private System.Windows.Forms.Button btnCerrarfrmDatosHab;
        private System.Windows.Forms.Button btnIrATablaPago;
        private System.Windows.Forms.Button btnEliminar;
    }
}