using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using App1.Models;
using App1.Utils;
using App1.Views;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace App1
{
    public enum SplitViewIndex
        {
            Add=0,Home,Achieve,Task,Goal,Shop
        }
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
       
            ApplyColorToTitleBar();
            
            Frame.Navigate(typeof(PageHome));
        }

        private void HamburgerButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (SplitView.IsPaneOpen)
                CloseNavMenu();
            else
                OpenNavMenu();
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }


        private void SplitView_OnPaneClosed(SplitView sender, object args)
        {
              CloseNavMenu();
        }

        private void IconsListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = IconsListBox.SelectedItem;
            var idx = IconsListBox.SelectedIndex;
            var val = IconsListBox.SelectedValue;
            switch (idx)
            {
                case (int)SplitViewIndex.Add:
                    var dialog = new DialogAddPlan();
                    var result = dialog.ShowAsync();
                    IconsListBox.SelectedIndex = -1;
                    break;
                case (int)SplitViewIndex.Achieve:
                    Frame.Navigate(typeof(PageAchieve));
                    break;
                case (int)SplitViewIndex.Task:
                    Frame.Navigate(typeof(PageTask));
                    break;
                case (int)SplitViewIndex.Goal:
                    Frame.Navigate(typeof(PageGoal));
                    break;
                case (int)SplitViewIndex.Shop:
                    Frame.Navigate(typeof(PageStore));
                    break;
                case (int)SplitViewIndex.Home:
                    Frame.Navigate(typeof(PageHome));
                    break;
            }

        }

        private void OpenNavMenu()
        {
            AvatarEllipse.SetValue(Ellipse.HeightProperty, 100);
            AvatarEllipse.SetValue(Ellipse.WidthProperty, 100);
            Avatar.SetValue(StackPanel.WidthProperty, 230);
            Avatar.SetValue(StackPanel.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            AvatarText.SetValue(TextBlock.VisibilityProperty, Visibility.Visible);
        }

        private void CloseNavMenu()
        {
            AvatarEllipse.SetValue(Ellipse.HeightProperty, 40);
            AvatarEllipse.SetValue(Ellipse.WidthProperty, 40);
            Avatar.SetValue(StackPanel.WidthProperty,50);
            Avatar.SetValue(StackPanel.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            AvatarText.SetValue(TextBlock.VisibilityProperty, Visibility.Collapsed);
        }


        void ApplyColorToTitleBar()
        {
            var view = ApplicationView.GetForCurrentView();
            byte r, g, b;


            // active
            ColorUtil.getGRB("#009688", out r, out g, out b);
            view.TitleBar.BackgroundColor = Color.FromArgb(byte.Parse("1"),r,g,b);
            view.TitleBar.ForegroundColor = Colors.White;

            // inactive
            view.TitleBar.InactiveBackgroundColor = Color.FromArgb(byte.Parse("1"), r, g, b);
            view.TitleBar.InactiveForegroundColor = Colors.Gray;

            // button
            ColorUtil.getGRB("#009688", out r, out g, out b);
            view.TitleBar.ButtonBackgroundColor = Color.FromArgb(byte.Parse("1"), r, g, b);
            view.TitleBar.ButtonForegroundColor = Colors.White;

            ColorUtil.getGRB("#B2DFDB", out r, out g, out b);
            view.TitleBar.ButtonHoverBackgroundColor = Color.FromArgb(byte.Parse("1"), r, g, b);
            view.TitleBar.ButtonHoverForegroundColor = Colors.White;

            ColorUtil.getGRB("#00796B", out r, out g, out b);
            view.TitleBar.ButtonPressedBackgroundColor = Color.FromArgb(byte.Parse("1"), r, g, b);
            view.TitleBar.ButtonPressedForegroundColor = Colors.White;

            ColorUtil.getGRB("#009688", out r, out g, out b);
            view.TitleBar.ButtonInactiveBackgroundColor = Color.FromArgb(byte.Parse("1"), r, g, b);
            view.TitleBar.ButtonInactiveForegroundColor = Colors.Gray;

        }

       

    }
}