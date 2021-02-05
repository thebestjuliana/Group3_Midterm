using System;
using System.Collections.Generic;
using System.Text;

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

        Payment()
        {

        }

        public void CheckOut()
        {

            


        

        }

        
        public double PrintTotal()
        {

            //public double TotalItem()
            //{
            //    return Quantity * Item.Price * (1 + salesTax);
            //}
            //public string TotalFormatedItem()
            //{
            //    return FormatNumber(TotalItem());
            //}

            //private string FormatNumber(double x)
            //{
            //    return x.ToString("C2");
            //}

            //return totalCost;
        }




        public PaymentType WhichType()
        {
            string input = Verify(Console.ReadLine());

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
            Console.WriteLine("How would you like to pay?");
            Console.Write("Cash, Check or Credit?  ");
            input.ToLower().Trim();

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

    }
}
