using System;

using NUnit.Framework;

using Xamarin.UITest;

namespace MyWeather.UITests
{
	public abstract class BaseTest
	{
		protected IApp App;
		protected Platform Platform;

		protected WeatherPage WeatherPage;
		protected ForecastPage ForecastPage;

		protected BaseTest(Platform platform)
		{
			Platform = platform;
		}

		[SetUp]
		public virtual void TestSetup()
		{
			App = AppInitializer.StartApp(Platform);

			WeatherPage = new WeatherPage(App, Platform);
			ForecastPage = new ForecastPage(App, Platform);
		}
	}
}
