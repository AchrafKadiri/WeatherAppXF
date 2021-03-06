﻿using Prism.Commands;
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
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
        private bool _isNotBusy = false;

        public bool IsNotBusy
        {
            get => _isNotBusy;
            set { SetProperty(ref _isNotBusy, value); }
        }


        private WeatherObject _weatherObj;

        private Main _mainInfo;

        private Sys _sysInfo;

        public Sys SysInfo

        {
            get { return _sysInfo; }
            set { SetProperty(ref _sysInfo, value); }
        }


        public Main MainInfo
        {
            get { return _mainInfo; }
            set { SetProperty(ref _mainInfo, value); }
        }


        public WeatherObject WeatherObj
        {
            get { return _weatherObj; }
            set { SetProperty(ref _weatherObj, value); }
        }
        private Weather _weatherInfo;

        public Weather WeatherInfo
        {
            get { return _weatherInfo; }
            set { SetProperty(ref _weatherInfo, value); }
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
                ex is ApiException ? "Can not connect to the Server. Please try again later" :
                ex is GeoLocationException ? ex.Message : "Problems getting current location. Pleas try again later" ;

        }

        public ViewModelBase(INavigationService navigationService)
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
