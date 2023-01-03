using Fog.Pages.Repos;
using LibGit2Sharp;
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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RepoHome : Page
    {
        public RepoHome()
        {
            this.InitializeComponent();
        }

        public string RepoPath { get; set; }
        public Repository Repo { get; set; }

        public bool IsRepoNotAvliable { get; set; } = false;
        public string NotAvliableReason { get; set; } = "Repository Is Not Avliable";
        public string ChangedFileCount { get; set; } = "";
        public ObservableCollection<Branch> LocalBranches { get; set; } = new ObservableCollection<Branch>();
        public ObservableCollection<Branch> RemoteBranches { get; set; } = new ObservableCollection<Branch>();
        public ObservableCollection<Tag> Tags { get; set; } = new ObservableCollection<Tag>();
        public ObservableCollection<Stash> Stashes { get; set; } = new ObservableCollection<Stash>();
        public ObservableCollection<Submodule> Submodules { get; set; } = new ObservableCollection<Submodule>();
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            RepoPath = (string)e.Parameter;
            RefreshRepository();

            RepoDetailFrame.Navigate(typeof(RepoStatusPage), this.Repo);
        }
        public void RefreshRepository()
        {
            ResetRepositoryData();

            if (Directory.Exists(RepoPath) == false)
            {
                MarkNotAvliable("Path: " + RepoPath + " Is Not Exist.");
                return;
            }

            if (Repository.IsValid(RepoPath) == false)
            {
                MarkNotAvliable("Path: " + RepoPath + " Is Not Valid Git Repository.");
                return;
            }

            Repository repository = new(RepoPath);
            this.Repo = repository;

            foreach (var branch in repository.Branches)
            {
                if (branch.IsRemote)
                {
                    RemoteBranches.Add(branch);
                }
                else
                {
                    LocalBranches.Add(branch);
                }
            }
            foreach (var tag in repository.Tags)
            {
                Tags.Add(tag);
            }
            foreach (var stash in repository.Stashes)
            {
                Stashes.Add(stash);
            }
            foreach (var note in repository.Notes)
            {
                Notes.Add(note);
            }
            foreach (var submodule in repository.Submodules)
            {
                Submodules.Add(submodule);
            }

            var changes = repository.RetrieveStatus(new StatusOptions()
            {
                IncludeIgnored = false
            });
            ChangedFileCount = changes.Count().ToString();
        }
        private void ResetRepositoryData()
        {
            IsRepoNotAvliable = false;
            LocalBranches.Clear();
            RemoteBranches.Clear();
            Tags.Clear();
            Stashes.Clear();
            Notes.Clear();
            Submodules.Clear();
        }

        private void MarkNotAvliable(string reason)
        {
            IsRepoNotAvliable = true;
            NotAvliableReason = reason;
        }

        private void GotoHome(object sender, RoutedEventArgs e)
        {
            Frame frame = Parent as Frame;
            frame.Navigate(typeof(Home), null, new DrillInNavigationTransitionInfo());
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedIndex == -1)
            {
                return;
            }
            switch ((sender as ListView).Name)
            {
                case "Workspace_LV":
                    ClearListViewSelection(LocalBranches_LV);
                    ClearListViewSelection(RemoteBranches_LV);
                    ClearListViewSelection(Tags_LV);
                    ClearListViewSelection(Submodules_LV);
                    break;
                case "LocalBranches_LV":
                    ClearListViewSelection(Workspace_LV);
                    ClearListViewSelection(RemoteBranches_LV);
                    ClearListViewSelection(Tags_LV);
                    ClearListViewSelection(Submodules_LV);
                    break;
                case "RemoteBranches_LV":
                    ClearListViewSelection(LocalBranches_LV);
                    ClearListViewSelection(Workspace_LV);
                    ClearListViewSelection(Tags_LV);
                    ClearListViewSelection(Submodules_LV);
                    break;
                case "Tags_LV":
                    ClearListViewSelection(LocalBranches_LV);
                    ClearListViewSelection(RemoteBranches_LV);
                    ClearListViewSelection(Workspace_LV);
                    ClearListViewSelection(Submodules_LV);
                    break;
                case "Submodules_LV":
                    ClearListViewSelection(LocalBranches_LV);
                    ClearListViewSelection(RemoteBranches_LV);
                    ClearListViewSelection(Tags_LV);
                    ClearListViewSelection(Workspace_LV);
                    break;
                default:
                    break;
            }
            Console.WriteLine((sender as ListView).SelectedItem);
        }

        private void ClearListViewSelection(ListView listView)
        {
            if (listView != null)
            {
                listView.SelectedIndex = -1;
            }
        }
    }
}
