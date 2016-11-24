using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Diagnostics;




namespace theCircuitLive
{
    /// <summary>
    /// Non static Webservices class 
    /// TODO: Implement non-static details as needed
    /// </summary>
    public class WebServices
    {
        /// <summary>
        /// stub constructor
        /// TODO: IF used replace this comment with its function
        /// </summary>
        public WebServices()
        {
            
        }

    }

    /// <summary>
    /// Anything that can be used statically goes in here
    /// TODO: Add methods to handle post and get on webpages
    /// </summary>
    public static class ConnectionManager
    {
        /// <summary>
        /// Async: Returns a string of html from a given url
        /// TODO: 
        /// </summary>
        /// <param name="url">url address</param>
        /// <returns>string of html contents</returns>
        public static async Task<string> UrlToHtml(string url)
        {
            using (var client = new HttpClient())
            {
                using (var page = await client.GetAsync(new Uri(url)))
                {
                    return await page.Content.ReadAsStringAsync();
                }   
            }
        }

        /// <summary>
        /// testing for json retrieval
        /// TODO: Remove this method and all dependencies
        /// </summary>
        /// <returns></returns>
        public static async Task<string> Jsonget()
        {
            string jsonObject;
            using (var client = new HttpClient())
            {
                using (var page = await client.GetAsync(new Uri("http://haydenszymanski.me/softeng05/Example.php")))
                {
                    jsonObject = JsonConvert.SerializeObject(page.Content.ReadAsStringAsync());
                }
            }
            
           return jsonObject;
        }

        /// <summary>
        /// Retrieves the event information (see Events file for structure) for the events
        /// </summary>
        /// <returns></returns>
        public static async Task<Events> GetEventData()
        {
           string ResponseContent;
            
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://haydenszymanski.me/softeng05/Example2.php");
                response.EnsureSuccessStatusCode();
                ResponseContent = await response.Content.ReadAsStringAsync();
            }
            Events tempEvent = JsonConvert.DeserializeObject<Events>(ResponseContent);

            return tempEvent;

        }

    }

    
}
