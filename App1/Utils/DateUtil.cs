using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Utils
{
    class DateUtil
    {
        public static string DateToString(DateTimeOffset date)
        {
            var ret = date.Year + "/" + date.Month + "/" + date.Day;
            return ret;
        }

    }
}
