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
    public partial class Default : System.Web.UI.Page
    {
        public DataSet myDS;
        public DBProcedures procedures;
        string usertype;
        string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            procedures = new DBProcedures();

            // Display usertype
            username = Session["Username"].ToString();
            username_display.InnerHtml = username;

            usertype = Session["Usertype"].ToString();

            checkUsertype();

            if (!IsPostBack)
            {
                /*MultiSelectDropDown1.Clear();
                MultiSelectDropDown1.List.Items.Add(new System.Web.UI.WebControls.ListItem("Apple", "1"));
                MultiSelectDropDown1.List.Items.Add(new System.Web.UI.WebControls.ListItem("Grapes", "2"));*/
                refreshGridView();
            }
        }

        public void logOut()
        {
            Session["Username"] = "";
            Response.Redirect("Login.aspx");
        }

        protected void restaurantView_Clicked(object sender, EventArgs e)
        {
            //Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            string selectedRestaurant = gvRestaurants.Rows[gvr.RowIndex].Cells[1].Text;
            Session.Add("selectedRestaurant", selectedRestaurant);
            Response.Redirect("Restaurant_Page.aspx");
        }

        protected void gvRestaurants_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void checkUsertype()
        {
            if (usertype == "Reviewer")
            {
                btnMyReviews.Style["visibility"] = "visible";
                btnAddRestaurant.Visible = true;
            }
            else if (usertype == "Representative")
            {
                btnAddRestaurant.Visible = true;
                btnMyRestaurants.Style["visibility"] = "visible";
            }
        }

        public void btnAddRestaurant_Clicked(object sender, EventArgs e)
        {
            if (usertype == "Reviewer")
            {
                restaurantModal.Visible = true;
            }
            else if (usertype == "Representative")
            {
                newRestaurantModal.Visible = true;
            } 
        }

        // Modal Buttons For Reviewer
        public void btnRestaurantSubmit_Clicked(object sender, EventArgs e)
        {
            // new review
            string restName = restaurantName_input.Text;
            int foodQ = Int32.Parse(ddlFoodQuality.SelectedValue);
            int serviceQ = Int32.Parse(ddlServiceQuality.SelectedValue);
            int atmosphereQ = Int32.Parse(ddlServiceQuality.SelectedValue);
            int priceQ = Int32.Parse(ddlPriceQuality.SelectedValue);
            string comment = txtComments.Text;

            // new restaurant
            string description = txtDescInput.Text;
            string category = txtCatInput.Text;
            string image = txtImgInput.Text;
            string representative = "";

            int success = -1;

            if (restName == "" || comment == "" || description == "" || category == "" || image == "") {
                lblRestaurantError.Text = "Please enter all of the information";
            }
            else
            {
                success = procedures.AddRestaurant(restName, description, category, image, representative);
            }

            // validate new restaurant
            if (!(success == -1))
            {
                int success2 = procedures.AddReview(username, restName, foodQ, serviceQ, atmosphereQ, priceQ, comment);

                if(!(success2 == -1))
                {
                    lblRestaurantError.Text = "";
                    lblRestaurantSubmitted.Text = "Thank you for adding a new restaurant to review!";
                    refreshGridView();
                }
                else
                {
                    lblRestaurantError.Text = "There was an error adding your review to the new restaurant. Please try again.";
                }
            }
            else
            {
                lblRestaurantError.Text = "There was an error creating the new restaurant. Please try again.";
            }

        }
        public void btnRestaurantCancel_Clicked(object sender, EventArgs e)
        {
            restaurantModal.Visible = false;
        }

        // Modal Buttons For Representative
        public void btnNewRestaurantSubmit_Clicked(object sender, EventArgs e)
        {
            string restName = txtAddName.Text;
            string desc = txtAddDescription.Text;
            string cat = txtAddCategory.Text;
            string img = txtAddImage.Text;
            string rep = username;

            int success = -1;

            if (restName == "" || desc == "" || cat == "" || img == "")
            {
                lblError.Text = "Please enter all of the information";
            }
            else
            {
                success = procedures.AddRestaurant(restName, desc, cat, img, rep);
            }

            if (!(success == -1))
            {
                lblError.Text = "";
                lblSuccess.Text = "You have successfully added a new restaurant!";
                refreshGridView();
            }
            else
            {
                lblRestaurantError.Text = "There was an error adding your new restaurant. Please try again.";
            }
        }
        public void btnNewRestaurantCancel_Clicked(object sender, EventArgs e)
        {
            newRestaurantModal.Visible = false;
        }


        public void refreshGridView()
        {
            myDS = procedures.GetAllRestaurants();
            gvRestaurants.DataSource = myDS;
            gvRestaurants.DataBind();
        }
    }
}