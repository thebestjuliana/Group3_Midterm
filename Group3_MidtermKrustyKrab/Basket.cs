using System;
using System.Collections.Generic;
using System.Text;

namespace Group3_MidtermKrustyKrab
{
    class Basket
    {

        public List<Product> MyBasket { get; set; }

        public Basket()
        {
            MyBasket = new List<Product>();
        }


        public void PrintCartItems()
        {
            if (MyBasket.Count < 1)
            {
                Console.WriteLine("You don't have anything in your Cart!");
            }
            else
            {
                int i = 1;
                foreach (Product item in MyBasket)
                {
                    Console.WriteLine($"{i} {item.ProductName}");
                    Console.WriteLine($"Quantity:{item.Quantity}");
                    Console.WriteLine($"Subtotal: {item.Quantity * item.Price}");
                    i++;
                }
            }
<<<<<<< HEAD
            Console.WriteLine($"\tSubtotal: {subtotal.ToString("C2")}");
            double tax = subtotal * 0.06;
            Console.WriteLine($"\tTax: {tax.ToString("C2")}");
            Console.WriteLine($"\tTotal: {(subtotal+tax).ToString("C2")}");

=======
>>>>>>> main
        }
        public int SelectCartItem()
        {
            while (true)
            {
                PrintCartItems();

                Console.WriteLine("Which item would you like to change?");
                int index;
                bool select = int.TryParse(Console.ReadLine(), out index);
                index = index - 1;
                if (select)
                {
                    if (index >= MyBasket.Count || index <= 0)
                    {
                        Console.WriteLine("Invalid Selection");
                        continue;
                    }
                    for (int i = index; i < MyBasket.Count; i++)
                    {
                        MyBasket[index].PrintItemDetails();
                        return index;
                    }


                }
                else
                {
                    Console.WriteLine("Invalid Item Selection, Try again. ");
                    continue;
                }
            }
        }
        public void UpdateQuantity()
        {
            int index = SelectCartItem();
            Console.WriteLine($"How many {MyBasket[index].ProductName} would you like?");
            int num = int.Parse(Console.ReadLine());
            MyBasket[index].Quantity = num;
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


        public void AddItem(Product selectedProduct, int quant)
        {
            int count = 0;

            if (MyBasket.Count > 0)
            {
                foreach (Product item in MyBasket)

                {
                    if (item.ProductName == selectedProduct.ProductName)
                    {
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                Console.WriteLine("That product is already in your cart. " +
                    "If you would like more, please edit the quantity of this item in your basket.");

            }
            else
            {
                selectedProduct.Quantity = quant;
                MyBasket.Add(selectedProduct);
            }
        }

    }
}
