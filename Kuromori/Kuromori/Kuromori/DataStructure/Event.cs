using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuromori.DataStructure
{
    /// <summary>
    /// Defines the structure of information for a particular event
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
}
