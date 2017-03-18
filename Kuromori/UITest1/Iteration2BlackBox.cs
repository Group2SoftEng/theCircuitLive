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


namespace UITest1
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Iteration2BlackBox
    {
        IApp app;
        Platform platform;

        public Iteration2BlackBox(Platform platform)
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
    }
}