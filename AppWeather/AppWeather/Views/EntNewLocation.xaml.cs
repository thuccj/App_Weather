﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;
using Xamarin.Essentials;

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


        // Tìm thông tin thời tiết và kiểm tra dữ liệu được nhập
        async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                Services.WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Services.Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherData;

                if (string.IsNullOrWhiteSpace(txtLocal.Text))
                {
                    DisplayAlert("Thông báo", "\nKhông có vị trí này trong danh sách tìm kiếm. \n\nVí dụ: Ha Noi", "đóng");
                }
                else
                {
                    nameWeather.Text = "Thời tiết ổn định đó";
                }
                
            }
            else
            {
                DisplayAlert("Thông báo", "\nBạn chưa nhập vị trí cần tìm. \n\nVí dụ: Ha Noi", "đóng");
            }
        }
        //private async void StartCall(object sender, EventArgs e)
        //{
        //    await DisplayPromptAsync("Nhập vị trí thành phố", "What's your name?");
        //}

        //Tạo một API với vị trí được nhập
        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += "&units=metric"; // units=metric
            requestUri += $"&APPID={Services.Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
}