using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuromori.DataStructure
{
    public class Speaker
    {
        /// <summary>
        /// SpeakerId, referencing the speaker_id column
        /// </summary>
        public int SpeakerId { get; set; }

        /// <summary>
        /// SpeakerName, referencing the speaker_name column
        /// </summary>
        public string SpeakerName { get; set; }

        /// <summary>
        /// SpeakerImg, referencing the speaker_img column
        /// </summary>
        public string SpeakerImg { get; set; }

        /// <summary>
        /// link to speaker website
        /// </summary>
        public string SpeakerUrl { get; set; }

        /// <summary>
        /// SpeakerDescription, referencing the speaker_desc column 
        /// </summary>
        public string SpeakerDescription { get; set; }
    }
}
