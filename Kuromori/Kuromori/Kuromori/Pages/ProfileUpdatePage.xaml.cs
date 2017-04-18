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
        UriImageSource ImgSrc;
        string SrcString;

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
            //ProfileImage.Text = ActiveUser.ProfilePicture;
            img1.Source = new Uri("http://haydenszymanski.me/softeng05/images/ProfileImages/usr_antelope.jpeg");
            img2.Source = new Uri("http://haydenszymanski.me/softeng05/images/ProfileImages/usr_chihuahua.jpeg");
            img3.Source = new Uri("http://haydenszymanski.me/softeng05/images/ProfileImages/usr_duckling.jpeg");
            img4.Source = new Uri("http://haydenszymanski.me/softeng05/images/ProfileImages/usr_horses.jpg");
            img5.Source = new Uri("http://haydenszymanski.me/softeng05/images/ProfileImages/usr_giraffe.jpg");
            img6.Source = new Uri("http://haydenszymanski.me/softeng05/images/ProfileImages/usr_hedgehog.jpeg");
            img7.Source = new Uri("http://haydenszymanski.me/softeng05/images/ProfileImages/usr_bunny.jpeg");

            ///<summary>
            ///if user selects img1 update profile image to img1
            /// </summary>
            img1.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    ImgSrc = (Xamarin.Forms.UriImageSource)img1.Source;
                    SrcString = ImgSrc.Uri.ToString();
                })
            });
            ///<summary>
            ///if user selects img1 update profile image to img1
            /// </summary>
            img2.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    ImgSrc = (Xamarin.Forms.UriImageSource)img2.Source;
                    SrcString = ImgSrc.Uri.ToString();
                })
            });
            ///<summary>
            ///if user selects img1 update profile image to img1
            /// </summary>
            img3.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    ImgSrc = (Xamarin.Forms.UriImageSource)img3.Source;
                    SrcString = ImgSrc.Uri.ToString();
                })
            });
            ///<summary>
            ///if user selects img1 update profile image to img1
            /// </summary>
            img4.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    ImgSrc = (Xamarin.Forms.UriImageSource)img4.Source;
                    SrcString = ImgSrc.Uri.ToString();
                })
            });
            ///<summary>
            ///if user selects img1 update profile image to img1
            /// </summary>
            img5.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    ImgSrc = (Xamarin.Forms.UriImageSource)img5.Source;
                    SrcString = ImgSrc.Uri.ToString();
                })
            });
            ///<summary>
            ///if user selects img1 update profile image to img1
            /// </summary>
            img6.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    ImgSrc = (Xamarin.Forms.UriImageSource)img6.Source;
                    SrcString = ImgSrc.Uri.ToString();
                })
            });
            ///<summary>
            ///if user selects img1 update profile image to img1
            /// </summary>
            img7.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    ImgSrc = (Xamarin.Forms.UriImageSource)img7.Source;
                    SrcString = ImgSrc.Uri.ToString();
                })
            });
        }

        /// <summary>
        ///   
        /// </summary>
        void OnProfileEditClick(object sender, EventArgs args)
        {
			Debug.WriteLine(ActiveUser.Id);
			Debug.WriteLine(HttpUtils.PostInfo(new List<KeyValuePair<string, string>> {
				new KeyValuePair<string, string>("user_id", ActiveUser.Id),
				new KeyValuePair<string, string>("user_zip", Zip.Text),
				new KeyValuePair<string, string>("user_phone", Phone.Text),
				new KeyValuePair<string, string>("user_first", First.Text),
				new KeyValuePair<string, string>("user_last", Last.Text),
				new KeyValuePair<string, string>("user_address", Address.Text),
				new KeyValuePair<string, string>("user_profile_picture", SrcString),
				new KeyValuePair<string, string>("user_about_me", AboutMe.Text),
				new KeyValuePair<string, string>("user_email", Email.Text),
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
				ActiveUser = await HttpUtils.GetJsonInfo<User>(new List<KeyValuePair<string, string>> {
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
					ActiveUser.ProfilePicture = SrcString;
					ActiveUser.AboutMe = AboutMe.Text;
					ActiveUser.PhoneNumber = Phone.Text;
					ActiveUser.Email = Email.Text;
					Navigation.InsertPageBefore(new ProfilePage(ActiveUser), Navigation.NavigationStack.First());
					Navigation.PopToRootAsync();
				});
			});


        }

		void OnCancelClick(object sender, EventArgs args)
		{
			Navigation.PopAsync();

		}
    }
}

