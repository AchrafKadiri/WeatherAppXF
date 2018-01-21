using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Exceptions;

namespace WeatherApp.Services
{
    public class ApiDriver
    {
        protected ApiDriver()
        {

        }

        protected async Task<T> GetAsync<T>(Uri webServiceUrl)
        {
            try
            {
                CheckConnection();
                using (var client =  new HttpClient())
                {
                    Debug.WriteLine($">>> Get {webServiceUrl} ");
                    var response = await client.GetAsync(webServiceUrl);
                    Debug.WriteLine($"<<< Get {webServiceUrl} ");

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<T>(content);
                        return result;


                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }

                }

            }
            catch (Exception ex)
            {

                throw ProcessException(ex);
            }
        }

        private static void CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                throw new ConnectionException("Connection error, check the connection");
            }
        }

        private static Exception ProcessException(Exception ex)
        {
            switch (ex)
            {
                case ConnectionException _:
                    throw new ConnectionException("Please try again once connectiviy is reestablished", ex);
                case ApiException _:
                    throw new ApiException(ex.Message, ex);
                default:
                    throw new ApiException("Issue calling the WeatherService. Check the City name and try again", ex);
            }
        }
    }
}
