using MyWeather.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyWeather.Cell
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WeatherCardView : ContentView
	{
		public WeatherCardView ()
		{
			InitializeComponent ();

            if(DesignMode.IsDesignModeEnabled)
            {
                BindingContext = new WeatherRoot
                {
                    Date = DateTime.Now.ToString(),
                    MainWeather = new Main
                    {
                        Temperature = 70
                    },
                    Weather = new List<Weather>()
                            {
                                new Weather
                                {
                                    Icon = "03d",
                                    Main = "Clear"
                                }
                            }
                };
            }
		}
	}
}