using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeather.Services;
using Xamarin.Forms;

namespace MyWeather.Helpers
{
    public static class HockeyappHelpers
    {
        public static void TrackEvent(string eventName)
        {
            switch (Device.OS)
            {
                case TargetPlatform.iOS:
                case TargetPlatform.Android:
                    HockeyApp.MetricsManager.TrackEvent(eventName);
                    break;
                case TargetPlatform.Windows:
                    DependencyService.Get<IHockeyappService>()?.TrackEvent(eventName);
                    break;
            }
        }

        public static void TrackEvent(string eventName, Dictionary<string, string> properties, Dictionary<string,double> measurements)
        {
            switch (Device.OS)
            {
                case TargetPlatform.iOS:
                case TargetPlatform.Android:
                    HockeyApp.MetricsManager.TrackEvent(eventName,properties,measurements);
                    break;
                case TargetPlatform.Windows:
                    DependencyService.Get<IHockeyappService>()?.TrackEvent(eventName, properties, measurements);
                    break;
            }
        }
    }
}
