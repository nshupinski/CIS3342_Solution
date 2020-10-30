using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Restaurant_Review
{
    public partial class MyRestaurants : System.Web.UI.Page
    {
        string username;
        DataSet myDS = new DataSet();
        DBProcedures procedure = new DBProcedures();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Display usertype
            username = Session["Username"].ToString();
            username_display.InnerHtml = username;

            btnMyRestaurants.Style["visibility"] = "visible";

            if (!IsPostBack)
            {
                ShowRestaurants();
            }
        }

        public void logOut()
        {
            Session["Username"] = "";
            Response.Redirect("Login.aspx");
        }

        public void ShowRestaurants()
        {
            myDS = procedure.GetRestaurantByUsername(username);
            gvMyRestaurants.DataSource = myDS;
            gvMyRestaurants.DataBind();
        }

        protected void gvMyRestaurants_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the row to edit-mode in the GridView
            gvMyRestaurants.EditIndex = e.NewEditIndex;

            ShowRestaurants();
        }

        protected void gvMyRestaurants_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gvMyRestaurants.Rows[e.RowIndex];
            int restaurantId = Int32.Parse(row.Cells[0].Text);

            procedure.DeleteRestaurantById(restaurantId);
            ShowRestaurants();
        }

        protected void gvMyRestaurants_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMyRestaurants.EditIndex = -1;
            ShowRestaurants();
        }

        protected void gvMyRestaurants_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int restaurantId = Int32.Parse(gvMyRestaurants.Rows[rowIndex].Cells[0].Text);
            string restaurantName = ((TextBox)gvMyRestaurants.Rows[rowIndex].Cells[1].Controls[0]).Text;
            string description = ((TextBox)gvMyRestaurants.Rows[rowIndex].Cells[2].Controls[0]).Text;
            string category = ((TextBox)gvMyRestaurants.Rows[rowIndex].Cells[3].Controls[0]).Text;
            string image = ((TextBox)gvMyRestaurants.Rows[rowIndex].Cells[4].Controls[0]).Text;

            procedure.UpdateRestaurantById(restaurantId, restaurantName, description, category, image, username);

            gvMyRestaurants.EditIndex = -1;
            ShowRestaurants();
        }






        protected void gvMyRestaurants_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}