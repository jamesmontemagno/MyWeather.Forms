
namespace MyWeather.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            Xamarin.Insights.Initialize(Xamarin.Insights.DebugModeKey);
            LoadApplication(new MyWeather.App());
        }
    }
}
