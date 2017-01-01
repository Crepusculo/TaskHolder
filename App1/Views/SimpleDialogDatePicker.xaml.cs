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
using Windows.UI.Xaml.Navigation;
using App1.Models;
using App1.Utils;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace App1.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SimpleDialogDatePicker : ContentDialog
    {
        private BaseDataModel model;
        private UserInfo user;
        private Grid _root;

        public SimpleDialogDatePicker(ref UserInfo user, ref TaskDataModel model, Grid root)
        {
            this.model = model;
            this.user = user;

            this._root = root;
            this.InitializeComponent();

            StartTime.MinYear = new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);
            StartTime.MaxYear = new DateTimeOffset(2070, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);

            EndTime.MinYear = new DateTimeOffset(DateTime.Now);
            EndTime.MaxYear = new DateTimeOffset(2070, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);

            StartTime.Date = ((TaskDataModel) model).StartTime;
            EndTime.Date = ((TaskDataModel) model).EndTime;
        }

        public SimpleDialogDatePicker(ref UserInfo user, ref GoalDataModel model, Grid root)
        {
            this.model = model;
            this.user = user;

            this._root = root;
            this.InitializeComponent();

            StartTime.MinYear = new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);
            StartTime.MaxYear = new DateTimeOffset(2070, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);

            EndTime.MinYear = new DateTimeOffset(DateTime.Now);
            EndTime.MaxYear = new DateTimeOffset(2070, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);


            StartTime.Date = ((GoalDataModel) model).StartTime;
            EndTime.Date = ((GoalDataModel) model).EndTime;
        }

        private void SimpleDialogDatePicker_OnPrimaryButtonClick(ContentDialog sender,
            ContentDialogButtonClickEventArgs args)
        {
            if (model.GetType() == typeof(GoalDataModel))
            {
                ((GoalDataModel) model).StartTime = StartTime.Date;
                ((GoalDataModel) model).EndTime = EndTime.Date;
                DebugUtil.WriteLine(this, model.ToString());
                NetworkUtil.UpdateGoalDataModel(user.Username, user.Token, (GoalDataModel) model);

                TextBlock startTextBlock = DebugUtil.FindControl<TextBlock>(_root, typeof(TextBlock),
                    "StartTimeTextBlock");
                TextBlock endTextBlock = DebugUtil.FindControl<TextBlock>(_root, typeof(TextBlock), 
                    "EndTimeTextBlock");
                startTextBlock.Text = DateUtil.DateToString(((GoalDataModel) model).StartTime);
                endTextBlock.Text = DateUtil.DateToString(((GoalDataModel) model).EndTime);
            }
            else if (model.GetType() == typeof(TaskDataModel))
            {
                ((TaskDataModel) model).StartTime = StartTime.Date;
                ((TaskDataModel) model).EndTime = EndTime.Date;
                DebugUtil.WriteLine(this, model.ToString());
                NetworkUtil.UpdateTaskDataModel(user.Username, user.Token, (TaskDataModel)model);

                TextBlock startTextBlock = DebugUtil.FindControl<TextBlock>(_root, typeof(TextBlock),
                    "StartTimeTextBlock");
                TextBlock endTextBlock = DebugUtil.FindControl<TextBlock>(_root, typeof(TextBlock),
                    "EndTimeTextBlock");
                startTextBlock.Text = DateUtil.DateToString(((TaskDataModel)model).StartTime);
                endTextBlock.Text = DateUtil.DateToString(((TaskDataModel)model).EndTime);
            }
        }

        private void SimpleDialogDatePicker_OnSecondaryButtonClick(ContentDialog sender,
            ContentDialogButtonClickEventArgs args)
        {
        }
    }
}