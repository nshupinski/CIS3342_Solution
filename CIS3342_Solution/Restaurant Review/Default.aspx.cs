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
            Response.Redirect("Login.aspx");
        }
    }
}