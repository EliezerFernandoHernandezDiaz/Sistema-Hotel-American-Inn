using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector; //Importando la libreria de mysql para conectar a la bd
using System.Configuration; 
using BCrypt.Net;
using Org.BouncyCastle.Crypto;
using Clave5_Grupo6;
using System.Diagnostics.Eventing.Reader; // Con esta libreria se encripta la contraseña

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
        }

        private void btnEntrarLog_Click(object sender, EventArgs e)
        {
            try
            {
                using (var cn = NuevaConexion())
                using (var cmd = new MySqlCommand(
                    "SELECT id, username, password_hash, rol, activo FROM usuarios WHERE username=@u LIMIT 1", cn))
                {
                    cmd.Parameters.AddWithValue("@u", txtUsuario.Text.Trim());
                    cn.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            if (rd.GetInt32("activo") == 0)
                            {
                                MessageBox.Show("El usuario no está activo.");
                                return;
                            }
                            var hash = rd.GetString("password_hash");
                            if (BCrypt.Net.BCrypt.Verify(txtPassword.Text, hash))
                            {
                                Sesion.UsuarioActual = new UsuarioSesion
                                {
                                    Id = rd.GetInt32("id"),
                                    Username = rd.GetString("username"),
                                    Rol = rd.GetString("rol")
                                };
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Contraseña incorrecta");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuario no existe");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login: " + ex.Message);
            }
        }
    }
}