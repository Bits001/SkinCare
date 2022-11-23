using SkinCare.ViewModels;

using Xamarin.Forms;

namespace SkinCare.Views
{

    public partial class OnboardingPage : ContentPage
    {
        public OnboardingPage()
        {
            InitializeComponent();
            BindingContext = new OnboardingViewModel(Navigation);
        }
    }
}