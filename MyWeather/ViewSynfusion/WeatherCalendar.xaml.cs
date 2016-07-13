using MyWeather.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Syncfusion.SfCalendar;
using Syncfusion.SfCalendar.XForms;

namespace MyWeather.View
{
    public partial class WeatherCalendar : ContentPage
    {
        WeatherViewModel VM => (WeatherViewModel)BindingContext;
        public WeatherCalendar()
        {
            InitializeComponent();

            if (Device.OS == TargetPlatform.iOS)
                Icon = new FileImageSource { File = "tab3.png" };
            BindingContextChanged += WeatherView_BindingContextChanged;
        }

        private void WeatherView_BindingContextChanged(object sender, System.EventArgs e)
        {
            VM.PropertyChanged += (sender2, args) =>
            {
                if (args.PropertyName == "IsBusy" && !VM.IsBusy)
                {
                    var events = VM.Forecast.Select(i => new CalendarInlineEvent
                    {
                        StartTime = DateTime.Parse(i.Date).ToLocalTime(),
                        EndTime = DateTime.Parse(i.Date).AddHours(3).ToLocalTime(),
                        Subject = i.DisplayTemp,
                        Color = i.MainWeather.Temperature > 80 ? Color.Red : (i.MainWeather.Temperature > 60 ? Color.Yellow : Color.Blue)
                    });
                    var collection = new CalendarEventCollection();
                    foreach (var ev in events)
                        collection.Add(ev);
                    calendar.DataSource = collection;
                }
            };
        }
    }
}
