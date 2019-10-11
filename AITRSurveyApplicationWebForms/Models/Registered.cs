using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITRSurveyApplicationWebForms.Models
{
    public class Registered
    {
        public int RegisteredID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        public string First_Name  { get; set; }
    }
}