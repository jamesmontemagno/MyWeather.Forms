using MyWeather.View;
using MyWeather.ViewModels;
using System;
using Xamarin.Forms;
using static System.Diagnostics.Debug;

namespace MyWeather
{
    public static class ViewModelLocator
    {

        static WeatherViewModel weatherVM;

        public static WeatherViewModel WeatherViewModel
        => weatherVM ?? (weatherVM = new WeatherViewModel()
        {
            Condition = "Rainy",
            Temp = "70F",
            Forecast = new Models.WeatherForecastRoot()
            {
                Items = new System.Collections.Generic.List<Models.WeatherRoot>
                {
                    new Models.WeatherRoot
                    {
                        MainWeather = new Models.Main
                        {
                            Temperature = 54
                        }
                        ,
                        Date = DateTime.UtcNow.ToString(),
                        Weather = new System.Collections.Generic.List<Models.Weather>
                        {
                            new Models.Weather
                            {
                                Icon = "01d"
                            }
                        }
                        
                    }
                }
            },
            Location = "Cleveland, OH"
        });

    }

    public class App : Application
    {
        public App()
        {
            var vm = new WeatherViewModel();
            var tabs = new TabbedPage
            {
                Title ="My Weather",
                BindingContext = vm,
                Children =
                {
                    new WeatherView() { BindingContext = vm },
                    new ForecastView() { BindingContext = vm }
                }
            };
            
            MainPage = new NavigationPage(tabs)
            {
                BarBackgroundColor = Color.FromHex("3498db"),
                BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
            base.OnStart();
            WriteLine("Application OnStart");
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            WriteLine("Application OnSleep");
        }

        protected override void OnResume()
        {
            base.OnResume();
            WriteLine("Application OnResume");
        }
    }
}

