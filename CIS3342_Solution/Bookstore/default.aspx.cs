using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Utilities;
using System.Collections;

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
            ArrayList arrBooks = new ArrayList();

            for (int row = 0; row < gvOrderBooks.Rows.Count; row++)
            {
                CheckBox CBox;
                CBox = (CheckBox)gvOrderBooks.Rows[row].FindControl("chBoxOrder");

                if (CBox.Checked)
                {
                    String ISBN = "";

                    ISBN = gvOrderBooks.Rows[row].Cells[3].Text;
                    arrBooks.Add(ISBN);
                }
            }
        }
    }
}