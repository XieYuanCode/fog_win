// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using GitLabApiClient.Models.Trees.Responses;
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
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.Storage;
using Windows.Storage.Pickers;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog.Pages.Welcome
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WelcomeGeneralSetting : Page
    {
        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        private int LastLanguage = ApplicationData.Current.LocalSettings.Values["Language"] == null ? 0 : (int)ApplicationData.Current.LocalSettings.Values["Language"];

        public WelcomeGeneralSetting()
        {
            this.InitializeComponent();

            DefaultClonedDir_TB.Text = localSettings.Values["DefaultClonedDir"] == null ? "" : (string)localSettings.Values["DefaultClonedDir"];
            Language_CB.SelectedIndex = localSettings.Values["Language"] == null ? 0 : (int)localSettings.Values["Language"];
            ColorMode_CB.SelectedIndex = localSettings.Values["ColorMode"] != null ? (int)localSettings.Values["ColorMode"] : 2;
        }

        private async void SelectDefaultClonedDir(object sender, RoutedEventArgs e)
        {
            var folder = await SelectFolder();
            if (folder != null)
            {
                localSettings.Values["DefaultClonedDir"] = folder.Path;
                DefaultClonedDir_TB.Text = folder.Path;
            }
        }

        private static async Task<Windows.Storage.StorageFolder> SelectFolder()
        {
            var window = new Window();
            var hwnd = WindowNative.GetWindowHandle(window);

            var folderPicker = new FolderPicker
            {
                SuggestedStartLocation = PickerLocationId.Desktop
            };
            folderPicker.FileTypeFilter.Add("*");
            InitializeWithWindow.Initialize(folderPicker, hwnd);

            Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();

            return folder;
        }

        private void Language_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            localSettings.Values["Language"] = Language_CB.SelectedIndex;

            if (Language_CB.SelectedIndex != LastLanguage)
            {
                RequireRestart_IB.IsOpen = true;
            }
            else
            {
                RequireRestart_IB.IsOpen = false;
            }

            ApplicationLanguages.PrimaryLanguageOverride = localSettings.Values["Language"] switch
            {
                0 => "en-us",
                1 => "zh-cn",
                2 => "ja-jp",
                3 => "ko-kr",
                _ => throw new NotImplementedException()
            };
        }

        private async void Restart_BTN_Click(object sender, RoutedEventArgs e)
        {
            var _ = await CoreApplication.RequestRestartAsync(String.Empty);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            localSettings.Values["ColorMode"] = ColorMode_CB.SelectedIndex;

            WindowManager.GetWindowManager().UpdateWindowTheme(ColorMode_CB.SelectedIndex);

            (WindowManager.GetWindowManager().welcole_window.Content as Grid).RequestedTheme = ColorMode_CB.SelectedIndex switch
            {
                0 => ElementTheme.Light,
                1 => ElementTheme.Dark,
                _ => ElementTheme.Default
            };
        }
    }
}
