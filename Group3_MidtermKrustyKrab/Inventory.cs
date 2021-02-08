using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Group3_MidtermKrustyKrab
{
    class Inventory
    {
        public List<Product> Catalogue { get; set; }

        public Inventory()
        {
            try
            {
                Catalogue = File.ReadAllLines(@"../../Products.csv")
                    .Skip(1)
                    .Select(v => Product.FromCsv(v))
                    .ToList();
            } catch(Exception e)
            {
                Console.WriteLine("An error occured. Please get a Krusty Krab representative for help.");
                Console.WriteLine(e.Message);
            }
        }

        public void PrintFullMenu()
        {
            int i = 1;
            foreach (Product item in Catalogue)
            {
                Console.WriteLine($"[{i}]");
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
    }

}
