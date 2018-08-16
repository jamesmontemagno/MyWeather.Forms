using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyWeather.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabs : TabbedPage
    {
        public MainTabs ()
        {
            InitializeComponent();
        }
    }
}