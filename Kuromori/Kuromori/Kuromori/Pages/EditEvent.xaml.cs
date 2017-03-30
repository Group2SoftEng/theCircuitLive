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
        public EditEvent(Event ev)
        {
            InitializeComponent();
            Ev = ev;
            Title.Text = ev.EventTitle;
            Topic.Text = ev.EventTopic;
            Description.Text = ev.EventDescription;
            RegisterURL.Text = ev.EventSignUpUrl;
            Date.Text = ev.EventDate;
            EBImage.Text = ev.EventImg;
            

        }
   

        void OnSubmitClick(object sender, EventArgs args)
        {
            //Debug.WriteLine(Ev.EventId);
            Debug.WriteLine(HttpUtils.PostInfo(new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("event_id", Ev.EventId),
                new KeyValuePair<string, string>("event_title", Title.Text),
                new KeyValuePair<string, string>("event_topic", Topic.Text),
                new KeyValuePair<string, string>("event_desc", Description.Text),
                new KeyValuePair<string, string>("event_url", RegisterURL.Text),
                new KeyValuePair<string, string>("event_date", Date.Text),
                new KeyValuePair<string, string>("event_img", EBImage.Text)
            }, "http://haydenszymanski.me/softeng05/update_event.php").ResponseSuccess);
            Navigation.PopToRootAsync();
            //Navigation.InsertPageBefore(new UserRegisteredEvents(), Navigation.NavigationStack.First());

            /*Task.Run(async () =>
            {
                Ev = await HttpUtils.GetJsonInfo<Event>(new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("event_id", Ev.EventId),
                }, "http://haydenszymanski.me/softeng05/get_single_event.php");
                Device.BeginInvokeOnMainThread(() =>
                {
                    Ev.EventTitle = Title.Text;
                    Ev.EventTopic = Topic.Text;
                    Ev.EventDescription = Description.Text;
                    Ev.EventSignUpUrl = RegisterURL.Text;
                    Ev.EventDate = Date.Text;
                    Ev.EventImg = EBImage.Text;

                    Navigation.PopToRootAsync();
                });
            });*/
        }
    }
}
