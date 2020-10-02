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

        public DataSet myDS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DBConnect objDB = new DBConnect();
                String strSQL = "SELECT * FROM Books";

                myDS = objDB.GetDataSet(strSQL);
                gvOrderBooks.DataSource = myDS;

                String[] basePrices = new String[1];
                basePrices[0] = "BasePrice";
                String thing = basePrices[0];
                gvOrderBooks.DataKeyNames = basePrices;

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

                    // If checked, add book to Arraylist
                    if (CBox.Checked)
                    {
                        Book newBook = new Book();

                        // Title
                        newBook.Title = gvOrderBooks.Rows[row].Cells[1].Text;

                        // Authors
                        newBook.Authors = gvOrderBooks.Rows[row].Cells[2].Text;

                        // ISBN
                        newBook.ISBN = gvOrderBooks.Rows[row].Cells[3].Text;

                        // Book Type
                        DropDownList ddlBookType = (DropDownList)gvOrderBooks.Rows[row].FindControl("ddbType");
                        newBook.BookType = ddlBookType.SelectedValue;

                        // Rent or Buy
                        DropDownList ddlRentOrBuy = (DropDownList)gvOrderBooks.Rows[row].FindControl("ddbRentBuy");
                        newBook.RentOrBuy = ddlRentOrBuy.SelectedValue;

                        // Quantity
                        TextBox txtQuantity = (TextBox)gvOrderBooks.Rows[row].FindControl("txtQuantity");
                        newBook.Quantity = Convert.ToInt32(txtQuantity.Text);             
            

                        // Price
                       newBook.Price = Convert.ToDouble(gvOrderBooks.DataKeys[row].Value);

                        // Total Cost
                        Order newOrder = new Order(newBook.BookType, newBook.RentOrBuy, newBook.Quantity, newBook.Price);
                        newBook.TotalCost = float.Parse(newOrder.CalcTotal().ToString());

                        arrBooks.Add(newBook);
                    }
                }

                gvOrder.DataSource = arrBooks;
                gvOrder.DataBind();

            }
        }
    }
}