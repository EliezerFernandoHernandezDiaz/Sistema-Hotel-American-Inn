using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace PRUEBAPROYECTO.Utils
{
    public static class LegacyPassword
    {
        public static string Sha256(string plain)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(plain));
                var sb = new StringBuilder();
                foreach (var b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
  public static bool VerifySha256(string plain, string storedHash256) =>
            !string.IsNullOrEmpty(storedHash256) && Sha256(plain) == storedHash256;
    }
   
    }
