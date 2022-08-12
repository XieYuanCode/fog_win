using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.Storage.Pickers;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Threading.Tasks;
using WinRT.Interop;
using LibGit2Sharp;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GitInitPage : Page
    {
        public GitInitPage()
        {
            InitializeComponent();

            InitGitData = new InitGitDataModel();
        }

        public InitGitDataModel InitGitData { get; set; }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectFolder = await SelectFolder();
            if (selectFolder != null)
            { 
                InitGitData.InitPath = selectFolder;
            }
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (InitGitData.InitPath == null)
            {
                InitGitData.Message = "先选择目录，再执行初始化操作";
            }
            else
            {
                var result = Repository.Discover(InitGitData.InitPath.Path);

                if (result != null)
                {
                    InitGitData.Message = "所选目录已经是一个git仓库";
                }
                else
                {
                    try
                    {
                        var rootedPath = Repository.Init(this.InitGitData.InitPath.Path, this.InitGitData.Bare);
                        InitGitData.Message = rootedPath;

                    }
                    catch (Exception err)
                    {
                        InitGitData.Message = err.Message;
                    }
                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            InitGitData.Bare = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            InitGitData.Bare = false;
        }
    }

    public class InitGitDataModel : INotifyPropertyChanged
    {
        private Windows.Storage.StorageFolder initPath;
        private string message;
        private bool bare = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public InitGitDataModel()
        {
        }

        public Windows.Storage.StorageFolder InitPath
        {
            get { return initPath; }
            set
            {
                initPath = value;
                OnPropertyChanged();
            }
        }

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }

        public bool Bare
        {
            get { return bare; }
            set
            {
                bare = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
