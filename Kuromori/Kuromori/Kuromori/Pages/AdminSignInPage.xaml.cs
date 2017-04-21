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
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Kuromori.AdminSignInPage"/> class.
		/// </summary>
		public AdminSignInPage()
		{
			InitializeComponent();
		}

		void OnSignInClick(object sender, EventArgs e) // Activates when sign in button is clicked
		{

			if (HttpUtils.PostInfo(new List<KeyValuePair<string, string>> {  // if admin credentials are valid
				new KeyValuePair<string, string>("admin_username", AdminUsername.Text),
				new KeyValuePair<string, string>("admin_password", AdminPassword.Text)},
				  "http://haydenszymanski.me/softeng05/login_admin.php").ResponseInfo.Equals("Success"))
			{
				Navigation.PushAsync( // On success push admin page onto the stack with admin credentials.
					new AdminPage(new Admin(AdminUsername.Text, 
                    AdminPassword.Text)){
                        Title = "Admin Panel"
                    }
				);
			}
			else // on failure display an alert.
			{
				DisplayAlert("Error", "Incorrect Username or Password. If you're not an admin, please return to the previous screen.", "Try Again");
			}
		}

		void CancelClick(object sender, EventArgs e) // on cancel pop this page off the stack
		{
			Navigation.PopAsync();
		}

	}
}
