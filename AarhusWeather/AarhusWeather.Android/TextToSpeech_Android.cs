using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Speech.Tts;
using AarhusWeather;
using TripExpenses.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeech_Android))]
namespace TripExpenses.Droid
{
  public class TextToSpeech_Android : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
  {
    TextToSpeech speaker;
    string toSpeak;

    public TextToSpeech_Android() { }

    public void Speak(string text)
    {
      var ctx = Xamarin.Forms.Forms.Context; // useful for many Android SDK features
      toSpeak = text;
      if (speaker == null)
      {
        speaker = new TextToSpeech(ctx, this);
      }
      else
      {
        var p = new Dictionary<string, string>();
        speaker.Speak(toSpeak, QueueMode.Flush, p);
      }
    }

    #region IOnInitListener implementation
    public void OnInit(OperationResult status)
    {
      if (status.Equals(OperationResult.Success))
      {
        var p = new Dictionary<string, string>();
        speaker.Speak(toSpeak, QueueMode.Flush, p);
      }
    }
    #endregion
  }
}