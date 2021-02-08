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
        /// <summary>
        /// Calls upon the included .csv file to import all the products inside the inventory
        /// </summary>
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
        /// <summary>
        /// Prints all the products and their details within inventory
        /// </summary>
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

        // Can be used in the future to select the menu by category rather than printing all products in inventory
        //public void DisplayByCourse(ProductCategory course)
        //{
        //    foreach (Product item in Catalogue)
        //    {
        //        if (item.FoodType == course)
        //        {
        //            item.PrintItemDetails();
        //        }
        //    }
        //}
    }

}
