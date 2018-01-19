using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Extensions;
using WeatherApp.IServices;
using WeatherApp.Models;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private IWeatherService _weatherService;

       
        public MainPageViewModel(INavigationService navigationService, IWeatherService weatherService) : base(navigationService)
        {
            _navigationService = navigationService;
            _weatherService = weatherService;

        }



        public async Task Load()
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

        private void Set(WeatherObject CurrentWeather)
        {
            WeatherObj = CurrentWeather;

            WeatherInfo = WeatherObj.Weather.FirstOrDefault();
            MainInfo = WeatherObj.Main;
            SysInfo = WeatherObj.Sys;
            IsBusy = false;
            IsNotBusy = true;

        }

        public ICommand NavigateDetailCommand => (new Command(
          async () =>
          {
              NavigationParameters par = new NavigationParameters();
              par.Add("detail", WeatherObj);

              await _navigationService.NavigateAsync("DetailPage", par);
          }));

        public ICommand WeatherGetCommand => (new Command(
          async () =>
          {
              IsBusy = true;
              await Load().ToTaskRun();
             
              

          }));



        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);

        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }
        public override void Destroy()
        {
            base.Destroy();
        }






    }
}
