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
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog.Pages.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingGit : Page
    {
        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public SettingGit()
        {
            this.InitializeComponent();

            // Git_Fetch
            AutoFetch_Switch.IsOn = localSettings.Values["AutoFetch"] == null ? true : (bool)localSettings.Values["AutoFetch"];
            AutoFetchTimeInterval_CB.SelectedIndex = localSettings.Values["AutoFetchTimeInterval"] == null ? 2 : (int)localSettings.Values["AutoFetchTimeInterval"];
            // Git_Commit
            NumberOfCommits_CB.SelectedIndex = localSettings.Values["NumberOfCommits"] == null ? 0 : (int)localSettings.Values["NumberOfCommits"];
            CommitTemplate_RTF.Document.SetText(Microsoft.UI.Text.TextSetOptions.None, localSettings.Values["CommitTemplate"] == null ? "<type>[optional scope]: <description>\r\r[optional body]\r\r[optional footer(s)]\r" : (string)localSettings.Values["CommitTemplate"]);
        }

        private void AutoFetch_Switch_Toggled(object sender, RoutedEventArgs e)
        {
            localSettings.Values["AutoFetch"] = AutoFetch_Switch.IsOn;
        }

        private void RichEditBox_TextChanged(object sender, RoutedEventArgs e)
        {
            string allText;
            var document = CommitTemplate_RTF.Document;
            document.GetText(Microsoft.UI.Text.TextGetOptions.None, out allText);
            localSettings.Values["CommitTemplate"] = allText;
            CommitTemplateCharCount_TB.Text = (allText.Length - 1).ToString();
        }

        private void AutoFetchTimeInterval_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            localSettings.Values["AutoFetchTimeInterval"] = AutoFetchTimeInterval_CB.SelectedIndex;
        }

        private void NumberOfCommits_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            localSettings.Values["NumberOfCommits"] = NumberOfCommits_CB.SelectedIndex;
        }

        private async void ResetCommitTemplate_btn_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new()
            {
                // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
                XamlRoot = this.XamlRoot,
                Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                Title = "Reset Confirm",
                Content = "Are you sure you want to reset the commit template?",
                PrimaryButtonText = "Reset",
                CloseButtonText = "Cancel",
                DefaultButton = ContentDialogButton.Primary
            };

            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                CommitTemplate_RTF.Document.SetText(Microsoft.UI.Text.TextSetOptions.None, "<type>[optional scope]: <description>\r\r[optional body]\r\r[optional footer(s)]\r");
            }
        }

    }
}
