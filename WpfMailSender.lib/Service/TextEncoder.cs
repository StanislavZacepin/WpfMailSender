using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.lib.Service
{
    // для тестовой кодировки 
   public static class TextEncoder
    {
        public static string Encode(string str, int key = 1)
            => new string(str.Select(c => (char)(c + key)).ToArray());

        public static string Decode(string str, int key = 1) => Encode(str, -key);
    }
}
