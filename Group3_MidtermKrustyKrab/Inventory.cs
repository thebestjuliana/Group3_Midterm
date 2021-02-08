using System;
using System.Collections.Generic;
using System.Text;

namespace Group3_MidtermKrustyKrab
{
    class Inventory
    {
        public List<Product> Catalogue { get; set; }

        public Inventory()
        {

            Catalogue = new List<Product>();

            //Product a = new Product("Italian Sub", ProductCategory.Sandwich, "Meatballs on a hoagie", 7.00, 0);
            //Product b = new Product("Chocolate Chip Cookie", ProductCategory.Dessert, "Made with love from your granny", 5.00, 0);

            //Catalogue.Add(new Product("Sugar Cookie", ProductCategory.Dessert, "Made with sugar", 5.00, 0));

            //Catalogue.Add(a);
            //Catalogue.Add(b);
        }

        public void PrintFullMenu()
        {
            int i = 1;
            foreach (Product item in Catalogue)
            {
                Console.WriteLine(i);
                item.PrintItemDetails();
                Console.WriteLine();
                i++;

            }
        }

        public void DisplayByCourse(ProductCategory course)
        {
            foreach (Product item in Catalogue)
            {
                if (item.FoodType == course)
                {
                    item.PrintItemDetails();
                }
            }
        }
        public ProductCategory FoodType(string input)
        {
            if (input == "ProductCategory.Sandwich")
            {
                return ProductCategory.Sandwich;
            }
            else if (input == "ProductCategory.Drink")
            {
                return ProductCategory.Drink;
            }
            else
            {
                return ProductCategory.Dessert;
            }
        }

    }

}
