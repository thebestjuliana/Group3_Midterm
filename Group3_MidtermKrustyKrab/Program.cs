using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Group3_MidtermKrustyKrab
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Inventory a = new Inventory();
            Basket b = new Basket();
            a.Catalogue = new List<Product>();
            string filePath = @".\Menu.txt";
            StreamReader reader;
            StreamWriter writer;
            try
            {
                reader = new StreamReader(filePath);
                string fileOutput = reader.ReadToEnd();
                string[] existingMenuItems = fileOutput.Trim().Split('/').ToArray();

                foreach (string item in existingMenuItems)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        List<String> listOfItems = item.Trim().Split(',').ToList();

                        {
                            string first = listOfItems[0];
                            string l = listOfItems[0];
                            ProductCategory selection = (ProductCategory)Enum.Parse(typeof(ProductCategory), listOfItems[1]);

                            a.Catalogue.Add(new Product(listOfItems[0], selection, listOfItems[2], double.Parse(listOfItems[3]), int.Parse(listOfItems[4])));

                        }
                    }
                }

                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

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

                    int userchoice = ValidCheck(Console.ReadLine(), 1, userMenu.Count+1);


                    if (userchoice == 2)
                    {
                        Console.WriteLine("Thank you! GoodBye!");
                        break;
                    }
                    else if (userchoice == 3)
                    {
                        while (true)
                        {


                           

                            try
                            {
                                reader = new StreamReader(filePath);
                                string fileOutput = reader.ReadToEnd();
                                string[] existingMenuItems = fileOutput.Trim().Split('/').ToArray();

                                foreach (string item in existingMenuItems)
                                {
                                    if (!string.IsNullOrEmpty(item))
                                    {
                                        List<String> listOfItems = item.Trim().Split(',').ToList();

                                        {
                                            string first = listOfItems[0];
                                            string l = listOfItems[0];
                                            ProductCategory selection = (ProductCategory)Enum.Parse(typeof(ProductCategory), listOfItems[1]);

                                            a.Catalogue.Add(new Product(listOfItems[0], selection, listOfItems[2], double.Parse(listOfItems[3]), int.Parse(listOfItems[4])));

                                        }
                                    }
                                }

                                Console.WriteLine("Existing Products:");
                                a.PrintFullMenu();
                                Console.WriteLine("Please Enter a new menu item name");
                                string productName = Console.ReadLine();
                                if (!fileOutput.Contains(productName))
                                {
                                    Console.WriteLine("Please Enter the food category- \n1) Drink \n2) Sandwich \n3) Dessert");
                                    string numInput = Console.ReadLine();
                                    string foodTypeInput = "";
                                    if (numInput == "1")
                                    {
                                        foodTypeInput = "Drink";
                                    }
                                    else if (numInput == "2")
                                    {
                                        foodTypeInput = "Sandwich";
                                    }
                                    else if (numInput == "3")
                                    {
                                        foodTypeInput = "Dessert";
                                    }
                                    Console.WriteLine($"Please enter a description for {productName}");
                                    string productDescription = Console.ReadLine();
                                    Console.WriteLine($"Please enter a price for {productName}");
                                    double price = double.Parse(Console.ReadLine());
                                    a.Catalogue.Add(new Product(productName, a.FoodType(numInput), productDescription, price, 0));
                                    fileOutput += $"{productName},{a.FoodType(foodTypeInput)},{productDescription}, {price}, 0/";


                                }
                                reader.Close();
                                writer = new StreamWriter(filePath);
                                writer.Write(fileOutput);
                                writer.Close();

                                Console.WriteLine("Would you like to add another item to the menu? Y/N");
                                string answer = Console.ReadLine().ToLower();
                                if (answer == "y")
                                {
                                    continue;
                                }

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine(e.StackTrace);
                            }
                            break;
                        }
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
                        while (running == true)
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
                        break;
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

