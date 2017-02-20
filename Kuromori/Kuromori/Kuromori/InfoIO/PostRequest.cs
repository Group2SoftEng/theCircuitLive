using System;
using System.Net.Http;
using System.Collections.Specialized;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Kuromori.InfoIO
{
	public class PostRequest
	{
		public void Send_Post(string user, string pass)
		{
			var client = new HttpClient();
			var pairs = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("username", user),
				new KeyValuePair<string, string>("password", pass)
			};

			var content = new FormUrlEncodedContent(pairs);

			var response = client.PostAsync(
				"http://haydenszymanski.me/softeng05/register_user.php"
				, content).Result;

			if (response.IsSuccessStatusCode)
			{
				var contents = response.Content.ReadAsStringAsync();
				Debug.WriteLine(contents.Result);
			}


		}
	}
}
