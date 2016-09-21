using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RealNext.Infrastructure.Utilities
{
    /// <summary>
    /// MD5 utility
    /// </summary>
    public static class MD5Utility
    {
        /// <summary>
        /// Get md5 hash
        /// </summary>
        /// <param name="input"></param>
        public static string GetMD5Hash(string input)
        {
            string hash = null;
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sb = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                hash = sb.ToString();
            }

            return hash;
        }
    }
}
