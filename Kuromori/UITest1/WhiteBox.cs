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
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

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
        public async static void WhiteBoxTest_EventAdapter_LoadEvents()
        {
            Event[] events = await EventAdapter.LoadEvents();
            Console.WriteLine(events[0].EventTopic);
        }


        //ConvertDate() is able to convert DateTime correctly
        [Test]
        public void WhiteBoxTest_EventAdapter_ConvertDate()
        {
            string Test = EventAdapter.ConvertDate("");
            Console.WriteLine(Test);

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

            Assert.True(Uri.TryCreate(testAddress, expectedAddress, out uriTest));
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
            Console.WriteLine(webResponse);
        }

        //Deprecated
        //Tests the web response from PostRequests userlogin attempt with invalid username
        [Test]
        public void WhiteBoxTest_PostRequest_User_Login_Invalid()
        {
            PostRequest post = new PostRequest();
            string webResponse = post.User_Login("TestUser123abc", "TestUser1!");
            Console.WriteLine(webResponse);
        }

        //Deprecated
        //Tests php for if the user exists
        [Test]
        public void WhiteBoxTest_PostRequest_UserExists()
        {
            PostRequest post = new PostRequest();
            Assert.True(post.UserExists("TestUser1", "TestUser1!"));
        }

        //Deprecated
        //Tests php for if the user doesn't exist 
        [Test]
        public void WhiteBoxTest_PostRequest_UserExists_Invalid()
        {
            PostRequest post = new PostRequest();
            Assert.False(post.UserExists("TestUser123abc", "TestUser1!"));
        }

        //Tests if we can connect WORK
        [Test]
        public void WhiteBoxTest_PostRequest_PostInfo_Connection()
        {
            PostRequest post = new PostRequest();
            //var result = post
        }

        //Tests the post info
        [Test]
        public void WhiteBoxTest_PostRequest_PostInfo()
        {
            List<KeyValuePair<string,string>> userList = new List<KeyValuePair<string, string>>();
            KeyValuePair<string, string> testUsers = new KeyValuePair<string, string>("TestUser1", "TestUser123");
            userList.Add(testUsers);
            PostRequest post = new PostRequest();
            var result = post.PostInfo(userList, "http://haydenszymanski.me/softeng05/get_events.php");
        }

        //Tests that EventPage gets events and sets them in the layout
        [Test]
        public void WhiteBoxTest_EventPage_EventPage()
        {
            //EventPage.EventPage();
        }

        [Test]
        public void WhiteBoxTest_UserSelectPage_UserSelectPage()
        {
            
        }

    }
}