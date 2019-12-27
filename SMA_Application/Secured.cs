using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMA_Application
{
    class Secured
    {
        public static string Encrytion(string input)
        {
            byte[] inputbytes1 = Encoding.ASCII.GetBytes(input);
            string encryptedpassword1 = Convert.ToBase64String(inputbytes1);
            byte[] inputbyes2 = Encoding.ASCII.GetBytes(encryptedpassword1);
            string encrpt2 = Convert.ToBase64String(inputbyes2);
            byte[] inputbyte3 = Encoding.ASCII.GetBytes(encrpt2);
            string encrypt3 = Convert.ToBase64String(inputbyte3);
            return encrypt3;
        }
        public static string Decryption(string input1)
        {
            byte[] b1 = Convert.FromBase64String(input1);
            string d1 = Encoding.ASCII.GetString(b1);
            byte[] b2 = Convert.FromBase64String(d1);
            string d2 = Encoding.ASCII.GetString(b2);
            byte[] b3 = Convert.FromBase64String(d2);
            string d3 = Encoding.ASCII.GetString(b3);
            return d3;
        }
    }
}
