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
using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ServiceAccountsPage : Page
    {
        public ServiceAccountsPage()
        {
            this.InitializeComponent();
        }

        public ObservableCollection<ServiceAccount> ServiceAccounts
        {
            get
            { 
                return ServiceAccountManager.GetServiceAccountManager().serviceAccounts;
            }
        }

        private void CloseServiceAccountsPage(object sender, RoutedEventArgs e)
        {
            Frame contentFrame = Parent as Frame;
            if (contentFrame.CurrentSourcePageType?.Name != "SettingPage")
            {
                contentFrame.Navigate(typeof(Home), null, new SuppressNavigationTransitionInfo());
            }
        }


        private void SwitchSettingPage(object sender, RoutedEventArgs e)
        {
            Frame contentFrame = Parent as Frame;
            if (contentFrame.CurrentSourcePageType?.Name != "SettingPage")
            {
                contentFrame.Navigate(typeof(SettingPage), null, new SuppressNavigationTransitionInfo());
            }
        }
    }
}
