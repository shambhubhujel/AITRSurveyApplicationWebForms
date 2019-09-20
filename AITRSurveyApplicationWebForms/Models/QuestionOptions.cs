using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITRSurveyApplicationWebForms.Models
{
    public class QuestionOptions
    {
        public int QueOptId { get; set; }
        public string QuesOption { get; set; }
        public int QuestionId { get; set; }
        public int? NextQueID { get; set; }
    }
}