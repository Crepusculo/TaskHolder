using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using App1.Animation;
using App1.Models;
using App1.Utils;

namespace App1.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class PageGoal : Page
    {
        List<StrWrap> groups;
        List<StrWrap> types;
        private UserInfo user;
        public List<GoalDataModel> goalsData;
        private bool b = true;

        public PageGoal()
        {
            this.Transitions = PageTransitions.SetUpPageAnimation(4);
            this.InitializeData();
            this.InitializeComponent();
        }

        private async void InitializeData()
        {
            goalsData = NetworkUtil.GetInstance().GetGoals("13391859311", "2333");
            user = new UserInfo() {Password = "123456", Username = "13391859311", Token = "20000"};
            types = NetworkUtil.GetUserType(user.Token, user.Username);
            groups = NetworkUtil.GetUserGroup(user.Token, user.Username);
        }

        ///
        /// root
        ///  |- father
        ///  |    |- *checkbox
        ///  |    |- morebutton
        ///  |    |- progressbutton
        ///  |   
        ///  |- Grid
        ///  |    |- ProgressBar
        ///  |    |- Grid
        ///  |        |-Button
        ///  |- TextBox
        ///  |- GridView
        ///  ...
        private void MoreButton_OnChecked(object sender, RoutedEventArgs e)
        {
            var father = (RelativePanel) VisualTreeHelper.GetParent((DependencyObject) sender);
            Grid root = (Grid) VisualTreeHelper.GetParent((DependencyObject) father);
            if (((ToggleButton) sender).IsChecked == true)
            {
                DebugUtil.WriteLine(sender, "True!");
                root.Children[root.Children.Count - 1].Visibility = Visibility.Visible;
            }
            else
            {
                DebugUtil.WriteLine(sender, "False!");
                root.Children[root.Children.Count - 1].Visibility = Visibility.Collapsed;
            }
        }

        ///
        /// root
        ///  |- father
        ///  |    |- checkbox
        ///  |    |- *morebutton
        ///  |    |- progressbutton
        ///  |   
        ///  |- Grid
        ///  |    |- ProgressBar
        ///  |    |- Grid
        ///  |        |-Button
        ///  |- TextBox
        ///  |- GridView
        ///  ...
        private void ProgressButton_OnClick(object sender, RoutedEventArgs e)
        {
            var father = (RelativePanel) VisualTreeHelper.GetParent((DependencyObject) sender);
            Grid root = (Grid) VisualTreeHelper.GetParent((DependencyObject) father);

            var model = (GoalDataModel) root.DataContext;
            var button = (Button) ((Grid) ((Grid) root.Children[1]).Children[1]).Children[0];
            var progrssbar = (ProgressBar) ((Grid) root.Children[1]).Children[0];
            if (((ToggleButton) sender).IsChecked == true)
            {
                button.Content = " ( " + model.WorkProgress + " / " + model.WorkAmount + " ) "
                                 + 100*((double) model.WorkProgress/(double) model.WorkAmount) + "%";
                button.Visibility = Visibility.Visible;
            }
            else
            {
                button.Visibility = Visibility.Collapsed;
            }
        }

        private void GoalsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DebugUtil.WriteLine(sender, "SelectionChanged!");
        }

        private void Progress_OnClick(object sender, RoutedEventArgs e)
        {
            DebugUtil.WriteLine(sender, "Click!");
            var root = (Grid) VisualTreeHelper.GetParent((DependencyObject) sender);
            var model = (GoalDataModel) root.DataContext;
            var groupPicker = new SimpleDialogProgressPicker(ref user, ref model, root);
            var result = groupPicker.ShowAsync();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var root = (Grid) VisualTreeHelper.GetParent((DependencyObject) sender);
            var model = (GoalDataModel) root.DataContext;

            DebugUtil.WriteLine(sender, "SelectionChanged!");
            var lists = ((GridView) sender);
            IAsyncOperation<ContentDialogResult> result;
            switch (lists.SelectedIndex)
            {
                case 0:
                    var typePicker = new SimpleDialogTypePicker(ref user, ref model, root);
                    result = typePicker.ShowAsync();
                    break;
                case 1:
                    var groupPicker = new SimpleDialogGroupPicker(ref user, ref model, root);
                    result = groupPicker.ShowAsync();
                    break;
                case 2:
                    var datePicker = new SimpleDialogDatePicker(ref user, ref model, root);
                    result = datePicker.ShowAsync();
                    break;
                case 3:
                    break;
            }
            ((GridView) sender).SelectedIndex = -1;
        }

        private void GroupComboBoxButton_OnClick(object sender, RoutedEventArgs e)
        {
            DebugUtil.WriteLine(sender, "Click!");
        }
    }
}