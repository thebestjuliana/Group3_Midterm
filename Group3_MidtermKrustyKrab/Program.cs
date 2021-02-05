using System;
using System.Collections.Generic;

namespace Group3_MidtermKrustyKrab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Krusty Krab");
            
            //while(true)
            {

                Console.WriteLine("Please see below for a selection of our lovely food to eat");

                Inventory a = new Inventory();
                Basket b = new Basket();
                for (int i = 0; i < 3; i++)
                {
                    Product thingToAddToBasket = a.SelectProduct();
                    
                    b.AddItem(thingToAddToBasket);
                }
               
                b.DisplayBasket();
               
                
                
                    //write customer option
                //


            }



        }

        
    }
}
