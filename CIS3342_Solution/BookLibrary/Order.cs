using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BookLibrary
{
    class Order
    {
        public string ISBN;
        public string BookType;
        public string RentOrBuy;
        public string Quantity;
        public string Price;
        public float TotalCost;


        public DataSet GetBookPrice()
        {
            DBConnect objDB = new DBConnect();
            DataSet bookPrice;
            String strSQL = "SELECT Price FROM Books WHERE ISBN = " + ISBN;

            bookPrice = objDB.GetDataSet(strSQL);

            return bookPrice;
        }
    }
}
