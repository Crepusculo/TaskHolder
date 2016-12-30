using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using App1.Animation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace App1.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public class Item
    {
        public string Name { get; set; }
    }

    public sealed partial class PageHome : Page
    {
        private int _absNum;
        private int _changedNum = -1;

        public PageHome()
        {
            _absNum = 0;
            this.Transitions = PageTransitions.SetUpPageAnimation(4);

            this.InitializeComponent();
            InitialFilpView(out _absNum);
        }

        private void InitialFilpView(out int absNum)
        {
            absNum = AbsFlipView.Items.Count;
            AbsFlipView.Items.Add(AbsFlipView.Items.IndexOf(0));
        }

        void UpdateAbsFlipView()
        {
        }

        private async void AbsFlipView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("AbsFlipView.SelectedIndex\t" + AbsFlipView.SelectedIndex);
            Debug.WriteLine("AbsFlipView.IsTabStop\t" + AbsFlipView.IsTabStop);
            if (AbsFlipView.SelectedIndex == _absNum)
            {
                await Task.Run(() => dalayReset());
                AbsFlipView.SelectedIndex = 0;
            }
        }

        private void dalayReset()
        {
            Task.Delay(450).Wait();
            _changedNum = 0;
        }
    }
}