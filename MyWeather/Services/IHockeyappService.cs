using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeather.Services
{
    public interface IHockeyappService
    {
        void TrackEvent(string eventName);
        void TrackEvent(string eventName, Dictionary<string, string> properties, Dictionary<string, double> measurements);
    }
}
