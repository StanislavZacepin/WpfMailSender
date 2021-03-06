using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.lib.Services
{
    // для тестовой кодировки 
   public static class TextEncoder
    {
        public static string Encode(string str, int key = 1)
        {
            return new string(str.Select(c => (char)(c + key)).ToArray());
        }

        public static string Decode(string str, int key = 1)
        {
            return Encode(str, -key);
        }
    }
}
