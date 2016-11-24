using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace theCircuitLive
{
    /// <summary>
    /// Work in progress class intended to expose events globally, while periodically updating info
    /// </summary>
    public static class EventInfo
    {
        /// <summary>
        /// get Event data ( unwrap events, and get the event array )
        /// Call as a task
        /// </summary>
        /// <returns></returns>
        public static async Task<Event[]> LoadEvents()
        {
            Events events = await ConnectionManager.GetEventData();
            return events.EventSet;
        }

        public static List<EventView> GetCards(Event[] events)
        {
            List<EventView> viewList =new List<EventView>();
            foreach (Event ev in events)
            {
                viewList.Add(new EventView(ev.EventTitle, ev.EventDescription, ev.EventDate));
            }
            return viewList;
        }

        public static List<string> getEventNames(Event[] ev)
        {
            List<string> ret = new List<string>();
            foreach (Event e in ev)
            {
                ret.Add(e.EventTitle);
            }
            return ret;
        }




    }


    /// <summary>
    /// Wrapper class for all the Events
    /// </summary>
    public class Events
    {
        /// <summary>
        /// The array of all events ( number of which can be changed in the example2 php file
        /// (switch LIMIT 4 to limit number you want to be used by the app)
        /// </summary>
        public Event[] EventSet;

        public List<Event> getList()
        {
            return EventSet.ToList();
        }
    }

    /// <summary>
    /// Class representing a single event
    /// </summary>
    public class Event
    {
        /// <summary>
        /// EventId, referencing the event_id column
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// EventTitle, referencing the event_title column
        /// </summary>
        public string EventTitle { get; set; }

        /// <summary>
        /// EventImg, referencing the event_img column
        /// </summary>
        public string EventImg { get; set; }

        /// <summary>
        /// EventTopic, referencing the event_topic column
        /// </summary>
        public string EventTopic { get; set; }

        /// <summary>
        /// EventDate, referencing the event_date column
        /// </summary>
        public string EventDate { get; set; }

        /// <summary>
        /// EventDescription, referencing the event_desc column
        /// </summary>
        public string EventDescription { get; set; }

        /// <summary>
        /// EventSpeakers : This will be an array of all the speakers attending or performing at the event.
        /// </summary>
        public Speaker[] EventSpeakers { get; set; }

        
    }

    /// <summary>
    /// Class representing a single speaker
    /// </summary>
    public class Speaker
    {
        /// <summary>
        /// SpeakerId, referencing the speaker_id column
        /// </summary>
        public int SpeakerId;

        /// <summary>
        /// SpeakerName, referencing the speaker_name column
        /// </summary>
        public string SpeakerName;

        /// <summary>
        /// SpeakerImg, referencing the speaker_img column
        /// </summary>
        public string SpeakerImg;

        /// <summary>
        /// SpeakerDescription, referencing the speaker_desc column 
        /// </summary>
        public string SpeakerDescription;
    }

    /// <summary>
    /// ignore, will be for testing in the future
    /// TODO: Implement tests ( with nunite using [testfixture] and [test]
    /// </summary>
    class ProgramTests
    {

    }

}
