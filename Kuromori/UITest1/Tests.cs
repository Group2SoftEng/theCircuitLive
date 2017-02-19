using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

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

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("Main");
        }
        [Test]
        public void TestThing()
        {
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void Speaker()
        {
            app.WaitForElement("Speakers");
        }

        [Test]
        public void TapImage()
        {
            app.Tap(c => c.Marked("Image"));
            //app.Tap("noImage");
        }

        [Test]
        public void FindDate()
        {
            app.Query("Topic:"); 
            //app.Tap("noImage");
        }
    }
}

