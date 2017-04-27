using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Kuromori.DataStructure;
using Kuromori.Pages;

using Xamarin.Forms;


namespace Kuromori
{
    /// <summary>
    ///   Profile page for a user. on load displays the current values in the current user static fields
    /// </summary>
    public partial class ProfilePage : ContentPage
    {
		public User ActiveUser { get; set; }

		public ProfilePage(User activeUser)
        {
            InitializeComponent();
			ActiveUser = activeUser;
			Title = "Profile Page";
			Debug.WriteLine(ActiveUser.Id);
			Name.Text = ActiveUser.FirstName + " " + ActiveUser.LastName;
			Username.Text = ActiveUser.UserName;
			Email.Text = ActiveUser.Email;
			About.Text = ActiveUser.AboutMe;
			Phone.Text = ActiveUser.PhoneNumber;


			ToolbarItem EditButton = new ToolbarItem();
			EditButton.Clicked += (sender, e) =>
			{
				Navigation.PushAsync(new ProfileUpdatePage(ActiveUser));
			};
            ToolbarItems.Add(EditButton);
			EditButton.Text = "Edit Profile";

			try
			{
				ProfileImage.Source = new Uri(ActiveUser.ProfilePicture);
			}

			catch (Exception res)
			{
				ProfileImage.Source = new Uri("https://x1.xingassets.com/assets/frontend_minified/img/users/nobody_m.original.jpg");
			}
		}

		void FindClick(object sender, EventArgs args)
		{
			Navigation.PushAsync(new EventPage());
		}

		void ChatClick(object sender, EventArgs args)
		{
            Navigation.PushAsync(new Chat(ActiveUser));
        }
    }
}
