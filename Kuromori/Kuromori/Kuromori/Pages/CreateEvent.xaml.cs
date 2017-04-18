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
    public partial class CreateEvent : ContentPage
    {
        User User;
        UriImageSource ImgSrc;
        string SrcString;

        public CreateEvent(User user)
        {
            InitializeComponent();
            User = user;

            img1.Source = new Uri("http://haydenszymanski.me/softeng05/images/ProfileImages/usr_antelope.jpeg");
            img2.Source = new Uri("http://haydenszymanski.me/softeng05/images/ProfileImages/usr_chihuahua.jpeg");
            img3.Source = new Uri("http://haydenszymanski.me/softeng05/images/ProfileImages/usr_duckling.jpeg");
            img4.Source = new Uri("http://haydenszymanski.me/softeng05/images/ProfileImages/usr_horses.jpg");
            img5.Source = new Uri("http://haydenszymanski.me/softeng05/images/ProfileImages/usr_giraffe.jpg");
            img6.Source = new Uri("http://haydenszymanski.me/softeng05/images/ProfileImages/usr_hedgehog.jpeg");
            img7.Source = new Uri("http://haydenszymanski.me/softeng05/images/ProfileImages/usr_bunny.jpeg");

            ///<summary>
            ///if user selects img1 create event with image to img1
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
            ///if user selects img2 update create event with image to img2
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
            ///if user selects img3 create event with image to img3
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
            ///if user selects img4 create event with image to img4
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
            ///if user selects img5 create event with image to img5
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
            ///if user selects img6 create event with image to img6
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
            ///if user selects img7 create event with image to img7
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
		/// Creates the event click.
		/// When the submit button is clicked we post all the fields from the text fields as a post array to
		/// the create_event.php url. Currently there is NO client side validation, meaning this is going to be
		/// vulnerable to injection
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
        public async void CreateEventClick(object sender, EventArgs args)
        {
           String n = (HttpUtils.PostInfo(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("event_title", Title.Text),
                new KeyValuePair<string, string>("organizer_id", User.Id ),
                new KeyValuePair<string, string>("event_desc", Description.Text),
                new KeyValuePair<string, string>("event_url", RegisterURL.Text),
				new KeyValuePair<string, string>("event_date", Date.Date.ToString("yyyy-MM-dd")),
                new KeyValuePair<string, string>("event_img", SrcString),
                new KeyValuePair<string, string>("event_topic", Topic.Text)
                //new KeyValuePair<string, string>("speaker_name", SpeakerName.Text),
                //new KeyValuePair<string, string>("speaker_desc", SpeakerDesc.Text),
                //new KeyValuePair<string, string>("speaker_img", SpeakerImg.Text)
			}, "http://haydenszymanski.me/softeng05/create_event.php").ResponseInfo);

			if (await DisplayAlert("Add Organizer", "Add Organizer?", "Yes", "No"))
			{
				await Navigation.PushAsync(new AddSpeakerPage());
			}
			else
			{
				Navigation.InsertPageBefore(new LandingPage(User), Navigation.NavigationStack.First());
				await Navigation.PopToRootAsync();
	            //await Navigation.PopToRootAsync();
			}
            /*Task.Run(async () =>
           {
               temp = await HttpUtils.GetEBEventData();
               Device.BeginInvokeOnMainThread(() =>
               {
                  

               });

           });*/
        }


    }
}


