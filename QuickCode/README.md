## Html Parsing Sandbox

All of the using directives that you'll need are there. If you want to create a project around this in Visual Studio I used the Console Application template. If you need to import anything ( your probably will) the things that youll need is System.Net and Html agility pack. Everything else should be part of .net and all you will then need to do is copy and paste this code.

```csharp
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using HtmlAgilityPack;
using System.Linq;
using System.Text.RegularExpressions;

namespace HtmlParser
{


	class MainClass
	{
		/// Temporary struct to contain Speaker information
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

		public static void Main(string[] args)
		{
			Regex patter = new Regex(@"(?<=<img src="")(.*)(?="" alt="""")");

			///// asynchronously retrieve html from the event page, clean up excess white space tabs and newlines 
			///// and then return an html object
			HtmlDocument doc = (Task.Run(async () =>
			{
				string body = await UrlToHtml(new Uri("http://thecircuitlive.com/index.php/events/"));
				body = Regex.Replace(body, @"( |\t|\r?\n)\1+", "$1"); // help from stackoverflow
				HtmlDocument tdoc = new HtmlDocument();
				tdoc.LoadHtml(body);
				return tdoc;
			}).Result);
			doc.OptionFixNestedTags = true;
			HtmlNodeCollection SpeakerInfo = doc.DocumentNode.SelectNodes("//h3[@class='caption-title']|//div[@class='caption']|//div//div[@class='circle-inner']");
			////////////////////////////////////////////////
			////////////////////////////////////////////////



			////////////////////////////////////////////////
			////////////////////////////////////////////////
			var name = from title in SpeakerInfo
					   where (title.OuterHtml.Substring(0, 3).Equals("<h3"))
					   select title;


			var desc = from content in SpeakerInfo
					where (content.OuterHtml.Contains(@"<div class=""caption"">"))
					 	  select content;


			var pic = from img in SpeakerInfo
					  where (img.OuterHtml.Contains("circle-inner"))
					  select img;
			///////////////////////////////////////////////////
			//////////////////////////////////////////////////
			 

			// This packages the three variables from above into one list of Speakers.
			var Speakers = name.Zip(desc.Zip(pic,(b, c) => new { b, c }),
			  (a, b) => new Speaker(a.InnerText
			                        , b.b.InnerText
			                        , patter.Match(b.c.ChildNodes.First().InnerHtml).Value));
			

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


		/// <summary>
		/// Adds the event value.
		/// </summary>




	}


}
```
