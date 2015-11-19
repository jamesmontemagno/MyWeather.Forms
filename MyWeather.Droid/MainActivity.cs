using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace MyWeather.Droid
{
	[Activity (Label = "My Weather", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : FormsAppCompatActivity
    {

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            Forms.Init(this, bundle);
            Xamarin.Insights.Initialize(Xamarin.Insights.DebugModeKey, this);

            ToolbarResource = Resource.Layout.toolbar;
            TabLayoutResource = Resource.Layout.tabs;
            LoadApplication(new App());
		}
	}
}


