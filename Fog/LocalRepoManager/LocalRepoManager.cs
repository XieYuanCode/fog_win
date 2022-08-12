using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary;
using LibGit2Sharp;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LocalRepoManager
{
    public class LocalRepoManager
    {
        private static LocalRepoManager localRepoManager = new LocalRepoManager();

        private LocalRepoManager() { }

        public static LocalRepoManager GetLocalRepoManager()
        {
            return localRepoManager;
        }

        public ObservableCollection<FogTreeViewItem> localRepositories = new ObservableCollection<FogTreeViewItem>();

        public void Init()
        {
            var data = DataAccess.GetData();
            data.ForEach(x =>
            {
            });
        }

        public void RegisterGitRepo(string path)
        {
            //var repo = new Repository(path);
            var repoItem = new LocalRepository
            {
                Text = Path.GetFileName(path),
                Path = path,
            };

            localRepositories.Add(repoItem);

            //DataAccess.AddLocalRepo("1", repoItem.Text, repoItem.Pin, repoItem.Path);
        }

        public void ReigsterRepoGroup()
        {
            var repoGroup = new LocalRepositoryGroup
            {
                Text = "New Group"
            };

            localRepositories.Add(repoGroup);
        }
    }
}
