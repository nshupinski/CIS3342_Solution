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
        public DBProcedures procedures = new DBProcedures();
        protected void Page_Load(object sender, EventArgs e)
        {
            checkUsertype();


            if (!IsPostBack)
            {
                string username = Session["Username"].ToString();
                myDS = procedures.GetReviewsByUsername(username);
                gvMyReviews.DataSource = myDS;
                gvMyReviews.DataBind();

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
    }
}