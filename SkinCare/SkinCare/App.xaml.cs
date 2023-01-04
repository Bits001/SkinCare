using SkinCare.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SkinCare
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new OnboardingPageView());
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
