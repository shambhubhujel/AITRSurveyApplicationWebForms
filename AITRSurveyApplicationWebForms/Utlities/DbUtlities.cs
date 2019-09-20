using AITRSurveyApplicationWebForms.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AITRSurveyApplicationWebForms.Utlities
{
    public class DbUtlities
    {
        public static Questions getQuestion(int QuestionId)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["DB_9AB8B7_D19DDA6422ConnectionString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);
            //conn.ConnectionString = "Data Source=SQL5017.site4now.net;Initial Catalog=DB_9AB8B7_D19DDA6422;Persist Security Info=True;User ID=DB_9AB8B7_D19DDA6422_admin;Password=hga6jJJZ";

            SqlCommand cmd = new SqlCommand("SELECT * from questions where QuestionID =" + QuestionId, conn);
            conn.Open();
            //cmd.Parameters.AddWithValue("QuestionID", +QuestionId );
            SqlDataReader cmdReader = cmd.ExecuteReader();
            if (cmdReader.Read())
            {
                Questions question = new Questions();
                question.QuestionID = (int)cmdReader["QuestionID"];
                question.Contents = cmdReader["Contents"].ToString();
                question.QuesType = cmdReader["QuesType"].ToString();
                question.NextQueID = cmdReader["NextQueID"] as int?;

                return question;

            }
            conn.Close();

            return null;

        }
        public static List<QuestionOptions> getQuestionOptions(int QuestionId)
        {

            List<QuestionOptions> questionOptions = new List<QuestionOptions>();
            string connectionString = ConfigurationManager.ConnectionStrings["DB_9AB8B7_D19DDA6422ConnectionString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);
            //conn.ConnectionString = "Data Source=SQL5017.site4now.net;Initial Catalog=DB_9AB8B7_D19DDA6422;Persist Security Info=True;User ID=DB_9AB8B7_D19DDA6422_admin;Password=hga6jJJZ";

            SqlCommand cmd = new SqlCommand("SELECT * from questionoptions where QuestionId =" + QuestionId, conn);
            conn.Open();
            //cmd.Parameters.AddWithValue("QuestionID", +QuestionId );
            SqlDataReader cmdReader = cmd.ExecuteReader();
            while (cmdReader.Read())
            {
                QuestionOptions options = new QuestionOptions();
                options.QueOptId = (int)cmdReader["QueOptId"];
                options.QuesOption = cmdReader["QuesOption"].ToString();
                options.QuestionId = (int)cmdReader["QuestionId"];
                options.NextQueID = cmdReader["NextQueID"] as int?;
                questionOptions.Add(options);
            }
            conn.Close();
            return questionOptions;
            

        }
    }
}