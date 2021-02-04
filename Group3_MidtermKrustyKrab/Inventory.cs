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
           
            List<Product> Catalogue = new List<Product>();

            Product a = new Product("Italian Sub", ProductCategory.Sandwich, "Meatballs on a hoagie", 7.00);
            Product b = new Product("Chocolate Chip Cookie", ProductCategory.Dessert, "Made with love from your granny", 5.00);

            Catalogue.Add(new Product("Sugar Cookie", ProductCategory.Dessert, "Made with sugar", 5.00));

            Catalogue.Add(a);
            Catalogue.Add(b);
        }
    }
}
