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

namespace Fog
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
            var data = DataAccess.GetRepoCollection();
            data.ForEach(x =>
            {
                Console.WriteLine(x);
            });
        }

        public void RegisterGitRepo(string path)
        {
            var repo = new Repository(path);
            var id = Guid.NewGuid().ToString();
            var repoItem = new LocalRepository
            {
                Text = Path.GetFileName(path),
                Repository = repo,
                Path = path,
                ID = id 
            };

            localRepositories.Add(repoItem);

            DataAccess.AddLocalRepo(id, repoItem.Text, repoItem.Pin, repoItem.Path);
        }

        public void ReigsterRepoGroup()
        {
            var id = Guid.NewGuid().ToString();
            var repoGroup = new LocalRepositoryGroup
            {
                Text = "New Group",
                ID = id,
            };

            localRepositories.Add(repoGroup);
        }
    }
}
