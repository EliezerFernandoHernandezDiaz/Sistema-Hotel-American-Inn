
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
            this.txtNombreHuesped = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIngresarApellidosHuesped = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDuiHuesped = new System.Windows.Forms.TextBox();
            this.dgvMostrarTablaCliente = new System.Windows.Forms.DataGridView();
            this.btnAgregarDatosHuesped = new System.Windows.Forms.Button();
            this.btnMostrarDatosHuesped = new System.Windows.Forms.Button();
            this.txtLimpiarCampos = new System.Windows.Forms.Button();
            this.btnCerrarfrmDatosCliente = new System.Windows.Forms.Button();
            this.btnProbarConex = new System.Windows.Forms.Button();
            this.btnIrHabitaciones = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminarDatos = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrarTablaCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombreHuesped
            // 
            this.txtNombreHuesped.Location = new System.Drawing.Point(253, 162);
            this.txtNombreHuesped.Name = "txtNombreHuesped";
            this.txtNombreHuesped.Size = new System.Drawing.Size(171, 22);
            this.txtNombreHuesped.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingrese el nombre del huesped";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingrese los apellidos del huesped";
            // 
            // txtIngresarApellidosHuesped
            // 
            this.txtIngresarApellidosHuesped.Location = new System.Drawing.Point(253, 262);
            this.txtIngresarApellidosHuesped.Name = "txtIngresarApellidosHuesped";
            this.txtIngresarApellidosHuesped.Size = new System.Drawing.Size(171, 22);
            this.txtIngresarApellidosHuesped.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ingrese el dui del huesped";
            // 
            // txtDuiHuesped
            // 
            this.txtDuiHuesped.Location = new System.Drawing.Point(253, 74);
            this.txtDuiHuesped.Name = "txtDuiHuesped";
            this.txtDuiHuesped.Size = new System.Drawing.Size(171, 22);
            this.txtDuiHuesped.TabIndex = 5;
            // 
            // dgvMostrarTablaCliente
            // 
            this.dgvMostrarTablaCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostrarTablaCliente.Location = new System.Drawing.Point(579, 131);
            this.dgvMostrarTablaCliente.Name = "dgvMostrarTablaCliente";
            this.dgvMostrarTablaCliente.RowHeadersWidth = 51;
            this.dgvMostrarTablaCliente.RowTemplate.Height = 24;
            this.dgvMostrarTablaCliente.Size = new System.Drawing.Size(472, 354);
            this.dgvMostrarTablaCliente.TabIndex = 6;
            // 
            // btnAgregarDatosHuesped
            // 
            this.btnAgregarDatosHuesped.Location = new System.Drawing.Point(158, 564);
            this.btnAgregarDatosHuesped.Name = "btnAgregarDatosHuesped";
            this.btnAgregarDatosHuesped.Size = new System.Drawing.Size(127, 77);
            this.btnAgregarDatosHuesped.TabIndex = 7;
            this.btnAgregarDatosHuesped.Text = "Agregar datos del huesped";
            this.btnAgregarDatosHuesped.UseVisualStyleBackColor = true;
            this.btnAgregarDatosHuesped.Click += new System.EventHandler(this.btnAgregarDatosHuesped_Click);
            // 
            // btnMostrarDatosHuesped
            // 
            this.btnMostrarDatosHuesped.Location = new System.Drawing.Point(187, 349);
            this.btnMostrarDatosHuesped.Name = "btnMostrarDatosHuesped";
            this.btnMostrarDatosHuesped.Size = new System.Drawing.Size(122, 51);
            this.btnMostrarDatosHuesped.TabIndex = 8;
            this.btnMostrarDatosHuesped.Text = "Mostrar datos del huesped";
            this.btnMostrarDatosHuesped.UseVisualStyleBackColor = true;
            this.btnMostrarDatosHuesped.Click += new System.EventHandler(this.btnMostrarDatosHuesped_Click);
            // 
            // txtLimpiarCampos
            // 
            this.txtLimpiarCampos.Location = new System.Drawing.Point(337, 349);
            this.txtLimpiarCampos.Name = "txtLimpiarCampos";
            this.txtLimpiarCampos.Size = new System.Drawing.Size(120, 51);
            this.txtLimpiarCampos.TabIndex = 9;
            this.txtLimpiarCampos.Text = "Limpiar todo";
            this.txtLimpiarCampos.UseVisualStyleBackColor = true;
            this.txtLimpiarCampos.Click += new System.EventHandler(this.txtLimpiarCampos_Click);
            // 
            // btnCerrarfrmDatosCliente
            // 
            this.btnCerrarfrmDatosCliente.Location = new System.Drawing.Point(18, 424);
            this.btnCerrarfrmDatosCliente.Name = "btnCerrarfrmDatosCliente";
            this.btnCerrarfrmDatosCliente.Size = new System.Drawing.Size(117, 61);
            this.btnCerrarfrmDatosCliente.TabIndex = 10;
            this.btnCerrarfrmDatosCliente.Text = "Cerrar";
            this.btnCerrarfrmDatosCliente.UseVisualStyleBackColor = true;
            this.btnCerrarfrmDatosCliente.Click += new System.EventHandler(this.btnCerrarfrmDatosCliente_Click);
            // 
            // btnProbarConex
            // 
            this.btnProbarConex.Location = new System.Drawing.Point(18, 349);
            this.btnProbarConex.Name = "btnProbarConex";
            this.btnProbarConex.Size = new System.Drawing.Size(127, 51);
            this.btnProbarConex.TabIndex = 11;
            this.btnProbarConex.Text = "Probar la conexion ";
            this.btnProbarConex.UseVisualStyleBackColor = true;
            this.btnProbarConex.Click += new System.EventHandler(this.btnProbarConex_Click);
            // 
            // btnIrHabitaciones
            // 
            this.btnIrHabitaciones.Location = new System.Drawing.Point(716, 570);
            this.btnIrHabitaciones.Name = "btnIrHabitaciones";
            this.btnIrHabitaciones.Size = new System.Drawing.Size(138, 71);
            this.btnIrHabitaciones.TabIndex = 12;
            this.btnIrHabitaciones.Text = "Ir al formulario habitaciones";
            this.btnIrHabitaciones.UseVisualStyleBackColor = true;
            this.btnIrHabitaciones.Click += new System.EventHandler(this.btnIrHabitaciones_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(786, 42);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(120, 28);
            this.btnBuscar.TabIndex = 13;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(337, 564);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(120, 77);
            this.btnModificar.TabIndex = 14;
            this.btnModificar.Text = "Modificar datos";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminarDatos
            // 
            this.btnEliminarDatos.Location = new System.Drawing.Point(530, 570);
            this.btnEliminarDatos.Name = "btnEliminarDatos";
            this.btnEliminarDatos.Size = new System.Drawing.Size(127, 71);
            this.btnEliminarDatos.TabIndex = 15;
            this.btnEliminarDatos.Text = "Eliminar datos";
            this.btnEliminarDatos.UseVisualStyleBackColor = true;
            this.btnEliminarDatos.Click += new System.EventHandler(this.btnEliminarDatos_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(557, 42);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(161, 22);
            this.txtBuscar.TabIndex = 16;
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 700);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnEliminarDatos);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnIrHabitaciones);
            this.Controls.Add(this.btnProbarConex);
            this.Controls.Add(this.btnCerrarfrmDatosCliente);
            this.Controls.Add(this.txtLimpiarCampos);
            this.Controls.Add(this.btnMostrarDatosHuesped);
            this.Controls.Add(this.btnAgregarDatosHuesped);
            this.Controls.Add(this.dgvMostrarTablaCliente);
            this.Controls.Add(this.txtDuiHuesped);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIngresarApellidosHuesped);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombreHuesped);
            this.Name = "frmCliente";
            this.Text = "Datos del cliente";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrarTablaCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreHuesped;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIngresarApellidosHuesped;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDuiHuesped;
        private System.Windows.Forms.DataGridView dgvMostrarTablaCliente;
        private System.Windows.Forms.Button btnAgregarDatosHuesped;
        private System.Windows.Forms.Button btnMostrarDatosHuesped;
        private System.Windows.Forms.Button txtLimpiarCampos;
        private System.Windows.Forms.Button btnCerrarfrmDatosCliente;
        private System.Windows.Forms.Button btnProbarConex;
        private System.Windows.Forms.Button btnIrHabitaciones;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminarDatos;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}