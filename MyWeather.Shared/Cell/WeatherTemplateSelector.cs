using MyWeather.Models;
using Xamarin.Forms;

namespace MyWeather.Cell
{
    class WeatherTemplateSelector : DataTemplateSelector
    {
        public WeatherTemplateSelector()
        {
            // Retain instances!
            rainDataTemplate = new DataTemplate(typeof(RainDataTemplate));
            normalDataTemplate = new DataTemplate(typeof(NormalDataTemplate));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (!(item is WeatherRoot weather))
                return null;

            return  weather.IsRainy ? rainDataTemplate : normalDataTemplate;
        }

        private readonly DataTemplate rainDataTemplate;
        private readonly DataTemplate normalDataTemplate;
    }
}
