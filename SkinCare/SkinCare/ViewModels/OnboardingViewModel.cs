using SkinCare.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SkinCare.ViewModels
{
    public class OnboardingViewModel
    {
        public INavigation Navigation { get; set; }
        public Command StartCmd { get; }

        public OnboardingViewModel(INavigation navigation)
        {
            Navigation = navigation;
            StartCmd = new Command(async () => await LoginViewPage());
        }

        private async Task LoginViewPage()
        {
            await Navigation.PushAsync(new LoginView());
        }
    }


}
