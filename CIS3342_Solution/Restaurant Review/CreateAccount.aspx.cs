using System;
using System.Collections.Generic;
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

                int success = procedure.AddUser(newUser.RealName, newUser.UserName, newUser.UserType);

                if(!(success == -1))
                {

                }
            }
        }
    }
}