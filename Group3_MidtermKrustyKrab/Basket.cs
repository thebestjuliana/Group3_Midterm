using System;
using System.Collections.Generic;
using System.Text;

namespace Group3_MidtermKrustyKrab
{
    class Basket
    {
        public Product Item { get; set; }
        
        public int Quantity { get; set; }

        public Basket (Product Item, int Quantity)
        {
            this.Item = Item;
            this.Quantity = Quantity;
        }

        public void DisplayBasket()
        {

        }

        public void RemoveItem()
        {

        }

    }
}
