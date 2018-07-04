using MyWeather.View;
using Xamarin.Forms;
using static System.Diagnostics.Debug;

[assembly:Xamarin.Forms.Xaml.XamlCompilation(Xamarin.Forms.Xaml.XamlCompilationOptions.Compile)]
namespace MyWeather
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new MainTabs())
            {
                BarBackgroundColor = Color.FromHex("3498db"),
                BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
            base.OnStart();
            WriteLine("Application OnStart");
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            WriteLine("Application OnSleep");
        }

        protected override void OnResume()
        {
            base.OnResume();
            WriteLine("Application OnResume");
        }
    }
}

