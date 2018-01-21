using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Exceptions;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        private string _city;

        protected string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        private bool _isBusy;

        protected bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
        private bool _isNotBusy = false;

        protected bool IsNotBusy
        {
            get => _isNotBusy;
            set => SetProperty(ref _isNotBusy, value);
        }


        private WeatherObject _weatherObj;

        private Main _mainInfo;

        private Sys _sysInfo;

        protected Sys SysInfo

        {
            get => _sysInfo;
            set => SetProperty(ref _sysInfo, value);
        }


        protected Main MainInfo
        {
            get => _mainInfo;
            set => SetProperty(ref _mainInfo, value);
        }


        protected WeatherObject WeatherObj
        {
            get => _weatherObj;
            set => SetProperty(ref _weatherObj, value);
        }
        private Weather _weatherInfo;

        protected Weather WeatherInfo
        {
            get => _weatherInfo;
            set => SetProperty(ref _weatherInfo, value);
        }


        public ViewModelBase()
        {

        }

        protected string ProcessException(Exception ex)
        {
            IsNotBusy = false;
            IsBusy = false;
            return
                ex is ConnectionException ? "No Conection to Server. Please try again later" :
                ex is ApiException ? ex.Message : "Can not connect to the Server. Please try again later";


        }

        protected ViewModelBase(INavigationService navigationService)
        {
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }

        public virtual void Destroy()
        {
            
        }

    }
}
