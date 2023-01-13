// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Fog.Pages.ContentDialogs;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog.Pages.Welcome
{
    public class WelcomeServiceAccountViewAddAccountBtnViewModel
    {
        public string Title { get; set; }
        public BitmapIcon Icon { get; set; }

        public bool IsEnable { get; set; }
    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WelcomeServiceAccountSetting : Page
    {
        public ServiceAccountManager serviceAccountManager = ServiceAccountManager.GetServiceAccountManager();

        private Compositor _compositor = WindowManager.GetWindowManager().welcole_window.Compositor;
        private SpringVector3NaturalMotionAnimation _springAnimation;

        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public ObservableCollection<ServiceAccount> ServiceAccounts
        {
            get
            {
                return serviceAccountManager.serviceAccounts;
            }
        }
        public WelcomeServiceAccountSetting()
        {
            this.InitializeComponent();
        }

        private void CreateOrUpdateSpringAnimation(Vector3 finalValue)
        {
            if (_springAnimation == null)
            {
                _springAnimation = _compositor.CreateSpringVector3Animation();
                _springAnimation.Target = "Scale";
            }

            _springAnimation.FinalValue = finalValue;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            AddServiceAccountContentDialog addServiceAccountContentDialog = new AddServiceAccountContentDialog(XamlRoot);
            addServiceAccountContentDialog.RequestedTheme = localSettings.Values["ColorMode"] switch
            {
                0 => ElementTheme.Light,
                1 => ElementTheme.Dark,
                _ => ElementTheme.Default
            }; 
            await addServiceAccountContentDialog.ShowAsync();

            Console.WriteLine(addServiceAccountContentDialog.Result);
        }

        private void Grid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            CreateOrUpdateSpringAnimation(new Vector3(1.1f));
            (sender as UIElement).CenterPoint = new Vector3(60, 60, 0);

            (sender as UIElement).StartAnimation(_springAnimation);
        }

        private void Grid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            CreateOrUpdateSpringAnimation(new Vector3(1, 1, 1));
            (sender as UIElement).CenterPoint = new Vector3(60, 60, 0);

            (sender as UIElement).StartAnimation(_springAnimation);
        }
    }
}
