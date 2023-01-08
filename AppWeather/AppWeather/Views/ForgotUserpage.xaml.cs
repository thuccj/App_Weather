using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWeather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotUserpage : ContentPage
    {
        public ForgotUserpage()
        {
            InitializeComponent();
        }
        private async void Forget_Clicked(object sender, EventArgs e)
        {
            if (EntNameEmail.Text == "")
            {
                await DisplayAlert("Thông báo", "Bạn chưa nhập email", "OK");
            }
            else
            {
                await DisplayAlert("Thông báo", "Link thay đổi mật khẩu đã được gửi", "OK");
                await Navigation.PushAsync(new LoginUserPage());
            }
        }
    }
}