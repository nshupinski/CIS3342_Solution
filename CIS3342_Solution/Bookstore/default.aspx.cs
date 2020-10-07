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
using System.Globalization;

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

            int totalQuantity = 0;
            double total = 0;
            int totalQuantityRented = 0;
            int totalQuantitySold = 0;

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
                        int a;
                        TextBox txtQuantity = (TextBox)gvOrderBooks.Rows[row].FindControl("txtQuantity");
                        if (!(Int32.TryParse(txtQuantity.Text, out a)))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('Please enter a valid quantity')", true);
                        }
                        else
                        {
                            newBook.Quantity = Convert.ToInt32(txtQuantity.Text);


                            // Price
                            newBook.Price = Convert.ToDouble(gvOrderBooks.DataKeys[row].Value);

                            // Total Cost
                            Order newOrder = new Order(newBook.BookType, newBook.RentOrBuy, newBook.Quantity, newBook.Price);
                            newBook.TotalCost = float.Parse(newOrder.CalcTotal().ToString());

                            arrBooks.Add(newBook);
                        }                       
                    }
                }

                // Bind Data to Gridview
                gvOrder.DataSource = arrBooks;
                gvOrder.DataBind();

                // Add footer
                int count = arrBooks.Count;
                
                for (int i = 0; i < count; i++)
                {
                    totalQuantity = totalQuantity + int.Parse(gvOrder.Rows[i].Cells[5].Text);
                    total = total + double.Parse(gvOrder.Rows[i].Cells[6].Text, NumberStyles.Currency);

                    // Get if buy or rent
                    DropDownList ddlBookType = (DropDownList)gvOrderBooks.Rows[i].FindControl("ddbType");
                    TextBox txtQuantity = (TextBox)gvOrderBooks.Rows[i].FindControl("txtQuantity");
                    int quantity = Convert.ToInt32(txtQuantity.Text);

                    if (ddlBookType.SelectedValue == "Rent")
                    {
                        totalQuantityRented = totalQuantityRented + quantity;
                    }
                    else if (ddlBookType.SelectedValue == "Buy")
                    {
                        totalQuantitySold = totalQuantitySold + quantity;
                    }
                }

                // Put the values into the corresponding footer column
                gvOrder.Columns[0].FooterText = "Totals:";
                gvOrder.Columns[5].FooterText = totalQuantity.ToString();
                gvOrder.Columns[6].FooterText = total.ToString("0.00");

                // Rebind Gridview with footer
                gvOrder.DataBind();

                // Hide gvOrderBooks
                gvOrderBooks.Visible = false;
                infoSection.Visible = false;
                formDiv.Visible = false;

                showOrderUserInfo(id, name, address, phone, campus);
            }

            String strSQL = "UPDATE Books SET TotalSales = TotalSales + " + total + ", " +
                "TotalQuantityRented = TotalQuantityRented + " + totalQuantityRented + ", " +
                "TotalQuantitySold = TotalQuantitySold + " + totalQuantitySold;

             DBConnect objDB = new DBConnect();
             objDB.DoUpdate(strSQL);

        }
        public void showOrderUserInfo(string id, string name, string address, string phone, string campus)
        {
            orderStudentID.Text = "Student ID: " + id + "<br>";
            orderStudentID.Visible = true;
            orderName.Text = "Name: " + name + "<br>";
            orderName.Visible = true;
            orderAddress.Text = "Address: " + address + "<br>";
            orderAddress.Visible = true;
            orderPhone.Text = "Phone Number: " + phone + "<br>";
            orderPhone.Visible = true;
            orderCampus.Text = "Campus: " + campus + "<br>";
            orderCampus.Visible = true;

            gvOrder.Visible = true;
        }

        public void btnBookSearch_Clicked(object sender, EventArgs e)
        {
            orderStudentID.Visible = false;
            orderName.Visible = false;
            orderAddress.Visible = false;
            orderPhone.Visible = false;
            orderCampus.Visible = false;

            gvOrder.Visible = false;

            gvManagementReport.Visible = false;

            gvOrderBooks.Visible = true;
            infoSection.Visible = true;
            formDiv.Visible = true;
        }

        public void btnManagement_Clicked(object sender, EventArgs e)
        {
            // Hide anything that might be displayed
            orderStudentID.Visible = false;
            orderName.Visible = false;
            orderAddress.Visible = false;
            orderPhone.Visible = false;
            orderCampus.Visible = false;

            gvOrderBooks.Visible = false;
            infoSection.Visible = false;
            formDiv.Visible = false;

            gvOrder.Visible = false;

            gvManagementReport.Visible = true;

            // Bind data to Management Report Gridview
            DBConnect objDB = new DBConnect();
            String strSQL = "SELECT * FROM Books";

            myDS = objDB.GetDataSet(strSQL);
            gvManagementReport.DataSource = myDS;

            gvManagementReport.DataBind();
        }  
    }
}