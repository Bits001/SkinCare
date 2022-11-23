using SkinCare.Services;
using SkinCare.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SkinCare.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region properties
        private string _Username;
        public string Username
        {
            set
            {
                this._Username = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Username;
            }
            
        }
        private string _Password;
        public string Password
        {
            set 
            { 
                this._Password = value;
                OnPropertyChanged();
            }
            get { return this._Password; }
        }
        private bool _IsBusy;
        public bool IsBusy
        {
            set 
            {
                this._IsBusy = value;
                OnPropertyChanged();
            }
            get
            {
                return this._IsBusy;
            }
        }

        private bool _Result;
        public bool Result
        {
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Result;
            }
        }

        public Command LoginCmd { get; set; }
        public Command RegisterCmd { get; set; }

        public INavigation Navigation { get; set; }
        #endregion


        public LoginViewModel(INavigation navigation)
        {

            LoginCmd = new Command(async () => await LoginCommand());
            RegisterCmd = new Command(async () => await RegisterCommand());
            Navigation = navigation;
        }

        private async Task RegisterCommand()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.RegisterUser(Username, Password);
                if (Result)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "User is Registered", "Ok");
                   
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "User already exists", "Ok");
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error",ex.Message,"Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task LoginCommand()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.LoginUser(Username, Password);
                if(Result)
                {
                    Preferences.Set("Username", Username);
                    await Navigation.PushAsync(new HomePageView());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Credentials", "Ok");
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
