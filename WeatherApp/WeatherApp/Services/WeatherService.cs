using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Constants;
using WeatherApp.IServices;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public abstract class WeatherService : IWeatherService
    {
        private readonly ApiService _apiService;

        protected WeatherService() => _apiService = new ApiService();

        async Task<WeatherObject> IWeatherService.GetWeatherByLocation(string city)
        {
            try
            {
                
                return await _apiService.GetApi<WeatherObject>(ApiUris.WeatherByCityGet, city);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
