using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using MyWeather.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(LargeTitleEffect), "LargeTitleEffect")]
namespace MyWeather.iOS.Effects
{
    public class LargeTitleEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (!UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
                return;

            ((UINavigationBar)(this.Control)).PrefersLargeTitles = true;
        }

        protected override void OnDetached()
        {
        }
    }
}