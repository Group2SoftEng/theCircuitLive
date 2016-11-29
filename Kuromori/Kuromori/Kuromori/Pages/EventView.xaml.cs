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
    /// <summary>
    /// Codebehind for Event View. Renders an event which is :
    /// 3 Labels : eventTopic, eventDesc, eventDate
    /// 1 Image WITH touch support : eventImage 
    /// Any number of Speaker Views in a stack layout
    /// </summary>
    public partial class EventView : Frame
    {
        /// <summary>
        /// A Frame that contains a grid layout, with the last column being
        /// a stack layout with any number of speaker views.
        /// </summary>
        /// <param name="anEvent">Event object to be rendered on event page</param>
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
           
            eventImage.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {

                    try
                    {
                        Device.OpenUri(new Uri(anEvent.EventSignUpUrl));
                    }
                    catch (FormatException res)
                    {
                        
                    }
                })
            });


            //Set image to the event image, if there is an error (no image, or malformed uri)
            //Set a default image. 
            try
            {
                eventImage.Source = new Uri(anEvent.EventImg);

            }
            catch (FormatException res)
            {
                eventImage.Source = ImageSource.FromFile(("noimage.png"));
            }

            //Only show speakers label if there are any speaker for this event
            if (anEvent.EventSpeakers.Length > 0)
            {
                this.FindByName<Label>("Speaker").Text = "Speakers";
            }

            //For every speaker create a speaker form them under this event
            foreach (Speaker speaker in anEvent.EventSpeakers)
            {
                this.FindByName<StackLayout>("Layout").Children.Add(new SpeakerView(speaker));
            }
            
           

            

        }
    }
}
