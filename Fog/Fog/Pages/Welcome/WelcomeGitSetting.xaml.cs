// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using LibGit2Sharp;
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
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog.Pages.Welcome
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WelcomeGitSetting : Page
    {
        public string GitGlobalUsername { get; set; } = "";
        public string GitGlobalEmail { get; set; } = "";
        public WelcomeGitSetting()
        {
            this.InitializeComponent();

            GitGlobalUsername = GitHelper.GlobalConfigHelper.GetGlobalConfig("user.name");
            GitGlobalEmail = GitHelper.GlobalConfigHelper.GetGlobalConfig("user.email");
        }

        private void Username_TB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Username_TB.Text.Trim() != GitGlobalUsername)
            {
                GitHelper.GlobalConfigHelper.SetGlobalConfig("user.name", Username_TB.Text.Trim());
                GitGlobalUsername = Username_TB.Text.Trim();
            }
        }

        private void User_Email_TB_LostFocus(object sender, RoutedEventArgs e)
        {
            if(User_Email_TB.Text.Trim() != GitGlobalEmail)
            {
                GitHelper.GlobalConfigHelper.SetGlobalConfig("user.email", User_Email_TB.Text.Trim());
                GitGlobalEmail = User_Email_TB.Text.Trim();
            }
        }
    }
}
