using AITRSurveyApplicationWebForms.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;

namespace AITRSurveyApplicationWebForms.Utlities
{
    public class DbUtlities
    {
        public static String connectionString = ConfigurationManager.ConnectionStrings["DB_9AB8B7_D19DDA6422ConnectionString"].ConnectionString;
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
        public static void registerUser(string firstName, string lastName, string dob, string phoneNumber, string userName, string password)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = "INSERT into registered_respondents (First_Name, Last_Name, DOB, Phone_Number, username, password) values(@fName, @lName, @DOB, @Mobile, @UserName, @passWord)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@fName", firstName);
                    cmd.Parameters.AddWithValue("@lName", lastName);
                    cmd.Parameters.AddWithValue("@DOB", dob);
                    cmd.Parameters.AddWithValue("@Mobile", phoneNumber);
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@passWord", password);

                    cmd.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine("Connection fail: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static bool validateStaffLogin(string userName, string passWord)
        {
            bool isStaff = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) from users WHERE username ='" + userName + "' AND password ='" + passWord + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    int staffCount = (int)cmd.ExecuteScalar();
                    if (staffCount == 1) isStaff = true;
                    else isStaff = false;

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine("Staff not found: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return isStaff;
        }

        public static Registered validateUser(string userName, string passWord)
        {
            Registered isRegister = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT TOP 1 * FROM registered_respondents WHERE username ='" + userName + "' AND password = '" + passWord + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        isRegister = new Registered();
                        isRegister.Username = reader["username"].ToString();
                        isRegister.Password = reader["password"].ToString();
                        isRegister.First_Name = reader["First_Name"].ToString();
                        isRegister.RegisteredID = (int)reader["RespondentID"];

                    }

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine("Connection Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return isRegister;
        }
        public static bool checkUsername(string userName)
        {
            bool isUserTaken = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = "SELECT * from registered_respondents";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Store username
                        string isTaken = reader["username"].ToString();

                        // Checks if username is take
                        if (isTaken.Equals(userName))
                        {
                            isUserTaken = true;
                        }
                        else
                        {
                            isUserTaken = false;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine("Connection fail: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return isUserTaken;

        }

        // Store Respondent Detail
        public static void insertRespondent(DateTime Date, string Ip, int? registerID = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    if (registerID != null)
                    {
                        String sql = "INSERT into respondent (date, ip, reg_respondentID) values(@dateStamp, @ipAddress, @registerID)";
                        SqlCommand cmd = new SqlCommand(sql, conn);

                        cmd.Parameters.AddWithValue("@dateStamp", Date);
                        cmd.Parameters.AddWithValue("@ipAddress", Ip);
                        cmd.Parameters.AddWithValue("@registerID", registerID);

                        cmd.ExecuteNonQuery();


                    }
                    else
                    {
                        String sql = "INSERT into Respondent (date, ip) values(@dateStamp, @ipAddress)";
                        SqlCommand cmd = new SqlCommand(sql, conn);

                        cmd.Parameters.AddWithValue("@dateStamp", Date);
                        cmd.Parameters.AddWithValue("@ipAddress", Ip);

                        cmd.ExecuteNonQuery();
                    }
                }

                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine("Connection fail: " + ex.Message);
                }

                finally
                {
                    conn.Close();
                }
            }
        }
        // Get latest Respondent ID
        public static int getLatestRespondentID()
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    String sql = "SELECT MAX(id) from Respondent";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = (int)reader.GetValue(0);
                    }

                }

                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine("Connection fail: " + ex.Message);
                }

                finally
                {
                    conn.Close();
                }
                return id;
            }
        }


        // Get Respondent IP Address
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        // Get current Date
        public static DateTime GetCurrentDate()
        {
            DateTime date = DateTime.Now;
            return date.Date;

        }
        // Insert Answer
        public static void insertAnswers(int queID, int resID, string answer, int? QueOptId = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    String query = "INSERT INTO Answers (Answer,QuestionID,RespondentID,QuesOptID) VALUES (@answerText,@questionId,@respondentID,@optionId)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@questionId", queID);
                    cmd.Parameters.AddWithValue("@respondentID", resID);
                    cmd.Parameters.AddWithValue("@answerText", answer);
                    cmd.Parameters.AddWithValue("@optionId", QueOptId);



                    int result = cmd.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                    }

                }

                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine("Connection fail: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }
        }
    }
}