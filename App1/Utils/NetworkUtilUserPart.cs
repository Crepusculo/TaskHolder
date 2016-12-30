using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Newtonsoft.Json;

namespace App1.Utils
{
    partial class NetworkUtil
    {
        public static List<StrWrap> GetUserGroup(string token, string username)
        {
            //TODO:: 
            var s = new List<StrWrap>();
            s.Add(new StrWrap("Classmates"));
            s.Add(new StrWrap("Family"));
            s.Add(new StrWrap("Roommates"));
            s.Add(new StrWrap("Friends"));
            s.Add(new StrWrap("Colleague"));
            return s;
        }

        public static List<StrWrap> GetUserType(string token, string username)
        {   
            //TODO:: 
            var s = new List<StrWrap>();
            s.Add(new StrWrap("General"));
            s.Add(new StrWrap("Read"));
            s.Add(new StrWrap("Program"));
            s.Add(new StrWrap("Write"));
            s.Add(new StrWrap("Progress"));
            s.Add(new StrWrap("Sub Tasks"));
            return s;
        }

        public void GetUserInfo(string user)
        {
        }

    }
}