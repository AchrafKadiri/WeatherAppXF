using System.Threading.Tasks;

namespace WeatherApp.IServices
{
    public interface IGeoLocationService
    {
        /// <summary>
        /// Method which converts a <see cref="Position"/> object on a string with the device location address.
        /// </summary>
        /// <returns>The address of the device on string format.</returns>
        /// <exception cref="GeolocationException">Returns exception if occurs any problem.</exception>
        Task<string> GetDeviceAddress();
    }
}
