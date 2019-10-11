using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITRSurveyApplicationWebForms.Models
{
    public class Respondents
    {
        public int RespondentID { get; set; }

        public DateTime DateStamp { get; set; }

        public string IPAddress { get; set; }

        public int? RegisteredID { get; set; }
    }
}