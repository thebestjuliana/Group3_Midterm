﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Group3_MidtermKrustyKrab
{
    public enum PaymentType
    {
        Cash,
        Check,
        Credit
    }
    class Payment
    {
        public double TotalCost { get; set; }
        public PaymentType PaymentType { get; set; }
    
         public Payment()
        {

        }
        /// <summary>
        /// This takes in the total cost of the cart and allows the user to check out with cash. 
        /// It has a valid check within it to not allow change to be given in $100 bills
        /// </summary>
        /// <param name="TotalCost"></param>
        /// <returns>Returns a double, change, which is displayed in the checkout(case#6)</returns>
        public double CashCheckOut(double TotalCost)
        {
            Console.Write("How much cash you got?  ");
            double tender = ValidCheck(Console.ReadLine(), TotalCost, (TotalCost+100));
            double change = tender - TotalCost;
            return change;
        }
        /// <summary>
        /// Takes the total cost of the cart and asks for the check number to pay with.
        /// </summary>
        /// <returns>Returns that check number for use on the user reciept</returns>
        public int CheckCheckOut()
        {
            Console.WriteLine("Please enter your check number. XXXX");
            int output = CheckCheck(Console.ReadLine(),1000, 9999);
            return output;
        }
        /// <summary>
        /// Takes the total cost of the cart and asks for the credit card number, expiration date, and CVV.
        /// All of these are checked by regex and will ask until valid numbers are inputed.
        /// </summary>
        /// <returns>Returns the last 4 digit of the credit card number as a string</returns>
        public string CreditCheckOut()
        {
            Console.WriteLine("Please enter your credit card number:  ");
            string creditNum = Console.ReadLine();

            while (true)
            {


                if (Regex.IsMatch(creditNum, @"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$"))
                {
                Console.Write("Please enter your expiration date:  ");
                    string date = Console.ReadLine();
                    while (true)
                    {
                        if (Regex.IsMatch(date, @"(0[1-9]|10|11|12)/20[0-9]{2}$"))//  mm/yyyy
                        {
                            Console.Write("Please enter the CVV number:  ");
                            string cvv = Console.ReadLine();
                            while (true)
                            {
                                if (Regex.IsMatch(cvv, @"^\d{3,4}$"))
                                {
                                    string lastDigit = creditNum.Substring(creditNum.Length - 4);

                                    return lastDigit;
                                }
                                else if (cvv == "quit")
                                {
                                    return "fail";
                                }
                                else
                                {
                                    Console.Write("Please enter a valid CVV number, or "+"quit"+" to exit:  ");
                                    cvv = Console.ReadLine().ToLower();
                                }
                            }
                        }
                        else if (date == "quit")
                        {
                            return "fail";
                        }
                        else
                        {
                            Console.Write("Please enter a valid expiration date, or "+"quit"+" to exit:  ");
                            date = Console.ReadLine().ToLower();
                        }

                    }
                }
                else if (creditNum == "quit")
                {
                    return "fail";
                }
                else
                {
                    Console.WriteLine("Please enter a valid credit number, or "+"quit"+" to exit");
                    creditNum = Console.ReadLine().ToLower();

                }
            }
        }

        /// <summary>
        /// Determines which type of payment method the user chooses to use. This is checked with Verify().
        /// </summary>
        /// <returns></returns>
        public PaymentType WhichType()
        {
            Console.WriteLine("How would you like to pay?");
            Console.Write("Cash, Check or Credit?  ");
            string input = Verify(Console.ReadLine().ToLower().Trim());
            if(input == "cash")
            {
                return PaymentType.Cash;
            }
            else if (input == "check")
            {
                return PaymentType.Check;
            }
            else
            {
                return PaymentType.Credit;
            }
        }
        /// <summary>
        /// Takes in a string input and verify that the user input was either
        /// Cash, Check or Credit. It then will prompt over and over until the conditions are met.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns a string input that is "Cash", "Check" or "Credit".</returns>
        public string Verify(string input)
        {
            
            while (true)
            {
                if(input == "cash" || input == "check" || input == "credit")
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("You must not be from around here. Cash, Check or Credit.  ");
                    input = Console.ReadLine().ToLower().Trim();
                }
            }
        }

        /// <summary>
        /// Checks that the user entered a valid amount for the cash payment.
        /// Checks that the amount covers the cost, and is not $100 over the cost amount.
        /// Also checks they did not enter words instead of a double.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Returns the amount the user tendered as a cash payment</returns>
        public double ValidCheck(string input, double min, double max)
        {
            double money;
            while (true)
            {
                if (Double.TryParse(input, out money))//Checks if it can be converted to a number
                {
                    if (money > min && money < max)//Checks that it is within the given range
                    {
                        return money;// returns a valid double and we make change
                    }
                    else if (money == min)
                    {
                        Console.WriteLine("Thank you this makes it easy!");//exact payment
                        return money;
                    }
                    else if (money >= max)
                    {
                        Console.WriteLine("Sorry we do not carry $100 Bills. We can't make change.");
                        Console.Write("Please give a reasonable amount:  ");
                        input = Console.ReadLine();
                    }
                    else
                    {
                        Console.Write("\nHey! That is not eough to pay for these items!  ");//requires them to keep trying until they give a valid entry
                        input = Console.ReadLine();
                    }
                }
                else
                {
                    Console.Write("\nYour word isn't worth anything here.  ");//requires them to keep trying until they give a valid entry
                    input = Console.ReadLine();
                }
            }
        }
        /// <summary>
        /// Validates the user inputs for a 4 digit check number
        /// </summary>
        /// <param name="input"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Returns a valid 4 digit check number</returns>
        public int CheckCheck(string input, int min, int max)
        {
            int money;
            while (true)
            {
                if (Int32.TryParse(input, out money))//Checks if it can be converted to a number
                {
                    if (money >= min && money <= max)//Checks that it is within the given range
                    {
                        return money;// returns a valid double and we make change
                    }
                    else
                    {
                        Console.Write("\nHey! That is not 4 digits!  ");//requires them to keep trying until they give a valid entry
                        input = Console.ReadLine();
                    }
                }
                else
                {
                    Console.Write("\nPlease enter your check number:  ");//requires them to keep trying until they give a valid entry
                    input = Console.ReadLine();
                }
            }


        }
    }
}
