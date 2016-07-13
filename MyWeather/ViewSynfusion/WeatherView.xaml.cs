using MyWeather.ViewModels;
using Xamarin.Forms;

namespace MyWeather.View
{
    public partial class WeatherView : ContentPage
    {
        WeatherViewModel VM => (WeatherViewModel)BindingContext;
        public WeatherView()
        {
            InitializeComponent();

            if (Device.OS == TargetPlatform.iOS)
                Icon = new FileImageSource { File = "tab1.png" };
            BindingContextChanged += WeatherView_BindingContextChanged;
        }

        private void WeatherView_BindingContextChanged(object sender, System.EventArgs e)
        {
            VM.PropertyChanged += (sender2, args) =>
            {
                if (args.PropertyName == "IsBusy" && !VM.IsBusy)
                {
                    barPointer.Value = VM.Humidity;
                }
            };
        }


    }
}
