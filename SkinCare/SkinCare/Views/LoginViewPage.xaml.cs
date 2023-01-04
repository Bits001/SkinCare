using SkinCare.Services;
using SkinCare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SkinCare.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginViewPage : ContentPage
    {
        public LoginViewPage()
        {
            InitializeComponent();
            //var pageService = new PageService();
            BindingContext = new LoginViewModel();
        }
    }
}