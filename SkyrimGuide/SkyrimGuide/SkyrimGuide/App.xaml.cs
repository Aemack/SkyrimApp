using SkyrimGuide.Services;
using SkyrimGuide.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SkyrimGuide
{
    public partial class App : Application
    {

        public static string DatabaseLocation = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            MainPage = new AppShell();

            DatabaseLocation = databaseLocation;
            DatabaseSetup.SetUpData();
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
