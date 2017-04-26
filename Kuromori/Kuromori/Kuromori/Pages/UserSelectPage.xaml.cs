using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Kuromori.DataStructure;
using Kuromori.Pages;

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
		void OnSignInClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new SignInPage()); 

		}

	    /// <summary>
	    ///   Push RegisterPage onto navigation stack
	    /// </summary>
		void OnRegisterClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new RegisterPage());
		}

	    /// <summary>
	    ///   Push EventPage onto navigation stack
	    /// </summary>
		void OnGuestClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new EventPage());

		}

		void Test(object sender, EventArgs e)
		{
			Navigation.PushAsync(new Chat(new User { UserName = "jfoley21", Password = "Hello0123!", Id ="66"}));
		}

	}
}
