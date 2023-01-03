using Microsoft.Toolkit.Uwp.Notifications;
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
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog.Pages.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingGeneral : Page
    {
        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public SettingGeneral()
        {
            this.InitializeComponent();

            DefaultClonedDir_TB.Text = localSettings.Values["DefaultClonedDir"] == null ? "" : (string)localSettings.Values["DefaultClonedDir"];
            //Behavior
            Sound_Switch.IsOn = localSettings.Values["Sound"] == null ? true : (bool)localSettings.Values["Sound"];
            Teaching_Switch.IsOn = localSettings.Values["Teaching"] == null ? true : (bool)localSettings.Values["Teaching"];
            Notification_Switch.IsOn = localSettings.Values["Notification"] == null ? true : (bool)localSettings.Values["Notification"];
            
        }

        private void Sound_Switch_Toggled(object sender, RoutedEventArgs e)
        {
            localSettings.Values["Sound"] = Sound_Switch.IsOn;
        }
        private void Teaching_Switch_Toggled(object sender, RoutedEventArgs e)
        {
            localSettings.Values["Teaching"] = Teaching_Switch.IsOn;
        }

        private void Notification_Switch_Toggled(object sender, RoutedEventArgs e)
        {
            localSettings.Values["Notification"] = Notification_Switch.IsOn;
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
    }
}
