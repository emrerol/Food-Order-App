using System;
using System.Collections.Generic;
using System.Text;

namespace YemekSepeti.Model
{
    public class FoodItem
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //public string Rating { get; set; }
        //public string RatingDetail { get; set; }
        //public string HomeSelected { get; set; }



    }
}
