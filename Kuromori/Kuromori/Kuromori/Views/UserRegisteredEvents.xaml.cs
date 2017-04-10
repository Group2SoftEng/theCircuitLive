using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kuromori.DataStructure;
using Kuromori.Pages;

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
		Event Ev;
		User OwnerUser;

        public UserRegisteredEvents(Event ev, User ownerUser)
        {
            InitializeComponent();

			OwnerUser = ownerUser;
			Ev = ev;

			EventDescription.Text = ev.EventDescription;
			EventName.Text = ev.EventTopic;
			EventDate.Text = ev.EventDate;

			try
			{
				SpeakerImage.Source = new Uri(ev.EventSpeakers.First().SpeakerImg);

			}
			catch (Exception res)
			{
				SpeakerImage.Source = ImageSource.FromFile(("noimage.png"));
			}


        }
		void EventDetails(object sender, EventArgs e)
		{
			if (OwnerUser.Id.Equals(Ev.OrganizerId))
			{
				Navigation.PushAsync(new EditEvent(Ev, OwnerUser));
			}

			else
			{
				Navigation.PushAsync(new NonOwnedEventPage(Ev));

			}

			
		}
    }
}
