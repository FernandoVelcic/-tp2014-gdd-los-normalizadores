using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace FrbaHotel.Tools
{
    class SHA256
    {
        private String value;

        public SHA256(String value)
        {
            this.value = value;
        }

        public override String ToString()
        {
            StringBuilder Sb = new StringBuilder();

            using (System.Security.Cryptography.SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
