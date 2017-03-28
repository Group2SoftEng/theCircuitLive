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

           
        //    public String JsonRequest_GetEventData()
          //  {
//                var temp = JsonRequest.GetEventData();
               // String eventDescription = temp.Result.EventSet[0].EventDescription;
                //return eventDescription;
           //  }



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

            [Test]
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
            }

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
                app.ScrollTo("Admin Panel");
                //admin.OnSignInClick(sender, args);
                //(app.Tap("Admin"));
            }

            [Test]
            public void SpeakerView_SpeakerView()
            {
                app.Repl();
                Console.WriteLine("Tappity tap");
                app.Tap("Let's get started");
                Console.WriteLine("Moar tap");
                app.Tap("Guest Access");
                Console.WriteLine("Making new speaker");
                Speaker speaker = new Speaker();
                Console.WriteLine("Setting ID");
                speaker.SpeakerId = 12;
                Console.WriteLine("Setting image");
                speaker.SpeakerImg = "https://s-media-cache-ak0.pinimg.com/736x/a3/20/92/a3209236d95082357583a9a53089da0d.jpg";
                speaker.SpeakerName = "Testy McTestface";
                speaker.SpeakerUrl = "https://www.google.com";
                speaker.SpeakerDescription = "I am a speaker!";
                Console.WriteLine("Done setting stuff; make it so");
                SpeakerView spView = new SpeakerView(speaker);
                Console.WriteLine("Made it so");
                // Check that the SpeakerView was made correctly
                app.ScrollTo("Testy McTestface");
                //speaker.set
                Console.WriteLine("The speaker description is: " + speaker.SpeakerDescription);

            }

            //For Admin class, set username/password, get username/password
        }
    }
}
