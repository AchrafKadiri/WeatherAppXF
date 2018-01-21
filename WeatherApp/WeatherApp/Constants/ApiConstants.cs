using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Constants
{
    public enum Units
    {
        Imperial,
        Metric
    }
    public enum ApiUris
    {
        WeatherByCityGet
    }
    public static class ApiConstants
    {
        public const string ApiHost = "api.openweathermap.org";

        public const string ApiProtocol = "http";


        public const string GetWeatherByCity = "data/2.5/weather?q=";

        public const string ApiKey = "4ac6eecbe9be59305202d72c6baa2a78";

    }
}
