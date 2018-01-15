using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Weather.UITest
{
    public class AppInitializer
    {

        public  readonly static string APK_FILE = "../../../WeatherApp/WeatherApp.Android/bin/Release/com.edgargonzalez.weather.apk";
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .ApkFile(APK_FILE)
                    .EnableLocalScreenshots()
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }

       
        

    }
}

