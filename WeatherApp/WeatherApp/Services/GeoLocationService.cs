using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Exceptions;
using WeatherApp.IServices;

namespace WeatherApp.Services
{
    public class GeoLocationService: IGeoLocationService
    {
        public GeoLocationService()
        {

        }

        public async Task<string> GetDeviceAddress()
        {
            string device_address = "";

            try
            {
                var locator = CrossGeolocator.Current;
                Position pos = await GetDeviceCoordinates();
                IEnumerable<Address> possibleAddresses = await locator.GetAddressesForPositionAsync(pos);

                if (possibleAddresses != null)
                {
                    foreach (var address in possibleAddresses)
                    {
                        device_address = address.Locality;
                        break;
                    }
                }
                else
                {
                    device_address = "address not found";
                }
            }
            catch (Exception ex)
            {
                throw new GeoLocationException();
            }

            return device_address;
        }

        private async Task<Position> GetDeviceCoordinates()
        {
            Position pos = null;
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                pos = await locator.GetPositionAsync(timeout: TimeSpan.FromTicks(20000));      
            }
            catch (Exception ex)
            {
                throw new GeoLocationException();
            }

            return pos;
        }
    }
}
