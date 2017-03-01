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
        public EventPage()
        {
            InitializeComponent();
            ScrollView scroll = this.FindByName<ScrollView>("scroll");
            Debug.WriteLine(scroll.ScrollY);

            StackLayout layout = this.FindByName<StackLayout>("Layout");
            Task.Run(async() =>
            {
                Events temp = await EventConnection.GetEventData();
                EventInformation.CurrentEvents = temp.EventSet;
                Device.BeginInvokeOnMainThread(() =>
                {
                    foreach (Event ev in EventInformation.CurrentEvents)
                    {
                        layout.Children.Add(new EventView(ev));
                    }
                });
            });

        }
    }
}
