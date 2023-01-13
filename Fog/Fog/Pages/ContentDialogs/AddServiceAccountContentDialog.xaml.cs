// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog.Pages.ContentDialogs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddServiceAccountContentDialog : ContentDialog
    {
        public AddServiceAccountContentDialog(XamlRoot xamlRoot)
        {
            this.InitializeComponent();

            this.XamlRoot = xamlRoot;
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ContentDialogButtonClickDeferral deferral = args.GetDeferral();
            var type = AccountType_ComboBox.SelectedIndex switch
            {
                0 => "GitHub",
                1 => "GitLab CE/EE",
                _ => ""
            };

            var isExist = ServiceAccountManager.GetServiceAccountManager().IsServiceAccountExist(type, Host_TB.Text, Username_TB.Text, PAT_TB.Text);
            if (isExist)
            {
                LoginExist_TT.Title = Username_TB.Text + " Is Already Exist!";
                LoginExist_TT.IsOpen = true;
                return;
            }
            else
            {
                switch (AccountType_ComboBox.SelectedIndex)
                {
                    case 0:

                        try
                        {
                            var serviceAccount = ServiceAccount.FromGitHub(Username_TB.Text, PAT_TB.Text);
                            var authenticateStatus = await serviceAccount.Authenticate();
                            ServiceAccountManager.GetServiceAccountManager().RegisterServiceAccount(serviceAccount);
                            deferral.Complete();

                        }
                        catch (Exception err)
                        {
                            Console.WriteLine(err);
                           // markLoginFail(err.Message);
                            throw;
                        }
                        break;
                    case 1:
                        try
                        {
                            var serviceAccount = ServiceAccount.FromGitLabCEEE(Host_TB.Text, Username_TB.Text, PAT_TB.Text);
                            var authenticateStatus = await serviceAccount.Authenticate();
                            ServiceAccountManager.GetServiceAccountManager().RegisterServiceAccount(serviceAccount);
                            deferral.Complete();
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine(err);
                            //markLoginFail(err.Message);
                            throw;
                        }
                        break;
                    default:
                        break;
                }
            }

        }

        void AddServiceAccountContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args) 
        {
        }
        void AddServiceAccountContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args) {
        }

        private void AccountType_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Host_TB != null)
            {
                if (AccountType_ComboBox.SelectedIndex == 0) // GitHub
                {
                    Host_TB.IsEnabled = false;
                    Host_TB.Text = "https://github.com";
                }
                else
                {
                    Host_TB.IsEnabled = true;
                    Host_TB.Text = "";
                }
            }
        }
    }
}
