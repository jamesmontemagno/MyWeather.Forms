using MyWeather.iOS.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(EntryBackgroundEffect), "EntryBackgroundEffect")]
namespace MyWeather.iOS.Helpers
{
    public class EntryBackgroundEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            ((UITextField)Control).BorderStyle = UITextBorderStyle.Line;
        }

        protected override void OnDetached()
        {
            //throw new NotImplementedException();
        }
    }
}
