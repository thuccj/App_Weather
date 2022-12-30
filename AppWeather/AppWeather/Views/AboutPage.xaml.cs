using AppWeather.Models;
using Xamarin.Forms;

namespace AppWeather.Views
{
    public partial class AboutPage : ContentPage
    {
        Location _Location;
        Services.RestService _restService;
        public AboutPage()
        {
            InitializeComponent();
            _restService = new Services.RestService();
        }
        public AboutPage(Location location)
        {
            InitializeComponent();
            _restService = new Services.RestService();
            _Location = location;
            GetWeather(_Location);
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
            return requestUri;
        }


    }
}