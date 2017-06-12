using AppKit;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

namespace MyWeather.macOS
{
    [Register("AppDelegate")]
	public class AppDelegate : FormsApplicationDelegate
    {
        NSWindow window;
		public AppDelegate()
		{
			var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

			var rect = new CoreGraphics.CGRect(200, 200, 1024/2, 768/2);
			window = new NSWindow(rect, style, NSBackingStore.Buffered, false);
			window.Title = "My Weather";
			window.TitleVisibility = NSWindowTitleVisibility.Hidden;
		}

        public override NSWindow MainWindow => window;

		public override void DidFinishLaunching(NSNotification notification)
		{
			Forms.Init();
			LoadApplication(new App());
			base.DidFinishLaunching(notification);
		}
	}
}
