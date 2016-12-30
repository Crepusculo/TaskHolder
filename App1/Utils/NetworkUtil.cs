using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Utils
{
    partial class NetworkUtil
    {
        internal class DataBase
        {
            public static string Task = "TaskData.sqlite";
            public static string Goal = "GoalData.sqlite";
            public static string PlayStore = "PlayStore.sqlite";
            public static string Achieve = "Achieve.sqlite";
        }

        protected static NetworkUtil networkUtil;

        public static NetworkUtil GetInstance()
        {
            if (networkUtil == null)
            {
                networkUtil = new NetworkUtil();
                return networkUtil;
            }
            else
            {
                return networkUtil;
            }
        }
    }
}