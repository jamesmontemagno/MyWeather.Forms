using MyWeather.Helpers;
using MyWeather.Models;
using MyWeather.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.Permissions.Abstractions;
using Plugin.Permissions;
using MvvmHelpers;

using Xamarin.Essentials;

namespace MyWeather.ViewModels
{
    public class WeatherViewModel : BaseViewModel
    {
        WeatherService WeatherService { get; } = new WeatherService();

        string location = Settings.City;
        public string Location
        {
            get { return location; }
            set
            {
                SetProperty(ref location, value);
                Settings.City = value;
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




        bool isImperial = Settings.IsImperial;
        public bool IsImperial
        {
            get { return isImperial; }
            set
            {
                SetProperty(ref isImperial, value);
                Settings.IsImperial = value;
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
                    var hasPermission = await CheckPermissions();
                    if (!hasPermission)
                        return;

                    var position = await Geolocation.GetLastKnownLocationAsync();

                    if (position == null)
                    {
                        // get full location if not cached.
                        position = await Geolocation.GetLocationAsync(new GeolocationRequest
                        {
                            DesiredAccuracy = GeolocationAccuracy.Medium,
                            Timeout = TimeSpan.FromSeconds(30)
                        });
                    }
                    
                    weatherRoot = await WeatherService.GetWeather(position.Latitude, position.Longitude, units);
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

                await TextToSpeech.SpeakAsync(Temp + " " + Condition);
            }
            catch (Exception ex)
            {
                Temp = "Unable to get Weather";
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task<bool> CheckPermissions()
        {
            var permissionStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            bool request = false;
            if (permissionStatus == PermissionStatus.Denied)
            {
                if (Device.RuntimePlatform == Device.iOS)
                {

                    var title = "Location Permission";
                    var question = "To get your current city the location permission is required. Please go into Settings and turn on Location for the app.";
                    var positive = "Settings";
                    var negative = "Maybe Later";
                    var task = Application.Current?.MainPage?.DisplayAlert(title, question, positive, negative);
                    if (task == null)
                        return false;

                    var result = await task;
                    if (result)
                    {
                        CrossPermissions.Current.OpenAppSettings();
                    }

                    return false;
                }

                request = true;                
            }

            if (request || permissionStatus != PermissionStatus.Granted)
            {
                var newStatus = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                if (newStatus.ContainsKey(Permission.Location) && newStatus[Permission.Location] != PermissionStatus.Granted)
                {
                    var title = "Location Permission";
                    var question = "To get your current city the location permission is required.";
                    var positive = "Settings";
                    var negative = "Maybe Later";
                    var task = Application.Current?.MainPage?.DisplayAlert(title, question, positive, negative);
                    if (task == null)
                        return false;

                    var result = await task;
                    if (result)
                    {
                        CrossPermissions.Current.OpenAppSettings();
                    }
                    return false;
                }
            }

            return true;
        }
    }
}
