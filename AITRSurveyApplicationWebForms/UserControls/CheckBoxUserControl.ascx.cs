﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITRSurveyApplicationWebForms.UserControls
{
    public partial class CheckBoxUserControl : System.Web.UI.UserControl
    {
        public Label QuestionLabel
        {
            get
            {
                return questionLabel;
            }
            set
            {
                questionLabel = value;
            }
        }

        public CheckBoxList QuestionCheckBoxList
        {
            get
            {
                return questionCheckBoxList;
            }
            set
            {
                questionCheckBoxList = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}