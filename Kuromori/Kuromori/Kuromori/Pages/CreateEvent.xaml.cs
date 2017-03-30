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

namespace Kuromori
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateEvent : ContentPage
    {
        public EBEvent temp { get; set; }

        public CreateEvent(User user)
        {
            InitializeComponent();
            
           // Title.Text = temp.NameText;
           // Description.Text = temp.DescriptionText;

            

           
        }
        public void CreateEventClick(object sender, EventArgs args)
        {
            Debug.WriteLine(HttpUtils.PostInfo(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("event_title", Title.Text),
                new KeyValuePair<string, string>("event_desc", Description.Text),
                new KeyValuePair<string, string>("event_url", RegisterURL.Text),
                new KeyValuePair<string, string>("event_date", Date.Text),
                new KeyValuePair<string, string>("event_img", EBImage.Text),
                new KeyValuePair<string, string>("event_topic", Topic.Text),
                new KeyValuePair<string, string>("speaker_name", SpeakerName.Text),
                new KeyValuePair<string, string>("speaker_desc", SpeakerDesc.Text),
                new KeyValuePair<string, string>("speaker_img", SpeakerImg.Text)
            }, "http://haydenszymanski.me/softeng05/create_event.php").ResponseSuccess);
            Navigation.PopToRootAsync();
            /*Task.Run(async () =>
           {
               temp = await HttpUtils.GetEBEventData();
               Device.BeginInvokeOnMainThread(() =>
               {
                  

               });

           });*/
        }


    }
}


