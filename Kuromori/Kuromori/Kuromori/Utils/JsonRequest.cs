using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Kuromori.DataStructure;
using Newtonsoft.Json;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace Kuromori.Utils
{
	public static class JsonRequest
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
				HttpResponseMessage response = await client.GetAsync("http://haydenszymanski.me/softeng05/get_events.php");
				response.EnsureSuccessStatusCode();
				responseContent = await response.Content.ReadAsStringAsync();
			}
			Events tempEvent = JsonConvert.DeserializeObject<Events>(responseContent);
			return tempEvent;
		}


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Type of jsonobject returned</typeparam>
        /// <param name="pairs">Post key-value pairs</param>
        /// <param name="url">url for the post request</param>
        /// <returns></returns>
		public static async Task<T> GetJsonData<T>(List<KeyValuePair<string, string>> pairs, string url)
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

		public static async Task<string> UrlToHtml(Uri url)
		{
			using (var client = new HttpClient())
			{
				using (var page = await client.GetAsync(url))
				{
					return await page.Content.ReadAsStringAsync();
				}
			}
		}
	}
}

