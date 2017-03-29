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
            public void HttpUtils_PostInfo()
            {
                List<KeyValuePair<string, string>> userList = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> testUsers = new KeyValuePair<string, string>("TestUser", "TestUser1!");
                userList.Add(testUsers);

                var temp = HttpUtils.PostInfo(userList, "http://haydenszymanski.me/softeng05/get_events.php");

                //A success from the get_events call
                Assert.IsTrue(temp.ResponseSuccess);

                //Get some info from the response
                Assert.IsNotEmpty(temp.ResponseInfo[0].ToString());
            }

            [Test]
            public void HttpUtils_GetEBEventData()
            {
                app.Tap("Let's get started");
                app.Tap("Guest Access");
               // var eventData = await HttpUtils.GetEBEventData();
               // Console.WriteLine(eventData.ToString());
                //var ebEvent = Kuromori.EBEvent;
                //Assert.IsInstanceOf(eventData.GetType(), Kuromori.EBEvent());
            }


            //Compares results of a JSONRequest to layout.children type
            [Test]
            public void EventPage_EventPage()
            {
                EventPage evnt = new EventPage();

                //Tests JsonRequest and verifies it's displayed in the layout
                // String eventDescription = JsonRequest_GetEventData();
                app.Tap(c => c.Marked("Let's get started"));
                app.Tap(c => c.Marked("Guest Access"));
                // app.ScrollTo(eventDescription);//Does the JSON request match what is in the layout for the app
            }

            /*   [Test]
               public void JsonRequest_GetUserData()
               {   
                   List<KeyValuePair<string,string>> userList = new List<KeyValuePair<string, string>>();
                   KeyValuePair<string, string> testUsers = new KeyValuePair<string, string>("TestUser", "TestUser1!");
                   userList.Add(testUsers);
                   //var Json = JsonRequest.GetUserData();
                  // var result = JsonRequest.GetUserData(userList, "http://haydenszymanski.me/softeng05/get_events.php");
                   Console.WriteLine("Before Data");
                   //Assert.IsTrue(result.Result.Email == "foo@bar.com");
                   Console.WriteLine("After Data");
               } */

            //Tests if the new page is pushed titled "Admin Panel"
            [Test]
            public void AdminSignInPage_OnClickSignIn()
            {
                // AdminSignInPage admin = new AdminSignInPage();
                app.Tap(c => c.Marked("Let's get started"));
                app.Tap(c => c.Marked("Sign In"));
                app.Tap("Admin");
                app.EnterText("Username", "admin");
                app.EnterText("Password", "1234r0987y");
                app.Tap("Sign In");
                app.ScrollTo("Admin Panel");
                //(app.Tap("Admin"));
            }

            [Test]
            public void AdminSignInPage_OnClickSignInCancel()
            {
                // AdminSignInPage admin = new AdminSignInPage();
                app.Tap(c => c.Marked("Let's get started"));
                app.Tap(c => c.Marked("Sign In"));
                app.Tap("Admin");
                app.Tap("Cancel");
                app.ScrollTo("Admin");
                //(app.Tap("Admin"));
            }

            //Testing Admin Promotion/Demotion
            [Test]
            public void AdminPage_OnParticipantClick()
            {
                AdminSignInPage_OnClickSignIn();//SignIn as admin

                //Promote/Demote TestUser then ensure testuser reappears
                app.Tap("Username : TestUser");
                app.Tap("Yes");
                app.ScrollTo("Username : TestUser");
            }

            //Testing Admin Promotion/Demotion
            [Test]
            public void AdminPage_ParticipantClick()
            {
                AdminSignInPage_OnClickSignIn();//SignIn as admin

                //Promote/Demote TestUser then ensure testuser reappears
                app.Tap("Username : TestUser");
                app.Tap("No");
                app.ScrollTo("Username : TestUser");
            }

            [Test]
            public void SpeakerView_SpeakerView()
            {
                app.Tap("Let's get started");
                app.Tap("Guest Access");
                app.ScrollTo("TIFFANY NUNNALLY");
            }

            [Test]
            public void EventView_EventView()
            {
                SpeakerView_SpeakerView();
                app.ScrollTo("Speakers");
            }

            [Test]
            public void UserSelectPage_SignIn()
            {
                app.Tap("Let's get started");
                app.Tap("Sign In");
                app.ScrollTo("Login");
            }

            [Test]
            public void UserSelectPage_Register()
            {
                app.Tap("Let's get started");
                app.Tap("Register");
                app.ScrollTo("Next");
            }

            [Test]
            public void UserSelectPage_GuestAccess()
            {
                SpeakerView_SpeakerView();
            }

            [Test]
            public void ProfilePage_GIFImage()
            {
                showProfile();
                app.Tap("Edit Profile");
                app.EnterText("Profile Image", "https://i.redd.it/3vg8aoyip5ny.gif");
                app.ScrollTo("Submit");
                app.Tap("Submit");
                app.WaitForElement("ProfileImage");
               
            }

            [Test]
            public void ProfilePage_NoImage()
            {
                showProfile();
                app.Tap("Edit Profile");
                app.ClearText("Profile Image");
                app.ScrollTo("Submit");
                app.Tap("Submit");
                app.WaitForElement("ProfileImage");
            }

            [Test]
            public void ProfilePage_ClickEvents()
            {
                showProfile();
                app.Tap("Find Events");
                app.ScrollTo("Events");
            }

            //Generic Method to get to the profile page
            public void showProfile()
            {
                app.Tap(c => c.Marked("Let's get started"));
                app.Tap(c => c.Marked("Sign In"));
                app.Tap("UsernameSignIn");

                app.EnterText("TestUser");

                app.Tap("PasswordSignIn");
                app.EnterText("TestUser1!");

                app.Tap(c => c.Marked("Login"));

            }
        }
    }
}
