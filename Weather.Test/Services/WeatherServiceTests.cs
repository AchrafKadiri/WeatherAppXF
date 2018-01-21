using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Navigation;
using System.IO;
using System.Threading.Tasks;
using WeatherApp.IServices;
using WeatherApp.Models;
using WeatherApp.ViewModels;

namespace Weather.Test
{
    [TestClass]
    public class WeatherServiceTests
    {
        private Mock<IWeatherService> mockWeatherService;
        private Mock<INavigationService> mockNavigationService;
        private WeatherObject weatherObject;

        [TestInitialize]
        public void Setup()
        {
            mockNavigationService = new Mock<INavigationService>();
            mockWeatherService = new Mock<IWeatherService>();
            weatherObject = new WeatherObject
            {
                Name = "Madrid",
                Clouds = new Clouds { All = 20 },
                Main = new Main { Humidity = 20, Pressure = 12, Temp = 25, TempMax = 25, TempMin = 45 },
                Coord = new Coord { Lat = 12, Lon = 25 },
                Base = "Base",
                Cod = 45,
                Dt = 45,
                Id = 47,
                Sys = new Sys { Country = "Spain", Id = 15, Message = 25, Sunrise = 45, Sunset = 47, Type = 14 },
                Visibility = 58,

            };
        }
        [TestMethod]
        public void WeatherService_GetWeatherByLocation_ReturnWeather()
        {
            mockWeatherService.Setup(e => e.GetWeatherByLocation(It.IsAny<string>())).Returns(Task.FromResult(weatherObject));
            mockWeatherService.Verify();
            Assert.AreEqual(weatherObject.Name, "Madrid");
        }
    }
}
