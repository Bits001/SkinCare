using SkinCare.Services;
using SkinCare.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SkinCare.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnboardingPageView : ContentPage
    {
        public OnboardingPageView()
        {
            InitializeComponent();
            var pageService = new PageService();

            BindingContext = new OnboardingPageViewModel(pageService);
        }
    }
}