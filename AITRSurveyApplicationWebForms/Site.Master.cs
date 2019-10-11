using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITRSurveyApplicationWebForms
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(Session["adminisLoggedIn"] != null)
            {
                admin.Visible = true;
                login.Visible = false;
                register.Visible = false;
                Logout.Visible = true;
            }
            else if (Session["userisLoggedIn"] !=null)
            {
                admin.Visible = false;
                login.Visible = false;
                register.Visible = false;
                Logout.Visible = true;
            }
            else
            {
                Logout.Visible = false;
            }
            
            // Checks if username is logged in, if true assigns username else assign empty string
            string userName = Session["registeredName"] == null ? "" : Session["registeredName"].ToString();
            _ = userName == "" ? username.Text = "" : username.Text ="Welcome, " +userName;
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["userisLoggedIn"] = false;
            Session["adminisLoggedIn"] = false;
            Logout.Visible = false;
            // If admin/user is logged in, Log out
            if ((Response.Cookies["adminLogin"] != null))
            {
                
                FormsAuthentication.SignOut();
                Session.RemoveAll();
                FormsAuthentication.RedirectToLoginPage();
                HttpCookie myCookie = new HttpCookie("adminLogin");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);

                HttpCookie myCookie2 = new HttpCookie("userLogin");
                myCookie2.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie2);

            }
        }
    }

}