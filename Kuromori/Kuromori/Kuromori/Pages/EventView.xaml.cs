using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kuromori.DataStructure;
using Kuromori.Pages;
using Xamarin.Forms;


namespace Kuromori
{
    public partial class EventView : Frame
    {
        public EventView(Event anEvent)
        {
            InitializeComponent();
            Label eventTopic = this.FindByName<Label>("Topic");
            Label eventDesc = this.FindByName<Label>("Description");
            Label eventDate = this.FindByName<Label>("Date");
            Image eventImage = this.FindByName<Image>("Image");
            eventTopic.FontSize = 16;
            eventTopic.FontAttributes = FontAttributes.Bold;

            eventTopic.Text += anEvent.EventTopic;
            eventDesc.Text = anEvent.EventDescription;
            eventDate.Text = anEvent.EventDate;
            try
            {
                eventImage.Source = new Uri(anEvent.EventImg);

            }
            catch (FormatException test)
            {
                eventImage.Source = ImageSource.FromFile(("noimage.png"));
            }

            if (anEvent.EventSpeakers.Length > 0)
            {
                this.FindByName<Label>("Speaker").Text = "Speakers";
            }
            foreach (Speaker speaker in anEvent.EventSpeakers)
            {
                this.FindByName<StackLayout>("Layout").Children.Add(new SpeakerView(speaker));
            }
            
           

            

        }
    }
}
