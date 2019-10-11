using AITRSurveyApplicationWebForms.Models;
using AITRSurveyApplicationWebForms.Utlities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITRSurveyApplicationWebForms
{
    public partial class EndofSurvey : System.Web.UI.Page
    {
        public string RespondentIP;
        public DateTime currentDate;
        public int RegisteredID = 0;

        public int RespondentID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            RespondentIP = DbUtlities.GetLocalIPAddress();
            currentDate = DbUtlities.GetCurrentDate();
            
            
            // Reading answers from session
            List<Answers> questionAnswersInSession = (List<Answers>)Session["Question_ANSWER_LIST"];
            foreach (Answers answer in questionAnswersInSession)
            {


                TableRow row = new TableRow();
                // Question id cell goes from here ------
                TableCell questionIdCell = new TableCell();
                // Setting question id of the answer to table cell
                questionIdCell.Text = answer.QuestionId.ToString();
                row.Cells.Add(questionIdCell);

                // Question answer text cell goes from here-------------
                TableCell answerTextCell = new TableCell();
                answerTextCell.Text = answer.Answer;
                row.Cells.Add(answerTextCell);

                // OptionId cell goes from here 
                TableCell optionIdCell = new TableCell();
                if (answer.QueOptId != null)
                {
                    optionIdCell.Text = answer.QueOptId.ToString();

                }
                else
                {
                    optionIdCell.Text = "";
                }

                row.Cells.Add(optionIdCell);


                questionAnswerDisplayTable.Rows.Add(row);

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Checks if registered id Session is set
            if (Session["RegisteredID"] != null)
            {
                RegisteredID = (int)Session["RegisteredID"];
            }
            // Reading answers from session
                List<Answers> questionAnswersInSession = (List<Answers>)Session["Question_ANSWER_LIST"];
                //Checks if user is registered
                if (RegisteredID > 0) // If registered
                {
                    DbUtlities.insertRespondent(currentDate, RespondentIP, RegisteredID);
                    RespondentID = DbUtlities.getLatestRespondentID();
                }
                else
                {
                    // Insert Latest respondent ip and date
                    DbUtlities.insertRespondent(currentDate, RespondentIP);

                    //Gets latest respondent ID
                    RespondentID = DbUtlities.getLatestRespondentID();

                }
                foreach (Answers answer in questionAnswersInSession)
                {
                    // Stores each answers to db
                    DbUtlities.insertAnswers(answer.QuestionId, RespondentID, answer.Answer, answer.QueOptId);
                }
                Response.Redirect("RespondentAnswers.aspx");

        }
    }

}