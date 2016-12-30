using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace App1.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class DialogAddPlan : ContentDialog
    {
        private List<ButtonInfo> manager;

        public DialogAddPlan()
        {
            manager = ButtonInfoManager.getList();
            this.InitializeComponent();
        }

        private void Btn_OnClick(object sender, RoutedEventArgs e)
        {
            Hide();
            Debug.WriteLine(((Button) sender).Tag);
            var tag = int.Parse(((Button) sender).Tag.ToString());
            switch (tag)
            {
                case 1:

                    break;
                case 2:
                    var dialogTask = new DialogTask();
                    dialogTask.MinWidth = this.ActualWidth;
                    dialogTask.MaxWidth = this.ActualWidth;
                    var resultTask = dialogTask.ShowAsync();
                    break;
                case 3:
                    var dialogGoal = new DialogGoal();
                    dialogGoal.MinWidth = this.ActualWidth;
                    dialogGoal.MaxWidth = this.ActualWidth;
                    var resultGoal = dialogGoal.ShowAsync();
                    break;
                case 4:
                    break;
                case 9:
                    break;
            }
        }
    }


    public class ButtonInfo
    {
        public int id { get; set; }
        public string Content { get; set; }
        public string Color { get; set; }

        public ButtonInfo(int id, string content, string color)
        {
            this.id = id;
            Content = content;
            Color = color;
        }
    }

    public class ButtonInfoManager : List<ButtonInfo>
    {
        public static List<ButtonInfo> getList()
        {
            var btns = new List<ButtonInfo>();
            ResourceLoader loader;
            try
            {
                loader = ResourceLoader.GetForViewIndependentUse("Resources");
            }
            catch (TypeInitializationException ex)
            {
                throw new Exception("Unable to locate the .resw file with the name: Strings.resw", ex);
            }
            btns.Add(new ButtonInfo(1, loader.GetString("string_achieve"), loader.GetString("color_achieve")));
            btns.Add(new ButtonInfo(2, loader.GetString("string_task"), loader.GetString("color_task")));
            btns.Add(new ButtonInfo(3, loader.GetString("string_goal"), loader.GetString("color_goal")));
            btns.Add(new ButtonInfo(4, loader.GetString("string_playstore"), loader.GetString("color_playstore")));
            return btns;
        }
    }
}