using Firebase.Database;
using Firebase.Database.Query;
using SkinCare.Resources.Images;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SkinCare.Services
{
    public class AddNewSkinCareProduct
    {
        FirebaseClient client;
        //public ObservableCollection<SkinCareItemsModel> SkinCareItems { get; set; }

        //public AddNewSkinCareProduct()
        //{
        //    client = new FirebaseClient("https://skincare-1c26a-default-rtdb.firebaseio.com/");
        //    SkinCareItems = new ObservableCollection<SkinCareItemsModel>()

        //    {
        //        new SkinCareItemsModel
        //        {
        //            ProductID = 1,
        //            CategoryID = 1,
        //            ProductImage = ImageSource.FromResource("SkinCare.Resources.Images.Serum1.jpg", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
        //            ProductDescription = "essential skincare summer hydrated skin",
        //            Rating = 4.9,
        //            RatingDetail = "(1.1k Ratings)",
        //            ProductPrice = 452
        //        },


        //        new SkinCareItemsModel
        //        {
        //            ProductID = 2,
        //            CategoryID = 1,
        //            ProductImage = ImageSource.FromResource("SkinCare.Resources.Images.Serum.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
        //            ProductDescription = "essential skincare summer hydrated skin",
        //            Rating = 4.9,
        //            RatingDetail = "(1.2k Ratings)",
        //            ProductPrice = 452
        //        },

        //        new SkinCareItemsModel
        //        {
        //            ProductID = 3,
        //            CategoryID = 2,
        //            ProductImage = ImageSource.FromResource("SkinCare.Resources.Images.sunscreen.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
        //            ProductDescription = "hydrated skin",
        //            Rating = 4.9,
        //            RatingDetail = "(2.1k Ratings)",
        //            ProductPrice = 452
        //        },

        //        new SkinCareItemsModel
        //        {
        //            ProductID = 4,
        //            CategoryID = 2,
        //            ProductImage = ImageSource.FromResource("SkinCare.Resources.Images.sunscreen2.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
        //            ProductDescription = "hydrated skin",
        //            Rating = 4.9,
        //            RatingDetail = "(1.3k Ratings)",
        //            ProductPrice = 452
        //        },
        //    };

        //}

        //public async Task AddSkinCareAsync()
        //    {
        //        try
        //        {
        //            foreach(var item in SkinCareItems)
        //            {
        //                await client.Child("ProductItems").PostAsync(new SkinCareItemsModel()
        //                {
        //                    CategoryID = item.CategoryID,
        //                    ProductID = item.ProductID,
        //                    ProductImage = item.ProductImage,
        //                    ProductDescription = item.ProductDescription,
        //                    Rating = item.Rating,
        //                    RatingDetail = item.RatingDetail,
        //                    ProductPrice = item.ProductPrice,
        //                    ProductName = item.ProductName,


        //                });
        //            }


        //        }
        //        catch (Exception ex)
        //        {
        //            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        //        }
        //    }
        //}
    }
}
