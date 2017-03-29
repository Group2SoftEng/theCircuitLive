using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kuromori.DataStructure;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kuromori
{
    /// <summary>
    ///   This page is part of one of our imcomplete user stories. It is not going to be tested this iteration
    ///   Its intention is to show events associated with a user
    ///   NOTE: Before proper implementation we need to integrate eventbrite api
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserRegisteredEvents : ContentView
    {
		string OrganizerId;
		Event Ev;

        public UserRegisteredEvents(Event ev, string organizerId)
        {
            InitializeComponent();

			OrganizerId = organizerId;
			Ev = ev;

			EventDescription.Text = ev.EventDescription;
			EventName.Text = ev.EventTopic;
			EventDate.Text = ev.EventDate;

			try
			{
				SpeakerImage.Source = new Uri(ev.EventSpeakers.First().SpeakerImg);

			}
			catch (FormatException res)
			{
				SpeakerImage.Source = ImageSource.FromFile(("noimage.png"));
			}


        }
		void EventDetails(object sender, EventArgs e)
		{
			if (OrganizerId.Equals(Ev.OrganizerId))
			{

			}

			else
			{
				Navigation.PushAsync(new NonOwnedEventPage(Ev));

			}

			
		}
    }
}
