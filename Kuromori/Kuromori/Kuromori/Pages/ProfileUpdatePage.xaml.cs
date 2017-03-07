using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kuromori.InfoIO;
using System.Diagnostics;
using Kuromori.DataStructure;
namespace Kuromori
{

    /// <summary>
    ///   Page that updates both the remote database and local static current user fields
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileUpdatePage : ContentPage
    {
		public User ActiveUser { get; set; }

        /// <summary>
        ///   
        /// </summary>
        public ProfileUpdatePage(User activeUser)
        {
            InitializeComponent();

			ActiveUser = activeUser; // Initial Local user 

			First.Text = ActiveUser.FirstName;
			Last.Text = ActiveUser.LastName;
			Email.Text = ActiveUser.Email;
			AboutMe.Text = ActiveUser.AboutMe;
			Phone.Text = ActiveUser.PhoneNumber;
			Address.Text = ActiveUser.Address;
			ProfileImage.Text = ActiveUser.ProfilePicture;
        }

        /// <summary>
        ///   
        /// </summary>
        void OnProfileEditClick(object sender, EventArgs args)
        {
			Debug.WriteLine(ActiveUser.Id);
			PostRequest post = new PostRequest();
			Debug.WriteLine(post.PostInfo(new List<KeyValuePair<string, string>> {
				new KeyValuePair<string, string>("user_id", ActiveUser.Id),
				new KeyValuePair<string, string>("user_zip", Zip.Text),
				new KeyValuePair<string, string>("user_phone", Phone.Text),
				new KeyValuePair<string, string>("user_first", First.Text),
				new KeyValuePair<string, string>("user_last", Last.Text),
				new KeyValuePair<string, string>("user_address", Address.Text),
				new KeyValuePair<string, string>("user_profile_picture", ProfileImage.Text),
				new KeyValuePair<string, string>("user_about_me", AboutMe.Text),
				new KeyValuePair<string, string>("user_state" , "")
			}, "http://haydenszymanski.me/softeng05/update_user.php").ResponseSuccess);



			/// <summary>
			///   after we update the database, we then immediately query that database to update our local static current user fields
			///   currently there is a bug that likely has to due with the timing of this task. In the future, all we need to do is
			///   change the local static fields according to the text we inputted
			///   NOTE: Bug Fixed
			/// </summary>
			Task.Run(async () =>
			{
				ActiveUser = await JsonRequest.GetUserData<User>(new List<KeyValuePair<string, string>> {
					new KeyValuePair<string, string>("username", ActiveUser.UserName),
					new KeyValuePair<string, string>("user_password", ActiveUser.Password)
				}, "http://haydenszymanski.me/softeng05/get_user.php");
				Device.BeginInvokeOnMainThread(() =>
				{
					ActiveUser.Zip = Zip.Text;
					ActiveUser.PhoneNumber = Phone.Text;
					ActiveUser.FirstName = First.Text;
					ActiveUser.LastName = Last.Text;
					ActiveUser.Address = Address.Text;
					ActiveUser.ProfilePicture = ProfileImage.Text;
					ActiveUser.AboutMe = AboutMe.Text;
					Navigation.InsertPageBefore(new ProfilePage(ActiveUser), Navigation.NavigationStack.First());
					Navigation.PopToRootAsync();
				});
			});


        }
    }
}

