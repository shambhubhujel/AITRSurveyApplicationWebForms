using AITRSurveyApplicationWebForms.Models;
using AITRSurveyApplicationWebForms.UserControls;
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
    public partial class SurveyPage : System.Web.UI.Page
    {
        //set up db connection
        public static string connectionString = ConfigurationManager.ConnectionStrings["DB_9AB8B7_D19DDA6422ConnectionString"].ConnectionString;

        SqlConnection conn = new SqlConnection(connectionString);
        public static SortedSet<int> followupTracker = new SortedSet<int>();
        public static int QuestionID;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
            Object userAnswer = Session["UserAnswer"];
            if (userAnswer != null)
            {
                Label1.Text = Session["UserAnswer"].ToString();
            }
            //Get Respondent IP here
            //Get Current Date here
            Stack<int> nextQuesID = (Stack<int>)Session["nextQueID"];
            if (nextQuesID == null)
            {
                nextQuesID = new Stack<int>();
                nextQuesID.Push(1);
                followupTracker.Add(1);
                Session["nextQueID"] = nextQuesID;
            }
            if (nextQuesID.Count() > 0)
            {
                QuestionID = nextQuesID.Peek();
            }
            Questions question = DbUtlities.getQuestion(QuestionID);

           
            
            //conn.ConnectionString = "Data Source=SQL5017.site4now.net;Initial Catalog=DB_9AB8B7_D19DDA6422;Persist Security Info=True;User ID=DB_9AB8B7_D19DDA6422_admin;Password=hga6jJJZ";

            //SqlCommand cmd = new SqlCommand("SELECT * from questions where QuestionID =" + QuestionId, conn);
            conn.Open();
            if (question != null)
            {
                string questionText = question.Contents.ToString();
                string questionType = question.QuesType.ToString().ToLower(); //just incase, so we dont have to check for textBox vs TextBox vs textbox
                if ("text".Equals(questionType))
                {
                    //TODO load up textbox controls
                    TextBoxUserControl textControl = (TextBoxUserControl)LoadControl("~/UserControls/TextBoxUserControl.ascx");
                    textControl.ID ="ansTextbox";
                    textControl.QuestionLabel.Text = questionText;

                    //add it to the ui
                    PlaceHolder1.Controls.Add(textControl);
                    Session["CURRENT_QUESTION_TYPE"] = textControl.ID;
                }
                else if ("checkbox".Equals(questionType))
                {
                    //TODO load up checkbox controls
                    CheckBoxUserControl checkBoxControl = (CheckBoxUserControl)LoadControl("~/UserControls/CheckBoxUserControl.ascx");
                    checkBoxControl.ID = "ansCheckbox";
                    checkBoxControl.QuestionLabel.Text = questionText;
                    Session["CURRENT_QUESTION_TYPE"] = checkBoxControl.ID;
                    //TODO load up checkbox options/choices to add to checkbox control
                    List<QuestionOptions> questionOptions = DbUtlities.getQuestionOptions(QuestionID);
                    foreach (QuestionOptions option in questionOptions)
                    {
                        ListItem newItem = new ListItem();
                        newItem.Value = option.QueOptId.ToString();
                        newItem.Text = option.QuesOption;
                        if (option.NextQueID != null)
                        {
                            newItem.Attributes["nextQuestionId"] = option.NextQueID.ToString();
                        }
                        checkBoxControl.QuestionCheckBoxList.Items.Add(newItem);
                    }

                    //done, add it to placeholder
                    PlaceHolder1.Controls.Add(checkBoxControl);

                }
                else if ("radio".Equals(questionType))
                {
                    //TODO load up checkbox controls
                    RadioUserControl radioButtonControl = (RadioUserControl)LoadControl("~/UserControls/RadioUserControl.ascx");
                    radioButtonControl.ID = "ansRadioButton";
                    radioButtonControl.QuestionLabel.Text = questionText;
                    Session["CURRENT_QUESTION_TYPE"] = radioButtonControl.ID;
                    //TODO load up radio list  options/choices to add to checkbox control
                    List<QuestionOptions> questionOptions = DbUtlities.getQuestionOptions(QuestionID);

                    foreach (QuestionOptions option in questionOptions)
                    {
                        ListItem newItem = new ListItem();
                        newItem.Text = option.QuesOption;
                        newItem.Value = option.QueOptId.ToString();
                        radioButtonControl.QuestionRadioButtonList.Items.Add(newItem); //add item to option list
                    }

                    //done, add it to placeholder
                    PlaceHolder1.Controls.Add(radioButtonControl);

                }
            }

            conn.Close();
            
        }

        protected void btnSkip_Click(object sender, EventArgs e)
        {
            // Accesss the current question from PlaceHolder
            Control userControl = PlaceHolder1.FindControl(Session["CURRENT_QUESTION_TYPE"].ToString());

            // Access question answers from session
            List<Answers> questionAnswersInSession = (List<Answers>)Session["Question_ANSWER_LIST"];
            if (questionAnswersInSession == null)
            {
                // Null means this is the first question so create new question answer list
                questionAnswersInSession = new List<Answers>();
                Session["Question_ANSWER_LIST"] = questionAnswersInSession;
            }

            Stack<int> followUpQuestionList = (Stack<int>)Session["nextQueID"];

            int QuestionID = followUpQuestionList.Pop();
            Questions question = DbUtlities.getQuestion(QuestionID);
            if (question.NextQueID != null)
            {
                //followUpQuestionList.Push((int)question.nextQuestionId);
                insertNextQuestionId((int)question.NextQueID, followUpQuestionList);
            }
            Session["UserAnswer"] = "";

            if (followUpQuestionList.Count() > 0)
            {
                //Session["CURRENT_QUESTION_ID"] = question.nextQuestionId;
                Response.Redirect("SurveyPage.aspx");
            }
            else
            {
                Response.Redirect("EndofSurvey.aspx");
            }

        }

        protected void btnNextQue_Click(object sender, EventArgs e)
        {
            // Accesss the current question from PlaceHolder
            Control userControl = PlaceHolder1.FindControl(Session["CURRENT_QUESTION_TYPE"].ToString());

            // Access question answers from session
            List<Answers> questionAnswersInSession = (List<Answers>)Session["Question_ANSWER_LIST"];
            if (questionAnswersInSession == null)
            {
                // Null means this is the first question so create new question answer list
                questionAnswersInSession = new List<Answers>();
                Session["Question_ANSWER_LIST"] = questionAnswersInSession;
            }

            Stack<int> followUpQuestionList = (Stack<int>)Session["nextQueID"];

            int QuestionID = followUpQuestionList.Pop();
            Questions question = DbUtlities.getQuestion(QuestionID);
            if (question.NextQueID != null)
            {
                //followUpQuestionList.Push((int)question.nextQuestionId);
                insertNextQuestionId((int)question.NextQueID, followUpQuestionList);
            }

            if (userControl is TextBoxUserControl)
            {


                TextBoxUserControl textBoxcontr = (TextBoxUserControl)userControl;
                //Label1.Text = textBoxcontr.getControl().Text;
                Session["UserAnswer"] = textBoxcontr.QuestionTextBox.Text;
                System.Diagnostics.Debug.WriteLine("Answer = " + textBoxcontr.QuestionTextBox.Text);

                Answers answer = new Answers();
                answer.Answer = textBoxcontr.QuestionTextBox.Text;
                answer.QuestionId = QuestionID;

                questionAnswersInSession.Add(answer);

            }
            else if (userControl is CheckBoxUserControl)
            {
                CheckBoxUserControl checkBoxcontr = (CheckBoxUserControl)userControl;
                string answerVar = "";
                foreach (ListItem item in checkBoxcontr.QuestionCheckBoxList.Items)
                {
                    if (item.Selected)
                    {
                        answerVar += item.Text + ",";

                        if (item.Attributes["nextQuestionId"] != null)
                        {
                            //followUpQuestionList.Push(int.Parse(item.Attributes["nextQuestionId"]));
                            insertNextQuestionId(int.Parse(item.Attributes["nextQuestionId"]), followUpQuestionList);
                        }

                        Answers answer = new Answers();
                        answer.Answer = item.Text;
                        answer.QuestionId = QuestionID;
                        answer.QueOptId = int.Parse(item.Value);

                        questionAnswersInSession.Add(answer);
                    }
                }

                Session["UserAnswer"] = answerVar;
            }
            else
            {
                // Radio button
                RadioUserControl radioUserControl = (RadioUserControl)userControl;
                string answerVar = "";
                foreach (ListItem item in radioUserControl.QuestionRadioButtonList.Items)
                {
                    if (item.Selected)
                    {
                        answerVar += item.Text;

                        if (item.Attributes["nextQuestionId"] != null)
                        {
                            //followUpQuestionList.Push(int.Parse(item.Attributes["nextQuestionId"]));
                            insertNextQuestionId(int.Parse(item.Attributes["nextQuestionId"]), followUpQuestionList);
                        }

                        Answers answer = new Answers();
                        answer.Answer = item.Text;
                        answer.QuestionId = QuestionID;
                        answer.QueOptId =int.Parse(item.Value);

                        questionAnswersInSession.Add(answer);
                    }
                }

                Session["UserAnswer"] = answerVar;
            }



            // 1. Identify which type of question is current question
            // 2. Access that question to get answer out from it
            // Label1.Text = "Test label";

            if (followUpQuestionList.Count() > 0)
            {
                //Session["CURRENT_QUESTION_ID"] = question.nextQuestionId;
                Response.Redirect("SurveyPage.aspx");
            }
            else
            {
                Response.Redirect("EndofSurvey.aspx");
            }


        }
        private void insertNextQuestionId(int nextQuestionId, Stack<int> followupList)
        {
            if (!followupList.Contains(nextQuestionId))
            {
                followupList.Push(nextQuestionId);
            }
        }
    }
}