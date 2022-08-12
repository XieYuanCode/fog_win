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
        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public SettingPage()
        {
            this.InitializeComponent();
        }

        public string ColorTheme
        {
            get
            {
                if (localSettings.Values["ColorTheme"] == null)
                {
                    return "System";
                }
                else
                {
                    return localSettings.Values["ColorTheme"] as string;
                }
            }
            set
            {
                ColorModeChanged_Tip.IsOpen = true;
                localSettings.Values["ColorTheme"] = value;
            }
        }

        private void CloseSettingPage(object sender, RoutedEventArgs e)
        {
            Frame frame = Parent as Frame;
            frame.Navigate(typeof(Home), null, new SuppressNavigationTransitionInfo());
        }
    }
}
