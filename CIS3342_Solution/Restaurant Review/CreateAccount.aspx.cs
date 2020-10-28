using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant_Review
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        User newUser = new User();
        DBProcedures procedure = new DBProcedures();

        protected void Page_Load(object sender, EventArgs e)
        {
            rbtn_usertypeReviewer.Checked = true;
        }

        protected void btnCreateAccount_Clicked(object sender, EventArgs e)
        {
            // Get usertype
            if(rbtn_usertypeReviewer.Checked)
            {
                newUser.UserType = rbtn_usertypeReviewer.Text;
            }
            else
            {
                newUser.UserType = rbtn_usertypeRepresentative.Text;
            }

            // Validate
            if(realName_input.Text == "" || username_input.Text == "")
            {
                lblErrors.Text = "Please fill out all of the information";
            }
            else
            {
                newUser.RealName = realName_input.Text;
                newUser.UserName = username_input.Text;

                if (is_ValidUsername(newUser.UserName)) {
                    int success = procedure.AddUser(newUser.RealName, newUser.UserName, newUser.UserType);

                    if (!(success == -1))
                    {
                        lblErrors.Text = "";
                        Session.Add("Username", newUser.UserName);
                        Session.Add("Usertype", newUser.UserType);
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        lblErrors.Text = "There was an error creating your account. Please try again.";
                    }
                }
                else
                {
                    lblErrors.Text = "That username already exists";
                }
            }
        }

        public bool is_ValidUsername(string username)
        {
            DataSet myDS = procedure.GetAllUsers();
            bool is_valid = false;

            for (int i=0; i<myDS.Tables[0].Rows.Count; i++)
            {
                if (username == myDS.Tables[0].Rows[i]["Username"].ToString())
                {
                    is_valid = false;
                }
                else
                {
                    is_valid = true;
                }
            }
            return is_valid;
        }
    }
}