using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Configuration;

namespace AITRSurveyApplicationWebForms
{
    public partial class SurveySearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_ShowAll_Click(object sender, EventArgs e)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DB_9AB8B7_D19DDA6422ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT  (CASE WHEN respondent.reg_respondentID IS NULL THEN 'Anonymous' ELSE registered_respondents.First_Name end) 'Respondent',q1.Contents 'Question', Answer 'Answer' from answers left join Questions q1 ON(answers.QuestionID = q1.QuestionID ) left join respondent ON(answers.RespondentID = respondent.id) left join registered_respondents ON(respondent.reg_respondentID = registered_respondents .RespondentID )";
                    cmd.Connection = con;

                    con.Open();
                    gvSearchResults.DataSource = cmd.ExecuteReader();
                    gvSearchResults.DataBind();
                    con.Close();
                }
            }
        }

        protected void btnSearchSurvey_Click(object sender, EventArgs e)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DB_9AB8B7_D19DDA6422ConnectionString"].ConnectionString;
            bool isGenderSelected, isStateSelected, isBankSelected;
            isGenderSelected = isStateSelected = isBankSelected = false;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT  (CASE WHEN respondent.reg_respondentID IS NULL THEN 'Anonymous' ELSE registered_respondents.First_Name end) 'Respondent',q1.Contents 'Question', Answer 'Answer' from answers left join Questions q1 ON(answers.QuestionID = q1.QuestionID ) left join respondent ON(answers.RespondentID = respondent.id) left join registered_respondents ON(respondent.reg_respondentID = registered_respondents .RespondentID )";
                    // Checks which value in the drop down list was selected
                    if (ddlGender.SelectedValue.ToString() != "")
                    {
                        // cmd.Parameter prevents sql injection
                        cmd.CommandText += "WHERE Answer= @gender";
                        cmd.Parameters.AddWithValue("@gender", ddlGender.SelectedValue.ToString());
                        isGenderSelected = true;
                    }
                    if (ddlState.SelectedValue.ToString() != "")
                    {

                        cmd.CommandText += isGenderSelected ? " OR Answer = @state " : " WHERE Answer = @state";
                        cmd.Parameters.AddWithValue("@state", ddlState.SelectedValue.ToString());
                        isStateSelected = true;
                    }
                    if (ddlBank.SelectedValue.ToString() != "")
                    {
                        if (isGenderSelected || isStateSelected)
                        {
                            cmd.CommandText += " OR Answer = @bank";
                        }
                        else
                        {
                            cmd.CommandText += " WHERE Answer = @bank";
                        }

                        cmd.Parameters.AddWithValue("@bank", ddlBank.SelectedValue.ToString());
                        isBankSelected = true;
                    }
                    if (ddlBankService.SelectedValue.ToString() != "")
                    {
                        if (isGenderSelected || isStateSelected || isBankSelected)
                        {
                            cmd.CommandText += " OR Answer = @service";
                        }
                        else
                        {
                            cmd.CommandText += " WHERE Answer = @service";
                        }
                        cmd.Parameters.AddWithValue("@service", ddlBankService.SelectedValue.ToString());
                    }

                    cmd.Connection = con;
                    con.Open();
                    gvSearchResults.DataSource = cmd.ExecuteReader();
                    gvSearchResults.DataBind();
                    con.Close();
                }
            }
        }
    }
}
