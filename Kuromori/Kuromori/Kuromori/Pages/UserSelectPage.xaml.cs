using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Kuromori.DataStructure;

namespace Kuromori
{
  /// <summary>
  ///   simple page with a logo and three buttons going to their respective pages
  /// </summary>
	public partial class UserSelectPage : ContentPage
	{
		public UserSelectPage()
		{
			InitializeComponent();
			SelectLogo.Source = new Uri("http://haydenszymanski.me/logo.png"); // set the image to the logo at this url
		}

	    /// <summary>
	    ///   Push signinpage onto navigation stack
	    /// </summary>
		async void OnSignInClick(object sender, EventArgs e)
		{
			SignIn.IsEnabled = false;
			await Navigation.PushAsync(new SignInPage());
			SignIn.IsEnabled = true;

		}

	    /// <summary>
	    ///   Push RegisterPage onto navigation stack
	    /// </summary>
		async void OnRegisterClick(object sender, EventArgs e)
		{
			Register.IsEnabled = false;
			await Navigation.PushAsync(new RegisterPage());
			Register.IsEnabled = true;
		}

	    /// <summary>
	    ///   Push EventPage onto navigation stack
	    /// </summary>
		async void OnGuestClick(object sender, EventArgs e)
		{
			Guest.IsEnabled = false;
			await Navigation.PushAsync(new EventPage());
			Guest.IsEnabled = true;
		}

		void Test(object sender, EventArgs e)
		{
			Navigation.PushAsync(new LandingPage(new User { UserName = "jfoley21", Id = "1" }));
		}

	}
}
