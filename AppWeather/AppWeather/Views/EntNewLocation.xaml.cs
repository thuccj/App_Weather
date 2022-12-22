using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWeather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntNewLocation : ContentPage
    {
        Services.RestService _restService;
        public EntNewLocation()
        {
            InitializeComponent();
            _restService = new Services.RestService();
        }
        async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                Services.WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Services.Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherData;
            }
        }
        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += "&units=metric"; // or units=metric
            requestUri += $"&APPID={Services.Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
}