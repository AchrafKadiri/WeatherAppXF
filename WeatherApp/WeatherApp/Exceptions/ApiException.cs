using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Exceptions
{
    public class ApiException: Exception
    {
        public ApiException()
        {

        }
        public ApiException(string message) : base(message)
        {

        }
        public ApiException(string message, Exception innerException): base(message)
        {

        }
    }
}
