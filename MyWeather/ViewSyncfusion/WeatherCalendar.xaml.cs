using MyWeather.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Syncfusion.SfCalendar;
using Syncfusion.SfCalendar.XForms;

namespace MyWeather.View
{
    public partial class WeatherCalendar : ContentPage
    {
        WeatherViewModel VM => (WeatherViewModel)BindingContext;
        public WeatherCalendar()
        {
            InitializeComponent();

            if (Device.OS == TargetPlatform.iOS)
                Icon = new FileImageSource { File = "tab3.png" };
        }
    }
}
