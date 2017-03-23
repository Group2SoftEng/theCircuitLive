using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Diagnostics;
using Kuromori.DataStructure;
using System.Threading;
using Kuromori;
using Kuromori.InfoIO;
using Kuromori.DataAdapters;
using Kuromori.Pages;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;


namespace UITest1
{
    class Iteration2WhiteBox
    {
        [TestFixture(Platform.Android)]
        [TestFixture(Platform.iOS)]
        public class WhiteBox
        {
            IApp app;
            Platform platform;

            public WhiteBox(Platform platform)
            {
                this.platform = platform;
            }

            [SetUp]
            public void BeforeEachTest()
            {
                app = AppInitializer.StartApp(platform);
            }

            //App launches
            [Test]
            public void WhiteBoxAppLaunches()
            {
                app.Screenshot("Main");
            }

            [Test]
            public void JsonRequest_GetEventData()
            {
                var temp = JsonRequest.GetEventData();
                Console.WriteLine(temp.CreationOptions);
                Console.WriteLine(temp.Exception);
                Console.WriteLine(temp.IsCanceled);
                Console.WriteLine(temp.IsCompleted);
                Console.WriteLine(temp.IsFaulted);
                Console.WriteLine(temp.Result);
                Console.WriteLine(temp.Status);
            }

            //Compares results of a JSONRequest to layout.children type
            [Test]
            public void EventPage_EventPage()
            {
                EventPage evnt = new EventPage();
                

            }
        }
    }
}
