using System;
using System.Collections.Generic;
using System.IO;
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
        /// <summary>
        /// Used in the .csv file to construct this from lines read from the external file.
        /// </summary>
        public Product()
        {

        }
        /// <summary>
        /// A basic constructor if the items are added in the code vs grabbing from a .csv file.
        /// </summary>
        /// <param name="ProductName"></param>
        /// <param name="FoodType"></param>
        /// <param name="Description"></param>
        /// <param name="Price"></param>
        /// <param name="Quantity"></param>
        public Product(string ProductName, ProductCategory FoodType, string Description, double Price, int Quantity)
        {

            this.ProductName = ProductName;
            this.FoodType = FoodType;
            this.Description = Description;
            this.Price = Price;
            this.Quantity = Quantity;

        }
        /// <summary>
        /// Converts every column in the .csv file into the appropriate Product parameter and then sends it back to the inventory to be cataloged
        /// </summary>
        /// <param name="csvLine"></param>
        /// <returns>Returns a full itme with the properties defined in Product class</returns>
        public static Product FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Product csvProducts = new Product();
            csvProducts.ProductName = Convert.ToString(values[0]);
            csvProducts.FoodType = (ProductCategory)Enum.Parse(typeof(ProductCategory), Convert.ToString(values[1]));
            csvProducts.Description = Convert.ToString(values[2]);
            csvProducts.Price = Convert.ToDouble(values[3]);
            csvProducts.Quantity = Convert.ToInt32(values[4]);
            return csvProducts;
        }

        /// <summary>
        /// Prints the items with their descriptions used in the main display
        /// </summary>
        public void PrintItemDetails()
        {
            string formatedPrice = string.Format("{0:C}", Convert.ToInt32(Price));
            Console.WriteLine($"{ProductName}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"{formatedPrice}");
            Console.WriteLine("_____________________________________");
        }

        //Not used, was an intial concept idea and then later transitioned to Receiept()

        //public void PrintCartItemDetails(Product item)
        //{
        //    Console.WriteLine($"{item.ProductName}");
        //    Console.WriteLine($"Quantity:{item.Quantity}");
        //    Console.WriteLine($"Subtotal: {item.Quantity * item.Price}");
        //}
        //public double PrintTotalForItem()
        //{
        //    double total = Price * Quantity;
        //    Console.WriteLine($"{ProductName}: ${total}");
        //    return total;
        //}


    }
}
