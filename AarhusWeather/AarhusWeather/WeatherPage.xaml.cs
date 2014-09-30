using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AarhusWeather
{
  public partial class WeatherPage
  {
    public WeatherPage()
    {
      InitializeComponent();
      BindingContext = new WeatherViewModel();

      this.SetBinding(Page.IsBusyProperty, "IsBusy");
      
    }
  }
}
