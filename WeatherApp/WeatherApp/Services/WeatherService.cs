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
    /// <summary>
    /// Class that implements IWeatherService
    /// This class can access to ApiService 
    /// </summary>
    public class WeatherService : IWeatherService
    {
        private ApiService _apiService;

        public WeatherService()
        {
            _apiService = new ApiService();
        }
     
        async Task<WeatherObject> IWeatherService.GetWeatherByLocation(string city)
        {
            try
            {
                
                return await _apiService.GetApi<WeatherObject>(ApiUris.WeatherByCity_GET, city);
            }
            catch (Exception cex)
            {

                throw cex;
            }
        }
    }
}
