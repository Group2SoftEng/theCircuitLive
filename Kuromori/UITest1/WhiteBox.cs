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
using System.Threading.Tasks;

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
            Console.WriteLine(events[0]);
        }


        //ConvertDate() is able to convert DateTime correctly
        [Test]
        public void WhiteBoxTest_EventAdapter_ConvertDate()
        {
            string Test = EventAdapter.ConvertDate("01-01-2017");
            Console.WriteLine(Test);

        }

        //Gets events from GetEventData() and test an individual event
        [Test]
        public async static void WhiteBoxTest_EventConnection_GetEventData()
        {
            Events events = await EventConnection.GetEventData();
            Console.WriteLine(events);
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
        public void WhiteBoxTest_Events_getList()
        {
        }

        //Tests the PostResponseItem
        [Test]
        public void WhiteBoxTest_PostResponseItem_PostResponseItem()
        {
            //PostResponseItem.PostResponseItem();
        }

        //Tests the web response from PostRequests userlogin attempt with valid username
        [Test]
        public void WhiteBoxTest_PostRequest_User_Login()
        {
            PostRequest post = new PostRequest();
            string webResponse = post.User_Login("TestUser1", "TestUser1!");
            Console.WriteLine(webResponse);
        }

        //Tests the web response from PostRequests userlogin attempt with invalid username
        [Test]
        public void WhiteBoxTest_PostRequest_User_Login_Invalid()
        {
            PostRequest post = new PostRequest();
            string webResponse = post.User_Login("TestUser123abc", "TestUser1!");
            Console.WriteLine(webResponse);
        }

        //Tests php for if the user exists
        [Test]
        public void WhiteBoxTest_PostRequest_UserExists()
        {
            PostRequest post = new PostRequest();
            Boolean userStatus = post.UserExists("TestUser1", "TestUser1!");
            Assert.True(userStatus);
        }

        //Tests php for if the user doesn't exist
        [Test]
        public void WhiteBoxTest_PostRequest_UserExists_Invalid()
        {
            PostRequest post = new PostRequest();
            Boolean userStatus = post.UserExists("TestUser123abc", "TestUser1!");
            Assert.False(userStatus);
        }

        //Tests the post info
        [Test]
        public void WhiteBoxTest_PostRequest_PostInfo()
        {

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
