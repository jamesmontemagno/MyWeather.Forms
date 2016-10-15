using Android.OS;
using Android.App;
using Android.Content.PM;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using HockeyApp.Android;
using HockeyApp.Android.Metrics;

using Plugin.Permissions;

using MyWeather;

[assembly: MetaData("net.hockeyapp.android.appIdentifier", Value = HockeyappConstants.HockeyAppId_Droid)]
namespace MyWeather.Droid
{
	[Activity(Label = "My Weather", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : FormsAppCompatActivity
	{

		protected override void OnCreate(Bundle bundle)
		{

			ToolbarResource = Resource.Layout.toolbar;
			TabLayoutResource = Resource.Layout.tabs;
			base.OnCreate(bundle);

			Forms.Init(this, bundle);

			CrashManager.Register(this, HockeyappConstants.HockeyAppId_Droid);
			UpdateManager.Register(this, HockeyappConstants.HockeyAppId_Droid, true);
			FeedbackManager.Register(this, HockeyappConstants.HockeyAppId_Droid, null);
			MetricsManager.Register(Application);

			LoadApplication(new App());
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
		{
			PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		protected override void OnResume()
		{
			base.OnResume();
			Tracking.StartUsage(this);
		}

		protected override void OnPause()
		{
			base.OnPause();
			Tracking.StopUsage(this);
		}
	}
}


