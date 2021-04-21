using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using YemekSepeti.Model;
using Firebase.Database;
using System.Collections.ObjectModel;

namespace YemekSepeti.Services
{
    public class FoodItemService
    {
        FirebaseClient client;

        public FoodItemService()
        {
            client = new FirebaseClient("https://yemeksepeti-4f8d7-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public async Task<List<Model.FoodItem>> GetFoodItemsAsync()
        {
            var products = (await client.Child("FoodItems")
                .OnceAsync<Model.FoodItem>())
                .Select(f => new Model.FoodItem
                {
                    Name = f.Object.Name,
                    ProductID = f.Object.ProductID,
                    CategoryID = f.Object.CategoryID,
                    Description = f.Object.Description,
                    Price = f.Object.Price,
                    Image = f.Object.Image,
                }).ToList();
            return products;
        }

        public async Task<ObservableCollection<FoodItem>> GetFoodItemsByCategoryAsync(int categoryID)
        {
            var foodItemsByCategory = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).Where(p => p.CategoryID == categoryID).ToList();
            foreach (var item in items)
            {
                foodItemsByCategory.Add(item);
            }
            return foodItemsByCategory;
        }

        public async Task<ObservableCollection<FoodItem>> GetLatestFoodItemsAsync()
        {
            var latestFoodItems = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).OrderByDescending(f => f.ProductID).Take(3);

            foreach (var item in items)
            {
                latestFoodItems.Add(item);
            }
            return latestFoodItems;
        }



       
    }
}
