﻿using System;
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
                    Console.WriteLine("Please see below for a selection of our lovely food to eat");


                    a.PrintFullMenu();
                    Console.WriteLine("Please enter the combo number of the item you would like");
                    int comboNumber = ValidCheck(Console.ReadLine(), 1, a.Catalogue.Count);
                    int quant;
                    Console.WriteLine("How many would you like?(Please, No more than 50 of any item)");
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
                        Console.WriteLine("How many would you like?(Please, No more than 50 of any item)");
                        quant = ValidCheck(Console.ReadLine(), 1, 50);

                        b.AddItem(a.Catalogue[comboNumber-1], quant);

                        break;
                    case 2:
                        //Remove product from cart
                        break;
                    case 3:
                        //view my cart
                        break;
                    case 4:
                        //Empty my cart
                        break;
                    case 5:
                        //Change quantity
                        break;
                    case 6:
                        while (true)
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
                                running = false;
                            }
                            else if (type == PaymentType.Check)
                            {
                                int checkNum = paymentMethod.CheckCheckOut();
                                double doNotReturn = b.Reciept();
                                Console.WriteLine($"You paid with a check and a check number of {checkNum}!");
                                Console.WriteLine($"Thank you for your payment! Have a great Day!");
                                running = false;
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
                                running = false;

                            }
                        }
                    case 7:
                        Console.WriteLine("GoodBye");
                        running = false;
                        //Leave
                        break;
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
    }
}

