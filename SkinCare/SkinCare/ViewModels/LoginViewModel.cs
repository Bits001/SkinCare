using GalaSoft.MvvmLight.Views;
using MvvmHelpers.Interfaces;
using SkinCare.Services;
using SkinCare.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SkinCare.ViewModels
{
    public class LoginViewModel : ViewModelBase

    {
        public LoginViewModel()
        {
          //_pageService = pageService;

          ChangeTemplateCmd = new Command<string>(key => AccountPageTemplate = key);
          LoginCmd = new Command(async () => await HomePageView());
          PrivacyCmd = new Command(async () => await ShowPrivacyPolicy());
          TermsCmd = new Command(async () => await ShowTermsAndCondition());
            RegisterCmd = new Command(async () => await RegisterPageView());
        }

        private Task ShowTermsAndCondition()
        {
            return Application.Current.MainPage.DisplayAlert("Terms and Condition", TermsAndCondition, "OK");
        }

        private Task ShowPrivacyPolicy()
        {
            return Application.Current.MainPage.DisplayAlert("Privacy & Policy", PrivacyPolicy, "OK");
        }



        private async Task RegisterPageView()
        {
            Application.Current.MainPage = new NavigationPage(new RegisterPageView());
        }

        private async Task  HomePageView()
        {
             Application.Current.MainPage = new NavigationPage(new HomePageView());
        }







        #region General Properties

        public Command<ScrollView> JoinUsCmd { get; set; }
        private IPageService _pageService;
        public Command LoginCmd { get; set; }
        public Command RegisterCmd { get; set; }
        public string AccountPageTemplate { get; set; }
        public Command ChangeTemplateCmd { get; }
        
        public Command PrivacyCmd { get; }
        public Command TermsCmd { get; } 
       
        private const string PrivacyPolicy = "asd";
        private const string TermsAndCondition = "This page contains our terms & conditions, as well as information about our return policy, etc. Please read these terms & conditions carefully before ordering any products from Beauty Everyday. By ordering any of our products, you agree to be bound by these terms & conditions.";
        #endregion
    }
}
