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
    public class UserProfileTests
    {
        IApp app;
        Platform platform;

        public UserProfileTests(Platform platform)
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
        public void UserProfileAppLaunches()
        {
            app.Screenshot("Main");
        }

        //Test cases work
        [Test]
        public void TestThing()
        {
            Assert.AreEqual(1, 1);
        }


        //Generic Method to get to the profile page
        public void showProfile()
        {
            app.Tap(c => c.Marked("Let's get started"));
            app.Tap(c => c.Marked("Sign In"));
            app.Tap("UsernameSignIn");

            app.EnterText("TestUser1");

            app.Tap("PasswordSignIn");
            app.EnterText("TestUser1!");

            app.Tap(c => c.Marked("Login"));
        }

        //Generic Test to get to EditProfilePage
        [Test]
        public void EditProfilePage()
        {
            showProfile();
            
            app.Tap("NoResourceEntry-0");
        }

        [Test]
        public void EmptyProfile()
        {
            EditProfilePage();
            app.ClearText("First");
            app.ClearText("Last");
            app.ClearText("EmailId");
            app.ClearText("Phone");
            app.ClearText("AddressId");
            app.ScrollDownTo("AboutMe");
            app.ClearText("ProfileImage");
            app.ClearText("ZipId");
            app.ScrollDownTo("Submit");
            app.TapCoordinates(551, 2200);//Removes the keyboard
            app.ScrollTo("Submit");
            app.Tap("Submit");
            app.WaitForElement("Username", "TestUser1");
        }

        //Clears and re-enters user information
        [Test]
        public void AddFullProfile()
        {
            EditProfilePage();

            app.ClearText("First");

            app.EnterText("First", "Firsty");
            Thread.Sleep(1000);

            app.ClearText("Last");

            app.EnterText("Last", "McFirstFace");
            Thread.Sleep(1000);

            app.ClearText("EmailId");

            app.EnterText("EmailId", "Emaily@EmailyMcEmailyFace.edu");
            Thread.Sleep(1000);

            app.ClearText("Phone");

            app.EnterText("Phone", "5555555555");
            Thread.Sleep(1000);

            app.ClearText("AddressId");

            app.EnterText("AddressId", "123 Streety McStreetyFace");
            Thread.Sleep(1000);

            app.ScrollDownTo("AboutMe");

            app.ClearText("ProfileImage");

            app.EnterText("ProfileImage", "http://i.imgur.com/CxV3Ex6.jpg");
            Thread.Sleep(1000);

            app.ClearText("ZipId");

            app.EnterText("ZipId", "24141");
            Thread.Sleep(1000);

            app.TapCoordinates(551, 2200);//Removes the keyboard
            app.ScrollTo("Submit");           
            app.Tap("Submit");

        }

        //Tests if the full name was set on the profile page
        [Test]
        public void UpdatedProfilePage_Name()
        {
            showProfile();
            app.WaitForElement("Firsty McFirstFace");//First and last are combined into Name
        }

        //Tests if the email was set on the profile page
        [Test]
        public void UpdatedProfilePage_Email()
        {
            showProfile();

            app.WaitForElement("Emaily@EmailyMcEmailyFace.edu");//First and last are combined into Name
        }

        //Tests if the phone number was set on the profile page
        [Test]
        public void UpdatedProfilePage_Phone()
        {
            showProfile();

            app.WaitForElement("5555555555");
        }

        //Tests if a 7-digit phone number will pass
        [Test]
        public void UpdatedProfilePage_Phone7Digit()
        {
            EditProfilePage();
            app.EnterText("Phone", "5555555");
            app.TapCoordinates(551, 2200);//Removes the keyboard
            app.ScrollTo("Submit");
            app.Tap("Submit");
            app.WaitForElement("5555555");
        }

        //Tests if a 6-digit phone number will pass
        [Test]
        public void UpdatedProfilePage_Phone6Digit()
        {
            EditProfilePage();
            app.EnterText("Phone", "555555");
            app.TapCoordinates(551, 2200);//Removes the keyboard
            app.ScrollTo("Submit");
            app.Tap("Submit");
            app.WaitForElement("555555");
        }

        //Tests if an 8-digit phone number will pass
        [Test]
        public void UpdatedProfilePage_Phone8Digit()
        {
            EditProfilePage();
            app.EnterText("Phone", "55555555");
            app.TapCoordinates(551, 2200);//Removes the keyboard
            app.ScrollTo("Submit");
            app.Tap("Submit");
            app.WaitForElement("5555555");
        }

        //Tests if the address was set on the profile page
        [Test]
        public void UpdatedProfilePage_Address()
        {
            EditProfilePage();
            app.ClearText("AddressId");
            app.EnterText("AddressId", "123 Streety McStreetyFace");
            app.TapCoordinates(551, 2200);//Removes the keyboard
            app.ScrollTo("Submit");
            app.Tap("Submit");
            app.WaitForElement("123 Streety McStreetyFace");
        }

        //Tests if the About Me was set on the profile page
        [Test]
        public void UpdatedProfilePage_AboutMe()
        {
            EditProfilePage();
            app.ScrollDown();
            app.ClearText("AboutMe");
            app.EnterText("AboutMe", "About Me");
            app.TapCoordinates(551, 2200);//Removes the keyboard
            app.ScrollTo("Submit");
            app.Tap("Submit");
            app.WaitForElement("About Me");
        }

        //Tests if the Image was set on the profile page
        [Test]
        public void UpdatedProfilePage_ProfileImage()
        {
            EditProfilePage();
            app.ClearText("ProfileImage");
            app.EnterText("ProfileImage", "http://i.imgur.com/CxV3Ex6.jpg");
            app.TapCoordinates(551, 2200);//Removes the keyboard
            app.ScrollTo("Submit");
            app.Tap("Submit");
            app.WaitForElement("http://i.imgur.com/CxV3Ex6.jpg");
        }

        [Test]
        public void UpdatedProfilePage_ZipId()
        {
            EditProfilePage();
            app.ClearText("ZipId");
            app.EnterText("ZipId", "24141");
            app.TapCoordinates(551, 2200);//Removes the keyboard
            app.ScrollTo("Submit");
            app.Tap("Submit");
            app.WaitForElement("24141");
        }

        [Test]
        public void UpdatedProfilePage_ZipId_TooLong()
        {
            EditProfilePage();
            app.ClearText("ZipId");
            app.EnterText("ZipId", "241410");
            app.TapCoordinates(551, 2200);//Removes the keyboard
            app.ScrollTo("Submit");
            app.Tap("Submit");
            var Result = app.Query(c => c.Marked("message").Invoke("getText"));
            Assert.IsTrue("Zip must contain all number and be exactly 5 digits".Equals(Result[0]));

            app.Tap(c => c.Marked("Continue"));
        }

        [Test]
        public void UpdatedProfilePage_ZipId_TooShort()
        {
            EditProfilePage();
            app.ClearText("ZipId");
            app.EnterText("ZipId", "2414");
            app.TapCoordinates(551, 2200);//Removes the keyboard
            app.ScrollTo("Submit");
            app.Tap("Submit");

            var Result = app.Query(c => c.Marked("message").Invoke("getText"));
            Assert.IsTrue("Zip must contain all number and be exactly 5 digits".Equals(Result[0]));

            app.Tap(c => c.Marked("Continue"));
        }
    }
}