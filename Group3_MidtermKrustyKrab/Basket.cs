using System;
using System.Collections.Generic;
using System.Text;

namespace Group3_MidtermKrustyKrab
{
    class Basket
    {
        public List<Product> MyBasket { get; set; }

       
        public Basket ()
        {
            MyBasket = new List<Product>();
        }

        public void DisplayBasket()
        {
            double subtotal = 0;
            foreach (Product item in MyBasket)
            {
                
                subtotal += item.PrintTotalForItem();

            }
            Console.WriteLine($"\tSubtotal: {subtotal.ToString("C2")}");
            double tax = subtotal * 0.06;
            Console.WriteLine($"\tTax: {tax.ToString("C2")}");
            Console.WriteLine($"\tTotal: {(subtotal+tax).ToString("C2")}");

        }

        public void RemoveItem()
        {

        }

        public void AddItem(Product selectedProduct)
        {
            Console.WriteLine("Would you like to add this product to your bag?");
            Console.WriteLine("How Many?");
            int i = int.Parse(Console.ReadLine());
            MyBasket.Add(new Product(selectedProduct.ProductName, selectedProduct.FoodType, selectedProduct.Description, selectedProduct.Price, i));
        }

    }
}
