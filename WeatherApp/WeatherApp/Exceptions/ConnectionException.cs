using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Exceptions
{
    public class ConnectionException : Exception
    {
        public ConnectionException()
        {

        }
        public ConnectionException(string message) : base(message)
        {

        }
        public ConnectionException(string message, Exception innerException) : base(message)
        {

        }

    }
}
