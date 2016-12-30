using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Utils
{
    class DebugUtil
    {
        public static void WriteLine(object obj, params string[] strs)
        {
            string ret = obj.GetType().Namespace + " " + obj.GetType().Name;
            foreach (var str in strs)
            {
                ret += "\t";
                ret += str;
            }
            Debug.WriteLine(ret);
        }
    }
}