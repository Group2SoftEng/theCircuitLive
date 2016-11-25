using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Kuromori.DataStructure;
using Newtonsoft.Json;

namespace Kuromori.InfoIO
{
    public static class EventConnection
    {
        /// <summary>
        /// Retrieves the event information (see Events file for structure) for the events
        /// </summary>
        /// <returns></returns>
        public static async Task<Events> GetEventData()
        {
            string responseContent;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://haydenszymanski.me/softeng05/Example2.php");
                response.EnsureSuccessStatusCode();
                responseContent = await response.Content.ReadAsStringAsync();
            }
            Events tempEvent = JsonConvert.DeserializeObject<Events>(responseContent);

            return tempEvent;

        }
    }
}
