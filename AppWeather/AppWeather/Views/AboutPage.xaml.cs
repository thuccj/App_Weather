using AppWeather.Models;
using System;
using Xamarin.Forms;

namespace AppWeather.Views
{
    public partial class AboutPage : ContentPage
    {
        Location _Location;
        Location _Location1;


        Services.RestService _restService;
        public AboutPage()
        {
            InitializeComponent();
            _restService = new Services.RestService();

            _Location1 = new Location { LocationName="Thu Duc", LocationId=1};
            _Location = _Location1;
            GetWeather(_Location1);
            
        }
        public AboutPage(Location location)
        {
            InitializeComponent();
            _restService = new Services.RestService();

            _Location = location;
            GetWeather(_Location);
            labelDate.Text = DateTime.Now.ToString();
            //Feelslike.Text = "Feelslike like ";
            UnitsMetricSpan.Text = "℃";
        }

        // Nhận giá trị từ trang khác gửi đến
        //public string GetNameLocation { get; set; }
        //

        public async void GetWeather(Location location_)
        {
            Services.WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Services.Constants.OpenWeatherMapEndpoint));
            BindingContext = weatherData;

            if (string.IsNullOrWhiteSpace(TextInfoLocal.Text))
            {
                await DisplayAlert("Thông báo", "\nKhông có vị trí này trong danh sách tìm kiếm.", "OK");
                await Shell.Current.GoToAsync($"//{nameof(SavedLocationPage)}");
            }
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={_Location.LocationName}";
            requestUri += "&units=metric"; // or units=metric
            requestUri += $"&APPID={Services.Constants.OpenWeatherMapAPIKey}";
            requestUri += "&lang=vi";
            return requestUri;
        }


    }
}