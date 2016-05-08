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

        private WebUserControlEnvironmentsData data; // Keeps the data of the fields
        public WebUserControlEnvironmentsData Data
        {
            get { return data; }
        }

        public event EventHandler UserControlButtonRemoveClicked;
        public event EventHandler UserControlFieldChanged;

        #region Event Handlers

        private void OnUserControlButtonRemoveClick()
        {
            if (UserControlButtonRemoveClicked != null)
            {
                UserControlButtonRemoveClicked(this, EventArgs.Empty);
            }
        }

        private void OnUserControlFieldChanged()
        {
            if (UserControlFieldChanged != null)
            {
                EnvironmentDataEventArgs dataEventArgs = new EnvironmentDataEventArgs(data);
                UserControlFieldChanged(this, dataEventArgs);
            }
        }

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            utilities = new Utility();
            SaveData();
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

            SaveData();
            OnUserControlFieldChanged(); // Send the information to parent page

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
                en = new Environment();
                en.name = TextBoxEnvironmentName.Text;
                en.travel_cost_enter = Decimal.Parse(TextBoxEnvironmentCostEnter.Text);
                en.travel_cost_in = Decimal.Parse(TextBoxEnvironmentCostIn.Text);
                en.travel_cost_exit = Decimal.Parse(TextBoxEnvironmentCostExit.Text);
                en.damage = Decimal.Parse(TextBoxEnvironmentDamage.Text);
            }
        }

        public void ButtonRemove_Click(object sender, EventArgs e)
        {
            OnUserControlButtonRemoveClick(); // So the parent page will remove it from it`s lists....
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

        // If the text box field is changed -> keep the new data
        protected void TextBoxEnvironment_TextChanged(object sender, EventArgs e)
        {
            SaveData();
            OnUserControlFieldChanged(); // Updates the paren control for it`s data.
        }

        private void SaveData()
        {
            data = new WebUserControlEnvironmentsData();

            data.environmentsData.Add(TextBoxEnvironmentName.Text);
            data.environmentsData.Add(TextBoxEnvironmentCostEnter.Text);
            data.environmentsData.Add(TextBoxEnvironmentCostIn.Text);
            data.environmentsData.Add(TextBoxEnvironmentCostExit.Text);
            data.environmentsData.Add(TextBoxEnvironmentDamage.Text);

            data.environmentsData.Add(LabelEnvironmentNameError.Text);
            data.environmentsData.Add(LabelEnvironmentCostEnterError.Text);
            data.environmentsData.Add(LabelEnvironmentCostInError.Text);
            data.environmentsData.Add(LabelEnvironmentCostExitError.Text);
            data.environmentsData.Add(LabelEnvironmentDamageError.Text);
        }

        public void LoadData(WebUserControlEnvironmentsData other)
        {
            if (other.environmentsData.Count != 10)
                throw new Exception("Opppsss");

            TextBoxEnvironmentName.Text = other.environmentsData[0];
            TextBoxEnvironmentCostEnter.Text = other.environmentsData[1];
            TextBoxEnvironmentCostIn.Text = other.environmentsData[2];
            TextBoxEnvironmentCostExit.Text = other.environmentsData[3];
            TextBoxEnvironmentDamage.Text = other.environmentsData[4];

            LabelEnvironmentNameError.Text = other.environmentsData[5];
            LabelEnvironmentCostEnterError.Text = other.environmentsData[6];
            LabelEnvironmentCostInError.Text = other.environmentsData[7];
            LabelEnvironmentCostExitError.Text = other.environmentsData[8];
            LabelEnvironmentDamageError.Text = other.environmentsData[9];

            SaveData();
        }
    }
}