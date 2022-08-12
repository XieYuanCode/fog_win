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
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using WinRT.Interop;
using LibGit2Sharp;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GitBranchPage : Page
    {
        public GitBranchPage()
        {
            this.InitializeComponent();

            Branch_View.ItemsSource = branches;
        }

        public ObservableCollection<Branch> branches = new ObservableCollection<Branch>();
        private async void Select_folder(object sender, RoutedEventArgs e)
        {
            var window = new Window();
            var hwnd = WindowNative.GetWindowHandle(window);

            var folderPicker = new FolderPicker
            {
                SuggestedStartLocation = PickerLocationId.Desktop
            };
            folderPicker.FileTypeFilter.Add("*");
            InitializeWithWindow.Initialize(folderPicker, hwnd);

            Windows.Storage.StorageFolder selectFolder = await folderPicker.PickSingleFolderAsync();

            if (selectFolder != null)
            {
                select_folder_tb.Text = selectFolder.Path;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Repository.Discover(select_folder_tb.Text) != null)
            {
                var repo = new Repository(select_folder_tb.Text);

                foreach (var branch in repo.Branches)
                {
                    branches.Add(branch);
                }
            }
        }
    }
}
