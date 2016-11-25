using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kuromori.DataStructure;
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

            eventTopic.Text += anEvent.EventTopic;
            eventDesc.Text = anEvent.EventDescription;
            eventDate.Text = anEvent.EventDate;
            eventImage.Source = new Uri(anEvent.EventImg);
            
            
           

            

        }
    }
}
