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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileImageGallerey : ContentPage
    {
        public User ActiveUser { get; set; }
        UriImageSource ImgSrc;
        string SrcString;

        public ProfileImageGallerey(User User)
        {
            InitializeComponent();

            ActiveUser = User;

            try
            {
                img1.Source = new Uri("http://haydenszymanski.me/softeng05/images/usr_profile_img_test.jpg");
                img2.Source = new Uri("http://haydenszymanski.me/softeng05/images/usr_profile_img_test2.png");
                img3.Source = new Uri("http://haydenszymanski.me/softeng05/images/usr_profile_img_test.jpg");
                img4.Source = new Uri("https://i.ytimg.com/vi/Q2-0w0YrsfA/maxresdefault.jpg");
                //img5.Source = new Uri("https://i.ytimg.com/vi/Q2-0w0YrsfA/maxresdefault.jpg");
                /*img6.Source = new Uri("https://vignette3.wikia.nocookie.net/jamescameronsavatar/images/9/9c/Alone_in_the_jungle.jpg/revision/latest?cb=20100127181549");
                img7.Source = new Uri("https://vignette3.wikia.nocookie.net/jamescameronsavatar/images/9/9c/Alone_in_the_jungle.jpg/revision/latest?cb=20100127181549");
                img8.Source = new Uri("https://vignette3.wikia.nocookie.net/jamescameronsavatar/images/9/9c/Alone_in_the_jungle.jpg/revision/latest?cb=20100127181549");
                img9.Source = new Uri("https://vignette3.wikia.nocookie.net/jamescameronsavatar/images/9/9c/Alone_in_the_jungle.jpg/revision/latest?cb=20100127181549");*/
            }
            catch(FormatException res)
            {
                
            }
            ///<summary>
            ///if user selects img1 update profile image to img1
            /// </summary>
            img1.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    ImgSrc = (Xamarin.Forms.UriImageSource)img1.Source;
                    SrcString = ImgSrc.Uri.ToString();
                    
                    try
                    {
                        Debug.WriteLine(HttpUtils.PostInfo(new List<KeyValuePair<string, string>> {
                            new KeyValuePair<string, string>("user_id", ActiveUser.Id),
                            new KeyValuePair<string, string>("user_profile_picture", SrcString)
                         }, "http://haydenszymanski.me/softeng05/update_user_profile_img.php").ResponseSuccess);

                        //Navigation.PushAsync()
                    }
                    catch (FormatException res)
                    {

                    }
                    //Navigation.PushAsync(new ProfilePage(ActiveUser));
                    Navigation.InsertPageBefore(new ProfilePage(ActiveUser), Navigation.NavigationStack.First());
                    Navigation.PopToRootAsync();
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

                    try
                    {
                        Debug.WriteLine(HttpUtils.PostInfo(new List<KeyValuePair<string, string>> {
                            new KeyValuePair<string, string>("user_id", ActiveUser.Id),
                            new KeyValuePair<string, string>("user_profile_picture", SrcString)
                         }, "http://haydenszymanski.me/softeng05/update_user_profile_img.php").ResponseSuccess);

                        //Navigation.PushAsync()
                    }
                    catch (FormatException res)
                    {

                    }
                    
                    Navigation.InsertPageBefore(new ProfilePage(ActiveUser), Navigation.NavigationStack.First());
                    Navigation.PopToRootAsync();
                })
            });
          
        }

    }
}
