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
    public class blah
    {
        HttpClient k = new HttpClient();
        public blah()
        {
            
        }
        public async Task<string> Download()
        {
            using (var client = new HttpClient())
            {
                using (var r = await client.GetAsync(new Uri("https://php.radford.edu/~softeng05/sample.php")))
                {
                    string result = await r.Content.ReadAsStringAsync();
                    return result;
                }
            }
            

        }

    }

    public interface ConnectionManager
    {

        String get();
        Boolean pageCon();
    }
}
