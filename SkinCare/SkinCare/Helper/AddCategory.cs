using Firebase.Database;
using Firebase.Database.Query;
using SkinCare.Model;
using SkinCare.Resources.Images;
using SkinCare.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SkinCare.Helper
{
    public class AddCategory : BaseViewModel
    {
        private ObservableCollection<CategoryModel> categories;
        public ObservableCollection<CategoryModel> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged();
            }

        }

        FirebaseClient client;

        public AddCategory( )
        {

            

            client = new FirebaseClient("https://skincare-1c26a-default-rtdb.firebaseio.com/");
          
            Categories = GetCategories();
        }

        public ObservableCollection<CategoryModel> GetCategories()
        {
            return new ObservableCollection<CategoryModel>
            {
                new CategoryModel
                {
                    CategoryID = 1,
                    CategoryName = "Try1",
                    CategoryPoster = ImageSource.FromResource("SkinCare.Resources.Images.Toner.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
                    ImageUrl= ImageSource.FromResource("SkinCare.Resources.Images.Toner2.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
                },

                new CategoryModel
                {
                    CategoryID = 2,
                    CategoryName = "Moisturizers",
                    CategoryPoster = ImageSource.FromResource("SkinCare.Resources.Images.moisturizer2.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
                    ImageUrl= ImageSource.FromResource("SkinCare.Resources.Images.Nmoisturizer.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly),

                },
                new CategoryModel()
                {
                    CategoryID = 3,
                    CategoryName = "Serums",
                    CategoryPoster = ImageSource.FromResource("SkinCare.Resources.Images.Serum.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
                    ImageUrl= ImageSource.FromResource("SkinCare.Resources.Images.Serum1.jpg", typeof(ImageResourceExtension).GetTypeInfo().Assembly),

                }
            };
        }

        public async Task AddCategories()
        {
            try
            {
                foreach(var category in Categories)
                {
                   await client.Child("Categories").PostAsync(new CategoryModel()
                   {
                       CategoryID = category.CategoryID,
                       CategoryName = category.CategoryName,
                       CategoryPoster = category.CategoryPoster,
                       ImageUrl= category.ImageUrl,
                   });
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
