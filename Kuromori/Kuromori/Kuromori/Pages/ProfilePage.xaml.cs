using System;
using System.Diagnostics;
using System.Collections.Generic;

using Xamarin.Forms;


namespace Kuromori
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            ProfileImage.Source = new Uri("https://x1.xingassets.com/assets/frontend_minified/img/users/nobody_m.original.jpg");
			Debug.WriteLine(ActiveUser.CurrentUser.Id);
			Name.Text = ActiveUser.CurrentUser.FirstName + " " + ActiveUser.CurrentUser.LastName;
			Username.Text = ActiveUser.CurrentUser.UserName;
			Email.Text = ActiveUser.CurrentUser.Email;
			ProfileImage.Source = new Uri(ActiveUser.CurrentUser.ProfilePicture);
        }
    }
}