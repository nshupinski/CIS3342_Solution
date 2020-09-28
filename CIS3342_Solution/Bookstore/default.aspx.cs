using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Utilities;

namespace Bookstore
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DBConnect objDB = new DBConnect();
                DataSet myDS;
                String strSQL = "SELECT * FROM Books";

                myDS = objDB.GetDataSet(strSQL);
                gvOrderBooks.DataSource = myDS;
                gvOrderBooks.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnOrder_Clicked(object sender, EventArgs e)
        {

        }
    }
}