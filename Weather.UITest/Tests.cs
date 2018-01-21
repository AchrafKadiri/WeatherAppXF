using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Weather.UITest
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
            app.WaitForElement("NoResourceEntry-6");
            app.Flash("NoResourceEntry-6");
            app.Screenshot("Flash NoResourceEntry-6");

            app.WaitForElement("NoResourceEntry-6");
            app.Tap("NoResourceEntry-6");
            app.Screenshot("Tap NoResourceEntry-6");

            app.WaitForElement("NoResourceEntry-6");
            app.EnterText("NoResourceEntry-6", "Madrid");
            app.Screenshot("Tap NoResourceEntry-6");


            app.DismissKeyboard();

            app.WaitForElement("NoResourceEntry-7");
            app.Tap("NoResourceEntry-7");
            app.Screenshot("NoResourceEntry-7");



            app.WaitForElement("NoResourceEntry-15");
            app.Tap("NoResourceEntry-15");
            app.Screenshot("NoResourceEntry-15");
        }
    }
}

