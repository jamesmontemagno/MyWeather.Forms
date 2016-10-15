using System;
using Xamarin.UITest;
namespace MyWeather.UITests
{
	public class ForecastPage : BasePage
	{
		public ForecastPage(IApp app, Platform platform) : base(app, platform, AutomationIdConstants.ForecastPageTitle)
		{
		}
	}
}
