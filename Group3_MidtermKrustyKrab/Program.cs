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

            while (true)
            {

                if (b.MyBasket.Count == 0)
                {
                    List<string> userMenu = new List<string> { "View Main Menu", "Leave" };
                    int i = 1;
                    foreach (string item in userMenu)
                    {

                        Console.WriteLine($"{i}) {item}");
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

                    b.AddItem(a.Catalogue[comboNumber], quant);
                }

                List<string> userMenu = new List<string>();




                //write customer option
                //


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
    }
}

