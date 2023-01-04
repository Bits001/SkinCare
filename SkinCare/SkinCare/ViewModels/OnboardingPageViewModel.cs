using GalaSoft.MvvmLight.Views;
using PropertyChanged;
using SkinCare.Model;
using SkinCare.Resources.Images;
using SkinCare.Services;
using SkinCare.Views;
using System.Collections.ObjectModel;
using System.Reflection;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace SkinCare.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class OnboardingPageViewModel : ViewModelBase
    {
        public OnboardingPageViewModel(IPageService pageService)
        { 
           
            Onboarding = new ObservableCollection<Onboardings>
            {
                new Onboardings()
                {
                   ImagePath = ImageSource.FromResource("SkinCare.Resources.Images.OnboardingImage.gif", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
                   Header ="Search",
                   Content="Look for products that suit your skin's needs",
                   CarouselItems= new WalkthroughItemPage()
                },

                new Onboardings()
                {
                   ImagePath = ImageSource.FromResource("SkinCare.Resources.Images.OnboardingImage2.gif", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
                   Header ="See",
                   Content="Know what goes into your favorite skincare products",
                   CarouselItems= new WalkthroughItemPage()
                },

                new Onboardings()
                {
                   ImagePath = ImageSource.FromResource("SkinCare.Resources.Images.OnboardingImage3.gif", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
                   Header ="Learn",
                   Content="Find out the purpose of each ingredient in a product",
                   CarouselItems= new WalkthroughItemPage()
                }
            };

            foreach (var boarding in Onboarding)
            {
                boarding.CarouselItems.BindingContext = boarding;
            }

            NextCmd = new Command(Next);
            SkipCmd = new Command(LoginViewPage);
        }

        private void LoginViewPage()
        {
            Application.Current.MainPage = new LoginViewPage();
        }

        private void Next(object obj)
        {
            if(PositionIndex < Onboarding.Count -1)
            {
                PositionIndex++;
            }
            else
            {
                LoginViewPage();
            }
        }
      

        public string NetButtonText
        {
            get
            {
                if (PositionIndex == Onboarding.Count - 1)
                    return "Done";
                return "Next     >";
            }
        }
        public ObservableCollection<Onboardings> Onboarding { get; set; }
        public Command NextCmd { get; set; }
        public Command SkipCmd { get; set; }
        public int PositionIndex { get; set; }
        private IPageService _pageService;

    }
    ////{
    ////    Navigation = _navigation;
    ////    StartCmd = new Command(async () => await RegisterViewPage());
    ////}
    ///
    ////private async Task RegisterViewPage()
    ////{
    ////    await Navigation.PushAsync(new RegisterViewPage());
    ////}

    ////#region Properties
    ////public Command StartCmd { get; set; }
    ////public INavigation Navigation { get; set; }

    //#endregion
}