﻿using AppWeather.Services;
using AppWeather.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWeather
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            MainPage = new AppShell();

            //bool kiemtra = false;

            //if (kiemtra == true)
            //{
            //    MainPage = new AppShell();
            //}
            //else
            //{
            //    MainPage = new Views.LoginPage();
            //    kiemtra = !kiemtra;
            //}
            
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
