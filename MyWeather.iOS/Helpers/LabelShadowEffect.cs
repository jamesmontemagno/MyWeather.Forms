using CoreGraphics;
using MyWeather.Effects;
using MyWeather.iOS.Helpers;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace MyWeather.iOS.Helpers
{
    public class LabelShadowEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                UpdateControl();
                Control.Layer.ShadowOpacity = 1.0f;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        private void UpdateControl()
        {
            UpdateRadius();
            UpdateColor();
            UpdateOffset();
        }

        protected override void OnDetached()
        {
        }

        void UpdateRadius()
        {
            Control.Layer.CornerRadius = (nfloat)ShadowEffect.GetRadius(Element);
        }

        void UpdateColor()
        {
            Control.Layer.ShadowColor = ShadowEffect.GetColor(Element).ToCGColor();
        }

        void UpdateOffset()
        {
            Control.Layer.ShadowOffset = new CGSize(
                (double)ShadowEffect.GetDistanceX(Element),
                (double)ShadowEffect.GetDistanceY(Element));
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args.PropertyName == ShadowEffect.RadiusProperty.PropertyName)
            {
                UpdateRadius();
            }
            else if (args.PropertyName == ShadowEffect.ColorProperty.PropertyName)
            {
                UpdateColor();
            }
            else if (args.PropertyName == ShadowEffect.DistanceXProperty.PropertyName ||
                     args.PropertyName == ShadowEffect.DistanceYProperty.PropertyName)
            {
                UpdateOffset();
            }
            else if (args.PropertyName == Label.TextProperty.PropertyName)
            {
                UpdateControl();
            }
        }
    }
}
