using MyWeather.Cell;
using MyWeather.ViewModels;
using MyWeather.Models;
using Xamarin.Forms;
using System;

namespace MyWeather.View
{
    public partial class ForecastView : ContentPage
    {
        public ForecastView()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.iOS)
                Icon = new FileImageSource { File = "tab2.png" };

            if (DesignMode.IsDesignModeEnabled)
                SetupFlex();

            

            //ListViewWeather.ItemTapped += (sender, args) => ListViewWeather.SelectedItem = null;
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            SetupFlex();
        }
        void SetupFlex()
        {

            if (DesignMode.IsDesignModeEnabled)
            {
                for (int i = 0; i < 10; i++)
                {
                    FlexForecast.Children.Add(new WeatherCardView());
                }
                return;
            }
            var vm = (WeatherViewModel)BindingContext;
            vm.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName != nameof(vm.Forecast))
                    return;

                FlexForecast.Children.Clear();
                foreach (var item in vm.Forecast.Items)
                    FlexForecast.Children.Add(new WeatherCardView
                    {
                        BindingContext = item
                    });
            };
        }
    }
}
