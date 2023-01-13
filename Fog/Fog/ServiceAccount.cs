using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitLabApiClient;

namespace Fog
{
    abstract public class ServiceAccount
    {
        public string ID { get; set; } = "";
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string Host { get; set; } = "";
        public string PAT { get; set; } = "";
        public string Avatar { get; set; } = "";
        public bool IsAuthenticated { get; set; } = false;
        public bool IsAuthenticating { get; set; } = false;

        public static GitHubServiceAccount FromGitHub(string name, string pat)
        {
            GitHubServiceAccount serviceAccount = new()
            {
                ID = Guid.NewGuid().ToString(),
                Type = "GitHub",
                Host = "https://github.com",
                Name = name,
                PAT = pat
            };

            return serviceAccount;

        }

        public static GitLabCEEEServiceAccount FromGitLabCEEE(string host, string name, string pat)
        {
            GitLabCEEEServiceAccount serviceAccount = new()
            {
                ID = Guid.NewGuid().ToString(),
                Type = "GitLab CE/EE",
                Host = host,
                Name = name,
                PAT = pat
            };

            return serviceAccount;
        }

        public abstract Task<bool> Authenticate();
    }

    public class GitHubServiceAccount : ServiceAccount
    {
        public Octokit.User CurrentUser { get; set; }
        public override async Task<bool> Authenticate()
        {
            IsAuthenticating = true;

            var gitHubClient = new GitHubClient(new ProductHeaderValue("fog"));
            var basicAuth = new Credentials(Name, PAT);
            gitHubClient.Credentials = basicAuth;
            try
            {
                CurrentUser = await gitHubClient.User.Current();
                Avatar = CurrentUser.AvatarUrl;
                IsAuthenticating = false;
                IsAuthenticated = true;

                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }
    }

    public class GitLabCEEEServiceAccount : ServiceAccount
    {
        public GitLabApiClient.Models.Users.Responses.User CurrentUser { get; set; }

        public override async Task<bool> Authenticate()
        {
            IsAuthenticating = true;

            try
            {
                var gitLabClient = new GitLabClient(Host, PAT);
                var users = await gitLabClient.Users.GetAsync();
                foreach (var user in users)
                {
                    if(user.Name == Name || user.Username == Name)
                    {
                        CurrentUser = user;
                        Avatar = user.AvatarUrl;
                    }
                }

                IsAuthenticating = false;
                IsAuthenticated = true;

                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }
    }
}
