using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuromori.DataStructure
{
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
}
