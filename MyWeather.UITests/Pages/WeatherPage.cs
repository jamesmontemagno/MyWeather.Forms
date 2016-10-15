using System;
using System.Linq;

using Xamarin.UITest;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MyWeather.UITests
{
	public class WeatherPage : BasePage
	{
		readonly Query ConditionLabel;
		readonly Query GetWeatherButton;
		readonly Query LocationEntry;
		readonly Query TempLabel;
		readonly Query UseGPSSwitch;
		readonly Query GetWeatherActivityIndicator;

		public WeatherPage(IApp app, Platform platform) : base(app, platform, AutomationIdConstants.WeatherPageTitle)
		{
			ConditionLabel = x => x.Marked(AutomationIdConstants.ConditionLabel);
			GetWeatherButton = x => x.Marked(AutomationIdConstants.GetWeatherButton);
			LocationEntry = x => x.Marked(AutomationIdConstants.LocationEntry);
			TempLabel = x => x.Marked(AutomationIdConstants.TempLabel);
			UseGPSSwitch = x => x.Marked(AutomationIdConstants.UseGPSSwitch);
			GetWeatherActivityIndicator = x => x.Marked(AutomationIdConstants.GetWeatherActivityIndicator);

			WaitForPageToLoad(20, this);
		}

		public string GetConditionText()
		{
			return App.Query(ConditionLabel)?.First()?.Text;
		}

		public string GetTemperatureText()
		{
			return App.Query(TempLabel)?.First()?.Text;
		}

		public void TapGetWeatherButton()
		{
			App.Tap(GetWeatherButton);
			App.Screenshot("Get Weather Button Tapped");
		}

		public void ToggleGPSSwitch()
		{
			App.Tap(UseGPSSwitch);
			App.Screenshot("GPS Switch Toggled");
		}

		public void EnterLocation(string location)
		{
			App.Tap(LocationEntry);
			App.ClearText();
			App.EnterText(location);
			App.DismissKeyboard();
			App.Screenshot($"Entered Location: {location}");
		}

		public void WaitForNoActivityIndicator()
		{
			App.WaitForNoElement(GetWeatherActivityIndicator);
			App.Screenshot("Activity Indicator Disappeared");
		}

		public bool IsWeatherPageVisible()
		{
			var getWeatherButtonQuery = App.Query(GetWeatherButton);
			return getWeatherButtonQuery.Length > 0;
		}
	}
}
