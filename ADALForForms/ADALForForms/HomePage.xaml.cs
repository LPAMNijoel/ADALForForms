using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;

namespace ADALForForms
{
    public partial class HomePage : ContentPage
    {
        public static string clientId = "your-client-id";
        public static string authority = "https://login.windows.net/common";
        public static string returnUri = "your-redirect-uri";
        private const string graphResourceUri = "https://graph.windows.net";
        public static string graphApiVersion = "2013-11-08";
        private AuthenticationResult authResult = null;

        public HomePage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var data = await DependencyService.Get<IAuthenticator>()
                .Authenticate(authority, graphResourceUri, clientId, returnUri);
            var userName = data.UserInfo.GivenName + " " + data.UserInfo.FamilyName;
            await DisplayAlert("Token", userName, "Ok", "Cancel");
        }
    }
}
