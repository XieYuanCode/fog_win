using Fog.Pages.Welcome;
using LibGit2Sharp;
using Microsoft.UI;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Windows.ApplicationModel.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.ViewManagement;
using WinRT;
using WinRT.Interop;
using static Fog.MainWindow;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WelcomeWindow : Window
    {
        MicaController m_backdropController;
        WindowsSystemDispatcherQueueHelper m_wsdqHelper;
        SystemBackdropConfiguration m_configurationSource;

        private IntPtr hwnd;
        private AppWindow _apw;
        private OverlappedPresenter _presenter;
        public int CurrentStep { get; set; } = 0;

        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public WelcomeWindow()
        {
            this.InitializeComponent();

            ComcustomizeTitleBar();

            TrySetSystemBackdrop();
            GetAppWindowAndPresenter();

            _apw.Resize(new Windows.Graphics.SizeInt32(_Width: 1000, _Height: 600));
            _presenter.IsResizable = false;

            Welcome_Frame.Navigate(typeof(WelcomeGreeting));
        }

        public void GetAppWindowAndPresenter()
        {
            hwnd = WindowNative.GetWindowHandle(this);
            WindowId myWndId = Win32Interop.GetWindowIdFromWindow(hwnd);
            _apw = AppWindow.GetFromWindowId(myWndId);
            _presenter = _apw.Presenter as OverlappedPresenter;
        }

        public void ComcustomizeTitleBar()
        {
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(AppTitleBar);
        }

        public void TrySetSystemBackdrop()
        {
            if (MicaController.IsSupported())
            {
                m_wsdqHelper = new WindowsSystemDispatcherQueueHelper();
                m_wsdqHelper.EnsureWindowsSystemDispatcherQueueController();

                m_configurationSource = new SystemBackdropConfiguration();
                this.Activated += Window_Activated;
                this.Closed += Window_Closed;
                ((FrameworkElement)this.Content).ActualThemeChanged += Window_ThemeChanged;

                m_configurationSource.IsInputActive = true;
                SetConfigurationSourceTheme();

                m_backdropController = new MicaController()
                {
                    Kind = MicaKind.BaseAlt
                };

                m_backdropController.AddSystemBackdropTarget(this.As<Microsoft.UI.Composition.ICompositionSupportsSystemBackdrop>());
                m_backdropController.SetSystemBackdropConfiguration(m_configurationSource);
            }
        }

        private void Window_Activated(object sender, WindowActivatedEventArgs args)
        {
            m_configurationSource.IsInputActive = args.WindowActivationState != WindowActivationState.Deactivated;
        }

        private void Window_Closed(object sender, WindowEventArgs args)
        {
            if (m_backdropController != null)
            {
                m_backdropController.Dispose();
                m_backdropController = null;
            }
            this.Activated -= Window_Activated;
            m_configurationSource = null;
        }

        private void Window_ThemeChanged(FrameworkElement sender, object args)
        {
            if (m_configurationSource != null)
            {
                SetConfigurationSourceTheme();
            }
        }

        private void SetConfigurationSourceTheme()
        {
            switch (((FrameworkElement)this.Content).ActualTheme)
            {
                case ElementTheme.Dark: m_configurationSource.Theme = SystemBackdropTheme.Dark; break;
                case ElementTheme.Light: m_configurationSource.Theme = SystemBackdropTheme.Light; break;
                case ElementTheme.Default: m_configurationSource.Theme = SystemBackdropTheme.Default; break;
            }
        }

        private void GoNext(object sender, RoutedEventArgs e)
        {
            if (CurrentStep < 3)
            {
                CurrentStep++;
                UpdateFrame(CurrentStep, true);
                Prev_Btn.Visibility = Visibility.Visible;
                //Welcome_FlipView.SelectedIndex = CurrentStep;

                if (CurrentStep == 3)
                {
                    Next_Btn.Text = "Get Start";
                }
            } else if ( CurrentStep == 3)
            {
                //localSettings.Values["IsFirstLoad"] = false;
                WindowManager.GetWindowManager().main_window.Activate();
                WindowManager.GetWindowManager().welcole_window.Close();
            }
        }

        private void GoPre(object sender, RoutedEventArgs e)
        {
            if (CurrentStep > 0)
            {
                CurrentStep--;
                UpdateFrame(CurrentStep, false);
                //Welcome_FlipView.SelectedIndex = CurrentStep;
                if (CurrentStep == 0)
                {
                    Prev_Btn.Visibility = Visibility.Collapsed;
                } else if (CurrentStep == 2)
                {
                    Next_Btn.Text = "Next";
                }
            }
        }

        private void UpdateFrame(int frameCount, bool forward)
        {
            var slideNavigationTransitionEffect = forward == true ? SlideNavigationTransitionEffect.FromRight : SlideNavigationTransitionEffect.FromLeft;
            var slideNavigationTransitionInfo = new SlideNavigationTransitionInfo() { Effect = slideNavigationTransitionEffect };

            switch (frameCount)
            {
                case 0:
                    Welcome_Frame.Navigate(typeof(WelcomeGreeting), null, slideNavigationTransitionInfo);
                    //bitmapImage.UriSource = new Uri("/Assets/Welcome_FlipView/welcome_carousel_1.jpg");
                    break;
                case 1:
                    Welcome_Frame.Navigate(typeof(WelcomeGeneralSetting), null, slideNavigationTransitionInfo);
                    //bitmapImage.UriSource = new Uri("/Assets/Welcome_FlipView/welcome_carousel_2.jpg");
                    break;
                case 2:
                    Welcome_Frame.Navigate(typeof(WelcomeGitSetting), null, slideNavigationTransitionInfo);
                    //bitmapImage.UriSource = new Uri("/Assets/Welcome_FlipView/welcome_carousel_3.jpg");
                    break;
                case 3:
                    Welcome_Frame.Navigate(typeof(WelcomeServiceAccountSetting), null, slideNavigationTransitionInfo);
                    //bitmapImage.UriSource = new Uri("/Assets/Welcome_FlipView/welcome_carousel_4.jpg");
                    break;
                default:
                    break;
            }

        }
    }
}
