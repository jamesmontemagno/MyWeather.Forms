
namespace MyWeather.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            
            new Syncfusion.SfBusyIndicator.XForms.SfBusyIndicator();
            new Syncfusion.SfCalendar.XForms.SfCalendar();
            new Syncfusion.SfGauge.XForms.SfLinearGauge();
            LoadApplication(new MyWeather.App());
        }
    }
}
