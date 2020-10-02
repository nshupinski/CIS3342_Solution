using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book
    {
        public string Title;
        public string Authors;
        public string ISBN;
        public string BookType;
        public string RentOrBuy;
        public int Quantity;
        public double Price;
        public float TotalCost;

        public String title
        {
            get { return Title; }
            set { Title = value; }
        }
        public String authors
        {
            get { return Authors; }
            set { Authors = value; }
        }
        public String isbn
        {
            get { return ISBN; }
            set { ISBN = value; }
        }
        public String bookType
        {
            get { return BookType; }
            set { BookType = value; }
        }
        public String rentOrBuy
        {
            get { return RentOrBuy; }
            set { RentOrBuy = value; }
        }
        public int quantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }
        public double price
        {
            get { return Price; }
            set { Price = value; }
        }
        public float totalCost { 
            get { return TotalCost; }
            set { TotalCost = value; }
        }
    }
}
