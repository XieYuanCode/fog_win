using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Text;
using Octokit;
using Page = Microsoft.UI.Xaml.Controls.Page;
using ProductHeaderValue = Octokit.ProductHeaderValue;
using Windows.Media.Protection.PlayReady;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountPage : Page
    {
        public AccountPage()
        {
            this.InitializeComponent();
        }

        private GitHubClient githubClient = new GitHubClient(new ProductHeaderValue("fog"));

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            var basicAuth = new Credentials(User_Name.Text, P_A_T.Text);
            githubClient.Credentials = basicAuth;

            var user = await githubClient.User.Current();

            Console.WriteLine(user);
        }
    }
}
