using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace xmlToSql
{
    public partial class WebUserControlEnvironments : System.Web.UI.UserControl
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

            if (!utilities.checkLenghtLessEqualThan(TextBoxEnvironmentName.Text, 32, ref output))
            {
                LabelEnvironmentNameError.Text = output;
                result = false;
            }
            else
                LabelEnvironmentNameError.Text = "";

            if (!utilities.checkDecimalValidAndRange(TextBoxEnvironmentCostEnter.Text, ref output, Decimal.MaxValue))
            {
                LabelEnvironmentCostEnterError.Text = output;
                result = false;
            }
            else
                LabelEnvironmentCostEnterError.Text = "";

            if (!utilities.checkDecimalValidAndRange(TextBoxEnvironmentCostIn.Text, ref output, Decimal.MaxValue))
            {
                LabelEnvironmentCostInError.Text = output;
                result = false;
            }
            else
                LabelEnvironmentCostInError.Text = "";

            if (!utilities.checkDecimalValidAndRange(TextBoxEnvironmentCostExit.Text, ref output, Decimal.MaxValue))
            {
                LabelEnvironmentCostExitError.Text = output;
                result = false;
            }
            else
                LabelEnvironmentCostExitError.Text = "";

            if (!utilities.checkDecimalValidAndRange(TextBoxEnvironmentDamage.Text, ref output, Decimal.MaxValue))
            {
                LabelEnvironmentDamageError.Text = output;
                result = false;
            }
            else
                LabelEnvironmentDamageError.Text = "";

            return result;
        }

        // Checks if the fields are valid and writes them to the given environment @en
        // If the fields are wrong-> sets the error messages and makes the @en NULL
        public void WriteToEnvironment(ref Environment en)
        {
            if (!Validate())
            {
                en = null;
            }
            else
            {
                en.name = TextBoxEnvironmentName.Text;
                en.travel_cost_enter = Decimal.Parse(TextBoxEnvironmentCostEnter.Text);
                en.travel_cost_in = Decimal.Parse(TextBoxEnvironmentCostIn.Text);
                en.travel_cost_exit = Decimal.Parse(TextBoxEnvironmentCostExit.Text);
                en.damage = Decimal.Parse(TextBoxEnvironmentDamage.Text);
            }
        }

        public void ButtonRemove_Click(object sender, EventArgs e)
        {
            OnUserControlButtonClick(); // So the parent page will remove it from it`s lists....
        }
        
        public void setValues(WebUserControlEnvironments other)
        {
            TextBoxEnvironmentName.Text = other.TextBoxEnvironmentName.Text;
            TextBoxEnvironmentCostEnter.Text = other.TextBoxEnvironmentCostEnter.Text;
            TextBoxEnvironmentCostIn.Text = other.TextBoxEnvironmentCostIn.Text;
            TextBoxEnvironmentCostExit.Text = other.TextBoxEnvironmentCostExit.Text;
            TextBoxEnvironmentDamage.Text = other.TextBoxEnvironmentDamage.Text;

            LabelEnvironmentNameError.Text = other.LabelEnvironmentNameError.Text;
            LabelEnvironmentCostEnterError.Text = other.LabelEnvironmentCostEnterError.Text;
            LabelEnvironmentCostInError.Text = other.LabelEnvironmentCostInError.Text;
            LabelEnvironmentCostExitError.Text = other.LabelEnvironmentCostExitError.Text;
            LabelEnvironmentDamageError.Text = other.LabelEnvironmentDamageError.Text;
        }

        // Clears the fields data.

        public void ButtonClearData_Click(object sender, EventArgs e)
        {
            TextBoxEnvironmentName.Text = "";
            TextBoxEnvironmentCostEnter.Text = "";
            TextBoxEnvironmentCostIn.Text = "";
            TextBoxEnvironmentCostExit.Text = "";
            TextBoxEnvironmentDamage.Text = "";

            LabelEnvironmentNameError.Text = "";
            LabelEnvironmentCostEnterError.Text = "";
            LabelEnvironmentCostInError.Text = "";
            LabelEnvironmentCostExitError.Text = "";
            LabelEnvironmentDamageError.Text = "";
        }
    }
}