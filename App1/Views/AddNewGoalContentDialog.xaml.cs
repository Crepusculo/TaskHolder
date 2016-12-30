using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using App1.Utils;
using static System.Diagnostics.Debug;

// “内容对话框”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上进行了说明

namespace App1
{
    public sealed partial class AddNewPlanContentDialog : ContentDialog
    {
        ResourceLoader loader;

        public AddNewPlanContentDialog()
        {
            InitializeComponent();
            try
            {
                loader =
                    ResourceLoader.GetForViewIndependentUse("Resources");
            }
            catch (TypeInitializationException ex)
            {
                throw new Exception("Unable to locate the .resw file with the name: Strings.resw", ex);
            }
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            var btn = ((Button) sender);
            string[] tags = {"achieve", "task", "goal", "playstore"};
            var tag = btn.Tag.ToString();
            switch (tag)
            {
                case "achieve":
                    ContentDialog.Hide();
                    break;
                case "task":
                    ContentDialog.Hide();
                    break;
                case "goal":
                    ContentDialog.Hide();
                    break;
                case "playstore":
                    ContentDialog.Hide();
                    break;
            }
        }
    }

    public class Customer
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }

        public Customer(string id, string title, string color)
        {
            this.ID = id;
            this.Color = color;
            this.Title = title;
        }
    }

    public class Customers : ObservableCollection<Customer>
    {
        public Customers()
        {
            ResourceLoader loader;
            try
            {
                loader =
                    ResourceLoader.GetForViewIndependentUse("Resources");
            }
            catch (TypeInitializationException ex)
            {
                throw new Exception("Unable to locate the .resw file with the name: Strings.resw", ex);
            }
            string[] tags = {"achieve", "task", "goal", "playstore"};
            Add(new Customer(tags[0], loader.GetString("string_achieve"), loader.GetString("color_achieve")));
            Add(new Customer(tags[1], loader.GetString("string_task"), loader.GetString("color_task")));
            Add(new Customer(tags[2], loader.GetString("string_goal"), loader.GetString("color_goal")));
            Add(new Customer(tags[3], loader.GetString("string_playstore"), loader.GetString("color_playstore")));
        }
    }
}