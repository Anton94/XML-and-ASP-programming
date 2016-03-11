using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace xmlToSql
{
    public partial class WebUserControlMaps : System.Web.UI.UserControl
    {
        private Utility utilities;

        public event EventHandler UserControlButtonClicked;

        public bool EventHandlerSeted()
        {
            return UserControlButtonClicked != null;
        }
        
        private void OnUserControlButtonClick()
        {
            if (EventHandlerSeted())
            {
                UserControlButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (utilities == null)
                utilities = new Utility();
        }

        public bool Validate()
        {
            string output = "";

            bool result = true;

            if (!utilities.checkLenghtLessEqualThan(TextBoxMapName.Text, 64, ref output))
            {
                LabelMapNameError.Text = output;
                result = false;
            }
            else
                LabelMapNameError.Text = "";

            if (!utilities.checkLenghtLessEqualThan(TextBoxMapMapData.Text, 64, ref output))
            {
                LabelMapMapDataError.Text = output;
                result = false;
            }
            else
                LabelMapMapDataError.Text = "";


            if (!utilities.checkDecimalValid(TextBoxMapDenivelation.Text, ref output))
            {
                LabelMapDenivelationError.Text = output;
                result = false;
            }
            else
                LabelMapDenivelationError.Text = "";


            return result;
        }

        // Checks if the fields are valid and writes them to the given environment @en
        // If the fields are wrong-> sets the error messages and makes the @en NULL
        public void WriteToMap(ref Map m)
        {
            if (!Validate())
            {
                m = null;
            }
            else
            {
                m.map_name = TextBoxMapName.Text;
                m.map_data = TextBoxMapMapData.Text;
                m.denivelation = Decimal.Parse(TextBoxMapDenivelation.Text);
            }
        }

        public void ButtonRemove_Click(object sender, EventArgs e)
        {
            OnUserControlButtonClick(); // So the parent page will remove it from it`s lists....
        }

        // Clears the fields data.

        public void ButtonClearData_Click(object sender, EventArgs e)
        {
            TextBoxMapName.Text = "";
            TextBoxMapMapData.Text = "";
            TextBoxMapDenivelation.Text = "";

            LabelMapNameError.Text = "";
            LabelMapMapDataError.Text = "";
            LabelMapDenivelationError.Text = "";
        }
    }
}