using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class DetailPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        private WeatherObject _weatherDetail;

        public WeatherObject WeatherDetail
        {
            get { return _weatherDetail; }
            set { SetProperty(ref _weatherDetail, value); }
        }




        public DetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            var weatherDetail = parameters["detail"];
           
            
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
                   
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            WeatherDetail = (WeatherObject)parameters["detail"];
            WeatherInfo = WeatherDetail.Weather.FirstOrDefault();

        }
        public override void Destroy()
        {
            base.Destroy();
        }





    }
}
