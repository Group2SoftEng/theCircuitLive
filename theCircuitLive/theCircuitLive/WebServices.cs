using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using Xamarin.Forms;


/**
 * TO DO
 * SET UP WITH PHP
 * 
 * */ 
namespace theCircuitLive
{
    /**
     * Use this class for whatever, if you can't get away with connection Manager, this should
     * handle everything else.
     * 
     * */
    public class WebServices
    {
        public WebServices()
        {
            
        }

    }

    /**
     * Anything that can be used statically. If using httpclient in this class make sure to do it
     * through something like using, else you'll have to manually dispose it.
     **/
    public static class ConnectionManager
    {
        /**
         * @param : String
         * @return : Task<string>
         * */
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
