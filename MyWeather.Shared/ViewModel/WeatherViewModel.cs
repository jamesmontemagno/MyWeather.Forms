using MyWeather.Models;
using MyWeather.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MvvmHelpers;
using Plugin.Permissions.Abstractions;

namespace MyWeather.ViewModels
{
    public class WeatherViewModel : BaseViewModel
    {
        WeatherService WeatherService { get; } = new WeatherService();

        string location = SettingsService.City;
        public string Location
        {
            get { return location; }
            set
            {
                SetProperty(ref location, value);
                SettingsService.City = value;
            }
        }

        bool useGPS;
        public bool UseGPS
        {
            get { return useGPS; }
            set
            {
                SetProperty(ref useGPS, value);
            }
        }




        bool isImperial = SettingsService.IsImperial;
        public bool IsImperial
        {
            get { return isImperial; }
            set
            {
                SetProperty(ref isImperial, value);
                SettingsService.IsImperial = value;
            }
        }


        string temp = string.Empty;
        public string Temp
        {
            get { return temp; }
            set { SetProperty(ref temp, value); }
        }

        string condition = string.Empty;
        public string Condition
        {
            get { return condition; }
            set { SetProperty(ref condition, value); ; }
        }

        
        WeatherForecastRoot forecast;
        public WeatherForecastRoot Forecast
        {
            get { return forecast; }
            set { forecast = value; OnPropertyChanged(); }
        }


        ICommand getWeather;
        public ICommand GetWeatherCommand =>
                getWeather ??
                (getWeather = new Command(async () => await ExecuteGetWeatherCommand()));

        private async Task ExecuteGetWeatherCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                WeatherRoot weatherRoot = null;
                var units = IsImperial ? Units.Imperial : Units.Metric;
               

                if (UseGPS)
                {
                    var hasPermission = await PermissionsService.CheckPermissions(Permission.Location);
                    if (!hasPermission)
                        return;

                    var gps = await GeolocationService.GetCurrentPositionAsync();
                    weatherRoot = await WeatherService.GetWeather(gps.Latitude, gps.Longitude, units);
                }
                else
                {
                    //Get weather by city
                    weatherRoot = await WeatherService.GetWeather(Location.Trim(), units);
                }
                

                //Get forecast based on cityId
                Forecast = await WeatherService.GetForecast(weatherRoot.CityId, units);

                var unit = IsImperial ? "F" : "C";

                Temp = $"Temp: {weatherRoot?.MainWeather?.Temperature ?? 0}°{unit}";
                Condition = $"{weatherRoot.Name}: {weatherRoot?.Weather?[0]?.Description ?? string.Empty}";

                TextToSpeechService.Speak($" The current temperature is {weatherRoot?.MainWeather?.Temperature ?? 0}°{unit}");
            }
            catch (Exception ex)
            {
                Temp = "Unable to get Weather";
            }
            finally
            {
                IsBusy = false;
            }
        }

       
    }
}
