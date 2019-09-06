using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITRSurveyApplicationWebForms.UserControls
{
    public partial class RadioUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
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

        public RadioButtonList QuestionRadioButtonList
        {
            get
            {
                return questionRadioButtonList;
            }
            set
            {
                questionRadioButtonList = value;
            }
        }
    }
}