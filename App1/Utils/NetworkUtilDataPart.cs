using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<TaskDataModel> GetTasks(string username, string token)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.
                Current.LocalFolder.Path, username, DataBase.Task);
            var db = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            db.TraceListener = new DebugTraceListener();
            var c = db.CreateTable<TaskDataModel>();
            ObservableCollection<TaskDataModel> tasks =
                new ObservableCollection<TaskDataModel>((from p in db.Table<TaskDataModel>()
                    select p).ToList());
            db.Close();
            return tasks;
        }

        public ObservableCollection<GoalDataModel> GetGoals(string username, string token)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.
                Current.LocalFolder.Path, username, DataBase.Goal);
            var db = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            db.TraceListener = new DebugTraceListener();
            var c = db.CreateTable<GoalDataModel>();
            ObservableCollection<GoalDataModel> goals =
                new ObservableCollection<GoalDataModel>((from p in db.Table<GoalDataModel>()
                    select p).ToList());
            db.Close();
            return goals;
        }

        public ObservableCollection<AchieveDataModel> GetAchievements(string username, string token)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.
                Current.LocalFolder.Path, username, DataBase.Achieve);
            var db = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            db.TraceListener = new DebugTraceListener();
            var c = db.CreateTable<AchieveDataModel>();
            ObservableCollection<AchieveDataModel> achievements =
                new ObservableCollection<AchieveDataModel>((from p in db.Table<AchieveDataModel>()
                    select p).ToList());
            db.Close();
            return achievements;
        }

        public ObservableCollection<PlayStoreDataModel> GetPlayStore(string username, string token)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.
                Current.LocalFolder.Path, username, DataBase.PlayStore);
            var db = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            db.TraceListener = new DebugTraceListener();
            var c = db.CreateTable<PlayStoreDataModel>();
            ObservableCollection<PlayStoreDataModel> playStore =
                new ObservableCollection<PlayStoreDataModel>((from p in db.Table<PlayStoreDataModel>()
                    select p).ToList());
            db.Close();
            return playStore;
        }

        public static void UpdateGoalDataModel(string username, string token, GoalDataModel model)
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

        public static void UpdateGoalDataModel(string username, string token, GoalDataModel model, UIElement page)
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

        public static void DeleteGoalDataModel(string username, string token, GoalDataModel model)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.
                Current.LocalFolder.Path, username, DataBase.Goal);
            var db = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            db.TraceListener = new DebugTraceListener();
            var c = db.CreateTable<GoalDataModel>();
            var info = db.GetMapping(typeof(GoalDataModel));

            db.Delete<GoalDataModel>(model.Id);
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