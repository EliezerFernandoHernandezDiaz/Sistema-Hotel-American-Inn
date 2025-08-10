using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;



namespace PRUEBAPROYECTO.Utils
{
    public static class PasswordHelper
    {
        //Generar un hash sha256 de una contraseña
        public static string HashPassword(string password) =>
              BCrypt.Net.BCrypt.HashPassword(password);

        //Verificar si la contraseña coincide con el hash almacenado 
        public static bool VerifyPassword(string enteredPassword, string storedHash) =>
            BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
    }
}
