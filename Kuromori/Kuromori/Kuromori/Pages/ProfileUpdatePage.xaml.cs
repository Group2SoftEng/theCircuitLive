using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kuromori.InfoIO;
using System.Diagnostics;
namespace Kuromori
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileUpdatePage : ContentPage
    {
        public ProfileUpdatePage()
        {
            InitializeComponent();
			Title = "Edit Profile";
			First.Text = ActiveUser.CurrentUser.FirstName;
			Last.Text = ActiveUser.CurrentUser.LastName;
			Email.Text = ActiveUser.CurrentUser.Email;
			AboutMe.Text = ActiveUser.CurrentUser.AboutMe;
			Phone.Text = ActiveUser.CurrentUser.PhoneNumber;
			Address.Text = ActiveUser.CurrentUser.Address;
			ProfileImage.Text = ActiveUser.CurrentUser.ProfilePicture;
        }

        void OnProfileEditClick(object sender, EventArgs args)
        {
			Debug.WriteLine(ActiveUser.CurrentUser.Id);
			PostRequest post = new PostRequest();
			Debug.WriteLine(post.PostInfo(new List<KeyValuePair<string, string>> {
				new KeyValuePair<string, string>("participant_id", ActiveUser.CurrentUser.Id),
				new KeyValuePair<string, string>("zip", Zip.Text),
				new KeyValuePair<string, string>("phone", Phone.Text),
				new KeyValuePair<string, string>("first_name", First.Text),
				new KeyValuePair<string, string>("last_name", Last.Text),
				new KeyValuePair<string, string>("address_line", Address.Text),
				new KeyValuePair<string, string>("profile_img", ProfileImage.Text),
				new KeyValuePair<string, string>("about_me", AboutMe.Text)
			}, "http://haydenszymanski.me/softeng05/update_user.php").ResponseSuccess);

			Task.Run(async () =>
			{
				ActiveUser.CurrentUser = await EventConnection.GetUserData(new List<KeyValuePair<string, string>> {
					new KeyValuePair<string, string>("username", ActiveUser.CurrentUser.UserName),
					new KeyValuePair<string, string>("password", ActiveUser.CurrentUser.Password)
				}, "http://haydenszymanski.me/softeng05/get_user.php");
				Device.BeginInvokeOnMainThread(() =>
				{
					Navigation.InsertPageBefore(new ProfilePage(), Navigation.NavigationStack.First());
					Navigation.PopToRootAsync();
				});
			});


        }
    }
}

