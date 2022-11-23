using SkinCare.Helper;
using SkinCare.Services;
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
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
        }

        private async void CategoryBtn_Clicked(object sender, EventArgs e)
        {
            var bot = new AddCategory();
            await bot.AddCategories();
        }

        private async void ProductBtn_Clicked(object sender, EventArgs e)
        {
            var d = new AddNewSkinCareProduct();
            await d.AddSkinCareAsync();
        }
    }
}