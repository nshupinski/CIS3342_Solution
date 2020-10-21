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
    public partial class Default : System.Web.UI.Page
    {
        public DataSet myDS;
        protected void Page_Load(object sender, EventArgs e)
        {

            // Display usertype
            username_display.InnerHtml = Session["Username"].ToString();

            if (!IsPostBack)
            {
                DBConnect objDB = new DBConnect();
                String strSQL = "SELECT * FROM Restaurant";

                myDS = objDB.GetDataSet(strSQL);
                gvRestaurants.DataSource = myDS;

                /*String[] basePrices = new String[1];
                basePrices[0] = "BasePrice";
                String thing = basePrices[0];
                gvRestaurants.DataKeyNames = ;*/

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
            Response.Redirect("Restaurant_Page.aspx?selectedRestaurant=" + selectedRestaurant);
        }

        protected void gvRestaurants_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}