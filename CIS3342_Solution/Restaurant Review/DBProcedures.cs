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

        public int AddReservation(string reservationName, string restaurantName, DateTime time, string phoneNumber, int numOfPeople)
        {
            DataSet myDS = new DataSet();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "AddReservation";
            objCommand.Parameters.AddWithValue("@reservationName", reservationName);
            objCommand.Parameters.AddWithValue("@restaurantName", restaurantName);
            objCommand.Parameters.AddWithValue("@time", time);
            objCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            objCommand.Parameters.AddWithValue("@numOfPeople", numOfPeople);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            int success = objDB.DoUpdateUsingCmdObj(objCommand);
            return success;
        }

        public int AddReview(string reviewerName, string restaurantName, int foodQuality, int serviceQuality, int atmosphereQuality, int priceQuality, string comment)
        {
            DataSet myDS = new DataSet();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "AddReview";
            objCommand.Parameters.AddWithValue("@reviewerName", reviewerName);
            objCommand.Parameters.AddWithValue("@restaurantName", restaurantName);
            objCommand.Parameters.AddWithValue("@foodQuality", foodQuality);
            objCommand.Parameters.AddWithValue("@serviceQuality", serviceQuality);
            objCommand.Parameters.AddWithValue("@atmosphereQuality", atmosphereQuality);
            objCommand.Parameters.AddWithValue("@priceQuality", priceQuality);
            objCommand.Parameters.AddWithValue("@comment", comment);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            int success = objDB.DoUpdateUsingCmdObj(objCommand);
            return success;
        }

        public DataSet GetReviewsByUsername(string username)
        {
            DataSet myDS = new DataSet();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReviewsByUsername";
            objCommand.Parameters.AddWithValue("@username", username);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public int AddUser(string RealName, string UserName, string UserType)
        {
            DataSet myDS = new DataSet();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "AddReview";
            objCommand.Parameters.AddWithValue("@RealName", RealName);
            objCommand.Parameters.AddWithValue("@UserName", UserName);
            objCommand.Parameters.AddWithValue("@UserType", UserType);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            int success = objDB.DoUpdateUsingCmdObj(objCommand);
            return success;
        }
    }
}