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
    public class MainPageViewModelTests
    {
        private Mock<IWeatherService> mockWeatherService;
        private Mock<INavigationService> mockNavigationService;
        private MainPageViewModel mainPageViewModel;

        [TestInitialize]
        public void Setup()
        {
            mockNavigationService = new Mock<INavigationService>();
            mockWeatherService = new Mock<IWeatherService>();
            mainPageViewModel = new MainPageViewModel(mockNavigationService.Object, mockWeatherService.Object);

        }
        [TestMethod]
        public void Load_WhenCalled_ServiceWeather_ReturnWeather()
        {

            WeatherObject weatherObject = new WeatherObject
            {

            };
            mockWeatherService.Setup(e => e.GetWeatherByLocation(It.IsAny<string>())).Returns(Task.FromResult(weatherObject));
            mockWeatherService.Verify();

            Task.Run(async () => { await mainPageViewModel.Load(); });

            Assert.IsNotNull(weatherObject);




        }
    }
}
