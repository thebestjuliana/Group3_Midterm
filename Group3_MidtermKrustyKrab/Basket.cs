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

        //public override string ToString()
        //{
        //    string output = $"{ProductName,-20}{Quantity,-5}{TotalFormatedItem(),-5}";
        //    return output;
        //}

        public void AddItem(Product selectedProduct, int quant)
        {
            selectedProduct.Quantity = quant;
            MyBasket.Add(selectedProduct);
        }

    }
}
