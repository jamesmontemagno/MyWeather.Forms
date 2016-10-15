using Xamarin.Forms;

using HockeyApp;

namespace MyWeather.View
{
    public partial class ForecastView : ContentPage
    {
        public ForecastView()
        {
            InitializeComponent();
            if (Device.OS == TargetPlatform.iOS)
                Icon = new FileImageSource { File = "tab2.png" };
            ListViewWeather.ItemTapped += (sender, args) => ListViewWeather.SelectedItem = null;
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
			MetricsManager.TrackEvent(HockeyappConstants.WeatherPageAppeared);
		}
    }
}
