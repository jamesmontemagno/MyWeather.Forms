using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MyWeather.UITests
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests : BaseTest
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform) : base(platform)
		{
			this.platform = platform;
		}

		public override void TestSetup()
		{
			base.TestSetup();
		}

		[TestCase("San Francisco,CA", "true")]
		[TestCase("San Francisco,CA", "false")]
		[TestCase("Orlando,FL", "true")]
		[TestCase("Orlando,FL", "false")]
		[TestCase("New York,NY", "true")]
		[TestCase("New York,NY", "false")]
		[Test]
		public void GetWeatherUsingText(string location, bool toggleScreensBeforeTest)
		{
			//Arrange
			string expectedConditionCityText = location.Substring(0, location.IndexOf(",", StringComparison.Ordinal));
			string actualTemperatureLabelText, actualConditionCityText;

			//Act
			ToggleScreens(toggleScreensBeforeTest);

			WeatherPage.EnterLocation(location);
			WeatherPage.TapGetWeatherButton();
			WeatherPage.WaitForNoActivityIndicator();

			//Assert
			actualConditionCityText = WeatherPage.GetConditionText().Substring(0, WeatherPage.GetConditionText().IndexOf(":", StringComparison.Ordinal));
			actualTemperatureLabelText = WeatherPage.GetTemperatureText();
			Assert.AreEqual(expectedConditionCityText,actualConditionCityText, "Exptected Condition City Does Not Match Actual Condition City");
			Assert.IsNotNull(actualTemperatureLabelText, "Temperature Text Is Null");
		}


		[TestCase("true")]
		[TestCase("false")]
		[Test]
		public void GetWeatherUsingGPS(bool toggleScreensBeforeTest)
		{
			//Arrange
			string actualTemperatureLabelText, actualConditionLabelText;

			//Act
			ToggleScreens(toggleScreensBeforeTest);

			WeatherPage.ToggleGPSSwitch();
			WeatherPage.TapGetWeatherButton();
			WeatherPage.WaitForNoActivityIndicator();

			//Assert
			actualConditionLabelText = WeatherPage.GetConditionText();
			actualTemperatureLabelText = WeatherPage.GetTemperatureText();
			Assert.IsNotNull(actualConditionLabelText, "Condition Text Is Null");
			Assert.IsNotNull(actualTemperatureLabelText, "Temperature Text Is Null");
		}

		void ToggleScreens(bool isToggleScreensEnabled)
		{
			if (!isToggleScreensEnabled)
				return;

			if(WeatherPage.IsWeatherPageVisible())
			{
				WeatherPage.TapForecastTab();
				ForecastPage.TapWeatherTab();
			}
			else
			{
				ForecastPage.TapWeatherTab();
				WeatherPage.TapForecastTab();
			}
		}
	}
}
