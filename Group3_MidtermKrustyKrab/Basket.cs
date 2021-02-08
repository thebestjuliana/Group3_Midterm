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

        /// <summary>
        /// Prints all products in the basket
        /// </summary>
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
                    Console.WriteLine($"\n{i}) {item.ProductName}");
                    Console.WriteLine($"Quantity:{item.Quantity}");
                    Console.WriteLine($"Subtotal: {FormatNumber(item.Quantity * item.Price)}");
                    i++;
                }
            }
        }
        /// <summary>
        /// Asks user which product they would like to interact with.
        /// Checks that it is a number on the list and isnt a string.
        /// </summary>
        /// <returns>Returns the index of the basket product</returns>
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

                    if (index >= MyBasket.Count || index < 0)
                    {
                        Console.WriteLine("Invalid Selection");
                        continue;
                    }
                    else
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
        /// <summary>
        /// Asks user what they would like to change the quantity to on a specific product in the basket
        /// </summary>
        public void UpdateQuantity()
        {
            int index = SelectCartItem();
            Console.WriteLine($"How many {MyBasket[index].ProductName} would you like?");
            int num = ValidCheck(Console.ReadLine(),1 , 50);
            MyBasket[index].Quantity = num;
        }
        /// <summary>
        /// Prints the product description, price per, quanitity, the subtotal, tax, and Grandtotal for the basket
        /// </summary>
        /// <returns>Returns the grand total to be used for change</returns>
        public double Reciept()
        {
            int i = 1;
            double tax = 1.06;
            double runningTotal = 0;
            foreach (Product item in MyBasket)
            {
                Console.WriteLine($"\tCart #{i}: {item.ProductName}");
                Console.WriteLine($"\tPrice (ea): {FormatNumber(item.Price)}");
                Console.WriteLine($"\tQuantity:{item.Quantity}");
                double itemSubTotal = item.Quantity * item.Price;
                Console.WriteLine($"\tSubtotal: {FormatNumber(itemSubTotal)}");
                runningTotal =+ itemSubTotal;
                i++;
            }
            double taxReturn = runningTotal * 0.06;
            double grandTotal = runningTotal * tax;
            Console.WriteLine("________________________________");
            Console.WriteLine($"\tTax: {FormatNumber(taxReturn)}");
            Console.WriteLine("________________________________");
            Console.WriteLine($"\tGrand Total: {FormatNumber(grandTotal)}");
            return grandTotal;
        }

        public string FormatNumber(double x)
        {
            return x.ToString("C2");
        }

        /// <summary>
        /// Takes in a specific product and an integer that will set the amount of the desired product.
        /// Adds the product to the basket
        /// </summary>
        /// <param name="selectedProduct"></param>
        /// <param name="quant"></param>
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
        /// <summary>
        /// Checks an inputed string can be converted to an int and falls between the ranges.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>returns a valid integer</returns>
        public int ValidCheck(string input, int min, int max)
        {
            int integer;
            while (true)
            {
                if (Int32.TryParse(input, out integer))//Checks if it can be converted to a number
                {
                    if (integer >= min && integer <= max)//Checks that it is within the given range
                    {
                        return integer;// returns a valid integer
                    }
                    else
                    {
                        Console.Write("\nPlease enter reasonable number! ");//requires them to keep trying until they give a valid entry
                        input = Console.ReadLine();
                    }
                }
                else
                {
                    Console.Write("\nPlease enter a number.  ");//requires them to keep trying until they give a valid entry
                    input = Console.ReadLine();
                }
            }
        }
    }

}
