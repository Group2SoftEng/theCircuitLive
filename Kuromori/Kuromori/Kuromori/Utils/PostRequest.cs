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

	    /// <summary>
	    ///   PostResponseItem : List<KeyValuePair<string,string>> (pairs), string (url)
	    ///   Given a list of keyvalue pairs that are strings encode that list as url content
	    ///   Creates a postrequest with encoded url content representing the post array,
	    ///   returns an object representing the request response from the html page and success code
	    /// </summary>
		public PostResponseItem PostInfo(List<KeyValuePair<string,string>> pairs, string url)
		{
			PostResponseItem result = new PostResponseItem();
			var client = new HttpClient();
			var content = new FormUrlEncodedContent(pairs);

			var response = client.PostAsync(url, content).Result;
			if (response.IsSuccessStatusCode)
			{
				var contents = response.Content.ReadAsStringAsync();
				Debug.WriteLine(contents.Result);
				result.ResponseSuccess = response.IsSuccessStatusCode;
				result.ResponseInfo = contents.Result;
			}
			client.Dispose();

			return result;
		}
	}
}
