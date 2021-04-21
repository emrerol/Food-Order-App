using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YemekSepeti.Helpers
{
    public class AddCategoryData
    {
        public List<Model.Category> Categories { get; set; }

        FirebaseClient client;

        public AddCategoryData()
        {
            client = new FirebaseClient("https://yemeksepeti-4f8d7-default-rtdb.europe-west1.firebasedatabase.app/");
            Categories = new List<Model.Category>()
            {
                new Model.Category()
                {
                CategoryID = 1,
                CategoryName = "Cigkofte",
                CategoryPoster = "MainCigkofte",
                CategoryImage = "Cigkofte.png"
                },
                new Model.Category()
                {
                CategoryID = 2,
                CategoryName = "Kebap",
                CategoryPoster = "MainKebap",
                CategoryImage = "Kebap.png"
                },
                new Model.Category()
                {
                CategoryID = 3,
                CategoryName = "Pizza",
                CategoryPoster = "MainPizza",
                CategoryImage = "Pizza.png"
                },
            };
        }

        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach(var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Model.Category()
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        CategoryImage = category.CategoryImage
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