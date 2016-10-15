using System;
namespace MyWeather
{
	public static class HockeyappConstants
	{
		#region AppID
		public const string HockeyAppId_iOS = "14069333d24b4da6bcc33dfd2c2dfa24";
		public const string HockeyAppId_Droid = "a4cac084464a4ae9901f4338d6f50996";
		#endregion

		#region EventManagerConstants
		public const string GetWeatherButtonTapped = "Get Weather Button Tapped";
		public const string WeatherPageAppeared = "Weather Page Appeared";
		public const string ForecastPageAppeared = "Forecast Page Appeared";
		public const string GPSSwitchEnabled = "GPS Switch Enabled";
		#endregion
	}
}
