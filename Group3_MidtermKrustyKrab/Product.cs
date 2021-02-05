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
        public int Quantity { get; set; }

        

        public Product(string ProductName, ProductCategory FoodType, string Description, double Price,int Quantity)
        {

            this.ProductName = ProductName;
            this.FoodType = FoodType;
            this.Description = Description;
            this.Price = Price;
            this.Quantity = Quantity;

        }

        


        public void PrintItemDetails()
        {
            string a = string.Format("{0:C}", Convert.ToInt32(Price));
            Console.WriteLine($"{ProductName}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"{a}");
        }
        public double PrintTotalForItem()
        {
            double total = Price * Quantity;
            Console.WriteLine($"{ProductName}: ${total}");
            return total;
        }


    }
}
