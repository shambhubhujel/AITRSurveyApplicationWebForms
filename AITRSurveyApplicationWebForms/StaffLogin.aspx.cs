using AITRSurveyApplicationWebForms.Models;
using AITRSurveyApplicationWebForms.Utlities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITRSurveyApplicationWebForms
{
    public partial class StaffLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogIn_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string passWord = txtPassword.Text;
            Registered validateUser = DbUtlities.validateUser(userName, passWord);

            if (DbUtlities.validateStaffLogin(userName, passWord))
            {
                FormsAuthentication.RedirectFromLoginPage(userName, false);
                Response.Cookies["adminLogin"].Value = "Admin Logged in";
                Session["registeredName"] = userName;
                Session["adminisLoggedIn"] = true;

            }
            else if (validateUser != null)
            {
                FormsAuthentication.RedirectFromLoginPage(userName, false);
                Response.Cookies["userLogin"].Value = "User Logged in";
                //Session["registeredUser"] = validateUser.Username;
                Session["registeredName"] = validateUser.Username;
                Session["RegisteredID"] = validateUser.RegisteredID;
                Session["userisLoggedIn"] = true;
                Response.Redirect("Default.aspx");
            }
            else
            {
                Msg.Text = "Invalid User";
            }
        }
        
    }
}