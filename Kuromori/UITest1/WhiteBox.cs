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

namespace Kuromori.DataStructure
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

        //Gets Event, not fully implemented
        [Test]
        public async static void WhiteBoxTest_EventAdapter_LoadEvents_Topic()
        {
            Event[] events = await EventAdapter.LoadEvents();
            Assert.IsTrue("Topic: To be announced" == events[0].EventTopic);
        }

        [Test]
        public async static void WhiteBoxTest_EventAdapter_LoadEvents_Description()
        {
            Event[] events = await EventAdapter.LoadEvents();
            Assert.IsTrue("The Software Engineering II presentation for Iteration 0" == events[1].EventDescription);
            //Not guaranteed to have an event description
        }

        [Test]
        public async static void WhiteBoxTest_EventAdapter_LoadEvents_Date()
        {
            Event[] events = await EventAdapter.LoadEvents();
            Assert.IsTrue("2017-03-24" == events[0].EventDate);
        }

        [Test]
        public async static void WhiteBoxTest_EventAdapter_LoadEvents_Id()
        {
            Event[] events = await EventAdapter.LoadEvents();
            Console.WriteLine(events[0].EventId);
            //Asert.IsTrue("" == events[0].EvenId);
        }

        [Test]
        public async static void WhiteBoxTest_EventAdapter_LoadEvents_Img()
        {
            Event[] events = await EventAdapter.LoadEvents();
            Console.WriteLine(events[0].EventImg);
            //Asert.IsTrue("" == events[0].EventImg);
        }

        [Test]
        public async static void WhiteBoxTest_EventAdapter_LoadEvents_SignUpUrl()
        {
            Event[] events = await EventAdapter.LoadEvents();
            Console.WriteLine(events[0].EventSignUpUrl);
            //Asert.IsTrue("" == events[0].EventSignUpUrl);
        }

        [Test]
        public async static void WhiteBoxTest_EventAdapter_LoadEvents_Speakers()
        {
            Event[] events = await EventAdapter.LoadEvents();
            Console.WriteLine(events[0].EventSpeakers);
            //Asert.IsTrue("" == events[0].EventSpeakers);
        }

        [Test]
        public async static void WhiteBoxTest_EventAdapter_LoadEvents_Title()
        {
            Event[] events = await EventAdapter.LoadEvents();
            Console.WriteLine(events[0].EventTitle);
            //Asert.IsTrue("" == events[0].EventTit;e);
        }

        //ConvertDate() is able to convert DateTime correctly
        [Test]
        public void WhiteBoxTest_EventAdapter_ConvertDate()
        {
            string Test = EventAdapter.ConvertDate("2017-03-24");
            Assert.IsTrue(Test == "March 24, 2017");

        }

        //Gets events from GetEventData() and test an individual event Topic
        [Test]
        public async static void WhiteBoxTest_EventConnection_GetEventData()
        {
            
            Events events = await EventConnection.GetEventData();
            Assert.True("Topic: To be announced" == events.EventSet[0].EventTopic);
        }

        //Tests if Uri is able to be created
        [Test]
        public async static void WhiteBoxAppTest_EventConnection_UrlToHtml()
        {
            Uri address = new Uri("https://www.google.com");//URI to send to method
            string testAddress = await EventConnection.UrlToHtml(address);//Sending uri to method
            UriKind expectedAddress = new UriKind();//URI kind for TryCreate
            Uri uriTest;//Result of Uri.TryCreate

            Assert.IsTrue(Uri.TryCreate(testAddress, expectedAddress, out uriTest));
            // If the address can be created using the testAddress from UrlToHtml
        }

        //Tests if you can get the list of events
        [Test]
        public async void WhiteBoxTest_Events_getList()
        {
            Event[] events = await EventAdapter.LoadEvents();

        }

        //Deprecated
        //Tests the web response from PostRequests userlogin attempt with valid username
        [Test]
        public void WhiteBoxTest_PostRequest_User_Login()
        {
            PostRequest post = new PostRequest();
            string webResponse = post.User_Login("TestUser1", "TestUser1!");
            Assert.IsTrue("Success" == webResponse);
        }

        //Deprecated
        //Tests the web response from PostRequests userlogin attempt with invalid username
        [Test]
        public void WhiteBoxTest_PostRequest_User_Login_Invalid()
        {
            PostRequest post = new PostRequest();
            string webResponse = post.User_Login("TestUser123abc", "TestUser1!");
            Assert.IsTrue("Incorrect username or password" == webResponse);
        }

        //Deprecated
        //Tests php for if the user exists
        [Test]
        public void WhiteBoxTest_PostRequest_UserExists()
        {
            PostRequest post = new PostRequest();
            Console.WriteLine(post.UserExists("TestUser1", "TestUser1!"));
            Assert.IsTrue(post.UserExists("TestUser1", "TestUser1!"));
        }

        //Deprecated
        //Tests php for if the user doesn't exist 
        [Test]
        public void WhiteBoxTest_PostRequest_UserExists_Invalid()
        {
            PostRequest post = new PostRequest();
            Assert.IsFalse(post.UserExists("TestUser123abc", "TestUser1!"));
        }

        //Tests if the URL to get_events.php is working
        [Test]
        public void WhiteBoxTest_PostRequest_PostInfo_Success()
        {
            List<KeyValuePair<string,string>> userList = new List<KeyValuePair<string, string>>();
            KeyValuePair<string, string> testUsers = new KeyValuePair<string, string>("TestUser", "TestUser1!");
            userList.Add(testUsers);
            PostRequest post = new PostRequest();
            var result = post.PostInfo(userList, "http://haydenszymanski.me/softeng05/get_events.php");
            Assert.IsTrue(result.ResponseSuccess);

        }

        //Tests that EventPage gets events and sets them in the layout
        [Test]
        public async void WhiteBoxTest_EventPage_EventPage()
        {
            EventPage eventPage = new EventPage();

            Events events = await EventConnection.GetEventData();
            await Task.Delay(10000);
            Assert.IsTrue(events.EventSet[0].EventDescription == eventPage.temp.EventSet[0].EventDescription);
            Assert.IsTrue(events.EventSet[0].EventDate == eventPage.temp.EventSet[0].EventDate);
            Assert.IsTrue(events.EventSet[0].EventId == eventPage.temp.EventSet[0].EventId);
            Assert.IsTrue(events.EventSet[0].EventTopic == eventPage.temp.EventSet[0].EventTopic);
            Assert.IsTrue(events.EventSet[0].EventImg == eventPage.temp.EventSet[0].EventImg);
            Assert.IsTrue(events.EventSet[0].EventLocation == eventPage.temp.EventSet[0].EventLocation);
            Assert.IsTrue(events.EventSet[0].EventSignUpUrl == eventPage.temp.EventSet[0].EventSignUpUrl);
        }

        [Test]
        public void WhiteBoxTest_UserSelectPage_UserSelectPage()
        {
            app.Tap("Let's get started");
          Console.WriteLine(app.Query("SelectLogo")[0]);
        }

    }
}