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
    /**
     * Methods that work with httpclient class
     * Anything that manages network connections on all platforms
     * for platform specific things create an interface in this file
     * and implement on other projects seperately. 
     * 
     **/
    public class ConnectionManager
    {
        /**
         * Given a string that can be parsed to a compatible url, returns
         * a string representing the html on that page
         * */
        public async Task<string> urlToHtml(string url)
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
