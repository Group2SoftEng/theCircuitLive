using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kuromori.InfoIO;
using Kuromori.DataStructure;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Kuromori
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
        }

		void SignInClick(object sender, EventArgs args)
		{
			PostRequest post = new PostRequest();
			/*post.PostInfo(new List<KeyValuePair<string, string>> {
				new KeyValuePair<string, string>("username", Username.Text),
				new KeyValuePair<string, string>("password", Password.Text)
			}, "http://haydenszymanski.me/softeng05/login_user.php");*/

			if (post.PostInfo(new List<KeyValuePair<string, string>> {
				new KeyValuePair<string, string>("username", Username.Text),
				new KeyValuePair<string, string>("password", Password.Text)

			}, "http://haydenszymanski.me/softeng05/login_user.php").ResponseInfo.Equals("Success"))
			{
				Task.Run(async () =>
				{
					ActiveUser.CurrentUser = await EventConnection.GetUserData(new List<KeyValuePair<string, string>> {
						new KeyValuePair<string, string>("username", Username.Text),
						new KeyValuePair<string, string>("password", Password.Text)
					}, "http://haydenszymanski.me/softeng05/get_user.php");
					Device.BeginInvokeOnMainThread(() =>
					{
						Navigation.InsertPageBefore(new ProfilePage(), Navigation.NavigationStack.First());
						Navigation.PopToRootAsync();
					});
				});


			};
		}
    }
}
