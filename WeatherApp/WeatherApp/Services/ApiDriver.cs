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
        public ApiDriver()
        {

        }

        protected async Task<T> GetAsync<T>(Uri WebServiceUrl)
        {
            try
            {
                CheckConnection();
                using (HttpClient client =  new HttpClient())
                {
                    Debug.WriteLine($">>> Get {WebServiceUrl} ");
                    var response = await client.GetAsync(WebServiceUrl);
                    Debug.WriteLine($"<<< Get {WebServiceUrl} ");

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

        private void CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                throw new ConnectionException("Connection error, check the connection");
            }
        }

        private Exception ProcessException(Exception ex)
        {
            if (ex is ConnectionException)
            {
                throw new ConnectionException("Please try again once connectiviy is reestablished", ex);
            }        
            else if (ex is ApiException)
            {
                throw new ApiException(ex.Message, ex);
            }
            else
            {
                throw new ApiException("Issue calling the WeatherService. Check the City name and try again", ex);
            }
        }
    }
}
