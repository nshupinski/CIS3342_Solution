using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant_Review
{
    public partial class MyReviews : System.Web.UI.Page
    {
        public DataSet myDS;
        public DBProcedures procedure = new DBProcedures();
        string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            checkUsertype();
            username = Session["Username"].ToString();

            if (!IsPostBack)
            {
                ShowReviews();

                //Check Username
                username_display.InnerHtml = username;
            }
        }

        public void checkUsertype()
        {
            string usertype = Session["Usertype"].ToString();

            if (usertype == "Reviewer")
            {
                btnMyReviews.Style["visibility"] = "visible";
            }
        }

        protected void gvMyReviews_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the row to edit-mode in the GridView
            gvMyReviews.EditIndex = e.NewEditIndex;

            ShowReviews();
        }

        public void ShowReviews()
        {
            myDS = procedure.GetReviewsByUsername(username);
            gvMyReviews.DataSource = myDS;
            gvMyReviews.DataBind();
        }

        protected void gvMyReviews_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMyReviews.EditIndex = -1;
            ShowReviews();
        }

        protected void gvMyReviews_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int reviewId = Int32.Parse(gvMyReviews.Rows[rowIndex].Cells[0].Text);
            string restaurantName = gvMyReviews.Rows[rowIndex].Cells[1].Text;
            int foodRating = Int32.Parse(((TextBox)gvMyReviews.Rows[rowIndex].Cells[2].Controls[0]).Text);
            int serviceRating = Int32.Parse(((TextBox)gvMyReviews.Rows[rowIndex].Cells[3].Controls[0]).Text);
            int atmosphereRating = Int32.Parse(((TextBox)gvMyReviews.Rows[rowIndex].Cells[4].Controls[0]).Text);
            int priceRating = Int32.Parse(((TextBox)gvMyReviews.Rows[rowIndex].Cells[5].Controls[0]).Text);
            string comment = ((TextBox)gvMyReviews.Rows[rowIndex].Cells[6].Controls[0]).Text;

            procedure.UpdateReviewById(reviewId, foodRating, serviceRating, atmosphereRating, priceRating, comment);

            gvMyReviews.EditIndex = -1;
            ShowReviews();
        }
    }
}