using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using App1.Animation;
using App1.Models;
using App1.Utils;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace App1.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class DialogGoal
        : ContentDialog
    {
        private UserInfo user;
        List<StrWrap> types;
        List<StrWrap> groups;
        List<StrWrap> frequency;

        public DialogGoal()
        {
            Task.Run(() => InitializeData());
            this.InitializeComponent();
            InitializeDatePicker();
        }

        private void InitializeDatePicker()
        {
            StartTimePicker.MinYear = new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);
            StartTimePicker.MaxYear = new DateTimeOffset(2070, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);

            EndTimePicker.MinYear = new DateTimeOffset(DateTime.Now);
            EndTimePicker.MaxYear = new DateTimeOffset(2070, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);
        }

        private void InitializeData()
        {
            user = new UserInfo() {Password = "123456", Username = "13391859311", Token = "20000"};
            //UserInfo user = UserInfo.LoadInfo();
            //TODO::GetStrList 需要放在更合适的地方
            frequency = StrWrap.GetStrList();
            types = NetworkUtil.GetUserType(user.Token, user.Username);
            groups = NetworkUtil.GetUserGroup(user.Token, user.Username);
        }


        private void ScoreButtonMinusOnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ScoreTextBox.Text == "") ScoreTextBox.Text = "0";
                else if (int.Parse(ScoreTextBox.Text) <= 0) ScoreTextBox.Text = "0";
                else ScoreTextBox.Text = (int.Parse(ScoreTextBox.Text) - 1).ToString();
            }
            catch (Exception)
            {
                var mg = new MessageDialog("Incorrect Input");
                var ret = mg.ShowAsync();
                ScoreTextBox.Text = "0";
            }
        }

        private void ScoreButtonAddOnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ScoreTextBox.Text = ScoreTextBox.Text == ""
                    ? "1"
                    : (int.Parse(ScoreTextBox.Text) + 1).ToString();
            }
            catch (Exception)
            {
                var mg = new MessageDialog("Incorrect Input");
                var ret = mg.ShowAsync();
                ScoreTextBox.Text = "0";
            }
        }

        private void CheckButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                // Initialize
                var model = new GoalDataModel();
                // Standard
                var taskTitle = TaskTitle.Text;
                var taskPoints = Convert.ToInt32(ScoreTextBox.Text);
                var taskWorkAmount = Convert.ToInt32(WorkAmount.Text);
                var taskContent = TaskContentTextBox.Text;
                // Type
                var taskType = ((StrWrap) TypeComboBox.SelectedItem).str;
                if (GroupToggleSwitch.IsOn)
                {
                    var taskGroup = ((StrWrap) GroupComboBox.SelectedItem).str;
                    model.UserGroup = taskGroup;
                }
                // 
                

                var taskStartTime = StartTimePicker.Date;
                var taskEndTime = EndTimePicker.Date;
                model.StartTime = taskStartTime;
                model.EndTime = taskEndTime;


                model.BelongsTo = user.Username;
                model.Name = taskTitle;
                model.Content = taskContent;
                model.Points = taskPoints;
                model.Description = "";

                model.WorkAmount = taskWorkAmount;
                model.WorkProgress = 0;

                model.Type = taskType;

                if (model.Name == "")
                {
                    var mg = new MessageDialog("Option \"Title\" can't be Null!");
                    var ret = mg.ShowAsync();
                    return;
                }
                if (model.StartTime > model.EndTime)
                {
                    var mg = new MessageDialog("Option \"Start\" Time can't later than End Time");
                    var ret = mg.ShowAsync();
                    return;
                }

                NetworkUtil.GetInstance().PostAddNewGoal(user.Username,user.Token, model);
                this.Hide();
                return;
            }
            catch (NullReferenceException)
            {
                var mg = new MessageDialog("Option \"Group\" / \"Repeat\" can't be Null!");
                var ret = mg.ShowAsync();
            }
            catch (FormatException)
            {
                var mg = new MessageDialog("Numberic Only in \"Numberic Option\"");
                var ret = mg.ShowAsync();
            }
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void RefreshButton_OnClick(object sender, RoutedEventArgs e)
        {
            TaskTitle.Text = "";
            ScoreTextBox.Text = "0";
            WorkAmount.Text = "0";
            TaskContentTextBox.Text = "";
            TypeComboBox.SelectedIndex = -1;
            GroupToggleSwitch.IsOn = false;
            GroupComboBox.SelectedIndex = -1;
            StartTimePicker.Date = DateTimeOffset.Now;
            EndTimePicker.Date = DateTimeOffset.Now;
        }

        private void Numberic_OnTextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            double dtemp;
            if (!double.TryParse(sender.Text, out dtemp) && sender.Text != "")
            {
                int pos = sender.SelectionStart - 1;
                sender.Text = "0";
            }
        }
    }
}