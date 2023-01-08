using AppWeather.Helper;
using AppWeather.Services;
using Xamarin.Forms;

namespace AppWeather
{
    public partial class App : Application
    {
        public static LocationDatabase LocationDb = new LocationDatabase();
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
