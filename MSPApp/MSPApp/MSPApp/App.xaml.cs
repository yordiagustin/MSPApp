using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using MSPApp.Helpers;
using MSPApp.Views;
using Xamarin.Forms;

namespace MSPApp
{
    public partial class App : Application
    {

        public static MobileServiceClient MobileService = new MobileServiceClient(Constants.serviceUrl);
        public static MasterDetailPage MasterPage;
        public App()
        {
            InitializeComponent();
            if (!Settings.IsLogged)
            {
                MainPage = new WelcomePage();
            }
            else
            {
                MainPage = new MasterPage();
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
