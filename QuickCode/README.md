## Html Parsing Sandbox // Updated, using Linq now.

All of the using directives that you'll need are there. If you want to create a project around this in Visual Studio I used the Console Application template. If you need to import anything ( your probably will) the things that youll need is System.Net and Html agility pack. Everything else should be part of .net and all you will then need to do is copy and paste this code.

### Challenges.

  * Currently on the TheCircuitLive event page the speaker info and event dates have the same surrounding tags, so it's likely going to require us to keep track of the order in which the two of those come int
  * Multiple speakers will be needed eventually, which is likely going to be hard to implement.
  

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

			///// asynchronously retrieve html from the event page, clean up excess white space tabs and newlines 
			///// and then return an html object
			HtmlDocument doc = (Task.Run(async () =>
			{
				string body = await UrlToHtml(new Uri("http://thecircuitlive.com/index.php/events/"));
				HtmlDocument tdoc = new HtmlDocument();
				tdoc.LoadHtml(body);
				return tdoc;
			}).Result);
			doc.OptionFixNestedTags = true;

			var Name =
				(from name in doc.DocumentNode.Descendants("h3")
				 where name.GetAttributeValue("class", "").Equals("caption-title")
				 select name.InnerText).DefaultIfEmpty();

			var Desc =
				(from desc in doc.DocumentNode.Descendants("div")
				 where desc.GetAttributeValue("class", "").Equals("caption")
				 select desc.InnerText).DefaultIfEmpty();

			var PicString =
				(from imgStr in doc.DocumentNode.Descendants("img")
				 where imgStr.GetAttributeValue("class", "").Equals("img-responsive")
				 select imgStr.GetAttributeValue("src", "")).DefaultIfEmpty();


			// This packages the three variables from above into one list of Speakers.
			var Speakers = Name.Zip(Desc.Zip(PicString, (b, c) => new { b, c }),
			  (a, b) => new Speaker(a
									, b.b
			                        , b.c));


			foreach (Speaker n in Speakers)
			{
				Console.WriteLine(n.Name);
				Console.WriteLine(n.Desc);
				Console.WriteLine(n.Pict);
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


```
