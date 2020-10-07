using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;


namespace BookLibrary
{
    public class Order
    {
        //public string ISBN;
        public string BookType;
        public string RentOrBuy;
        public int Quantity;
        public double Price;

        public Order(string bookType, string rentOrBuy, int quantity, double price)
        {
            BookType = bookType;
            RentOrBuy = rentOrBuy;
            Quantity = quantity;
            Price = price;
        }

        public double CalcTotal()
        {
            double total;
            total = Price;

            total = bookTypePrice(total);
            total = RentOrBuyPrice(total);

            total = total * Quantity;

            return total;
        }


        public double bookTypePrice(double total)
        {
            if (BookType == "Hard Cover")
            {
                Price = (Price * .2) + 5;
            }
            else if (BookType == "e-Book")
            {
                Price = Price - (Price * 0.4);
            }
            else
            {
                total = Price;
            }

            return total;
        }

        public double RentOrBuyPrice(double total)
        {
            if (RentOrBuy == "Rent")
            {
                total = total - (total * .5);
            }

            return total;
        }
    }
}
