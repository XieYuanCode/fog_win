using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using DataAccessLibrary;
using Windows.UI.ViewManagement;
using Windows.Storage;
using Windows.Globalization;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {

        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        private WindowManager windowManager = WindowManager.GetWindowManager();
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            ApplicationLanguages.PrimaryLanguageOverride = localSettings.Values["Language"] == null ? "en-us" : localSettings.Values["Language"] switch
            {
                0 => "en-us",
                1 => "zh-cn",
                2 => "ja-jp",
                3 => "ko-kr",
                _ => throw new NotImplementedException()
            };
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected async override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {

            await DataAccess.InitializeDatabase();

            windowManager.InitAllWindow();

            var isFirstLoad = localSettings.Values["IsFirstLoad"] == null ? true : (bool)localSettings.Values["IsFirstLoad"];

            var floder = ApplicationData.Current.LocalFolder;

            if (isFirstLoad == true)
            {
                windowManager.welcole_window.Activate();
                
                // windowManager.main_window.Activate();
            }
            else
            {
                windowManager.main_window.Activate();
            }

            ServiceAccountManager.GetServiceAccountManager().Init();
        }
    }
}
