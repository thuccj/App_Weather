using Firebase.Auth;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWeather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupUserPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyAxRp4OlhUwOtvvzdC_VxZ1WE7ZKqJ5hf8";
        public SignupUserPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        //Ẩn hiện mật khẩu
        async void IsCheckedPassword(object sender, CheckedChangedEventArgs e)
        {
            bool isCheck = CheckBoxPass.IsChecked;
            if (!isCheck)
            {
                UserNewPassword.IsPassword = true;
                UserNewAgainPassword.IsPassword = true;
                TextShowHidePassword.Text = "Hiện mật khẩu";
            }
            else
            {
                UserNewPassword.IsPassword = false;
                UserNewAgainPassword.IsPassword = false;
                TextShowHidePassword.Text = "Ẩn mật khẩu";
            }
        }
        async void signupbuttonclicked(Object sender, EventArgs e)
        {
            try
            {
                string check_email = "@gmail.com";
                int index_check = UserNewEmail.Text.IndexOf('@');
                string getfull_check = UserNewEmail.Text.Substring(index_check);

                //Check True Value
                if (check_email != getfull_check || index_check == -1)
                {
                    await App.Current.MainPage.DisplayAlert("Thông báo", "Email không hợp lệ \n\n-Email: ***@gmail.com", "Ok");
                }
                else if (UserNewPassword.Text.Length < 6)
                {
                    await App.Current.MainPage.DisplayAlert("Thông báo", "Mật khẩu tối thiểu 6 ký tự", "Ok");
                }
                else if (UserNewPassword.Text != UserNewAgainPassword.Text)
                {
                    await App.Current.MainPage.DisplayAlert("Thông báo", "Mật khẩu nhập lại không khớp", "Ok");
                }
                else
                {
                    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                    var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserNewEmail.Text, UserNewPassword.Text);

                    await App.Current.MainPage.DisplayAlert("Thông báo", "Tạo tài khoản thành công", "Ok");
                    await Navigation.PushAsync(new LoginPage());
                }
            }
            catch (Exception ex)
            {
                //await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                await App.Current.MainPage.DisplayAlert("Thông báo", "Kiểm tra lại thông tin tài khoản \n\n-Tài khoản có thể đã tồn tại \n-Chưa nhập đủ thông tin", "OK");
            }
        }

        private async void loginbuttonclicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginUserPage());
        }
    }
}