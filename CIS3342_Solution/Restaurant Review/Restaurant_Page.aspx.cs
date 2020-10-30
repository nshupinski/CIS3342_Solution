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
        DataSet myDS = new DataSet();
        DataSet reviews = new DataSet();
        string restaurantName;
        string representative;
        DBProcedures procedure = new DBProcedures();
        Reservation newReservation = new Reservation();
        Restaurant selectedRestaurant = new Restaurant();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Check Username
            representative = Session["Username"].ToString();
            username_display.InnerHtml = representative;

            restaurantName = Session["selectedRestaurant"].ToString();
            // Get Restaurant Name from HTTP QueryString
            //restaurantName = Request.QueryString["selectedRestaurant"];

            // Get Restaurant info from DB
            if (!IsPostBack)
            {
                GetSelectedRestaurant();
                
                showReviews();

                showRestaurantRatings();
            }
        }

        private void displayRestaurantInfo(Restaurant rest)
        {
            // restaurant info
            restaurantImage.Src = rest.Image;
            title.InnerHtml = rest.Name;
            rep.InnerHtml = rep.InnerHtml + rest.Representative;
            description.InnerHtml = rest.Description;

            // reservation info
            modalTitle.InnerHtml = rest.Name;

            // review info
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

                if (!(success == -1))
                {
                    lblReservationError.Text = "";
                    lblReservationSubmitted.Text = "Thank you for making a reservation at " + restaurantName + "!";
                }
                else
                {
                    lblReservationError.Text = "There was an error when saving your reservation. Please Try again";
                }
            }
        }

        public void GetReservationDateTime()
        {
            int reservationMonth = Int32.Parse(ddlDateMonth.SelectedItem.Text);
            int reservationDay = Int32.Parse(ddlDateDay.SelectedItem.Text);
            string dayTime = amORpm.SelectedValue;
            int reservationTimeHour = 0;
            int reservationTimeMinute = 0;

            if (validateReservationDateTime(reservationMonth, reservationDay, dayTime, reservationTimeHour, reservationTimeMinute))
            {
                reservationTimeHour = Int32.Parse(txtTimeHour.Text);
                reservationTimeMinute = Int32.Parse(txtTimeMinute.Text);

                string dateTimeString = reservationMonth + "-" + reservationDay + "-" + DateTime.Now.Year + " " + reservationTimeHour + ":" + reservationTimeMinute + " " + dayTime;
                DateTime newReservationDateTime = DateTime.ParseExact(dateTimeString, "M-d-yyyy h:mm tt", null);

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

        public void checkUsertype(string rep)
        {
            string usertype = Session["Usertype"].ToString();

            if (usertype == "Reviewer")
            {
                btnMyReviews.Style["visibility"] = "visible";
                btnMakeReview.Style["visibility"] = "visible";
            }
            else if (usertype == "Representative")
            {
                btnMyRestaurants.Style["visibility"] = "visible";
            }
            else if ( (usertype == "Representative") && (rep == "") )
            {
                btnClaimRestaurant.Visible = true;
            }
        }

        public void btnMakeReview_Clicked(object sender, EventArgs e)
        {
            reviewModal.Style["visibility"] = "visible";
        }

        public void btnReviewSubmit_Clicked(object sender, EventArgs e)
        {
            if (txtComments.Text == "")
            {
                lblReviewError.Text = "Please leave a comment with your review";
            }
            else
            {
                lblReviewError.Text = "";
                Review newReview = new Review();
                newReview.ReviewerName = Session["Username"].ToString();
                newReview.RestaurantName = restaurantName;
                newReview.FoodQuality = Int32.Parse(ddlFoodQuality.SelectedValue);
                newReview.ServiceQuality = Int32.Parse(ddlServiceQuality.SelectedValue);
                newReview.AtmosphereQuality = Int32.Parse(ddlAtmosphereQuality.SelectedValue);
                newReview.PriceQuality = Int32.Parse(ddlPriceQuality.SelectedValue);
                newReview.Comment = txtComments.Text;

                int success = procedure.AddReview(newReview.ReviewerName, newReview.RestaurantName, 
                    newReview.FoodQuality, newReview.ServiceQuality, newReview.AtmosphereQuality, 
                    newReview.PriceQuality, newReview.Comment);

                if (!(success == -1))
                {
                    lblReviewError.Text = "";
                    lblReviewSubmitted.Text = "Thank you for submitting a review for " + restaurantName + "!";
                    gvReviews.DataBind();
                    showReviews();
                }
                else
                {
                    lblReviewError.Text = "There was an error when saving your review. Please Try again";
                }
            }
        }

        public void btnReviewCancel_Clicked(object sender, EventArgs e)
        {
            reviewModal.Style["visibility"] = "hidden";
        }

        public void showRestaurantRatings()
        {
            double foodAverage = 0;
            double serviceAverage = 0;
            double atmosphereAverage = 0;
            double priceAverage = 0;

            if(reviews.Tables[0].Rows.Count == 0)
            {
                foodRating.InnerHtml = foodRating.InnerHtml + "No reviews yet";
                serviceRating.InnerHtml = serviceRating.InnerHtml + "No reviews yet";
                atmosphereRating.InnerHtml = atmosphereRating.InnerHtml + "No reviews yet";
                priceRating.InnerHtml = priceRating.InnerHtml + "No reviews yet";
            }
            else
            {
                for (int i = 0; i < reviews.Tables[0].Rows.Count; i++)
                {
                    foodAverage += Int32.Parse(reviews.Tables[0].Rows[i]["FoodQuality"].ToString());
                    serviceAverage += Int32.Parse(reviews.Tables[0].Rows[i]["Service"].ToString());
                    atmosphereAverage += Int32.Parse(reviews.Tables[0].Rows[i]["Atmosphere"].ToString());
                    priceAverage += Int32.Parse(reviews.Tables[0].Rows[i]["PriceRating"].ToString());
                }

                foodAverage = Math.Round((foodAverage / reviews.Tables[0].Rows.Count), 2);
                serviceAverage = Math.Round((serviceAverage / reviews.Tables[0].Rows.Count), 2);
                atmosphereAverage = Math.Round((atmosphereAverage / reviews.Tables[0].Rows.Count), 2);
                priceAverage = Math.Round((priceAverage / reviews.Tables[0].Rows.Count), 2);

                foodRating.InnerHtml = foodRating.InnerHtml + foodAverage;
                serviceRating.InnerHtml = serviceRating.InnerHtml + serviceAverage;
                atmosphereRating.InnerHtml = atmosphereRating.InnerHtml + atmosphereAverage;
                priceRating.InnerHtml = priceRating.InnerHtml + priceAverage;
            }
        }

        public Restaurant GetRestaurantInfo(Restaurant selectedRestaurant)
        {
            selectedRestaurant.Name = myDS.Tables[0].Rows[0]["RestaurantName"].ToString();
            selectedRestaurant.Description = myDS.Tables[0].Rows[0]["Description"].ToString();
            selectedRestaurant.Category = myDS.Tables[0].Rows[0]["Category"].ToString();
            selectedRestaurant.Image = myDS.Tables[0].Rows[0]["Image"].ToString();
            selectedRestaurant.Representative = myDS.Tables[0].Rows[0]["Representative"].ToString();

            return selectedRestaurant;
        }

        public void showReviews()
        {
            // Get reviews for selected restaurant
            reviews = procedure.GetReviewsByRestaurantName(restaurantName);

            // Set the datasource of the Repeater control and bind the data
            gvReviews.DataSource = reviews;
            gvReviews.DataBind();
        }

        public void btnClaimRestaurant_Clicked(object sender, EventArgs e)
        {
            modalClaimed.Visible = true;
            GetSelectedRestaurant();
            selectedRestaurant.Representative = Session["Username"].ToString();

            procedure.UpdateRestaurantByName(selectedRestaurant.Name, selectedRestaurant.Description, selectedRestaurant.Category, selectedRestaurant.Image, selectedRestaurant.Representative);

            btnClaimRestaurant.Visible = false;
            GetSelectedRestaurant();
        }

        public void btnClose_Clicked(object sender, EventArgs e)
        {
            modalClaimed.Visible = false;
        }

        public void GetSelectedRestaurant()
        {
            myDS = procedure.GetRestaurantByName(restaurantName);
            selectedRestaurant = GetRestaurantInfo(selectedRestaurant);

            checkUsertype(selectedRestaurant.Representative);
            displayRestaurantInfo(selectedRestaurant);
        }
    }
}