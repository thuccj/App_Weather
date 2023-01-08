using AppWeather.ViewModels;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWeather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountUserPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyAxRp4OlhUwOtvvzdC_VxZ1WE7ZKqJ5hf8";
        public AccountUserPage()
        {
            InitializeComponent();
            GetProfileInformationAndRefreshToken();
        }
        async private void GetProfileInformationAndRefreshToken()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                //Lưu thời gian đăng nhập
                var savedfirebaseauth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
                //Refreshing token
                var RefreshedContent = await authProvider.RefreshAuthAsync(savedfirebaseauth);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));
                //Xuất thông tin user
                MyUserName.Text = savedfirebaseauth.User.Email;

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                //await App.Current.MainPage.DisplayAlert("Alert", "Oh no !  Token expired", "OK");
            }
        }
        private async void Logout_Clicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync($"//{nameof(LoginUserPage)}");
            await DisplayAlert("Thông báo", "Tính năng đang được bảo trì", "OK");
        }
        private async void Default_Light_Clicked(object sender, CheckedChangedEventArgs e)
        {
            Background_App.BackgroundColor = Color.White;
            MyUserName.TextColor = Color.FromHex("#063267");
            MyuserName.TextColor = Color.FromHex("#063267");
            Theme.TextColor = Color.FromHex("#063267");
        }
        private async void Dark_Clicked(object sender, CheckedChangedEventArgs e)
        {
            Background_App.BackgroundColor = Color.DarkGray;
            MyUserName.TextColor = Color.White;
            MyuserName.TextColor = Color.White;
            Theme.TextColor = Color.White;
        }
    }
}