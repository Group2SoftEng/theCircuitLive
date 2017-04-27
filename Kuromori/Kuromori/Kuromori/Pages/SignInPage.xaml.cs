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
    /// <summary>
    ///   Sign a user in given correct criteria
    ///   Because we are using names with improper forms for quick tests, this page currently doesn't
    ///   have client-side validation. For registration it does. this is intentional.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();

			ToolbarItem AdminLogin = new ToolbarItem();
			AdminLogin.Clicked += (sender, e) =>
			{
				Navigation.PushAsync(new AdminSignInPage());

			};
			AdminLogin.Text = "Admin";
			ToolbarItems.Add(AdminLogin);
        }

	    /// <summary>
	    ///   On sign in click popular current user static fields with remote user info
		///   
	    /// </summary>
		void SignInClick(object sender, EventArgs args)
		{

			String userType = HttpUtils.PostInfo(new List<KeyValuePair<string, string>> {
				new KeyValuePair<string, string>("username", Username.Text)
			}, "http://haydenszymanski.me/softeng05/get_user_type.php").ResponseInfo;

			/*
			switch (userType)
			{
				case "organizer" :
					Debug.WriteLine("organizer");
					break;
				case "participant" :
					Debug.WriteLine("participant");
					break;
				case "none" :
					Debug.WriteLine("none");
					break;
			}
			*/

			if (HttpUtils.PostInfo(new List<KeyValuePair<string, string>> {
				new KeyValuePair<string, string>("username", Username.Text),
				new KeyValuePair<string, string>("user_password", Password.Text)

			}, "http://haydenszymanski.me/softeng05/login_user.php").ResponseInfo.Equals("Success"))
			{
				Task.Run(async () =>
				{
					User UserSigningIn = await HttpUtils.GetJsonInfo<User>(new List<KeyValuePair<string, string>> {
						new KeyValuePair<string, string>("username", Username.Text),
						new KeyValuePair<string, string>("user_password", Password.Text)
					}, "http://haydenszymanski.me/softeng05/get_user.php");

					Device.BeginInvokeOnMainThread(() =>
					{
						Navigation.InsertPageBefore(new LandingPage(UserSigningIn), Navigation.NavigationStack.First());
						Navigation.PopToRootAsync();
					});
				});


			}
			else
			{
				DisplayAlert("Error", "Credentials Incorrect", "Continue");
			}
		}

		void CancelClick(object sender, EventArgs args)
		{
			Navigation.PopAsync();
		}
    }
}
