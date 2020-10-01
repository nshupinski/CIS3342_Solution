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
        public string ISBN;
        public string BookType;
        public string RentOrBuy;
        public string Quantity;
        public double Price;

        public Order(string isbn, string bookType, string rentOrBuy, string quantity, double price)
        {
            ISBN = isbn;
            BookType = bookType;
            RentOrBuy = rentOrBuy;
            Quantity = quantity;
            Price = price;
        }

        public DataSet GetBookPrice()
        {
            DBConnect objDB = new DBConnect();
            DataSet myDS;
            String strSQL = "SELECT Price FROM Books WHERE ISBN = " + ISBN;

            myDS = objDB.GetDataSet(strSQL);
            
            return myDS;
        }
    }
}
