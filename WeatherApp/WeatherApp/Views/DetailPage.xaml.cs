using Prism.Navigation;
using Xamarin.Forms;

namespace WeatherApp.Views
{
    public partial class DetailPage : ContentPage , IDestructible
    {
        public DetailPage()
        {
            InitializeComponent();
        }

        public void Destroy()
        {
           
        }
    }
}
