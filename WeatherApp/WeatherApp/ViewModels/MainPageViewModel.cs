using Prism.Navigation;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Extensions;
using WeatherApp.IServices;
using WeatherApp.Models;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public abstract class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IWeatherService _weatherService;


        protected MainPageViewModel(INavigationService navigationService, IWeatherService weatherService) : base(navigationService)
        {
            _navigationService = navigationService;
            _weatherService = weatherService;

        }

        private async Task Load()
        {
            try
            {
                var weatherTask = _weatherService.GetWeatherByLocation(City);
                await Task.WhenAll(weatherTask);

                var currentWeather = weatherTask.Result;

                Set(currentWeather);

            }
            catch (Exception ex)
            {

                base.ProcessException(ex).DisplayAlert();
                
            }
        }

        private void Set(WeatherObject currentWeather)
        {
            WeatherObj = currentWeather;

            WeatherInfo = WeatherObj.Weather.FirstOrDefault();
            MainInfo = WeatherObj.Main;
            SysInfo = WeatherObj.Sys;
            IsBusy = false;
            IsNotBusy = true;

        }

        public ICommand NavigateDetailCommand => (new Command(
          async () =>
          {
              var par = new NavigationParameters {{"detail", WeatherObj}};

              await _navigationService.NavigateAsync("DetailPage", par);
          }));

        public ICommand WeatherGetCommand => (new Command(
          async () =>
          {
              IsBusy = true;
              await Load().ToTaskRun();
             
          }));

        public override void OnNavigatingTo(NavigationParameters parameters) => base.OnNavigatingTo(parameters);


        public override void OnNavigatedFrom(NavigationParameters parameters) => base.OnNavigatedFrom(parameters);

        public override void OnNavigatedTo(NavigationParameters parameters) => base.OnNavigatedTo(parameters);
        public override void Destroy() => base.Destroy();
    }
}
