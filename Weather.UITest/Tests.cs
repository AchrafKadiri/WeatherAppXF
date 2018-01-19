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
            app.WaitForElement("NoResourceEntry-4");
            app.Flash("NoResourceEntry-4");
            app.Screenshot("Flash NoResourceEntry-4");

            app.WaitForElement("NoResourceEntry-4");
            app.Tap("NoResourceEntry-4");
            app.Screenshot("Tap NoResourceEntry-4");

            app.WaitForElement("NoResourceEntry-4");
            app.EnterText("NoResourceEntry-4", "London");
            app.Screenshot("EnterText NoResourceEntry-4");


            app.DismissKeyboard();

            app.WaitForElement("NoResourceEntry-5");
            app.Tap("NoResourceEntry-5");
            app.Screenshot("Tap NoResourceEntry-5");

            app.WaitForElement("NoResourceEntry-13");
            app.Tap("NoResourceEntry-13");
            app.Screenshot("Tap NoResourceEntry-13");
        }
    }
}

