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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventPage : ContentPage
    {
        public Events temp { get; set; }
        /// <summary>
        ///   This page is a container for the event cards that will be shown on the screen
        /// </summary>
        public EventPage()
        {
            //StackLayout layout = this.FindByName<StackLayout>("Layout");
            InitializeComponent();
            ScrollView scroll = this.FindByName<ScrollView>("scroll");
            Debug.WriteLine(scroll.ScrollY);

            Task.Run(async() =>
            {
                temp = await EventConnection.GetEventData();

                Device.BeginInvokeOnMainThread(() =>
                {
					EventInformation.CurrentEvents = temp.EventSet;
					foreach (Event ev in EventInformation.CurrentEvents)
                    {
                       Layout.Children.Add(new EventView(ev));
                    }
                });
            });

        }
    }
}
