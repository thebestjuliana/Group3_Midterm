using System;
using System.Collections.Generic;
using System.Text;

namespace Group3_MidtermKrustyKrab
{
    class Basket
    {

        double salesTax = .06;
        public Product Item { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
       
        public Basket ()
        {
           MyBasket = new List<Product>();
        }

        public void UpdateQuantity(int num)
        {
            Quantity = num;
        }
        public double TotalItem()
        {
            return Quantity * Item.Price * (1 + salesTax);
        }
        public string TotalFormatedItem()
        {
            return FormatNumber(TotalItem());
        }

        private string FormatNumber(double x)
        {
            return x.ToString("C2");
        }

        public override string ToString()
        {
            string output = $"{ProductName,-20}{Quantity,-5}{TotalFormatedItem(),-5}";
            return output;
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
