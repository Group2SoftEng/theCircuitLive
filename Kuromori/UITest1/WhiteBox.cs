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
    }
}