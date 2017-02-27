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

		public string User_Login(string user, string pass)
		{

			string webResponse = "";

			var client = new HttpClient();
			var pairs = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("username", user),
				new KeyValuePair<string, string>("password", pass)
			};

			var content = new FormUrlEncodedContent(pairs);

			var response = client.PostAsync(
				"http://haydenszymanski.me/softeng05/login_user.php"
				, content).Result;

			if (response.IsSuccessStatusCode)
			{
				var contents = response.Content.ReadAsStringAsync();
				Debug.WriteLine(contents.Result);
				webResponse = contents.Result;
			}
			client.Dispose();
			return webResponse;
		}

		public Boolean UserExists(string user, string pass)
		{

			Boolean res = false;

			var client = new HttpClient();
			var pairs = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("username", user),
				new KeyValuePair<string, string>("password", pass)
			};

			var content = new FormUrlEncodedContent(pairs);

			var response = client.PostAsync(
				"http://haydenszymanski.me/softeng05/validate_user.php"
				, content).Result;

			if (response.IsSuccessStatusCode)
			{
				var contents = response.Content.ReadAsStringAsync();
				Debug.WriteLine(contents.Result);
				if (contents.Result.Equals("success"))
				{
					res = true;
				}
			}
			client.Dispose();
			return res;
		}

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
