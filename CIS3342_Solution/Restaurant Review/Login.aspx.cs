﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace Restaurant_Review
{
    public partial class Login : System.Web.UI.Page
    {
        public DataSet myDS;
        public DBProcedures procedures = new DBProcedures();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Clicked(object sender, EventArgs e)
        {
            myDS = procedures.GetUsername();

            // Get selected usertype on login
            string username = username_input.Text;
            string selectedType = get_usertype();

            // Look for username and match type
            validate_username(myDS, username, selectedType);
        }

        protected void btnCreateAccount_Clicked(object sender, EventArgs e)
        {

        }

        public string get_usertype()
        {
            string selectedType = "";

            if (rbtn_usertypeRepresentative.Checked || rbtn_usertypeReviewer.Checked)
            {
                if (rbtn_usertypeReviewer.Checked)
                {
                    selectedType = rbtn_usertypeReviewer.Text;
                }
                else
                {
                    selectedType = rbtn_usertypeRepresentative.Text;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('Make sure a usertype is selected')", true);
            }

            return selectedType;
        }

        public void validate_username(DataSet myDS, string username, string selectedType)
        {

            for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
            { 
                if (username == myDS.Tables[0].Rows[i]["Username"].ToString())
                {
                    if (selectedType == myDS.Tables[0].Rows[i]["Type"].ToString())
                    {
                        Session.Add("Username", username);
                        Session.Add("Usertype", selectedType);
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        lblErrors.Text = "The user you submitted does not match the selected user type";
                    }
                }
                else
                {
                    lblErrors.Text = "There are no users with username: " + username;
                }
            }
        }
    }
}