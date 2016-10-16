using System;
using System.Windows.Input;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using Plugin.Geolocator;
using Plugin.TextToSpeech;

using HockeyApp;

using MyWeather.Models;
using MyWeather.Helpers;
using MyWeather.Services;

namespace MyWeather.ViewModels
{
	public class WeatherViewModel : INotifyPropertyChanged
	{
		WeatherService WeatherService { get; } = new WeatherService();

		string location = Settings.City;
		public string Location
		{
			get { return location; }
			set
			{
				location = value;
				OnPropertyChanged();
				Settings.City = value;
			}
		}

		bool useGPS;
		public bool UseGPS
		{
			get { return useGPS; }
			set
			{
				if (value)
					MetricsManager.TrackEvent(HockeyappConstants.GPSSwitchEnabled);

				useGPS = value;
				OnPropertyChanged();
			}
		}




		bool isImperial = Settings.IsImperial;
		public bool IsImperial
		{
			get { return isImperial; }
			set
			{
				isImperial = value;
				OnPropertyChanged();
				Settings.IsImperial = value;
			}
		}



		string temp = string.Empty;
		public string Temp
		{
			get { return temp; }
			set { temp = value; OnPropertyChanged(); }
		}

		string condition = string.Empty;
		public string Condition
		{
			get { return condition; }
			set { condition = value; OnPropertyChanged(); }
		}



		bool isBusy = false;
		public bool IsBusy
		{
			get { return isBusy; }
			set { isBusy = value; OnPropertyChanged(); }
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
		(getWeather = new Command(async () =>
		{
			MetricsManager.TrackEvent(HockeyappConstants.GetWeatherButtonTapped);
			await ExecuteGetWeatherCommand();
		}));


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

					var gps = await CrossGeolocator.Current.GetPositionAsync(10000);
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
				CrossTextToSpeech.Current.Speak(Temp + " " + Condition);
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

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName]string name = "")
		{
			var handle = PropertyChanged;
			handle?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
