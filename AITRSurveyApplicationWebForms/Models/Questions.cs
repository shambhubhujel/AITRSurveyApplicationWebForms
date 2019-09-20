using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITRSurveyApplicationWebForms.Models
{
    public class Questions
    {
        public int QuestionID { get; set; }
        public string Contents { get; set; }
        public string QuesType { get; set; }
        public int? NextQueID { get; set; }
    }
}