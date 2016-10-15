using System;
using Xamarin.UITest;
using Xamarin.UITest.iOS;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MyWeather.UITests
{
	public abstract class BasePage
	{
		protected readonly IApp App;
		protected readonly bool OnAndroid;
		protected readonly bool OniOS;
		protected readonly string Title;

		readonly Query TitleQuery;
		readonly Query ForecastTab;
		readonly Query WeatherTab;

		protected BasePage(IApp app, Platform platform, string title)
		{
			App = app;

			OnAndroid = platform == Platform.Android;
			OniOS = platform == Platform.iOS;

			Title = title;

			ForecastTab = x => x.Marked("Forecast");
			WeatherTab = x => x.Marked("Weather");
			TitleQuery = x => x.Marked(Title);
		}

		public virtual void WaitForPageToLoad(int timeoutInSeconds, BasePage page)
		{
			App.WaitForElement(TitleQuery, $"{page.GetType().Name} Failed To Load", TimeSpan.FromSeconds(timeoutInSeconds));
		}

		public void TapForecastTab()
		{
			App.Tap(ForecastTab);
			App.Screenshot("Forecast Page Tab Tapped");
		}

		public void TapWeatherTab()
		{
			App.Tap(WeatherTab);
			App.Screenshot("Weather Page Tab Tapped");
		}

		public virtual void WaitForPageToLoad()
		{

		}

	}
}
