using Kuromori.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Kuromori.InfoIO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kuromori
{
	/// <summary>
	/// Wrapper for events
	/// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventPage : ContentPage
    {
        public Events temp { get; set; }

        /// <summary>
        ///   This page is a container for the event cards that will be shown on the screen
        /// </summary>
        public EventPage()
        {
            InitializeComponent();
            Title = "Event Details";

            Task.Run(async() => // body runs asynchronously 
            {
				temp = await HttpUtils.GetJsonInfo<Events>(new List<KeyValuePair<string, string>>{  // get events and set them to temp
				new KeyValuePair<string, string>("", "")}, "http://haydenszymanski.me/softeng05/get_events.php");
                Device.BeginInvokeOnMainThread(() => // runs body after await operator
                {
					EventInformation.CurrentEvents = temp.EventSet; // set displayed event list to the eventset of temp
					foreach (Event ev in EventInformation.CurrentEvents)
                    {
                       Layout.Children.Add(new EventView(ev)); // for each event add a new eventview for that event to the layout
                    }
                });
            });

        }
    }
}
