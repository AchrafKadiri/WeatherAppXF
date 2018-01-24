using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Exceptions
{
    public class GeoLocationException : Exception
    {

        public GeoLocationException()
        {

        }
        public GeoLocationException(string message) : base(message)
        {

        }
        public GeoLocationException(string message, Exception innerException) : base(message)
        {

        }
    }
}
