using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherApp.Extensions
{
    public static class CoreExtensions
    {

        public static Task ToTaskRun(this Task me)
        {
            return Task.Run(async () => { await me; });
        }

        public static void DisplayAlert(this string message, string title = null)
        {
            Device.BeginInvokeOnMainThread(async () => await App.Current.MainPage.DisplayAlert(title, message, "Ok"));
        }
    }
}
