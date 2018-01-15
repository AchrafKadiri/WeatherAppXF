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
            app.Screenshot("First screen.");
            app.Repl();

            app.Tap("NoResourceEntry-4");
            app.EnterText("NoResourceEntry-4", "Madrid");
            app.DismissKeyboard();
            app.Tap("NoResourceEntry-5");
            app.Tap("NoResourceEntry-5");
        }
    }
}

