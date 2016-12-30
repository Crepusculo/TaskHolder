using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace App1.Utils
{
    class JsonUtil<T>
    {
        public static string ObjectToJson(object obj)
        {
            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return json;
        }

        public static T JsonToObject(string json)
        {
            var obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }
    }
}
