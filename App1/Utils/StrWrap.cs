using System;
using System.Collections.Generic;

namespace App1.Utils
{
    public class StrWrap
    {
        public String str { get; set; }

        public StrWrap(string str)
        {
            this.str = str;
        }

        public static List<StrWrap> GetStrList()
        {
            var ret = new List<StrWrap>();
            var t = new TimeToInt();
            foreach (var str in t.strs)
            {
                ret.Add(new StrWrap(str));
            }
            return ret;
        }
    }
}