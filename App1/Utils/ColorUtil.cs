using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace App1.Utils
{
    static class ColorUtil
    {
        public static void getGRB(String hexColor, out byte r, out byte g, out byte b)
        {
            r = byte.Parse(hexColor.Substring(1, 2), NumberStyles.HexNumber);
            g = byte.Parse(hexColor.Substring(3, 2), NumberStyles.HexNumber);
            b = byte.Parse(hexColor.Substring(5, 2), NumberStyles.HexNumber);
        }

        public static Color getColor(string hexColor)
        {
            byte a, r, g, b;
            a = byte.Parse("1");
            getGRB(hexColor, out r, out g, out b);
            var ret = new Color
            {
                A = a,
                B = b,
                G = g,
                R = r
            };
            return ret;
        }
    }
}