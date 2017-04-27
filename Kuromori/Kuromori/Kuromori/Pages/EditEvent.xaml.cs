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

namespace Kuromori.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditEvent : ContentPage
    {
        Event Ev;
		User User;
        UriImageSource ImgSrc;
        string SrcString;
        public EditEvent(Event ev, User user)
        {
            InitializeComponent();
            Ev = ev;
			User = user;
            Title.Text = ev.EventTitle;
            Topic.Text = ev.EventTopic;
            Description.Text = ev.EventDescription;
            RegisterURL.Text = ev.EventSignUpUrl;
            //Date.Date = ev.EventDate;
            //EBImage.Text = ev.EventImg;

            ToolbarItem DeleteEventButton = new ToolbarItem();
            DeleteEventButton.Clicked += (sender, e) =>
            {
                DeleteEvent(sender, e);
                Navigation.PopToRootAsync();
            };

            DeleteEventButton.Text = "Cancel Event";
            ToolbarItems.Add(DeleteEventButton);

            /*img1.Source = new Uri("http://haydenszymanski.me/softeng05/images/ProfileImages/usr_antelope.jpeg");
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
            });*/
        }
   

        async void OnSubmitClick(object sender, EventArgs args)
        {
			String n = (HttpUtils.PostInfo(new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("event_id", Ev.EventId),
				new KeyValuePair<string, string>("event_title", Title.Text),
				new KeyValuePair<string, string>("event_topic", Topic.Text),
				new KeyValuePair<string, string>("event_desc", Description.Text),
				new KeyValuePair<string, string>("event_url", RegisterURL.Text),
				new KeyValuePair<string, string>("event_date", Date.Date.ToString("yyyy-MM-dd")),
				//new KeyValuePair<string, string>("event_img", EBImage.Text),
			}, "http://haydenszymanski.me/softeng05/update_event.php").ResponseInfo);
			Navigation.InsertPageBefore(new LandingPage(User), Navigation.NavigationStack.First());
            await Navigation.PopToRootAsync();
        }

		void OnCancelClick(object sender, EventArgs args)
		{
			Navigation.PopAsync();
		}
        void DeleteEvent(object sender, EventArgs args)
        {
            Debug.WriteLine(HttpUtils.PostInfo(new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("event_id", Ev.EventId),
            }, "http://haydenszymanski.me/softeng05/delete_event.php").ResponseSuccess);

        }
    }
}
