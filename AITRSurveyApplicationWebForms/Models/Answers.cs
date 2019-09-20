using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITRSurveyApplicationWebForms.Models
{
    public class Answers
    {
        public int AnswerId { get; set; }

        public string Answer { get; set; }
        public int? QueOptId { get; set; }
        public int QuestionId { get; set; }
        public int RespondantId { get; set; }
    }
}