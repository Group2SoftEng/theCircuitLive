using System.Threading.Tasks;
using Kuromori.DataStructure;
using Kuromori.InfoIO;

namespace Kuromori.DataAdapters
{
    /// <summary>
    /// 
    /// </summary>
    public static class EventAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<Event[]> LoadEvents()
        {
            Events events = await EventConnection.GetEventData();
            return events.EventSet;
        }
    }
}
