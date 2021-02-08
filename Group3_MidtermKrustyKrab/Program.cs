using System;
using System.Collections.Generic;

namespace Group3_MidtermKrustyKrab
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory a = new Inventory();
            Basket b = new Basket();
            Console.WriteLine("Welcome to the Krusty Krab");
            bool running = true;
            while (running == true)
            {

                if (b.MyBasket.Count == 0)
                {
                    List<string> userMenu = new List<string> { "View Menu", "Leave" };
                    int i = 1;
                    foreach (string item in userMenu)
                    {

                        Console.WriteLine($"{i}) {item}");
                        i++;
                    }

                    int userchoice = ValidCheck(Console.ReadLine(), 1, userMenu.Count);


                    if (userchoice == 2)
                    {
                        Console.WriteLine("Thank you! GoodBye!");
                        break;
                    }

                    Console.WriteLine("Please see below for a selection of our lovely food to eat\n");


                    a.PrintFullMenu();
                    Console.WriteLine("Please enter the combo number of the item you would like");
                    int comboNumber = ValidCheck(Console.ReadLine(), 1, a.Catalogue.Count);
                    int quant;
                    Console.WriteLine($"How many {a.Catalogue[comboNumber-1].ProductName} would you like?(Please, No more than 50 of any item)");
                    quant = ValidCheck(Console.ReadLine(), 1, 50);

                    b.AddItem(a.Catalogue[comboNumber-1], quant);
                }

                int selectedOption = PrintMenu2ReturnUserSelection();

                switch (selectedOption)
                {
                    case 1:
                        //add product to cart
                        a.PrintFullMenu();
                        Console.WriteLine("Please enter the combo number of the item you would like");
                        int comboNumber = ValidCheck(Console.ReadLine(), 1, a.Catalogue.Count);
                        int quant;
                        Console.WriteLine($"How many {a.Catalogue[comboNumber - 1].ProductName} would you like?(Please, No more than 50 of any item)");
                        quant = ValidCheck(Console.ReadLine(), 1, 50);

                        b.AddItem(a.Catalogue[comboNumber-1], quant);

                        break;
                    case 2:
                        //Remove product from cart
                        comboNumber = b.SelectCartItem();
                        Console.WriteLine($"Are you sure you'd like to remove {b.MyBasket[comboNumber].ProductName} from your cart? (Y/N)");
                        bool answer = YesNoValidation();
                        if(answer == true)
                        {
                            Console.WriteLine($" {b.MyBasket[comboNumber].ProductName} has been removed from your cart!\n");
                            b.MyBasket.RemoveAt(comboNumber);
                            Console.WriteLine("Returning to the main menu!");
                        }
                        else
                        {
                            Console.WriteLine($"Ok We'll keep {b.MyBasket[comboNumber].ProductName} in your cart. \nReturning to the main menu.");

                        }

                        break;
                    case 3:
                        //view my cart
                        Console.WriteLine("\nThe items in your cart are:");
                        b.PrintCartItems();
                        Console.WriteLine();
                        break;
                    case 4:
                        //Empty my cart
                        Console.WriteLine($"Are you sure you'd like to  empty your cart? (Y/N)");
                        
                        answer = YesNoValidation();
                        if(answer == true)
                        {
                            b.MyBasket.Clear();
                            b.MyBasket.TrimExcess();
                        }
                        Console.WriteLine("All items have been removed from your cart. Your order has been cancelled!");
                        break;
                    case 5:
                        //Change quantity
                        b.UpdateQuantity();
                        break;
                    case 6:
                        //Checkout
                        bool again = true;
                        while (again == true)
                        {
                            Payment paymentMethod = new Payment();
                            PaymentType type = paymentMethod.WhichType();

                            if (type == PaymentType.Cash)
                            {
                                double grandTotal = b.Reciept();
                                double change = paymentMethod.CashCheckOut(grandTotal);
                                double doNotReturn = b.Reciept();
                                Console.WriteLine("You paid in cash!");
                                Console.WriteLine($"Amount Tendered: {b.FormatNumber(grandTotal + change)}");
                                Console.WriteLine($"Change: ({b.FormatNumber(change)})");
                                Console.WriteLine($"Thank you for your payment! Have a great Day!");
                                again = false;
                                b.MyBasket.Clear();
                                b.MyBasket.TrimExcess();
                            }
                            else if (type == PaymentType.Check)
                            {
                                int checkNum = paymentMethod.CheckCheckOut();
                                double doNotReturn = b.Reciept();
                                Console.WriteLine($"You paid with a check and a check number of {checkNum}!");
                                Console.WriteLine($"Thank you for your payment! Have a great Day!");
                                again = false;
                                b.MyBasket.Clear();
                                b.MyBasket.TrimExcess();
                            }
                            else
                            {
                                double doNotReturn = b.Reciept();
                                string cc = paymentMethod.CreditCheckOut();
                                if (cc == "fail")
                                {
                                    continue;
                                }
                                Console.WriteLine($"You paid with a credit card ending in {cc}!");
                                Console.WriteLine($"Thank you for your payment! Have a great Day!");
                                again = false;
                                b.MyBasket.Clear();
                                b.MyBasket.TrimExcess();

                            }
                        }
                        break;
                    case 7:
                        Console.WriteLine("GoodBye");
                        running = false;
                        //Leave
                        break;

                }
                if (b.MyBasket.Count == 0)
                {
                    Console.WriteLine("\nReturning to the main menu\n");
                }

            }
        }
        public static int ValidCheck(string input, int min, int max)
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
        public static int PrintMenu2ReturnUserSelection()
        {
            List<string> userMenu2 = new List<string>();
            userMenu2.Add("Add Product to cart");
            userMenu2.Add("Remove a product from your cart");
            userMenu2.Add("View my Cart");
            userMenu2.Add("Empty My Cart");
            userMenu2.Add("Edit Quantity");
            userMenu2.Add("Check Out");
            userMenu2.Add("Cancel Order and Leave");
            int i = 1;
            foreach (string item in userMenu2)
            {
                Console.WriteLine($"{i}) {item}");
                i++;
            }

            int option = ValidCheck(Console.ReadLine(), 1, userMenu2.Count);
            return option;

        }
        public static bool YesNoValidation()
        {
            while (true)
            {
                string answer = Console.ReadLine();

                if (answer.ToLower() == "y")
                {
                    return true;
                }
                else if (answer.ToLower() == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid response. Y/N. Try again!");
                    continue;
                }
            }

        }

    }
}

