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
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.Tap(c => c.Marked("Next"));
            var Result = app.Query(c => c.Marked("message").Invoke("getText"));
            Assert.IsTrue("Usernames must be 6 to 15 characters long, with no special characters".Equals(Result[0]));
            app.Tap(c => c.Marked("Continue"));
        }

        //Enters Username
        [Test]
        public void CreateUserAllEmptyPass()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.Tap("UsernameId");
            Thread.Sleep(1000);
            app.EnterText("TestUser1");

            app.Tap(c => c.Marked("Next"));
            var Result = app.Query(c => c.Marked("message").Invoke("getText"));
            Assert.IsTrue("Passwords must contain at least 8 characters withat least 1 special character and 1 capital letter".Equals(Result[0]));

            app.Tap(c => c.Marked("Continue"));
        }

        //Create an account with a username less than the min characters
        [Test]
        public void CreateUserShortUser()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.Tap("UsernameId");
            Thread.Sleep(1000);
            app.EnterText("TUse1");

            app.Tap("PasswordId");
            app.EnterText("TestUser1!");

            app.Tap("ReenterPasswordId");
            app.EnterText("TestUser1!");

            app.Tap(c => c.Marked("Next"));

            var Result = app.Query(c => c.Marked("message").Invoke("getText"));
            Assert.IsTrue("Usernames must be 6 to 15 characters long, with no special characters".Equals(Result[0]));
            app.Tap(c => c.Marked("Continue"));
        }

        //User creates a username that is too long
        [Test]
        public void CreateUserLongUser()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.Tap("UsernameId");
            Thread.Sleep(1000);
            app.EnterText("TestingUserLengths1!");

            app.Tap("PasswordId");
            app.EnterText("TestUser1");

            app.Tap("ReenterPasswordId");
            app.EnterText("TestUser1!");

            app.Tap(c => c.Marked("Next"));

            var Result = app.Query(c => c.Marked("message").Invoke("getText"));
            Assert.IsTrue("Usernames must be 6 to 15 characters long, with no special characters".Equals(Result[0]));

            app.Tap(c => c.Marked("Continue"));
        }

        //Creates a password that is too short
        [Test]
        public void CreateUserShortPass()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.Tap("UsernameId");
            Thread.Sleep(1000);
            app.EnterText("TestUser1");//Won't enter text

            app.Tap("PasswordId");
            app.EnterText("T1!");

            app.Tap("ReenterPasswordId");
            app.EnterText("T1!");

            app.Tap(c => c.Marked("Next"));

            var Result = app.Query(c => c.Marked("message").Invoke("getText"));
            Assert.IsTrue("Passwords must contain at least 8 characters withat least 1 special character and 1 capital letter".Equals(Result[0]));

            app.Tap(c => c.Marked("Continue"));
        }

        //Creates a password that has a capital but no special character
        [Test]
        public void CreateUserCapitalNoSpecial()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.Tap("UsernameId");
            Thread.Sleep(1000);
            app.EnterText("TestUser1");

            app.Tap("PasswordId");
            app.EnterText("TestUser1");

            app.Tap("ReenterPasswordId");
            app.EnterText("TestUser1");

            app.Tap(c => c.Marked("Next"));
            var Result = app.Query(c => c.Marked("message").Invoke("getText"));
            Assert.IsTrue("Passwords must contain at least 8 characters withat least 1 special character and 1 capital letter".Equals(Result[0]));

            app.Tap(c => c.Marked("Continue"));
        }

        //Creates a password that has a special character but no capital letter
        [Test]
        public void CreateUserSpecialNoCapital()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.Tap("UsernameId");
            Thread.Sleep(1000);
            app.EnterText("TestUser1");

            app.Tap("PasswordId");
            app.EnterText("testuser1!");

            app.Tap("ReenterPasswordId");
            app.EnterText("testuser1!");

            app.Tap(c => c.Marked("Next"));
            var Result = app.Query(c => c.Marked("message").Invoke("getText"));
            Assert.IsTrue("Passwords must contain at least 8 characters withat least 1 special character and 1 capital letter".Equals(Result[0]));

            app.Tap(c => c.Marked("Continue"));
        }

        //Creates an account with a username that has already been taken
        //Fails because it cannot find the DisplayAlert but a DisplayAlert is given in the app
        [Test]
        public void CreateUserTakenUsername()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Register"));
            app.Tap("UsernameId");
            Thread.Sleep(1000);
            app.EnterText("TestUser1");

            app.Tap("PasswordId");
            app.EnterText("TestUser1!");

            app.Tap("ReenterPasswordId");
            app.EnterText("TestUser1!");

            app.Tap(c => c.Marked("Next"));
            Thread.Sleep(1000);
            var Result = app.Query(c => c.Marked("message").Invoke("getText"));
            Assert.IsTrue("Please retype username".Equals(Result[0]));

            app.Tap(c => c.Marked("Continue"));
        }


        //Attempts to signin as a valid user
        [Test]
        public void UserSigninSuccessful()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Sign In"));
            app.Tap("UsernameSignIn");
            Thread.Sleep(1000);
            app.EnterText("TestUser1");

            app.Tap("PasswordSignIn");
            app.EnterText("TestUser1!");

            app.Tap(c => c.Marked("Login"));
        }

        //Attempts to sign into the app with an incorrect username
        [Test]
        public void UserSigninIncorrectUsername()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Sign In"));
            app.Tap("UsernameSignIn");
            Thread.Sleep(1000);
            app.EnterText("TestingUser1");

            app.Tap("PasswordSignIn");
            app.EnterText("TestUser1!");

            app.Tap(c => c.Marked("Login"));
            Thread.Sleep(1000);
            var Result = app.Query(c => c.Marked("message").Invoke("getText"));
            Assert.IsTrue("Please retype username".Equals(Result[0]));

            app.Tap(c => c.Marked("Continue"));
        }

        //Attempts to Sign into the app with an incorrect password
        [Test]
        public void UserSigninIncorrectPassword()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Sign In"));
            app.Tap("UsernameSignIn");
            Thread.Sleep(1000);
            app.EnterText("TestUser1");

            app.Tap("PasswordSignIn");
            app.EnterText("TU1!");

            app.Tap(c => c.Marked("Login"));
            Thread.Sleep(1000);
            var Result = app.Query(c => c.Marked("message").Invoke("getText"));
            Console.WriteLine(Result[0]);

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

        //App goes to Eventbrite (Iteration 2)
        [Test]
        public void GuestUserRegistersForEvent()
        {
            app.Tap("Let's get started");
            app.Tap("Guest Access");
            app.Tap("content");
        }
    }

}

