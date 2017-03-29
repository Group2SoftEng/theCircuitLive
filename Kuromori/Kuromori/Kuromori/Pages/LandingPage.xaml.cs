using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kuromori.DataAdapters;
using Kuromori.DataStructure;
using Kuromori.InfoIO;


using Xamarin.Forms;

namespace Kuromori
{
	public partial class LandingPage : ContentPage
	{
		public LandingPage(User user)
		{
			InitializeComponent();
			Events temp;

			Task.Run(async () => // body runs asynchronously 
			{
				temp = await HttpUtils.GetJsonInfo<Events>(new List<KeyValuePair<string, string>>{  // get events and set them to temp
				new KeyValuePair<string, string>("", "")}, "http://haydenszymanski.me/softeng05/get_events.php");
				Device.BeginInvokeOnMainThread(() => // runs body after await operator
				{
					EventInformation.CurrentEvents = temp.EventSet; // set displayed event list to the eventset of temp
					foreach (Event ev in EventInformation.CurrentEvents)
					{
						Layout.Children.Add(new UserRegisteredEvents(ev, user.Id)); // for each event add a new eventview for that event to the layout
					}
				});
			});

			ToolbarItem EditButton = new ToolbarItem();
			EditButton.Clicked += (sender, e) =>
			{
				Navigation.PushAsync(new ProfilePage(user));
			};

			EditButton.Text = "Edit Profile";
			ToolbarItems.Add(EditButton);

			String userType = "organizer";

			if (userType.Equals("organizer"))
			{
				ToolbarItem CreateEventButton = new ToolbarItem();
				CreateEventButton.Clicked += (sender, e) =>
				{
					// Navigation.PushAsync(new createEvent(User))
				};
				EditButton.Text = "Create Event";
				ToolbarItems.Add(EditButton);
			}


		}
	}
}
