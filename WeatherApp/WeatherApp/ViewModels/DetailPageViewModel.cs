using Prism.Navigation;
using System.Linq;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public abstract class DetailPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        private WeatherObject _weatherDetail;

        private WeatherObject WeatherDetail
        {
            get => _weatherDetail;
            set => SetProperty(ref _weatherDetail, value);
        }

        protected DetailPageViewModel(INavigationService navigationService) : base(navigationService) => _navigationService = navigationService;
        

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            var weatherDetail = parameters["detail"];
              
        }

        public override void OnNavigatedFrom(NavigationParameters parameters) => base.OnNavigatedFrom(parameters);

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            WeatherDetail = (WeatherObject)parameters["detail"];
            WeatherInfo = WeatherDetail.Weather.FirstOrDefault();

        }
        public override void Destroy() => base.Destroy();

    }
}
