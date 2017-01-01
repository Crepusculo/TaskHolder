using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class SimpleDialogProgressPicker : ContentDialog
    {
        private BaseDataModel model;
        private UserInfo user;
        private Grid _root;

        List<StrWrap> types;


        public SimpleDialogProgressPicker(ref UserInfo user, ref TaskDataModel model, Grid root)
        {
            this.model = model;
            this.user = user;

            this._root = root;
            this.InitializeComponent();

            WorkAmount.Text = model.WorkAmount.ToString();
            WorkProgress.Text = model.WorkProgress.ToString();
        }


        public SimpleDialogProgressPicker(ref UserInfo user, ref GoalDataModel model, Grid root)
        {
            this.model = model;
            this.user = user;

            this._root = root;
            this.InitializeComponent();
            WorkAmount.Text = model.WorkAmount.ToString();
            WorkProgress.Text = model.WorkProgress.ToString();
        }


        private void SimpleDialogDatePicker_OnPrimaryButtonClick(ContentDialog sender,
            ContentDialogButtonClickEventArgs args)
        {
            try
            {
                if (model.GetType() == typeof(GoalDataModel))
                {
                    if (Convert.ToInt32(WorkAmount.Text) < Convert.ToInt32(WorkProgress.Text))
                    {
                        var mg = new MessageDialog("Error! Progress can't great than Amount");
                        var ret = mg.ShowAsync();
                        return;
                    }
                    ((GoalDataModel) model).WorkAmount   = Convert.ToInt32(WorkAmount.Text);
                    ((GoalDataModel) model).WorkProgress = Convert.ToInt32(WorkProgress.Text);

                    NetworkUtil.UpdateGoalDataModel(user.Username, user.Token, (GoalDataModel) model);
                    Button progressInfoButton = DebugUtil.FindControl<Button>(_root, typeof(Button),
                        "ProgressInfoButton");

                    var grid = VisualTreeHelper.GetParent(progressInfoButton);
                    var father = VisualTreeHelper.GetParent(grid);
                    var progrssbar = (ProgressBar)((Grid)father).Children[0];
                    progrssbar.Value = ((GoalDataModel) model).WorkProgress;
                    progressInfoButton.Content = " ( "
                                                 + ((GoalDataModel) model).WorkProgress + " / "
                                                 + ((GoalDataModel) model).WorkAmount + " ) "
                                                 +
                                                 100*
                                                 ((double) ((GoalDataModel) model).WorkProgress/
                                                  (double) ((GoalDataModel) model).WorkAmount)
                                                 + "%";
                }
                else if (model.GetType() == typeof(TaskDataModel))
                {
                    ((TaskDataModel) model).WorkAmount = Convert.ToInt32(WorkAmount.Text);
                    ((TaskDataModel) model).WorkProgress = Convert.ToInt32(WorkProgress.Text);

                    DebugUtil.WriteLine(this, model.ToString());
                    NetworkUtil.UpdateTaskDataModel(user.Username, user.Token, (TaskDataModel) model);
                    Button progressInfoButton = DebugUtil.FindControl<Button>(_root, typeof(Button),
                        "ProgressInfoButton");
                    ProgressBar progressBar = DebugUtil.FindControl<ProgressBar>(_root, typeof(ProgressBar),
                        "ProgressBar");
                    progressInfoButton.Content = " ( "
                                                 + ((TaskDataModel) model).WorkProgress + " / "
                                                 + ((TaskDataModel) model).WorkAmount + " ) "
                                                 +
                                                 100*
                                                 ((double) ((GoalDataModel) model).WorkProgress/
                                                  (double) ((GoalDataModel) model).WorkAmount)
                                                 + "%";
                }
            }
            catch (FormatException)
            {
                var mg = new MessageDialog("Numberic Only in \"Numberic Option\"");
                var ret = mg.ShowAsync();
            }
        }

        private void SimpleDialogDatePicker_OnSecondaryButtonClick(ContentDialog sender,
            ContentDialogButtonClickEventArgs args)
        {
        }
    }
}