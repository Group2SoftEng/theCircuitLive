using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Kuromori
{
	public partial class SplashPage : ContentPage
	{
		public SplashPage()
		{

			InitializeComponent();
			InitializeComponent();
			Splash.Source = new Uri("http://haydenszymanski.me/splash-image.png");
			Splash.Aspect = Aspect.Fill;
			Logo.Source = new Uri("http://haydenszymanski.me/logo.png");

		}

		void OnButtonClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new UserRegisteredEvents());
		}
	}
}
