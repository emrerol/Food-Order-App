using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSepeti.Services
{
    public class CategoryDataService
    {
        FirebaseClient client;

        public CategoryDataService()
        {
            client = new FirebaseClient("https://yemeksepeti-4f8d7-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public async Task<List<Model.Category>> GetCategoriesAsync()
        {
            var categories = (await client.Child("Categories")
                .OnceAsync<Model.Category>())
                .Select(c => new Model.Category
                {
                    CategoryID = c.Object.CategoryID,
                    CategoryName = c.Object.CategoryName,
                    CategoryPoster = c.Object.CategoryPoster,
                    CategoryImage = c.Object.CategoryImage
                }).ToList();
            return categories;
        }
    }
}
