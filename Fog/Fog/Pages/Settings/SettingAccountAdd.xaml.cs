using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Octokit;
using Windows.Foundation.Collections;
using Page = Microsoft.UI.Xaml.Controls.Page;
using DataAccessLibrary;
using GitLabApiClient;
using Windows.Media.Protection.PlayReady;
using System.Collections.ObjectModel;
using Microsoft.UI.Xaml.Media.Animation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog.Pages.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingAccountAdd : Page
    {
        public SettingAccountAdd()
        {
            this.InitializeComponent();
        }

        private GitHubClient gitHubClient = new GitHubClient(new ProductHeaderValue("fog"));

        public string[] BreadcrumbBarItems { get; set; } = new string[] { "Service Account", "Add Account" };

        public bool isConfirming = false;

        private void BreadcrumbBar_ItemClicked(BreadcrumbBar sender, BreadcrumbBarItemClickedEventArgs args)
        {
            if (args.Index == 0)
            {
                (Parent as Frame).Navigate(typeof(SettingAccount), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromLeft });
            }
        }

        private async void AddServiceAccount(object sender, RoutedEventArgs e)
        {

            if (isConfirming)
            {
                return;
            }

            var type = AccountType_ComboBox.SelectedIndex switch
            {
                0 => "GitHub",
                1 => "GitLab CE/EE",
                _ => ""
            };


            var isExist = ServiceAccountManager.GetServiceAccountManager().IsServiceAccountExist(type, Host_TextBox.Text, Username_TextBox.Text, PAT_TextBox.Text);

            if (isExist)
            {
                LoginExist_TT.Title = Username_TextBox.Text + "Is Already Exist!";
                LoginExist_TT.IsOpen = true;
                return;
            }
            else
            {
                IsLoading_ProgressBar.Visibility = Visibility.Visible;
                isConfirming = true;
                switch (AccountType_ComboBox.SelectedIndex)
                {
                    case 0:

                        try
                        {
                            var serviceAccount = ServiceAccount.FromGitHub(Username_TextBox.Text, PAT_TextBox.Text);
                            var authenticateStatus = await serviceAccount.Authenticate();
                            markLoginSussess(serviceAccount);
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine(err);
                            markLoginFail(err.Message);
                            throw;
                        }
                        break;
                    case 1:
                        try
                        {
                            var serviceAccount = ServiceAccount.FromGitLabCEEE(Host_TextBox.Text, Username_TextBox.Text, PAT_TextBox.Text);
                            var authenticateStatus = await serviceAccount.Authenticate();
                            markLoginSussess(serviceAccount);
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine(err);
                            markLoginFail(err.Message);
                            throw;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void markLoginSussess(ServiceAccount serviceAccount)
        {
            IsLoading_ProgressBar.Visibility = Visibility.Collapsed;
            LoginSuccess_TT.Title = "Confirm Success! Welcome to fog, " + serviceAccount.Name;
            LoginSuccess_TT.IsOpen = true;
            isConfirming = false;

            ServiceAccountManager.GetServiceAccountManager().RegisterServiceAccount(serviceAccount);

            (Parent as Frame).Navigate(typeof(SettingAccount));
        }

        private void markLoginFail(string message)
        {
            IsLoading_ProgressBar.ShowError = true;
            LoginFail_TT.Title = message;
            LoginFail_TT.IsOpen = true;
        }

        static public bool GetHostTextBoxVisibility(int index)
        {
            return index == 1;
        }

        static public bool GetConfirmButtonIsEnabled(int index, string host, string name, string pat)
        {
            switch (index)
            {
                case 0:
                    return !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(pat);
                case 1:
                    return !string.IsNullOrWhiteSpace(host) && !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(pat);
                default:
                    return false;
            }
        }

        private void AccountType_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AccountType_ComboBox.SelectedIndex == 0)
            {
                if (Host_TextBox != null)
                {
                    Host_TextBox.Text = "https://github.com/";
                }
            } else
            {
                if (Host_TextBox != null)
                {
                    Host_TextBox.Text = "";
                }
            }
        }
    }
}
