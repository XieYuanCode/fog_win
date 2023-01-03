using LibGit2Sharp;
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
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog.Pages.Repos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RepoStatusPage : Page
    {
        public RepoStatusPage()
        {
            this.InitializeComponent();
        }

        public Repository Repo { get; set; }

        public ObservableCollection<StatusEntry> RepoStatus = new ObservableCollection<StatusEntry>();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Repo = (Repository)e.Parameter;

            this.UpdateRepoStatus();
        }

        private void UpdateRepoStatus()
        {
            var changes = Repo.RetrieveStatus(new StatusOptions()
            {
                IncludeIgnored = false
            });

            foreach (var change in changes)
            {
                RepoStatus.Add(change);
            }
        }
    }
}
