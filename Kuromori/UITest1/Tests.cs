using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Diagnostics;

namespace UITest1
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

        //Speaker Element Loads
        //[Test]
     //   public void Speaker()
     //   {
            
      //      app.WaitForElement(c => c.Marked("Speaker"), "Timed out waiting for Logged In popup");
          
       // }

        [Test]
        public void SignIn()
        {
            //app.Tap("Sign In");
            app.Tap(c => c.Marked("Sign In"));
        }
    }
}

