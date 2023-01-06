using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Fog
{
    public class WindowManager
    {
        private static WindowManager instence = new WindowManager();

        private WindowManager() { }

        public static WindowManager GetWindowManager()
        {
            return instence;
        }

        public Window main_window;
        public Window welcole_window;

        public void InitAllWindow()
        {
            main_window = new MainWindow();
            welcole_window = new WelcomeWindow();

            int ColorMode = ApplicationData.Current.LocalSettings.Values["ColorMode"] != null? (int)ApplicationData.Current.LocalSettings.Values["ColorMode"]:2;

            UpdateWindowTheme(ColorMode);
        }

        public void UpdateWindowTheme(int theme)
        {
            (main_window.Content as Grid).RequestedTheme = theme switch
            {
                0 => ElementTheme.Light,
                1 => ElementTheme.Dark,
                _ => ElementTheme.Default
            };

            (welcole_window.Content as Grid).RequestedTheme = theme switch
            {
                0 => ElementTheme.Light,
                1 => ElementTheme.Dark,
                _ => ElementTheme.Default
            };
        }
    }
}
