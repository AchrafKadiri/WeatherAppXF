using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Constants;
using System.Threading.Tasks;
using WeatherApp.IServices;
using static WeatherApp.Constants.Units;
using static WeatherApp.Constants.ApiConstants;
using WeatherApp.Exceptions;

namespace WeatherApp.Services
{
    public class ApiService : ApiDriver, IApiService
    {
        public ApiService() : base()
        {

        }

        public async Task<T> GetApi<T>(ApiUris apiUris, string city)
        {
            var uri = FabricateUrl(apiUris, city);
            return await GetApi<T>(apiUris, uri);
        }

        private async Task<T> GetApi<T>(ApiUris apiUris, Uri uri)
        {
            try
            {
                var content = await base.GetAsync<T>(uri);

                return content;

            }
            catch (Exception ex)
            {

                throw new ApiException(ex.Message, ex);
            }
        }

        private static Uri FabricateUrl(ApiUris apiUris, string args) => new Uri($"{API_PROTOCOL}://{API_HOST}/{GetWeatherByCity}{args}&units={Metric}&appid={ApiKey}", UriKind.Absolute);
    }
}
