using System;
using System.Collections.Generic;
using Kuromori;
using Kuromori.InfoIO;
using Kuromori.DataStructure;
using Xamarin.Forms;

namespace Kuromori
{
	public partial class AdminSignInPage : ContentPage
	{
		public AdminSignInPage()
		{
			InitializeComponent();
		}

		void OnSignInClick(object sender, EventArgs e)
		{
			/*Navigation.PushAsync(
				new AdminPage { Title = "Admin Panel" });*/
			PostRequest post = new PostRequest();

			if (post.PostInfo(new List<KeyValuePair<string, string>> {
				new KeyValuePair<string, string>("admin_username", AdminUsername.Text),
				new KeyValuePair<string, string>("admin_password", AdminPassword.Text)},
				  "http://haydenszymanski.me/softeng05/login_admin.php").ResponseInfo.Equals("Success"))
			{
				Navigation.PushAsync(
					new AdminPage(new Admin(AdminUsername.Text, 
                    AdminPassword.Text)){
                        Title = "Admin Panel"
                    }
				);
			}
			else
			{
				DisplayAlert("Error", "Credentials Incorrect", "Continue");
			}
		}

		void CancelClick(object sender, EventArgs e)
		{
			Navigation.PopAsync();
		}

	}
}
