using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Utilities;
using System.Collections;
using BookLibrary;

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
            string id = txtID.Text;
            string name = txtName.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            string campus = campusList.SelectedItem.Text;

            if (id == "" || name == "" || address == "" || phone == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('Please fill out all of your information')", true);
            }
            else
            {
                ArrayList arrBooks = new ArrayList();

                for (int row = 0; row < gvOrderBooks.Rows.Count; row++)
                {
                    CheckBox CBox;
                    CBox = (CheckBox)gvOrderBooks.Rows[row].FindControl("chBoxOrder");

                    if (CBox.Checked)
                    {
                        String Title = "";
                        String Authors = "";
                        String ISBN = "";
                        String BookType = "";
                        String Quantity = "";
                        String Price = "";
                        float TotalCost = 0;

                        Book newBook = new Book();
                        newBook.Title = gvOrderBooks.Rows[row].Cells[1].Text;
                        newBook.Authors = gvOrderBooks.Rows[row].Cells[2].Text;
                        newBook.ISBN = gvOrderBooks.Rows[row].Cells[3].Text;
                        newBook.BookType = gvOrderBooks.Rows[row].Cells[4].Text;


                        ISBN = gvOrderBooks.Rows[row].Cells[3].Text;
                        arrBooks.Add(ISBN);
                    }
                }
            }
        }
    }
}