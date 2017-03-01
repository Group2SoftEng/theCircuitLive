using System;
using System.Linq;
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
			Title = "Profile Page";
			Debug.WriteLine(ActiveUser.CurrentUser.Id);
			Name.Text = ActiveUser.CurrentUser.FirstName + " " + ActiveUser.CurrentUser.LastName;
			Username.Text = ActiveUser.CurrentUser.UserName;
			Email.Text = ActiveUser.CurrentUser.Email;
			About.Text = ActiveUser.CurrentUser.AboutMe;

			ToolbarItem EditButton = new ToolbarItem();
			EditButton.Clicked += (sender, e) =>
			{
				Navigation.PushAsync(new ProfileUpdatePage());
			};
			EditButton.Text = "Edit Profile";
			ToolbarItems.Add(EditButton);
			try
			{
				ProfileImage.Source = new Uri(ActiveUser.CurrentUser.ProfilePicture);

			}
			catch (FormatException res)
			{
				ProfileImage.Source = new Uri("https://x1.xingassets.com/assets/frontend_minified/img/users/nobody_m.original.jpg");
			}
		}
		void FindClick(object sender, EventArgs args)
		{
			Navigation.PushAsync(new EventPage());

		}
		void MyEventsClick(object sender, EventArgs args)
		{

		}
    }
}