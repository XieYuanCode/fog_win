using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using Octokit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Page = Microsoft.UI.Xaml.Controls.Page;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog.Pages.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingAccount : Page
    {
        private Compositor _compositor = WindowManager.GetWindowManager().main_window.Compositor;
        private SpringVector3NaturalMotionAnimation _springAnimation;

        public SettingAccount()
        {
            this.InitializeComponent();


            //AccountCardControl.Translation += new Vector3(0, 0, 20);
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

        public static ImageSource GetAccountCardTypeIcon(string type)
        {
            return type switch
            {
                "GitHub" => new BitmapImage(new Uri("/Assets/github-logo.png", UriKind.RelativeOrAbsolute)),
                "GitLab CE/EE" =>new BitmapImage(new Uri("/Assets/gitlab-logo.png", UriKind.RelativeOrAbsolute)),
                _ => null
            };

        }


        private GitHubClient githubClient = new GitHubClient(new ProductHeaderValue("fog"));
        private ServiceAccountManager serviceAccountManager = ServiceAccountManager.GetServiceAccountManager();

        public ObservableCollection<ServiceAccount> ServiceAccounts
        {
            get
            {
                return serviceAccountManager.serviceAccounts;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (Parent as Frame).Navigate(typeof(SettingAccountAdd), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }

        public static Visibility isGitHub(string type)
        {
            if(type == "GitHub")
                return Visibility.Visible;
            else 
                return Visibility.Collapsed;
        }

        public static Visibility isGitLab(string type)
        {
            if (type == "GitLab" || type == "GitLab CE/EE")
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        private void Grid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            CreateOrUpdateSpringAnimation(new Vector3(1.1f));
            (sender as UIElement).CenterPoint = new Vector3(100, 100, 0);

            (sender as UIElement).StartAnimation(_springAnimation);
        }

        private void Grid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            CreateOrUpdateSpringAnimation(new Vector3(1, 1, 1));
            (sender as UIElement).CenterPoint = new Vector3(100, 100, 0);

            (sender as UIElement).StartAnimation(_springAnimation);
        }
    }
}
