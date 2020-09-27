using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRAPHICS_CREATOR
{
    class GCBase64
    {
        public static string charlist = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ<>";
        public static Dictionary<char, int> charmap = new Dictionary<char, int>();
        static GCBase64()
        {
            for (int i = 0; i < charlist.Length; i++)
            {
                charmap.Add(charlist[i], i);
            }
        }
        public static string GetString(int value,int bit)
        {
            StringBuilder builder = new StringBuilder();
            char[] list = new char[bit];
            for (int i = bit-1; i >= 0; i--)
            {
                list[i] = charlist[value % 64];
                value = (value - value % 64) >> 6;
            }
            for (int i = 0; i < list.Length; i++)
            {
                builder.Append(list[i]);
            }
            return builder.ToString();
        }

        public static int GetNumber(string value)
        {
            int number = 0;
            for (int i = 0; i < value.Length; i++)
            {
                number = (number << 6) + charmap[value[i]];
            }
            return number;

        }
    }
}
