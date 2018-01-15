using WeatherApp.ViewModels;
using WeatherApp.Views;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using WeatherApp.IServices;
using WeatherApp.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WeatherApp
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        //public App(WeatherApp.iOS.iOSInitializer iOSInitializer) : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            
            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }
        

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {


            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailPage, DetailPageViewModel>();


            //containerRegistry.Register<ApiDriver>();
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.Register<IWeatherService, WeatherService>();
           
        }
        
    }
}
