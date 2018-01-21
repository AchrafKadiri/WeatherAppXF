using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Navigation;
using WeatherApp.IServices;
using WeatherApp.Models;

namespace Weather.Test.Services
{
    [TestClass]
    public class WeatherServiceTests
    {
        private Mock<IWeatherService> _mockWeatherService;
        private Mock<INavigationService> _mockNavigationService;
        private WeatherObject _weatherObject;

        [TestInitialize]
        public void Setup()
        {
            _mockNavigationService = new Mock<INavigationService>();
            _mockWeatherService = new Mock<IWeatherService>();
            _weatherObject = new WeatherObject
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
            _mockWeatherService.Setup(e => e.GetWeatherByLocation(It.IsAny<string>())).Returns(Task.FromResult(_weatherObject));
            _mockWeatherService.Verify();
            Assert.AreEqual(_weatherObject.Name, "Madrid");
        }
    }
}
