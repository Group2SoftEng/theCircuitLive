using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using Xamarin.Forms;



namespace theCircuitLive
{
    /// <summary>
    /// Non static Webservices class 
    /// TODO: Implement non-static details as needed
    /// </summary>
    public class WebServices
    {
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
        public static async Task<string> urlToHtml(string url)
        {
            using (var client = new HttpClient())
            {
                using (var page = await client.GetAsync(new Uri(url)))
                {
                    return await page.Content.ReadAsStringAsync();
                }   
            }
        }

    }

    
}
