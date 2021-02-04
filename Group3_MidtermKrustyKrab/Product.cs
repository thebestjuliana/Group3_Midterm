using System;
using System.Collections.Generic;
using System.Text;

namespace Group3_MidtermKrustyKrab
{

    public enum ProductCategory
    {
        Sandwich,
        Drink,
        Dessert,
    }

    class Product
    {
        public string ProductName { get; set; }
        public ProductCategory FoodType { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Product(string ProductName, ProductCategory FoodType, string Description, double Price)
        {

            this.ProductName = ProductName;
            this.FoodType = FoodType;
            this.Description = Description;
            this.Price = Price;

        }

        List<Product> Catalogue = new List<Product>();


    }
}
