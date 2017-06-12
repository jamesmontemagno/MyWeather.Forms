using MyWeather.iOS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportEffect(typeof(EntryBackgroundEffect), "EntryBackgroundEffect")]
namespace MyWeather.iOS.Helpers
{
    public class EntryBackgroundEffect : PlatformEffect
    {
        UIColor backgroundColor;

        protected override void OnAttached()
        {
            backgroundColor = UIColor.FromRGB(204, 153, 255);
            ((UITextField)Control).BorderStyle = UITextBorderStyle.Line;
        }

        protected override void OnDetached()
        {
            //throw new NotImplementedException();
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    if (Control.BackgroundColor == backgroundColor)
                    {
                        Control.BackgroundColor = UIColor.White;
                    }
                    else
                    {
                        Control.BackgroundColor = backgroundColor;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }
    }

}