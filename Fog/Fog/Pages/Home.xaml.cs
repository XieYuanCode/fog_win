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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
        }

        ObservableCollection<FogTreeViewItem> localRepositories = LocalRepoManager.GetLocalRepoManager().localRepositories;

        private void ReopGroup_ContextRequested(UIElement sender, ContextRequestedEventArgs args)
        {
            Point point = new Point(0, 0);

            if (args.TryGetPosition(sender, out point))
            {
                RepoGroupMenuFlyout.ShowAt(sender, point);

            }
            else
            {
                RepoGroupMenuFlyout.ShowAt((FrameworkElement)sender);
            }
        }

        private void ReopItem_ContextRequested(UIElement sender, ContextRequestedEventArgs args)
        {
            Point point = new Point(0, 0);


            SetFlyoutPinStatus(((sender as TreeViewItem).DataContext as LocalRepository).Pin);

            if (args.TryGetPosition(sender, out point))
            {
                RepoMenuFlyout.ShowAt(sender, point);
            }
            else
            {
                RepoMenuFlyout.ShowAt((FrameworkElement)sender);
            }
        }

        private void SetFlyoutPinStatus(bool pin)
        {
            (RepoMenuFlyout.Items[0] as ToggleMenuFlyoutItem).IsChecked = pin;
        }

        private void RevealRepoInFileExplorer(object sender, RoutedEventArgs e)
        {
            if ((sender as MenuFlyoutItem).DataContext == null) return;
            string selectRepoPath = ((sender as MenuFlyoutItem).DataContext as LocalRepository).Path;

            if (string.IsNullOrEmpty(selectRepoPath)) return;
            if (Directory.Exists(selectRepoPath) == false) return;

            var psi = new ProcessStartInfo() { FileName = selectRepoPath, UseShellExecute = true };
            Process.Start(psi);
        }

        private void OpenRepoInTerminal(object sender, RoutedEventArgs e)
        {
            if ((sender as MenuFlyoutItem).DataContext == null) return;
            string selectRepoPath = ((sender as MenuFlyoutItem).DataContext as LocalRepository).Path;

            if (string.IsNullOrEmpty(selectRepoPath)) return;
            if (Directory.Exists(selectRepoPath) == false) return;

            var psi = new ProcessStartInfo() { FileName = "wt.exe", Arguments = "-d " + selectRepoPath };
            Process.Start(psi);
        }

        private void OpenRepoInEditor(object sender, RoutedEventArgs e)
        {
            if ((sender as MenuFlyoutItem).DataContext == null) return;
        }
        private void CopyRepoPath(object sender, RoutedEventArgs e)
        {
            if ((sender as MenuFlyoutItem).DataContext == null) return;
            string selectRepoPath = ((sender as MenuFlyoutItem).DataContext as LocalRepository).Path;

            DataPackage dataPackage = new DataPackage();
            dataPackage.SetText(selectRepoPath);
            Clipboard.SetContent(dataPackage);

            copyed_TT.IsOpen = true;
        }
        private void ShowAddMenuFlyout(object sender, RoutedEventArgs e)
        {
            AddMenuFlout.ShowAt((FrameworkElement)sender);
        }

        private async void AddLocalRepo(object sender, RoutedEventArgs e)
        {
            var selectFolder = await SelectFolder();
            if (selectFolder != null)
            {
                LocalRepoManager.GetLocalRepoManager().RegisterGitRepo(selectFolder.Path);
            }
        }

        private void AddLocalRepoGroup(object sender, RoutedEventArgs e)
        {
            LocalRepoManager.GetLocalRepoManager().ReigsterRepoGroup();
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

        private void SwitchSettingPage(object sender, RoutedEventArgs e)
        {
            Frame contentFrame = Parent as Frame;
            if (contentFrame.CurrentSourcePageType?.Name != "SettingPage")
            {
                contentFrame.Navigate(typeof(SettingPage), null, new SuppressNavigationTransitionInfo());
            }
        }

        private void TreeViewItem_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var repo = (sender as TreeViewItem).DataContext as LocalRepository;
            OpenRepoHome(repo);
        }

        public void OpenRepoHome(LocalRepository repo)
        {
            //RepoFrame.Navigate(typeof(RepoHome), repo, new DrillInNavigationTransitionInfo());
        }
    }

    public class ExplorerItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FolderTemplate { get; set; }
        public DataTemplate FileTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            var explorerItem = (FogTreeViewItem)item;
            if (explorerItem.Type == TreeViewItemType.Folder) return FolderTemplate;

            return FileTemplate;
        }
    }
}
