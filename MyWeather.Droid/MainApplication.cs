using System;

using Android.OS;
using Android.App;
using Android.Runtime;

using Plugin.CurrentActivity;

namespace MyWeather.Droid
{
	//You can specify additional application information in this attribute
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          :base(handle, transer)
        {
        }

        public override void OnCreate()
        {
			//A great place to initialize Xamarin.Insights and Dependency Services!
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
			UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityPaused(Activity activity)
        {
			UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityResumed(Activity activity)
        {
			RegisterActivityLifecycleCallbacks(this);
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
			RegisterActivityLifecycleCallbacks(this);
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityStopped(Activity activity)
        {
			UnregisterActivityLifecycleCallbacks(this);
        }
    }
}