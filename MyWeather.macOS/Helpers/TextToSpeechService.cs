using Plugin.TextToSpeech;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MyWeather.Services
{
    public class TextToSpeechService
    {
        public static void Speak(string text)
        {
            CrossTextToSpeech.Current.Speak(text).ContinueWith((t) => { });
        }
    }
}
