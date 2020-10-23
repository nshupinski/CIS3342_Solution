using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Utilities;

namespace Restaurant_Review
{
    public class DBProcedures
    {
        public DataSet myDS;
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        public DataSet GetAllRestaurants()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetAllRestaurants";

            // Execute stored procedure using DBConnect object and the SQLCommand object
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet GetRestaurantByName(string restaurantName)
        {
            DataSet myDS = new DataSet();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRestaurantByName";
            objCommand.Parameters.AddWithValue("@restaurantName", restaurantName);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet GetUsername()
        {
            DataSet myDS = new DataSet();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUsername";

            // Execute stored procedure using DBConnect object and the SQLCommand object
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public void AddReservation()
        {

        }
    }
}