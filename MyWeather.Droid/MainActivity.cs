
using Android.App;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Plugin.Permissions;
using Android.Content.PM;
using Android.Gms.Ads;
using Plugin.CurrentActivity;

namespace MyWeather.Droid
{
    [Activity(Label = "@string/app_name",
    Icon = "@mipmap/ic_launcher",
    LaunchMode = LaunchMode.SingleTask,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {

		protected override void OnCreate (Bundle bundle)
		{
			
		    ToolbarResource = Resource.Layout.MyToolbar;
		    TabLayoutResource = Resource.Layout.MyTabbar;

		    base.OnCreate (bundle);

            MobileAds.Initialize(ApplicationContext, "ca-app-pub-2457246758474079~6998031863");

            Xamarin.Essentials.Platform.Init(this, bundle);

            CrossCurrentActivity.Current.Init(this, bundle);
		    Forms.Init(this, bundle);
		
		    LoadApplication(new App());
            
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}


