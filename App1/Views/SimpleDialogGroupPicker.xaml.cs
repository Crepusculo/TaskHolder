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
using App1.Models;
using App1.Utils;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace App1.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SimpleDialogGroupPicker : ContentDialog
    {
        private BaseDataModel model;
        private UserInfo user;
        private Grid _root;
        
        List<StrWrap> groups;


        public SimpleDialogGroupPicker(ref UserInfo user, ref TaskDataModel model, Grid root)
        {
            this.model = model;
            this.user = user;

            this._root = root;
            this.InitializeComponent();

            Task.Run(() => InitializeData());
            TypeComboBox.PlaceholderText = model.UserGroup;

        }


        public SimpleDialogGroupPicker(ref UserInfo user, ref GoalDataModel model, Grid root)
        {
            this.model = model;
            this.user = user;

            this._root = root;
            this.InitializeComponent();
            Task.Run(() => InitializeData());
            TypeComboBox.PlaceholderText = model.UserGroup;

        }


        private void InitializeData()
        {
            groups = NetworkUtil.GetUserGroup(user.Token, user.Username);
        }

        private void SimpleDialogDatePicker_OnPrimaryButtonClick(ContentDialog sender,
            ContentDialogButtonClickEventArgs args)
        {
            try
            {
                if (model.GetType() == typeof(GoalDataModel))
                {
                    ((GoalDataModel) model).UserGroup = ((StrWrap) TypeComboBox.SelectedItem).str;
                    DebugUtil.WriteLine(this, model.ToString());
                    NetworkUtil.UpdateGoalDataModel(user.Username, user.Token, (GoalDataModel) model);

                    TextBlock userGroupTextBlock = DebugUtil.FindControl<TextBlock>(_root, typeof(TextBlock),
                        "UserGroupTextBlock");
                    userGroupTextBlock.Text = ((GoalDataModel) model).UserGroup;
                }
                else if (model.GetType() == typeof(TaskDataModel))
                {
                    ((TaskDataModel) model).UserGroup = ((StrWrap) TypeComboBox.SelectedItem).str;
                    DebugUtil.WriteLine(this, model.ToString());
                    NetworkUtil.UpdateTaskDataModel(user.Username, user.Token, (TaskDataModel) model);
                    TextBlock userGroupTextBlock = DebugUtil.FindControl<TextBlock>(_root, typeof(TextBlock),
                        "UserGroupTextBlock");
                    userGroupTextBlock.Text = ((TaskDataModel) model).UserGroup;
                }
            }
            catch (Exception)
            {
                DebugUtil.WriteLine(this, "Unseclect!");
            }
        }

        private void SimpleDialogDatePicker_OnSecondaryButtonClick(ContentDialog sender,
            ContentDialogButtonClickEventArgs args)
        {
        }
    }
}