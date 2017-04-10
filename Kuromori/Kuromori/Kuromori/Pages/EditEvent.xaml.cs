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
        public EditEvent(Event ev, User user)
        {
            InitializeComponent();
            Ev = ev;
			User = user;
            Title.Text = ev.EventTitle;
            Topic.Text = ev.EventTopic;
            Description.Text = ev.EventDescription;
            RegisterURL.Text = ev.EventSignUpUrl;
            Date.Text = ev.EventDate;
            EBImage.Text = ev.EventImg;
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
				new KeyValuePair<string, string>("event_date", Date.Text),
				new KeyValuePair<string, string>("event_img", EBImage.Text),
			}, "http://haydenszymanski.me/softeng05/update_event.php").ResponseInfo);
			Navigation.InsertPageBefore(new LandingPage(User), Navigation.NavigationStack.First());
            await Navigation.PopToRootAsync();
        }

		void OnCancelClick(object sender, EventArgs args)
		{
			Navigation.PopAsync();
		}
    }
}
