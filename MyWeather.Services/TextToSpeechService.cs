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
            TextToSpeech.SpeakAsync(text).ContinueWith((t) => { });
        }
    }
}
