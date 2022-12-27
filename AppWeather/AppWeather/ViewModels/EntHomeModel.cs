using AppWeather.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

using System.Windows.Input;
using Xamarin.Essentials;

namespace AppWeather.ViewModels
{
    public class EntHomeModel : LoginViewModel
    {
        public EntHomeModel()
        {
            btnUseLocal = new Command(async () => { await Shell.Current.GoToAsync($"//{nameof(AboutPage)}"); });
        }
        public ICommand btnUseLocal { get; }
    }
}