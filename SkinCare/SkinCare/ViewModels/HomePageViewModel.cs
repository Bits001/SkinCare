using Firebase.Database;
using SkinCare.Model;
using SkinCare.Resources.Images;
using SkinCare.Views;
using System;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SkinCare.ViewModels
{
	public class HomePageViewModel : BaseViewModel
	{

		FirebaseClient client;

	
        public HomePageViewModel(INavigation navigation)
		{

			client = new FirebaseClient("https://skincare-1c26a-default-rtdb.firebaseio.com/");
            MenuList = GetMenu();
			Categories = GetCategories();
			HomePage = new ObservableCollection<HomePageModel>
			{
				new HomePageModel()
				{
					ProductCategory="Serum",
					ProductName = "Ordinary Serum",
					ProductDescription = "Combines a range of comprehensive research to target multiple signs of anging at once.",
					Price=820,
					Image = ImageSource.FromResource("SkinCare.Resources.Images.product1-removebg-preview.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
				},
				new HomePageModel()
				{
					ProductCategory = "Sunscreen",
					ProductName = "Azelaic Acid Suspension 10%",
					ProductDescription="Use sun protection during the day.",
					Price=119,
					Image = ImageSource.FromResource("SkinCare.Resources.Images.sunscreen.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
				},
				new HomePageModel()
				{ 
					ProductCategory = "Moisturizer",
					ProductName = "Natural Moisturizing Factors + HA (NMF)",
					ProductDescription = "NMF are elements that keep the outer layer of the skin protected and well-hydrated. ",
					Price=600,
					Image = ImageSource.FromResource("SkinCare.Resources.Images.Nmoisturizer.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
				},
				new HomePageModel()
				{ 
					ProductCategory = "Toner",
					ProductName = "Lactic Acid",
					ProductDescription = "offers very mild exfoliation and is supported with a purified Tasmanian pepperberry known to reduce signs of inflammation",
					Price=566,
					Image = ImageSource.FromResource("SkinCare.Resources.Images.Toner.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
				},

				new HomePageModel()
				{
					ProductCategory = "Toner",
					ProductName = "Lactic Acid",
					ProductDescription = "offers very mild exfoliation and is supported with a purified Tasmanian pepperberry known to reduce signs of inflammation",
					Price=566,
					Image = ImageSource.FromResource("SkinCare.Resources.Images.Toner.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
				},
				new HomePageModel()
				{
					ProductCategory = "Moisturizer",
					ProductName = "Natural Moisturizing Factors + HA (NMF)",
					ProductDescription = "NMF are elements that keep the outer layer of the skin protected and well-hydrated. ",
					Price=600,
					Image = ImageSource.FromResource("SkinCare.Resources.Images.Nmoisturizer.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
				},
			};
			  ChangeCarouselPosition();
			//Image = Preferences.Get("gender", "Male").Equals("Male") ? Image = ImageSource.FromResource("SkinCare.Resources.Images.avatar.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly) :
		 //   Preferences.Get("gender", "Female").Equals("Female") ? Image = ImageSource.FromResource("SkinCare.Resources.Images.avatar1.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly) :
			//Image = ImageSource.FromResource("SkinCare.Resources.Images.avatar.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly);
			Time = DateTime.Now.Hour > 0 && DateTime.Now.Hour < 12 ? Time = "Good Morning!" : DateTime.Now.Hour >  11 && DateTime.Now.Hour < 19 ? Time = "Good Afternoon, " : Time = "Good Evening,";
			//Name = Preferences.Get("name", "User");
			Navigation = navigation;
			BackBtn = new Command(async () => await OnboardingPage());
            
            
        }
		private ObservableCollection<MenuModel> GetMenu()
		{
			return new ObservableCollection<MenuModel>
			{
				new MenuModel
				{
					Name ="Order",
					Icon = ImageSource.FromResource("SkinCare.Resources.Images.packageIcon.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly)
				},
				new MenuModel
				{
					Name="Favorite",
					Icon =ImageSource.FromResource("SkinCare.Resources.Images.favoriteIcon.png",typeof(ImageResourceExtension).GetTypeInfo().Assembly)
				},
				new MenuModel
				{
					Name = "Cart",
					Icon = ImageSource.FromResource("SkinCare.Resources.Images.cartIcon.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly)
				},
			};
		}
        private ObservableCollection<CategoryModel> GetCategories()
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


        #region Methods 
        private void ChangeCarouselPosition()
		{
			Device.StartTimer(TimeSpan.FromSeconds(4.0), () =>
			{
				Position = Position != HomePage.Count - 1 ? Position++ : Position = 0;
				return true;
			});

		}
		private async Task OnboardingPage()
		{
			await Navigation.PushAsync(new OnboardingPage());
		}


        public async Task AddCategories()
        {
            try
            {
                foreach (var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new CategoryModel()
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        ImageUrl = category.ImageUrl,
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }


        #endregion

        #region Properties

        private ObservableCollection<HomePageModel> hompage;
		public ObservableCollection<HomePageModel> HomePage
		{
			get { return hompage; }
			set { hompage = value; }
		}
		private string placeholder;
		public string PlaceHolder
		{
			get { return placeholder; }
			set { placeholder = value; }
		}

		private string time;
		public string Time
		{
			get { return time; }
			set { time = value; }
		}
		private string name;
		public string Name
		{ 
			get { return name; }
			set { name = value; }
		}
		public string Title { get; set; }

		private object image; 
		public object Image
		{
			get { return image; }
			set { image = value; }

		}
		private int position;
		public int Position 
		{ 
			get { return position; }
			set { position = value; }
		}
		private ObservableCollection<MenuModel> menuList;
		public ObservableCollection<MenuModel> MenuList
		{
			get { return menuList; }
			set
			{
				menuList = value;
				OnPropertyChanged();
			}
		}

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

        public Command BackBtn { get;  }
		public INavigation Navigation { get; set; }
		#endregion 
	}
}
