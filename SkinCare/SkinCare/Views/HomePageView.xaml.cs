using SkinCare.Helper;
using SkinCare.ViewModels;
using System;

using Xamarin.Forms;

namespace SkinCare.Views
{
    public partial class HomePageView : ContentPage
    {
        public HomePageView()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel(Navigation);
            
        }

        private void OpenMenu()
        {
            MenuGrid.IsVisible = true;

            Action<double> callback = input => MenuView.TranslationX = input;
            MenuView.Animate("anim", callback, -260, 0, 16, 300, Easing.CubicInOut);
        }

      
        private void CloseMenu()
        {
            Action<double> callback = input => MenuView.TranslationX = input;
            MenuView.Animate("Anim", callback, 0, -260, 16, 380, Easing.CubicInOut);
            MenuGrid.IsVisible = false;
        }
        private void OverlayTapped(object sender, EventArgs e)
        {
            CloseMenu();
        }

        private void MenuTapped(object sender, EventArgs e)
        {
            OpenMenu();
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CollectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}