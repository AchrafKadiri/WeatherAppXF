using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Constants;

namespace WeatherApp.IServices
{
    public interface IApiService
    {
        Task<T> GetApi<T>(ApiUris apiUris, string city);
    }
}
