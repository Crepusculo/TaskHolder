using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.UI.Xaml;
using App1.Models;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;

namespace App1.Utils
{
    partial class NetworkUtil
    {
        public async void PostAddNewTask(string username, string token, TaskDataModel model)
        {
//                        string newTask = JsonUtil<TaskDataModel>.ObjectToJson(model);
//                        DebugUtil.WriteLine(model, newTask);
            
//                        Windows.Storage.StorageFolder folder =
//                            Windows.Storage.ApplicationData.Current.LocalFolder;
//                        await folder.CreateFolderAsync(username);
//                        await folder.CreateFileAsync("sample.txt",
//                            Windows.Storage.CreationCollisionOption.ReplaceExisting);
//            
//                        Windows.Storage.StorageFile file =
//                            await folder.GetFileAsync("sample.txt");
//            
//                        await Windows.Storage.FileIO.WriteTextAsync(file, "Swift as a shadow");
//            
//                        DebugUtil.WriteLine(this, "Write something!");
//            
//                        string text = await Windows.Storage.FileIO.ReadTextAsync(file);
//                        DebugUtil.WriteLine(this, "Read something!",text);
            string path = Path.Combine(Windows.Storage.ApplicationData.
                Current.LocalFolder.Path, username, DataBase.Task);
            var db = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            db.TraceListener = new DebugTraceListener();
            var c = db.CreateTable<TaskDataModel>();
            var info = db.GetMapping(typeof(TaskDataModel));
            db.Insert(model);
            db.Close();
        }

        public async void PostAddNewGoal(string username, string token, GoalDataModel model)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.
                Current.LocalFolder.Path, username, DataBase.Goal);
            var db = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            db.TraceListener = new DebugTraceListener();
            var c = db.CreateTable<GoalDataModel>();
            var info = db.GetMapping(typeof(GoalDataModel));
            db.Insert(model);
            db.Close();
        }

        public async void PostAddNewPlayStore(string username, string token, PlayStoreDataModel model)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.
                Current.LocalFolder.Path, username, DataBase.PlayStore);
            var db = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            db.TraceListener = new DebugTraceListener();
            var c = db.CreateTable<PlayStoreDataModel>();
            var info = db.GetMapping(typeof(PlayStoreDataModel));
            db.Insert(model);
            db.Close();
        }

        public async void PostAddNewAchieve(string username, string token, AchieveDataModel model)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.
                Current.LocalFolder.Path, username, DataBase.Achieve);
            var db = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            db.TraceListener = new DebugTraceListener();
            var c = db.CreateTable<AchieveDataModel>();
            var info = db.GetMapping(typeof(AchieveDataModel));
            db.Insert(model);
            db.Close();
        }

        public List<TaskDataModel> GetTasks(string username, string token)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.
                Current.LocalFolder.Path, username, DataBase.Task);
            var db = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            db.TraceListener = new DebugTraceListener();
            var c = db.CreateTable<TaskDataModel>();
            List<TaskDataModel> tasks = (from p in db.Table<TaskDataModel>()
                select p).ToList();
            db.Close();
            return tasks;
        }

        public List<GoalDataModel> GetGoals(string username, string token)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.
                Current.LocalFolder.Path, username, DataBase.Goal);
            var db = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            db.TraceListener = new DebugTraceListener();
            var c = db.CreateTable<GoalDataModel>();
            List<GoalDataModel> goals = (from p in db.Table<GoalDataModel>()
                select p).ToList();
            db.Close();
            return goals;
        }

        public List<AchieveDataModel> GetAchievements(string username, string token)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.
                Current.LocalFolder.Path, username, DataBase.Achieve);
            var db = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            db.TraceListener = new DebugTraceListener();
            var c = db.CreateTable<AchieveDataModel>();
            List<AchieveDataModel> achievements = (from p in db.Table<AchieveDataModel>()
                select p).ToList();
            db.Close();
            return achievements;
        }

        public List<PlayStoreDataModel> GetPlayStore(string username, string token)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.
                Current.LocalFolder.Path, username, DataBase.PlayStore);
            var db = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            db.TraceListener = new DebugTraceListener();
            var c = db.CreateTable<PlayStoreDataModel>();
            List<PlayStoreDataModel> playStore = (from p in db.Table<PlayStoreDataModel>()
                select p).ToList();
            db.Close();
            return playStore;
        }

        public static void UpdateGoalDataModel(string username, string token,GoalDataModel model)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.
                Current.LocalFolder.Path, username, DataBase.Goal);
            var db = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            db.TraceListener = new DebugTraceListener();
            var c = db.CreateTable<GoalDataModel>();
            var info = db.GetMapping(typeof(GoalDataModel));
            db.InsertOrReplace(model);
            db.Close();
        }

        public static void UpdateGoalDataModel(string username, string token, GoalDataModel model,UIElement page)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.
                Current.LocalFolder.Path, username, DataBase.Goal);
            var db = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            db.TraceListener = new DebugTraceListener();
            var c = db.CreateTable<GoalDataModel>();
            var info = db.GetMapping(typeof(GoalDataModel));
            db.InsertOrReplace(model);
            db.Close();
        }

        public static void UpdateTaskDataModel(string username, string token, TaskDataModel model)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.
                Current.LocalFolder.Path, username, DataBase.Task);
            var db = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            db.TraceListener = new DebugTraceListener();
            var c = db.CreateTable<TaskDataModel>();
            var info = db.GetMapping(typeof(TaskDataModel));
            db.InsertOrReplace(model);
            db.Close();
            
        }

        public class DebugTraceListener : ITraceListener
        {
            public void Receive(string message)
            {
                Debug.WriteLine(message);
            }
        }

        
    }
}