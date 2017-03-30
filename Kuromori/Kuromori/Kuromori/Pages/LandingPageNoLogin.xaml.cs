using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kuromori.DataAdapters;
using Kuromori.DataStructure;
using Kuromori.InfoIO;


using Xamarin.Forms;

namespace Kuromori
{
    public partial class LandingPageNoLogin : ContentPage
    {
        public LandingPageNoLogin()
        {
            InitializeComponent();
            Events temp;
            Title = "The Circuit Live";

            Task.Run(async () => // body runs asynchronously 
            {
                temp = await HttpUtils.GetJsonInfo<Events>(new List<KeyValuePair<string, string>>{  // get events and set them to temp
				new KeyValuePair<string, string>("", "")}, "http://haydenszymanski.me/softeng05/get_events.php");
                Device.BeginInvokeOnMainThread(() => // runs body after await operator
                {
                    EventInformation.CurrentEvents = temp.EventSet; // set displayed event list to the eventset of temp
                    foreach (Event ev in EventInformation.CurrentEvents)
                    {
                        Layout.Children.Add(new UserRegisteredEvents(ev, "-1")); // for each event add a new eventview for that event to the layout
                    }
                });
            });

            

            Task.Run(async () =>
            {
                PostResponseItem userResponse = await HttpUtils.AsyncPostInfo(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("id", "-1")
                }, "http://haydenszymanski.me/softeng05/user_by_id.php");

                Device.BeginInvokeOnMainThread(() =>
                {
                    string userType = userResponse.ResponseInfo;

                    
                });
            });


        }
    }
}
