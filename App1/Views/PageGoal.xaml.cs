using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
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

        public ObservableCollection<GoalDataModel> goalsDataOrder
        {
            get { return (ObservableCollection<GoalDataModel>) GetValue(NewsCollectionProperty); }
            set { SetValue(NewsCollectionProperty, value); }
        }

        private bool b = true;

        public static readonly DependencyProperty NewsCollectionProperty =
            DependencyProperty.Register("NewsCollection", typeof(ObservableCollection<GoalDataModel>),
                typeof(GoalDataModel), new PropertyMetadata(null));

        public PageGoal()
        {
            this.Transitions = PageTransitions.SetUpPageAnimation(4);
            this.InitializeData();
            this.InitializeComponent();
        }

        private async void InitializeData()
        {
            user = new UserInfo() {Password = "123456", Username = "13391859311", Token = "20000"};
            goalsDataOrder =
                new ObservableCollection<GoalDataModel>(NetworkUtil.GetInstance().GetGoals(user.Username, user.Token));
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
                case 10:
                    goalsDataOrder.Remove(model);
                    NetworkUtil.DeleteGoalDataModel(user.Username, user.Token, model);
                    break;
            }
            ((GridView) sender).SelectedIndex = -1;
        }


        ///
        /// root
        ///  |- father
        ///  |    |- checkbox
        ///  |    |- morebutton
        ///  |    |- progressbutton
        ///  |   
        ///  |- Grid
        ///  |    |- *ProgressBar
        ///  |    |- Grid
        ///  |        |-Button
        ///  |- TextBox
        ///  |- GridView
        ///  ...
        private void ProgressBar_OnValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            var progressBar = sender as ProgressBar;
            var grid = VisualTreeHelper.GetParent((DependencyObject) sender);
            var root = VisualTreeHelper.GetParent(grid);
            var father = VisualTreeHelper.GetChild(root, 0);
            CheckBox checkBox = (CheckBox) VisualTreeHelper.GetChild(father, 0);
            checkBox.IsChecked = progressBar.Value >= progressBar.Maximum;
        }

        private void CheckBox_OnClick(object sender, RoutedEventArgs e)
        {
            var root = (RelativePanel) VisualTreeHelper.GetParent((DependencyObject) sender);
            var model = (GoalDataModel) root.DataContext;
            model.Done = (bool) ((CheckBox) sender).IsChecked;
            NetworkUtil.UpdateGoalDataModel(user.Username, user.Token, model);
        }

        private void SortMethod_Changed(object sender, RoutedEventArgs e)
        {
        }

        private void GoalsList_OnDataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            Debug.WriteLine("ITEMS CHANGED");
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var mg = new DialogGoal(goalsDataOrder);
            mg.MinWidth = this.ActualWidth;
            mg.MaxWidth = this.ActualWidth;
            await mg.ShowAsync();
        }

        private void Refresh_OnClick(object sender, RoutedEventArgs e)
        {
            goalsDataOrder = NetworkUtil.GetInstance().GetGoals(user.Username, user.Token);
        }

        private async void Camera_OnClick(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                var stream = (FileRandomAccessStream)await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                var image = new BitmapImage();
                image.SetSource(stream);
                ScrollViewer.Background = new ImageBrush()
                {
                    ImageSource = image,
                    Stretch = Stretch.UniformToFill
                };
            }
        }
    }
}