using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyWeather.View
{
    public partial class WeatherView : ContentPage
    {
        public WeatherView()
        {
            InitializeComponent();

            if (Device.OS == TargetPlatform.iOS)
                Icon = new FileImageSource { File = "tab1.png" };
        }
    }
}
