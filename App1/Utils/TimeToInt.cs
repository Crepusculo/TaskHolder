using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Utils
{
    class TimeToInt
    {
        public string[] strs =
        {
            "Daily", "Two days", "Three days", "Five days", "Weekly", "Ten days", "Twice a month", "Monthly",
            "Two Month", "Three Month", "Half Year",
            "Annual"
        };

        public int[] nlist = {1, 2, 3, 5, 7, 10, 14, 30, 60, 90, 180, 360};
        private static Dictionary<string, int> intervalsDictionary;

        public TimeToInt()
        {
            intervalsDictionary = new Dictionary<string, int>();
            for (int index = 0; index < strs.Length; index++)
            {
                intervalsDictionary.Add(strs[index], nlist[index]);
            }
        }

        public int TranslateTime(string s)
        {
            int ret = -1;
            intervalsDictionary.TryGetValue(s, out ret);
            return ret;
        }
    }
}