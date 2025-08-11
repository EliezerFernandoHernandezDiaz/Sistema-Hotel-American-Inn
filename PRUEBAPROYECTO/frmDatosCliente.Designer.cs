
namespace Clave5_Grupo6
{
    partial class frmCliente
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
            this.components = new System.ComponentModel.Container();
            this.txtNombreHuesped = new System.Windows.Forms.TextBox();
            this.txtIngresarApellidosHuesped = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvMostrarTablaCliente = new System.Windows.Forms.DataGridView();
            this.btnAgregarDatosHuesped = new System.Windows.Forms.Button();
            this.btnMostrarDatosHuesped = new System.Windows.Forms.Button();
            this.txtLimpiarCampos = new System.Windows.Forms.Button();
            this.btnCerrarfrmDatosCliente = new System.Windows.Forms.Button();
            this.btnIrHabitaciones = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminarDatos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedDui = new System.Windows.Forms.MaskedTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cboBuscarPor = new System.Windows.Forms.ComboBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBusqueda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrarTablaCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombreHuesped
            // 
            this.txtNombreHuesped.Location = new System.Drawing.Point(396, 164);
            this.txtNombreHuesped.Name = "txtNombreHuesped";
            this.txtNombreHuesped.Size = new System.Drawing.Size(232, 22);
            this.txtNombreHuesped.TabIndex = 0;
            // 
            // txtIngresarApellidosHuesped
            // 
            this.txtIngresarApellidosHuesped.Location = new System.Drawing.Point(357, 262);
            this.txtIngresarApellidosHuesped.Name = "txtIngresarApellidosHuesped";
            this.txtIngresarApellidosHuesped.Size = new System.Drawing.Size(232, 22);
            this.txtIngresarApellidosHuesped.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ingrese el dui del huesped";
            // 
            // dgvMostrarTablaCliente
            // 
            this.dgvMostrarTablaCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostrarTablaCliente.Location = new System.Drawing.Point(634, 106);
            this.dgvMostrarTablaCliente.Name = "dgvMostrarTablaCliente";
            this.dgvMostrarTablaCliente.RowHeadersWidth = 51;
            this.dgvMostrarTablaCliente.RowTemplate.Height = 24;
            this.dgvMostrarTablaCliente.Size = new System.Drawing.Size(681, 397);
            this.dgvMostrarTablaCliente.TabIndex = 6;
            // 
            // btnAgregarDatosHuesped
            // 
            this.btnAgregarDatosHuesped.Location = new System.Drawing.Point(18, 389);
            this.btnAgregarDatosHuesped.Name = "btnAgregarDatosHuesped";
            this.btnAgregarDatosHuesped.Size = new System.Drawing.Size(127, 77);
            this.btnAgregarDatosHuesped.TabIndex = 7;
            this.btnAgregarDatosHuesped.Text = "Agregar datos del huesped";
            this.btnAgregarDatosHuesped.UseVisualStyleBackColor = true;
            this.btnAgregarDatosHuesped.Click += new System.EventHandler(this.btnAgregarDatosHuesped_Click);
            // 
            // btnMostrarDatosHuesped
            // 
            this.btnMostrarDatosHuesped.Location = new System.Drawing.Point(175, 389);
            this.btnMostrarDatosHuesped.Name = "btnMostrarDatosHuesped";
            this.btnMostrarDatosHuesped.Size = new System.Drawing.Size(122, 77);
            this.btnMostrarDatosHuesped.TabIndex = 8;
            this.btnMostrarDatosHuesped.Text = "Mostrar datos de huespedes";
            this.btnMostrarDatosHuesped.UseVisualStyleBackColor = true;
            this.btnMostrarDatosHuesped.Click += new System.EventHandler(this.btnMostrarDatosHuesped_Click);
            // 
            // txtLimpiarCampos
            // 
            this.txtLimpiarCampos.Location = new System.Drawing.Point(317, 389);
            this.txtLimpiarCampos.Name = "txtLimpiarCampos";
            this.txtLimpiarCampos.Size = new System.Drawing.Size(120, 77);
            this.txtLimpiarCampos.TabIndex = 9;
            this.txtLimpiarCampos.Text = "Limpiar datos ingresados";
            this.txtLimpiarCampos.UseVisualStyleBackColor = true;
            this.txtLimpiarCampos.Click += new System.EventHandler(this.txtLimpiarCampos_Click);
            // 
            // btnCerrarfrmDatosCliente
            // 
            this.btnCerrarfrmDatosCliente.Location = new System.Drawing.Point(320, 495);
            this.btnCerrarfrmDatosCliente.Name = "btnCerrarfrmDatosCliente";
            this.btnCerrarfrmDatosCliente.Size = new System.Drawing.Size(117, 77);
            this.btnCerrarfrmDatosCliente.TabIndex = 10;
            this.btnCerrarfrmDatosCliente.Text = "Cerrar aplicación";
            this.btnCerrarfrmDatosCliente.UseVisualStyleBackColor = true;
            this.btnCerrarfrmDatosCliente.Click += new System.EventHandler(this.btnCerrarfrmDatosCliente_Click);
            // 
            // btnIrHabitaciones
            // 
            this.btnIrHabitaciones.Location = new System.Drawing.Point(1032, 548);
            this.btnIrHabitaciones.Name = "btnIrHabitaciones";
            this.btnIrHabitaciones.Size = new System.Drawing.Size(138, 71);
            this.btnIrHabitaciones.TabIndex = 12;
            this.btnIrHabitaciones.Text = "Agregar datos de la habitación\r\n=>";
            this.btnIrHabitaciones.UseVisualStyleBackColor = true;
            this.btnIrHabitaciones.Click += new System.EventHandler(this.btnIrHabitaciones_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1149, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(120, 28);
            this.btnBuscar.TabIndex = 13;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(25, 495);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(120, 77);
            this.btnModificar.TabIndex = 14;
            this.btnModificar.Text = "Modificar datos del huesped\r\n";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminarDatos
            // 
            this.btnEliminarDatos.Location = new System.Drawing.Point(170, 495);
            this.btnEliminarDatos.Name = "btnEliminarDatos";
            this.btnEliminarDatos.Size = new System.Drawing.Size(127, 77);
            this.btnEliminarDatos.TabIndex = 15;
            this.btnEliminarDatos.Text = "Eliminar huesped\r\n";
            this.btnEliminarDatos.UseVisualStyleBackColor = true;
            this.btnEliminarDatos.Click += new System.EventHandler(this.btnEliminarDatos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label1.Location = new System.Drawing.Point(7, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 40);
            this.label1.TabIndex = 18;
            this.label1.Text = "Ingrese los nombres de los huesped\r\n\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label2.Location = new System.Drawing.Point(7, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 60);
            this.label2.TabIndex = 19;
            this.label2.Text = "Ingrese los apellidos del huesped\r\n\r\n\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label4.Location = new System.Drawing.Point(584, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(263, 40);
            this.label4.TabIndex = 20;
            this.label4.Text = "Seleccionar tipo de busqueda \r\n\r\n";
            // 
            // maskedDui
            // 
            this.maskedDui.Location = new System.Drawing.Point(396, 74);
            this.maskedDui.Mask = "00000000-0";
            this.maskedDui.Name = "maskedDui";
            this.maskedDui.Size = new System.Drawing.Size(179, 22);
            this.maskedDui.TabIndex = 21;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cboBuscarPor
            // 
            this.cboBuscarPor.FormattingEnabled = true;
            this.cboBuscarPor.Items.AddRange(new object[] {
            "Todos ",
            "Dui",
            "Nombre ",
            "Apellido"});
            this.cboBuscarPor.Location = new System.Drawing.Point(926, 12);
            this.cboBuscarPor.Name = "cboBuscarPor";
            this.cboBuscarPor.Size = new System.Drawing.Size(179, 24);
            this.cboBuscarPor.TabIndex = 22;
            this.cboBuscarPor.SelectedIndexChanged += new System.EventHandler(this.cboBuscarPor_SelectedIndexChanged);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(1089, 56);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(226, 22);
            this.txtBuscar.TabIndex = 23;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusqueda.Location = new System.Drawing.Point(630, 56);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(120, 22);
            this.lblBusqueda.TabIndex = 24;
            this.lblBusqueda.Text = "lblBusqueda";
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1331, 731);
            this.Controls.Add(this.lblBusqueda);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.cboBuscarPor);
            this.Controls.Add(this.maskedDui);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminarDatos);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnIrHabitaciones);
            this.Controls.Add(this.btnCerrarfrmDatosCliente);
            this.Controls.Add(this.txtLimpiarCampos);
            this.Controls.Add(this.btnMostrarDatosHuesped);
            this.Controls.Add(this.btnAgregarDatosHuesped);
            this.Controls.Add(this.dgvMostrarTablaCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIngresarApellidosHuesped);
            this.Controls.Add(this.txtNombreHuesped);
            this.Name = "frmCliente";
            this.Text = "Datos del cliente";
            this.Load += new System.EventHandler(this.frmCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrarTablaCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreHuesped;
        private System.Windows.Forms.TextBox txtIngresarApellidosHuesped;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvMostrarTablaCliente;
        private System.Windows.Forms.Button btnAgregarDatosHuesped;
        private System.Windows.Forms.Button btnMostrarDatosHuesped;
        private System.Windows.Forms.Button txtLimpiarCampos;
        private System.Windows.Forms.Button btnCerrarfrmDatosCliente;
        private System.Windows.Forms.Button btnIrHabitaciones;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminarDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskedDui;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cboBuscarPor;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}