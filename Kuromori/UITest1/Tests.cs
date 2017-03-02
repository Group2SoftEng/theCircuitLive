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


namespace Kuromori.DataStructure
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
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
        public void AppLaunches()
        {
            app.Screenshot("Main");
        }

        //Test cases work
        [Test]
        public void TestThing()
        {
            Assert.AreEqual(1, 1);
        }

        //Leave all Register fields blank
        [Test]
        public void CreateUserAllEmpty()
        {
            app.Repl();
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.Invoke("RegisterPage");
            app.Tap(c => c.Marked("Next"));
            var Result = app.Query(c => c.Marked("message").Invoke("getText"));
            Assert.True("Usernames must be 6 to 15 characters long, with no special characters".Equals(Result[0]));
            app.Tap(c => c.Marked("Continue"));
        }

        //Enters Username
        [Test]
        public void CreateUserAllEmptyPass()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.TapCoordinates(720, 690);
            Thread.Sleep(1000);
            app.EnterText("TestUser1");//Won't enter text

            app.Tap(c => c.Marked("Next"));
            app.Tap(c => c.Marked("Continue"));
        }

        //Create an account with a username less than the min characters
        [Test]
        public void CreateUserShortUser()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.TapCoordinates(720, 690);
            Thread.Sleep(1000);
            app.EnterText("TUser1!");//Won't enter text

            app.TapCoordinates(720, 1104);
            app.EnterText("TestUser1!");

            app.TapCoordinates(720, 1518);
            app.EnterText("TestUser1!");

            app.Tap(c => c.Marked("Next"));
            app.Tap(c => c.Marked("Continue"));
        }

        //User creates a username that is too long
        [Test]
        public void CreateUserLongUser()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.TapCoordinates(720, 690);
            Thread.Sleep(1000);
            app.EnterText("TestingUserLengths1!");//Won't enter text

            app.TapCoordinates(720, 1104);
            app.EnterText("TestUser1!");

            app.TapCoordinates(720, 1518);
            app.EnterText("TestUser1!");

            app.Tap(c => c.Marked("Next"));
            app.Tap(c => c.Marked("Continue"));
        }

        //Creates a password that is too short
        [Test]
        public void CreateUserShortPass()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.TapCoordinates(720, 690);
            Thread.Sleep(1000);
            app.EnterText("TestUser1!");//Won't enter text

            app.TapCoordinates(720, 1104);
            app.EnterText("T1!");

            app.TapCoordinates(720, 1518);
            app.EnterText("T1!");

            app.Tap(c => c.Marked("Next"));
            app.Tap(c => c.Marked("Continue"));
        }

        //Creates a password that has a capital but no special character
        [Test]
        public void CreateUserCapitalNoSpecial()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.TapCoordinates(720, 690);
            Thread.Sleep(1000);
            app.EnterText("TestUser1!");//Won't enter text

            app.TapCoordinates(720, 1104);
            app.EnterText("TestUser1");

            app.TapCoordinates(720, 1518);
            app.EnterText("TestUser1");

            app.Tap(c => c.Marked("Next"));
            app.Tap(c => c.Marked("Continue"));
        }

        //Creates a password that has a special character but no capital letter
        [Test]
        public void CreateUserSpecialNoCapital()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.TapCoordinates(720, 690);
            Thread.Sleep(1000);
            app.EnterText("TestUser1!");//Won't enter text

            app.TapCoordinates(720, 1104);
            app.EnterText("testuser1!");

            app.TapCoordinates(720, 1518);
            app.EnterText("testuser1!");

            app.Tap(c => c.Marked("Next"));
            app.Tap(c => c.Marked("Continue"));
        }

        //Creates an account with a username that has already been taken
        [Test]
        public void CreateUserTakenUsername()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.TapCoordinates(720, 690);
            Thread.Sleep(1000);
            app.EnterText("TestUser1!");//Won't enter text

            app.TapCoordinates(720, 1104);
            app.EnterText("TestUser1!");

            app.TapCoordinates(720, 1518);
            app.EnterText("TestUser1!");

            app.Tap(c => c.Marked("Next"));
            app.Tap(c => c.Marked("Continue"));
        }

        //Attempts to signin as a valid user
        [Test]
        public void UserSigninSuccessful()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.TapCoordinates(720, 690);
            Thread.Sleep(1000);
            app.EnterText("TestUser1");//Won't enter text
    
            app.Tap(c => c.Marked("Next"));
            app.Tap(c => c.Marked("Continue"));
        }

        [Test]
        public void UserSigninIncorrectUsername()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.TapCoordinates(720, 690);
            Thread.Sleep(1000);
            app.EnterText("TestUser1");//Won't enter text
            app.Repl();
            app.Tap(c => c.Marked("Next"));
            app.Tap(c => c.Marked("Continue"));
        }

        [Test]
        public void UserSigninIncorrectPassword()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.TapCoordinates(720, 690);
            Thread.Sleep(1000);
            app.EnterText("TestUser1");//Won't enter text
            app.Repl();
            app.Tap(c => c.Marked("Next"));
            app.Tap(c => c.Marked("Continue"));
        }

        //Speaker description loads
        [Test]
        public void GuestUserViewsEventsSpeaker()
        {
            app.Tap("Let's get started");
            app.Tap("Guest Access");
            app.ScrollDownTo(c => c.Marked("Daniel is our tester"));
        }

        //Topic Loads
        [Test]
        public void GuestUserViewsEventsTopic()
        {
            app.Tap("Let's get started");
            app.Tap("Guest Access");
            
            app.WaitForElement(c => c.Marked("Topic: Software Engineering Presentation"));
        }

        //Date Loads
        [Test]
        public void GuestUserViewsEventsDate()
        {
            app.Tap("Let's get started");
            app.Tap("Guest Access");
            app.ScrollDownTo(c => c.Marked("July 19, 2017"));
       
        }

        //App goes to Eventbrite
        [Test]
        public void GuestUserRegistersForEvent()
        {
            app.Tap("Let's get started");
            app.Tap("Guest Access");
            app.Tap("content");
        }

        //Test account is TestUser; TestUser1!
        [Test]
        public void GuestUserReturnsToSignIn()
        {
            app.Tap("Let's get started");
            app.Tap("Guest Access");
            app.Tap("Events");
            app.Tap(c => c.Marked("Next"));
            app.Tap(c => c.Marked("Continue"));

        }


        [Test]
        public void SimpleMethodTest()
        {
            
        }
    }

}

