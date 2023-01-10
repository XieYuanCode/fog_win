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
    public sealed partial class SettingAppearance : Page
    {
        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public SettingAppearance()
        {
            this.InitializeComponent();

            ColorMode_CB.SelectedIndex = localSettings.Values["ColorMode"] != null ? (int)localSettings.Values["ColorMode"] : 2;
        }

        private void OpenWidnwosColorSettings(object sender, RoutedEventArgs e)
        {
            IAsyncOperation<bool> asyncOperation = Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:colors"));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            localSettings.Values["ColorMode"] = ColorMode_CB.SelectedIndex;

            WindowManager.GetWindowManager().UpdateWindowTheme(ColorMode_CB.SelectedIndex);
        }
    }
}
