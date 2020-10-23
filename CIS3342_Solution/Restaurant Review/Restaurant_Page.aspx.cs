using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        string restaurantName;
        DBProcedures procedure;

        protected void Page_Load(object sender, EventArgs e)
        {
            procedure = new DBProcedures();

            //Check Usertype
            username_display.InnerHtml = Session["Username"].ToString();

            // Get Restaurant Name from HTTP QueryString
            restaurantName = Request.QueryString["selectedRestaurant"];

            // Get Restaurant info from DB
            if (!IsPostBack)
            {
                myDS = procedure.GetRestaurantByName(restaurantName);

                // Get selected restaurant info from DB
                Restaurant selectedRestaurant = new Restaurant();
                selectedRestaurant.ID = (int)myDS.Tables[0].Rows[0]["Restaurant_Id"];
                selectedRestaurant.Name = myDS.Tables[0].Rows[0]["RestaurantName"].ToString();
                selectedRestaurant.Description = myDS.Tables[0].Rows[0]["Description"].ToString();
                selectedRestaurant.Category = myDS.Tables[0].Rows[0]["Category"].ToString();
                selectedRestaurant.Image = myDS.Tables[0].Rows[0]["Image"].ToString();
                selectedRestaurant.Representative = myDS.Tables[0].Rows[0]["Representative"].ToString();

                // Set the datasource of the Repeater control and bind the data
                gvReviews.DataSource = myDS;
                gvReviews.DataBind();

                displayRestaurantInfo(selectedRestaurant);
                displayReservationInfo(selectedRestaurant);
            }  
        }

        private void displayRestaurantInfo(Restaurant rest)
        {
            restaurantImage.Src = rest.Image;
            title.InnerHtml = rest.Name;
            rep.InnerHtml = rep.InnerHtml + rest.Representative;
            description.InnerHtml = rest.Description;
        }

        public void btnReservation_Clicked(object sender, EventArgs e)
        {
            reservationModal.Style["visibility"] = "visible";
        }

        public void btnModalCancel_Clicked(object sender, EventArgs e)
        {
            reservationModal.Style["visibility"] = "hidden";
        }

        public void btnModalSubmit_Clicked(object sender, EventArgs e)
        {
            int reservationMonth = Int32.Parse(ddlDateMonth.SelectedItem.Text);
            int reservationDay = Int32.Parse(ddlDateDay.SelectedItem.Text);
            string dayTime = amORpm.SelectedValue;
            int reservationTime = 0;
            if (Int32.TryParse(txtTime.Text, out reservationTime))
            {
                reservationTime = Int32.Parse(txtTime.Text);
            }
            else
            {
                lblReservationError.Text = "The time was not input correctly";
            }

            // Validate
            if(reservationName_input.Text == "" || txtTime.Text == "")
            {
                lblReservationError.Text = "Please input all of the required data";
            }
            
            reservationModal.Style["visibility"] = "hidden";

        }

        public void displayReservationInfo(Restaurant rest)
        {
            modalTitle.InnerHtml = rest.Name;
        }

    }
}