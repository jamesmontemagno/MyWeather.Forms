using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AarhusWeather
{
  public interface ITextToSpeech
  {
    void Speak(string text);
  }
}
