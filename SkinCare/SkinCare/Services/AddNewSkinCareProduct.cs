using Firebase.Database;
using Firebase.Database.Query;
using SkinCare.Model;
using SkinCare.Resources.Images;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SkinCare.Services
{
    public class AddNewSkinCareProduct
    {
        FirebaseClient client;
        public List<SkinCareItems> SkinCareItems { get; set; }

        public AddNewSkinCareProduct()
        {
            client = new FirebaseClient("https://skincare-1c26a-default-rtdb.firebaseio.com/");
            SkinCareItems = new List<SkinCareItems>()

            {
                new SkinCareItems
                {
                    ProductID = 1,
                    CategoryID = 1,
                    ImageUrl = ImageSource.FromResource("SkinCare.Resources.Images.Serum1.jpg", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
                    Description = "essential skincare summer hydrated skin",
                    Rating = 4.9,
                    RatingDetail = "(1.1k Ratings)",
                    Price = 452
                },


                new SkinCareItems
                {
                    ProductID = 2,
                    CategoryID = 1,
                    ImageUrl = ImageSource.FromResource("SkinCare.Resources.Images.Serum.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
                    Description = "essential skincare summer hydrated skin",
                    Rating = 4.9,
                    RatingDetail = "(1.2k Ratings)",
                    Price = 452
                },

                new SkinCareItems
                {
                    ProductID = 3,
                    CategoryID = 2,
                    ImageUrl = ImageSource.FromResource("SkinCare.Resources.Images.sunscreen.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
                    Description = "hydrated skin",
                    Rating = 4.9,
                    RatingDetail = "(2.1k Ratings)",
                    Price = 452
                },

                new SkinCareItems
                {
                    ProductID = 4,
                    CategoryID = 2,
                    ImageUrl = ImageSource.FromResource("SkinCare.Resources.Images.sunscreen2.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
                    Description = "hydrated skin",
                    Rating = 4.9,
                    RatingDetail = "(1.3k Ratings)",
                    Price = 452
                },
            };

        }

        public async Task AddSkinCareAsync()
        {
            try
            {
                foreach(var item in SkinCareItems)
                {
                    await client.Child("ProductItems").PostAsync(new SkinCareItems()
                    {
                        CategoryID = item.CategoryID,
                        ProductID = item.ProductID,
                        ImageUrl = item.ImageUrl,
                        Description = item.Description,
                        Rating = item.Rating,
                        RatingDetail = item.RatingDetail,
                        Price = item.Price,
                        Name = item.Name,
                        
                          
                    });
                }

                
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
