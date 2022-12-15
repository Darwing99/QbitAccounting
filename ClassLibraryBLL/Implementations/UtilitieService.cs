using ClassLibraryBLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryBLL.Implementations
{
    public class UtilitieService : IUtilitieService
    {
        public string ConvertirSha256(string Text)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 Hash = SHA256.Create())
            {
                Encoding encoding = Encoding.UTF8;
                byte[] result = Hash.ComputeHash(encoding.GetBytes(Text));
                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }

        public string GenerarClave()
        {

            string clave = Guid.NewGuid().ToString("N").Substring(0, 6);
            return clave;

        }
    }
}
