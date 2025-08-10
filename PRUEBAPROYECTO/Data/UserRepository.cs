using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using MySqlConnector;
using PRUEBAPROYECTO.Utils;

namespace PRUEBAPROYECTO.Data
{
    public class UserRepository
    {
        private MySqlConnection NewConn()
        {
            var cs = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;
            return new MySqlConnection(cs);
            
        }
        public (int id, string username, string hash, string legacy, string rol, bool activo)? GetByUsername(string username)
        {
            using (var cn = NewConn())
            using (var cmd = new MySqlCommand(
                "SELECT id, username, password_hash, password_sha256, rol, activo FROM usuarios WHERE username=@u LIMIT 1", cn))
            {
            
                cmd.Parameters.AddWithValue("@u", username);
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return null;
                    return (
                        rd.GetInt32("id"),
                        rd.GetString("username"),
                        // FIX: Verificar NULL antes de leer password_hash
                        rd.IsDBNull(rd.GetOrdinal("password_hash")) ? null : rd.GetString("password_hash"),
                        rd.IsDBNull(rd.GetOrdinal("password_sha256")) ? null : rd.GetString("password_sha256"),
                        rd.GetString("rol"),
                        rd.GetInt32("activo") == 1);
                }
            }
        }
        public void SetBcrypt(int id, string bcrypt)
        {
            using (var cn = NewConn())
            using(var cmd = new MySqlCommand(
                "UPDATE usuarios SET password_hash=@h, password_sha256= NULL WHERE id=@id", cn))
            {
                cmd.Parameters.AddWithValue("@h", bcrypt);
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

}
