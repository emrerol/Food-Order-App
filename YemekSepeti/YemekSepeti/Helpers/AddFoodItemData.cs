using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YemekSepeti.Helpers
{
    public class AddFoodItemData
    {
        FirebaseClient client;

        public List<Model.FoodItem> FoodItems { get; set; }

        public AddFoodItemData()
        {
            client = new FirebaseClient("https://yemeksepeti-4f8d7-default-rtdb.europe-west1.firebasedatabase.app/");
            FoodItems = new List<Model.FoodItem>()
            {
                new Model.FoodItem()
                {
                    ProductID = 1,
                    CategoryID = 1,
                    Name = "Çiğ Köfte Dürüm",
                    Description = "90gr. çiğ köfte, tek lavaş",
                    Image = "cigkoftedurum1.png",
                    Price = 7.5M
                    //HomeSelected
                    //RatingDetail
                    //Rating
                },
                new Model.FoodItem()
                {
                    ProductID = 2,
                    CategoryID = 1,
                    Name = "Ultra Mega Çiğ Köfte Dürüm",
                    Description = "150gr. çiğ köfte, çift lavaş",
                    Image = "cigkoftedurum2.png",
                    Price = 11.5M
                },
                new Model.FoodItem()
                {
                    ProductID = 3,
                    CategoryID = 2,
                    Name = "Lahmacun",
                    Description = "Mevsim salata, acılı ezme ile",
                    Image = "Lahmacun.png",
                    Price = 13,
                },
                new Model.FoodItem()
                {
                    ProductID = 4,
                    CategoryID = 3,
                    Name = "Karışık Pizza (Büyük)",
                    Description = "Pizza sosu, mozzarella peyniri, dana sucuk, dana salam, dana sosis, mantar, yeşilbiber, zeytin",
                    Image = "Pizza1.png",
                    Price = 41M,
                },
            };
        }

        public async Task AddFoodItemAsync()
        {
            try
            {
                foreach (var food in FoodItems)
                {
                    await client.Child("FoodItems").PostAsync(new Model.FoodItem()
                    {
                        CategoryID = food.CategoryID,
                        ProductID = food.ProductID,
                        Description = food.Description,
                        Image = food.Image,
                        Name = food.Name,
                        Price = food.Price,
                        //HomeSelected = food.HomeSelected,
                        //Rating = food.Rating,
                        //RatingDetail = food.RatingDetail
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
