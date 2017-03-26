using System;
using System.Net.Http;
using System.Collections.Specialized;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Kuromori.InfoIO
{
	/// <summary>
	/// Http utils.
	/// This class contains any function that aids with http requests, it also contains classes that returns json types from http requests.
	/// </summary>
	public static class HttpUtils
	{

		/// <summary>
		///   PostResponseItem : List<KeyValuePair<string,string>> (pairs), string (url)
		///   Given a list of keyvalue pairs that are strings encode that list as url content
		///   Creates a postrequest with encoded url content representing the post array,
		///   returns an object representing the request response from the html page and success code
		/// </summary>
		public static PostResponseItem PostInfo(List<KeyValuePair<string, string>> pairs, string url)
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

		/// <summary>
		/// Gets the json info.
		/// </summary>
		/// <returns>The json info.</returns>
		/// <param name="pairs">Pairs.</param>
		/// <param name="url">URL.</param>
		/// <typeparam name="T">List<KeyValuePair<string,string>> : This will be post keyval pairs for the post http request</typeparam>
		public static async Task<T> GetJsonInfo<T>(List<KeyValuePair<string, string>> pairs, string url)
		{
			string responseContent;
			using (HttpClient client = new HttpClient())
			{
				var content = new FormUrlEncodedContent(pairs);
				HttpResponseMessage response = await client.PostAsync(url, content);
				response.EnsureSuccessStatusCode();
				responseContent = await response.Content.ReadAsStringAsync();
			}
			T tempUser = JsonConvert.DeserializeObject<T>(responseContent);
			return tempUser;
		}



	}

}
