using MyWeather.Services;
using MyWeather.UWP.Services;

[assembly: Xamarin.Forms.Dependency(typeof(HockeyappService_UWP))]

namespace MyWeather.UWP.Services
{
    public class HockeyappService_UWP : IHockeyappService
    {
        public void TrackEvent(string eventName)
        {
            Microsoft.HockeyApp.HockeyClient.Current.TrackEvent(eventName);
        }
    }
}
