using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Kuromori
{
  /// <summary>
  ///   Simple splash page with an image, logo and button
  /// </summary>
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

    /// <summary>
    ///   Push a new page onto navigation stack
    /// </summary>
		void OnButtonClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new UserSelectPage());
		}

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
