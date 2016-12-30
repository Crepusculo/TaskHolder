using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using App1.Utils;
using FileAttributes = System.IO.FileAttributes;

namespace App1.Models
{
    class UserInfo
    {
        static string path = @"C:\Users\airfr\Desktop\userinfo.json";
        public string Nickname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public string CurrentFileBuffer { get; private set; }

        public async void SaveInfo(UserInfo info)
        {
            string contents = JsonUtil<UserInfo>.ObjectToJson(info);


        }

        public async void LoadInfo()
        {
            File.SetAttributes(path, FileAttributes.Normal);
            JsonUtil<UserInfo>.JsonToObject(System.IO.File.ReadAllText(path, Encoding.UTF8));

            var folder = Package.Current.InstalledLocation;
            var file = await folder.GetFileAsync(path);
            var read = await FileIO.ReadTextAsync(file);
            
        }
    }
}