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

			InitializeHockeyApp(HockeyappConstants.HockeyAppId_Droid);

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

		void InitializeHockeyApp(string hockeyAppID)
		{
			CrashManager.Register(this, hockeyAppID);
			UpdateManager.Register(this, hockeyAppID, true);
			FeedbackManager.Register(this, hockeyAppID, null);
			MetricsManager.Register(Application);
		}
	}
}


