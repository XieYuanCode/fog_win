using Fog.Pages.Settings;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
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

namespace Fog.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingPage : Page
    {

        public SettingPage()
        {
            this.InitializeComponent();
            SettingFrame.Navigate(typeof(SettingGeneral));
        }



        private void CloseSettingPage(object sender, RoutedEventArgs e)
        {
            Frame frame = Parent as Frame;
            frame.Navigate(typeof(Home), null, new SuppressNavigationTransitionInfo());
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tag = (e.ClickedItem as StackPanel).Tag.ToString();

            switch (tag)
            {
                case "General":
                    if (SettingFrame.CurrentSourcePageType.Name == "SettingGeneral") return;
                    SettingFrame.Navigate(typeof(SettingGeneral));
                    break;
                case "Appearance":
                    if (SettingFrame.CurrentSourcePageType.Name == "SettingAppearance") return;
                    SettingFrame.Navigate(typeof(SettingAppearance));
                    break;
                case "Git":
                    if (SettingFrame.CurrentSourcePageType.Name == "SettingGit") return;
                    SettingFrame.Navigate(typeof(SettingGit));
                    break;
                case "Account":
                    if (SettingFrame.CurrentSourcePageType.Name == "SettingAccount") return;
                    SettingFrame.Navigate(typeof(SettingAccount));
                    break;
                case "User Profiles":
                    if (SettingFrame.CurrentSourcePageType.Name == "SettingUserProfile") return;
                    SettingFrame.Navigate(typeof(SettingUserProfile));
                    break;
                case "Shortcut":
                    if (SettingFrame.CurrentSourcePageType.Name == "SettingShortcut") return;
                    SettingFrame.Navigate(typeof(SettingShortcut));
                    break;
                case "Integration":
                    if (SettingFrame.CurrentSourcePageType.Name == "SettingIntegration") return;
                    SettingFrame.Navigate(typeof(SettingIntegration));
                    break;
                case "About":
                    if (SettingFrame.CurrentSourcePageType.Name == "SettingAbout") return;
                    SettingFrame.Navigate(typeof(SettingAbout));
                    break;
                default:
                    break;
            }

        }
    }
}
