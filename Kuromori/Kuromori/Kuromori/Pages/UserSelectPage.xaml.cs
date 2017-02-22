using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace Kuromori
{

	public partial class UserSelectPage : ContentPage
	{

		public UserSelectPage()
		{
			InitializeComponent();
			SelectLogo.Source = new Uri("http://haydenszymanski.me/logo.png");

		}

		void OnSignInClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new SignInPage());

		}

		void OnRegisterClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new RegisterPage());
		}

		void OnGuestClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new EventPage());

		}

	}
}
