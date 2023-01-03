using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DataAccessLibrary;
using LibGit2Sharp;
using GitLabApiClient;
using Octokit;
using Credentials = Octokit.Credentials;

namespace Fog
{
    public class ServiceAccountManager
    {
        private static ServiceAccountManager instance = new ServiceAccountManager();

        private ServiceAccountManager() { }

        public static ServiceAccountManager GetServiceAccountManager()
        {
            return instance;
        }

        public ObservableCollection<ServiceAccount> serviceAccounts = new ObservableCollection<ServiceAccount>();

        public void Init()
        {
            var serviceAccountsCached = DataAccess.GetServiceAccounts();
            serviceAccountsCached.ForEach(x =>
            {
                switch (x[1])
                {
                    case "GitHub":
                        var gitHubServiceAccount = ServiceAccount.FromGitHub(x[3], x[4]);
                        serviceAccounts.Add(gitHubServiceAccount);
                        _ = gitHubServiceAccount.Authenticate();
                        break;

                    case "GitLab CE/EE":
                        var gitLabCEEEserviceAccount = ServiceAccount.FromGitLabCEEE(x[2], x[3], x[4]);
                        serviceAccounts.Add(gitLabCEEEserviceAccount);
                        _ = gitLabCEEEserviceAccount.Authenticate();
                        break;
                    default:
                        break;
                }
            });
        }

        public void RegisterServiceAccount(ServiceAccount serviceAccount)
        {
            serviceAccounts.Add(serviceAccount);

            DataAccess.AddAccount(serviceAccount.ID, serviceAccount.Type, serviceAccount.Host, serviceAccount.Name, serviceAccount.PAT);
        }

        public bool IsServiceAccountExist(string type, string host, string name, string pat)
        {
            var isExist = false;
            foreach (var serviceAccount in serviceAccounts)
            {
                if (type == "GitHub")
                {
                    isExist = (name == serviceAccount.Name && serviceAccount.Type == "GitHub");
                    break;
                }
                else if (type == "GitLab CE/EE")
                {
                    isExist = (name == serviceAccount.Name && host == serviceAccount.Host && serviceAccount.Type == "GitLab CE/EE");
                }
            }

            return isExist;
        }
    }
}
