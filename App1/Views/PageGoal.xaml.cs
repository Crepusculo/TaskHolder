using System;
using System.Collections.Generic;
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
        private List<GoalDataModel> goalsData;

        public PageGoal()
        {
            this.Transitions = PageTransitions.SetUpPageAnimation(4);
            this.InitializeData();
            this.InitializeComponent();
        }

        private  void InitializeData()
        {
           goalsData = NetworkUtil.GetInstance().GetGoals("13391859311", "2333"); 
        }

        
    }
}