using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.IServices
{
    public interface IWeatherService
    {
        Task<WeatherObject> GetWeatherByLocation(string city);
    }
}
