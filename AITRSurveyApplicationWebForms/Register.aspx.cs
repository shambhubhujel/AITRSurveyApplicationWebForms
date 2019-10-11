using AITRSurveyApplicationWebForms.Utlities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITRSurveyApplicationWebForms
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dobCalendar.Visible = false;

            }

        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            string userName = username.Text.ToString();
            string passWord = password.Text.ToString();
            string firstName = txtFirstName.Text.ToString();
            string lastName = txtLastName.Text.ToString();
            string DOB = txtDoB.Text.ToString();
            string mobile = txtContactNumber.Text.ToString();

            if (userName != null && passWord != null)
            {
                // Register user
                bool isUserTaken = DbUtlities.checkUsername(userName);
                // if username not used already, insert new user
                if (!isUserTaken)
                {
                    DbUtlities.registerUser(firstName, lastName, DOB, mobile, userName, passWord);
                    Response.Redirect("StaffLogin.aspx");

                }
                else
                {
                    userNameTaken.Text = "Username is already in use!!!";
                }
            }

        }

        protected void Skip_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void clndr_btn_Click(object sender, ImageClickEventArgs e)
        {
            _ = dobCalendar.Visible.Equals(false) ? dobCalendar.Visible = true : dobCalendar.Visible = false;
        }

        protected void dobCalendar_SelectionChanged(object sender, EventArgs e)
        {
            txtDoB.Text = dobCalendar.SelectedDate.ToShortDateString();
            dobCalendar.Visible = false;
        }
    }
}