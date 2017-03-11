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

namespace Kuromori.InfoIO
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

		public static async Task<User> GetUserData(List<KeyValuePair<string,string>> pairs, string url)
		{
			string responseContent;
			using (HttpClient client = new HttpClient())
			{
				var content = new FormUrlEncodedContent(pairs);
				HttpResponseMessage response = await client.PostAsync(url, content);
				response.EnsureSuccessStatusCode();
				responseContent = await response.Content.ReadAsStringAsync();
			}
			User tempUser = JsonConvert.DeserializeObject<User>(responseContent);
			return tempUser;

		}

		public static async Task<T> GetUserData<T>(List<KeyValuePair<string, string>> pairs, string url)
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

		struct Speaker
		{
			public string Name { get; set; }
			public string Desc { get; set; }
			public string Pict { get; set; }

			public Speaker(string _n, string _d, string _p)
			{
				Name = _n;
				Desc = _d;
				Pict = _p;
			}
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

