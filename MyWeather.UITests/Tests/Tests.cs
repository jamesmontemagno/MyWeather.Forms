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

		[TestCase("San Francisco,CA")]
		[TestCase("Orlando,FL")]
		[TestCase("New York,NY")]
		[Test]
		public void GetWeatherUsingText(string location)
		{
			//Arrange
			string expectedConditionCityText = location.Substring(0, location.IndexOf(",", StringComparison.Ordinal));
			string actualTemperatureLabelText, actualConditionCityText;

			//Act
			WeatherPage.EnterLocation(location);
			WeatherPage.TapGetWeatherButton();
			WeatherPage.WaitForNoActivityIndicator();

			//Assert
			actualConditionCityText = WeatherPage.GetConditionText().Substring(0, WeatherPage.GetConditionText().IndexOf(":", StringComparison.Ordinal));
			actualTemperatureLabelText = WeatherPage.GetTemperatureText();
			Assert.AreEqual(expectedConditionCityText,actualConditionCityText, "Exptected Condition City Does Not Match Actual Condition City");
			Assert.IsNotNull(actualTemperatureLabelText, "Temperature Text Is Null");
		}

		[Test]
		public void GetWeatherUsingGPS()
		{
			//Arrange
			string actualTemperatureLabelText, actualConditionLabelText;

			//Act
			WeatherPage.ToggleGPSSwitch();
			WeatherPage.TapGetWeatherButton();
			WeatherPage.WaitForNoActivityIndicator();

			//Assert
			actualConditionLabelText = WeatherPage.GetConditionText();
			actualTemperatureLabelText = WeatherPage.GetTemperatureText();
			Assert.IsNotNull(actualConditionLabelText, "Condition Text Is Null");
			Assert.IsNotNull(actualTemperatureLabelText, "Temperature Text Is Null");
		}
	}
}
