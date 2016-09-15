using MyWeather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyWeather.Cell
{
    class WeatherTemplateSelector : Xamarin.Forms.DataTemplateSelector
    {
        public WeatherTemplateSelector()
        {
            // Retain instances!
            this.rainDataTemplate = new DataTemplate(typeof(RainDataTemplate));
            this.normalDataTemplate = new DataTemplate(typeof(NormalDataTemplate));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var weather = item as WeatherRoot;
            if (weather == null)
                return null;
            return  weather.IsRainy ? this.rainDataTemplate : this.normalDataTemplate;
        }

        private readonly DataTemplate rainDataTemplate;
        private readonly DataTemplate normalDataTemplate;
    }
}
