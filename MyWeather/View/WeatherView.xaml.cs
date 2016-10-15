using Xamarin.Forms;

using HockeyApp;

namespace MyWeather.View
{
    public partial class WeatherView : ContentPage
    {
        public WeatherView()
        {
            InitializeComponent();

            if (Device.OS == TargetPlatform.iOS)
                Icon = new FileImageSource { File = "tab1.png" };
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
			MetricsManager.TrackEvent(HockeyappConstants.WeatherPageAppeared);
		}
    }
}
