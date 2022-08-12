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
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.System.Threading.Core;
using WinRT.Interop;
using LibGit2Sharp;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GitClonePage : Page
    {
        public GitClonePage()
        {
            this.InitializeComponent();


            CloneData = new CloneGitDataModel();
        }

        public CloneGitDataModel CloneData { get; set; }

        private async void Select_folder(object sender, RoutedEventArgs e)
        {
            var selectFolder = await SelectFolder();
            if (selectFolder != null)
            {
                CloneData.ClonePath = selectFolder;
            }
        }

        private void Bare_Checked(object sender, RoutedEventArgs e)
        {
            CloneData.Bare = true;
        }

        private void Bare_Unchecked(object sender, RoutedEventArgs e)
        {
            CloneData.Bare = false;
        }

        private async void Clone(object sender, RoutedEventArgs e)
        {
            if (CloneData.Remote == null)
            {
                CloneData.Message = "输入远程地址";
            }
            else
            {
                if (CloneData.ClonePath == null)
                {
                    CloneData.Message = "选择本地地址";
                }
                else
                {

                    try
                    {
                        CloneData.Message = "克隆中";

                        var cloneOption = new CloneOptions
                        {
                            IsBare = CloneData.Bare
                        };

                        IAsyncAction asyncCloneAction = Windows.System.Threading.ThreadPool.RunAsync(e =>
                        {
                            var repo = Repository.Clone(CloneData.Remote, CloneData.ClonePath.Path, cloneOption);
                        });

                        await asyncCloneAction.AsTask();

                        CloneData.Message = "success";

                    }
                    catch (Exception err)
                    {

                        CloneData.Message = err.Message;
                    }
                }
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
    }


    public class CloneGitDataModel : INotifyPropertyChanged
    {
        private Windows.Storage.StorageFolder clonePath;
        private string message;
        private string remote = "https://github.com/XieYuanCode/fog.git";
        private bool bare = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public CloneGitDataModel()
        {
        }

        public Windows.Storage.StorageFolder ClonePath
        {
            get { return clonePath; }
            set
            {
                clonePath = value;
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

        public string Remote
        {
            get { return remote; }
            set
            {
                remote = value;
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
