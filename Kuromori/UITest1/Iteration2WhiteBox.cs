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

           
            public String JsonRequest_GetEventData()
            {
                var temp = JsonRequest.GetEventData();
                String eventDescription = temp.Result.EventSet[0].EventDescription;
                return eventDescription;
             }



            //Compares results of a JSONRequest to layout.children type
            [Test]
            public void EventPage_EventPage()
            {
                EventPage evnt = new EventPage();

                //Tests JsonRequest and verifies it's displayed in the layout
                String eventDescription = JsonRequest_GetEventData();
                app.Tap(c => c.Marked("Let's get started"));
                app.Tap(c => c.Marked("Guest Access"));
                app.ScrollTo(eventDescription);//Does the JSON request match what is in the layout for the app
            }

            [Test]
            public void JsonRequest_GetUserData()
            {   
                List<KeyValuePair<string,string>> userList = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> testUsers = new KeyValuePair<string, string>("TestUser", "TestUser1!");
                userList.Add(testUsers);
                //var Json = JsonRequest.GetUserData();
                var result = JsonRequest.GetUserData(userList, "http://haydenszymanski.me/softeng05/get_events.php");
                Assert.IsTrue(result.Result.Email == "foo@bar.com");
            }

            [Test]
            public void AdminSignInPage_OnClickSignIn()
            {
                AdminSignInPage admin = new AdminSignInPage();
                //admin.OnSignInClick();
            }

            //For Admin class, set username/password, get username/password
        }
    }
}
