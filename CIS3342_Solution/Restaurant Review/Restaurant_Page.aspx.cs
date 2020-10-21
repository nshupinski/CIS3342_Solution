using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace Restaurant_Review
{
    public partial class Restaurant_Page : System.Web.UI.Page
    {
        public DataSet myDS;

        protected void Page_Load(object sender, EventArgs e)
        {
            username_display.InnerHtml = Session["Username"].ToString();
            string restaurantName = Request.QueryString["selectedRestaurant"];

            if (!IsPostBack) { 
            // Get restaurant data from DB
            DBConnect objDB = new DBConnect();
            String strSQL = "SELECT * FROM Restaurant WHERE Name = " + "'" + restaurantName + "'";
            myDS = objDB.GetDataSet(strSQL);

            // Get selected restaurant info from DB
            Restaurant selectedRestaurant = new Restaurant();
            selectedRestaurant.ID = (int)myDS.Tables[0].Rows[0]["Id"];
            selectedRestaurant.Name = myDS.Tables[0].Rows[0]["Name"].ToString();
            selectedRestaurant.Description = myDS.Tables[0].Rows[0]["Description"].ToString();
            selectedRestaurant.Category = myDS.Tables[0].Rows[0]["Category"].ToString();
            selectedRestaurant.Image = myDS.Tables[0].Rows[0]["Image"].ToString();
            selectedRestaurant.Representative = myDS.Tables[0].Rows[0]["Representative"].ToString();

            // Get review from DB
            String strSQL2 = "SELECT * FROM Review WHERE RestaurantName = " + "'" + restaurantName + "'";

            // Set the datasource of the Repeater control and bind the data
            gvReviews.DataSource = objDB.GetDataSet(strSQL2);
            gvReviews.DataBind();

            displayRestaurantInfo(selectedRestaurant);
            displayReservationInfo(selectedRestaurant);
            }
        }

        public void displayRestaurantInfo(Restaurant rest)
        {
            restaurantImage.Src = rest.Image;
            title.InnerHtml = rest.Name;
            rep.InnerHtml = rep.InnerHtml + rest.Representative;
            description.InnerHtml = rest.Description;
        }

        public void btnReservation_Clicked(object sender, EventArgs e)
        {
            reservationModal.Attributes.Add("style", "display: block");
        }

        public void displayReservationInfo(Restaurant rest)
        {
            modalTitle.InnerHtml = rest.Name;
        }
    }
}