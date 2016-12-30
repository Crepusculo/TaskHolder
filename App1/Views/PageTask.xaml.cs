using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using App1.Animation;
using App1.Utils;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace App1.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class PageTask : Page
    {
        public PageTask()
        {
            this.Transitions = PageTransitions.SetUpPageAnimation(4);
            this.InitializeComponent();
            var ret = "";
            foreach (var p in tasks)
            {
                ret += p.ToString();
                ret += "\n";
            }
            TextBlock.Text = NetworkUtil.GetInstance().GetTasks("13391859311");
        }
    }
}
