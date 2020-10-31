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
        DataSet mainDS = new DataSet();
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
                ShowReservations();
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
        public void ShowReservations()
        {
            DataSet newDS = new DataSet();

            myDS = procedure.GetRestaurantByUsername(username);
            for (int i=0; i<myDS.Tables[0].Rows.Count; i++)
            {
                newDS = procedure.GetReservationsByRestaurant(myDS.Tables[0].Rows[i]["RestaurantName"].ToString());
                mainDS.Merge(newDS);
            }

            if(!(myDS.Tables[0].Rows.Count == 0))
            {
                gvMyReservations.DataSource = mainDS;
                gvMyReservations.DataBind();
            }
        }

        // Restaurant Gridview
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


        // Reservation Gridview
        protected void gvMyReservations_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMyReservations.EditIndex = -1;
            ShowReservations();
        }

        protected void gvMyReservations_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gvMyReservations.Rows[e.RowIndex];
            int reservationId = Int32.Parse(row.Cells[0].Text);

            procedure.DeleteReservationById(reservationId);
            ShowReservations();
        }

        protected void gvMyReservations_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMyReservations.EditIndex = -1;

            //ShowReservations();
        }

        protected void gvMyReservations_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int reservationId = Int32.Parse(gvMyReservations.Rows[rowIndex].Cells[0].Text);
            string restaurantName = ((TextBox)gvMyReservations.Rows[rowIndex].Cells[1].Controls[0]).Text;
            string reservationName = ((TextBox)gvMyReservations.Rows[rowIndex].Cells[2].Controls[0]).Text;
            string time = ((TextBox)gvMyReservations.Rows[rowIndex].Cells[3].Controls[0]).Text;
            string phoneNumber = ((TextBox)gvMyReservations.Rows[rowIndex].Cells[4].Controls[0]).Text;
            int partySize = Int32.Parse(gvMyReservations.Rows[rowIndex].Cells[5].Text);

            procedure.UpdateReservationById(reservationId, restaurantName, reservationName, time, phoneNumber, partySize);

            gvMyRestaurants.EditIndex = -1;
            ShowReservations();
        }







        protected void gvMyReservations_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvMyRestaurants_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}