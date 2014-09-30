using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.AVFoundation;
using TripExpenses.iOS;
using AarhusWeather;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeech_iOS))]
namespace TripExpenses.iOS
{
  public class TextToSpeech_iOS : ITextToSpeech
  {
    public TextToSpeech_iOS() { }

    public void Speak(string text)
    {
      var speechSynthesizer = new AVSpeechSynthesizer();

      var speechUtterance = new AVSpeechUtterance(text)
      {
        Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
        Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
        Volume = 0.5f,
        PitchMultiplier = 1.0f
      };

      speechSynthesizer.SpeakUtterance(speechUtterance);
    }
  }
}