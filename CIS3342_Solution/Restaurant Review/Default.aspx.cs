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
        string restaurantName;
        public DataSet myDS;
        public DBProcedures procedures;

        protected void Page_Load(object sender, EventArgs e)
        {
            procedures = new DBProcedures();
            checkUsertype();

            // Display usertype
            username_display.InnerHtml = Session["Username"].ToString();

            if (!IsPostBack)
            {
                myDS = procedures.GetAllRestaurants();
                gvRestaurants.DataSource = myDS;
                gvRestaurants.DataBind();
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
            string usertype = Session["Usertype"].ToString();

            if (usertype == "Reviewer")
            {
                btnMyReviews.Style["visibility"] = "visible";
            }
        }
    }
}