using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Data;
using System.Diagnostics.Eventing.Reader; // Con esta libreria se encripta la contraseña
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using Clave5_Grupo6;
using MySqlConnector; //Importando la libreria de mysql para conectar a la bd
using Org.BouncyCastle.Crypto;
using PRUEBAPROYECTO.Data;
using PRUEBAPROYECTO.Utils;

namespace PRUEBAPROYECTO
{

    public partial class frmLogin : Form
    {
        private MySqlConnection NuevaConexion()
        {
            var cs = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;
            return new MySqlConnection(cs);
        }
        public frmLogin()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true; //para ocultar la contraseña mientras se escribe 
        }

        private void btnEntrarLog_Click(object sender, EventArgs e)

        {
            try
            {
                var repo = new UserRepository();
                var rec = repo.GetByUsername(txtUsuario.Text.Trim());

                if (rec == null) { MessageBox.Show("Usuario no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                var (id, username, bcrypt, legacy, rol, activo) = rec.Value;
                if (!activo) { MessageBox.Show("El usuario no está activo."); return; }

                var pass = txtPassword.Text;

                // 1) Intenta BCrypt
                if (!string.IsNullOrEmpty(bcrypt) && PasswordHelper.VerifyPassword(pass, bcrypt))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                // 2) Intenta SHA-256 (migración) y si coincide, re-hashea a BCrypt
                if (LegacyPassword.VerifySha256(pass, legacy))
                {
                    var newHash = PasswordHelper.HashPassword(pass);
                    repo.SetBcrypt(id, newHash);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
                //Agregando un messsage box interactivo para mostrar el error
                MessageBox.Show("Contraseña Incorrecta", "Errror de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login: " + ex.Message);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

 
    }
}