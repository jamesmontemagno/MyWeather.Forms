using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AarhusWeather
{
  public class WeatherViewModel : INotifyPropertyChanged
  {

    private string temp = string.Empty;
    public string Temp
    {
      get { return temp; }
      set { temp = value; OnPropertyChanged("Temp"); }
    }

    private string condition = string.Empty;
    public string Condition
    {
      get { return condition; }
      set { condition = value; OnPropertyChanged("Condition"); }
    }

    private ICommand getWeather;
    public ICommand GetWeather
    {
      get
      {
        return getWeather ?? (getWeather = new Command(
          () => ExecuteGetWeather()));
      }
    }

    private string location = "Aarhus,Denmark";
    public string Location
    {
      get { return location; }
      set { location = value; OnPropertyChanged("Location"); }
    }


    private bool isBusy = false;
    public bool IsBusy
    {
      get { return isBusy; }
      set { isBusy = value; OnPropertyChanged("IsBusy"); }
    }

    private string apiCall = "http://api.openweathermap.org/data/2.5/weather?q={0}&units=Metric";
    private async Task ExecuteGetWeather()
    {
      IsBusy = true;
      var client = new HttpClient();
      var weather = await client.GetStringAsync(string.Format
        (apiCall, Location.Trim()));

      var weatherStuff = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(weather);
      Temp = weatherStuff.main.temp.ToString() + "C";
      Condition = weatherStuff.weather[0].main;
      IsBusy = false;

      DependencyService.Get<ITextToSpeech>().Speak(
        "Today in " + Location + " it is " + Condition +
        "and currently " + Temp + " Degrees Celcius.");
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string name)
    {
      if (PropertyChanged == null)
        return;

      PropertyChanged(this, new PropertyChangedEventArgs(name)); ;
    }
  }
}
