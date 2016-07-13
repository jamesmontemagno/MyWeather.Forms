using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyWeather.View
{
    public partial class WeatherViewC : ContentPage
    {
        public WeatherViewC()
        {
            InitializeComponent();
            if (Device.OS == TargetPlatform.iOS)
                Icon = new FileImageSource { File = "tab1.png" };
        }
    }
}
