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
        Reservation newReservation = new Reservation();

        protected void Page_Load(object sender, EventArgs e)
        {
            procedure = new DBProcedures();

            checkUsertype();

            //Check Username
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
                displayReviewInfo(selectedRestaurant);
            }  
        }

        private void displayRestaurantInfo(Restaurant rest)
        {
            restaurantImage.Src = rest.Image;
            title.InnerHtml = rest.Name;
            rep.InnerHtml = rep.InnerHtml + rest.Representative;
            description.InnerHtml = rest.Description;
        }

        public void displayReservationInfo(Restaurant rest)
        {
            modalTitle.InnerHtml = rest.Name;
        }

        public void displayReviewInfo(Restaurant rest)
        {
            reviewModalTitle.InnerHtml = rest.Name;
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
            string phone = txtPhoneNumber.Text;
            int partySize = Int32.Parse(numPeople.SelectedValue);

            if (validateReservationInput() == true)
            {
                GetReservationDateTime();
                newReservation.PhoneNumber = phone;
                newReservation.PartySize = partySize;
                newReservation.RestaurantName = restaurantName;
                newReservation.ReservationName = reservationName_input.Text;

                int success = procedure.AddReservation(newReservation.ReservationName, newReservation.RestaurantName, newReservation.Time, newReservation.PhoneNumber, newReservation.PartySize);

                if(!(success == -1))
                {
                    lblReservationError.Text = "";
                    lblReservationSubmitted.Text = "Thank you for making a reservation at " + restaurantName + "!";
                }
                else
                {
                    lblReservationError.Text = "There was an error when saving your reservation. Please Try again";
                }

                //reservationModal.Style["visibility"] = "hidden";
            }
        }

        public void GetReservationDateTime()
        {
            int reservationMonth = Int32.Parse(ddlDateMonth.SelectedItem.Text);
            int reservationDay = Int32.Parse(ddlDateDay.SelectedItem.Text);
            string dayTime = amORpm.SelectedValue;
            int reservationTimeHour = 0;
            int reservationTimeMinute = 0;

            if(validateReservationDateTime(reservationMonth, reservationDay, dayTime, reservationTimeHour, reservationTimeMinute))
            {
                reservationTimeHour = Int32.Parse(txtTimeHour.Text);
                reservationTimeMinute = Int32.Parse(txtTimeMinute.Text);

                string dateTimeString = reservationMonth + "-" + reservationDay + "-" + DateTime.Now.Year + " " + reservationTimeHour + ":" + reservationTimeMinute + " " + dayTime;
                DateTime newReservationDateTime = DateTime.ParseExact(dateTimeString, "M-d-yyyy H:mm tt", null);

                newReservation.Time = newReservationDateTime;
            }
        }

        public bool validateReservationInput()
        {
            // Validate
            if (reservationName_input.Text == "" || txtTimeHour.Text == "" || txtTimeMinute.Text == "" || txtPhoneNumber.Text == "")
            {
                lblReservationError.Text = "Please input all of the required data";
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool validateReservationDateTime(int reservationMonth, int reservationDay, string dayTime, int reservationTimeHour, int reservationTimeMinute)
        {
            if ((Int32.TryParse(txtTimeHour.Text, out reservationTimeHour)) && (Int32.TryParse(txtTimeMinute.Text, out reservationTimeMinute)))
            {
                return true;
            }
            else
            {
                lblReservationError.Text = "The time was not input correctly";
                return false;
            }
        }

        public void checkUsertype()
        {
            string usertype = Session["Usertype"].ToString();

            if (usertype == "Reviewer")
            {
                btnMakeReview.Style["visibility"] = "visible";
            }
        }

        public void btnMakeReview_Clicked(object sender, EventArgs e)
        {
            reviewModal.Style["visibility"] = "visible";
        }

        public void btnReviewSubmit_Clicked(object sender, EventArgs e)
        {

        }

        public void btnReviewCancel_Clicked(object sender, EventArgs e)
        {
            reviewModal.Style["visibility"] = "hidden";
        }
    }
}