﻿using System;
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

        public DataSet GetAllCategories()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetAllCategories";

            // Execute stored procedure using DBConnect object and the SQLCommand object
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet GetRestaurantByName(string restaurantName)
        {
            DataSet myDS = new DataSet();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRestaurantByName";
            objCommand.Parameters.AddWithValue("@restaurantName", restaurantName);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet GetRestaurantByCategory(string category)
        {
            DataSet myDS = new DataSet();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRestaurantByCategory";
            objCommand.Parameters.AddWithValue("@category", category);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet GetUsername()
        {
            DataSet myDS = new DataSet();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUsername";

            // Execute stored procedure using DBConnect object and the SQLCommand object
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public int AddReservation(string reservationName, string restaurantName, DateTime time, string phoneNumber, int numOfPeople)
        {
            DataSet myDS = new DataSet();
            SqlCommand objCommand = new SqlCommand();
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
            SqlCommand objCommand = new SqlCommand();
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
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReviewsByUsername";
            objCommand.Parameters.AddWithValue("@username", username);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet GetReviewsByRestaurantName(string restaurantName)
        {
            DataSet myDS = new DataSet();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReviewsByRestaurantName";
            objCommand.Parameters.AddWithValue("@restaurantName", restaurantName);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public int AddUser(string RealName, string UserName, string UserType)
        {
            DataSet myDS = new DataSet();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "AddUser";
            objCommand.Parameters.AddWithValue("@RealName", RealName);
            objCommand.Parameters.AddWithValue("@UserName", UserName);
            objCommand.Parameters.AddWithValue("@UserType", UserType);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            int success = objDB.DoUpdateUsingCmdObj(objCommand);
            return success;
        }

        public DataSet GetAllUsers()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUsername";

            // Execute stored procedure using DBConnect object and the SQLCommand object
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public void UpdateReviewById(int reviewId, int foodRating, int serviceRating, int atmosphereRating, int priceRating, string comment)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateReviewById";
            objCommand.Parameters.AddWithValue("@reviewId", reviewId);
            objCommand.Parameters.AddWithValue("@foodRating", foodRating);
            objCommand.Parameters.AddWithValue("@serviceRating", serviceRating);
            objCommand.Parameters.AddWithValue("@atmosphereRating", atmosphereRating);
            objCommand.Parameters.AddWithValue("@priceRating", priceRating);
            objCommand.Parameters.AddWithValue("@comment", comment);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        public int AddRestaurant(string name, string description, string category, string image, string rep)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "AddRestaurant";
            objCommand.Parameters.AddWithValue("@RestaurantName", name);
            objCommand.Parameters.AddWithValue("@Description", description);
            objCommand.Parameters.AddWithValue("@Category", category);
            objCommand.Parameters.AddWithValue("@Image", image);
            objCommand.Parameters.AddWithValue("@Representative", rep);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            int success = objDB.DoUpdateUsingCmdObj(objCommand);
            return success;
        }

        public void DeleteReviewById(int reviewId)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteReviewById";
            objCommand.Parameters.AddWithValue("@reviewId", reviewId);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        public void UpdateRestaurantByName(string name, string desc, string cat, string img, string rep)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateRestaurantByName";
            objCommand.Parameters.AddWithValue("@RestaurantName", name);
            objCommand.Parameters.AddWithValue("@Description", desc);
            objCommand.Parameters.AddWithValue("@Category", cat);
            objCommand.Parameters.AddWithValue("@Image", img);
            objCommand.Parameters.AddWithValue("@Representative", rep);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        public void UpdateReservationById(int id, string rest, string name, string time, string phone, int size)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateRestaurantByName";
            objCommand.Parameters.AddWithValue("@id", id);
            objCommand.Parameters.AddWithValue("@rest", rest);
            objCommand.Parameters.AddWithValue("@name", name);
            objCommand.Parameters.AddWithValue("@time", time);
            objCommand.Parameters.AddWithValue("@phone", phone);
            objCommand.Parameters.AddWithValue("@size", size);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        public DataSet GetRestaurantByUsername(string username)
        {
            DataSet myDS = new DataSet();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRestaurantByUsername";
            objCommand.Parameters.AddWithValue("@representative", username);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public void DeleteReservationById(int reservationId)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteReservationById";
            objCommand.Parameters.AddWithValue("@reservationId", reservationId);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        public void DeleteRestaurantById(int restaurantId)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteRestaurantById";
            objCommand.Parameters.AddWithValue("@restaurantId", restaurantId);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        public void UpdateRestaurantById(int id, string name, string desc, string cat, string img, string rep)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateRestaurantById";
            objCommand.Parameters.AddWithValue("@RestaurantId", id);
            objCommand.Parameters.AddWithValue("@RestaurantName", name);
            objCommand.Parameters.AddWithValue("@Description", desc);
            objCommand.Parameters.AddWithValue("@Category", cat);
            objCommand.Parameters.AddWithValue("@Image", img);
            objCommand.Parameters.AddWithValue("@Representative", rep);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        public DataSet GetReservationsByRestaurant(string rest)
        {
            DataSet myDS = new DataSet();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReservationsByRestaurant";
            objCommand.Parameters.AddWithValue("@rest", rest);

            // Execute stored procedure using DBConnect object and the SQLCommand object
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }
    }
}