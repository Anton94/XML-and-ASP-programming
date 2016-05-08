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

        private WebUserControlMapsData data; // Keeps the data of the fields
        public WebUserControlMapsData Data
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
                MapDataEventArgs dataEventArgs = new MapDataEventArgs(data);
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

            SaveData();
            OnUserControlFieldChanged(); // Send the information to parent page

            return result;
        }

        // Checks if the fields are valid and writes them to the given map @m
        // If the fields are wrong-> sets the error messages and makes the @m NULL
        public void WriteToMap(ref Map m)
        {
            if (!Validate())
            {
                m = null;
            }
            else
            {
                m = new Map();
                m.map_name = TextBoxMapName.Text;
                m.map_data = TextBoxMapMapData.Text;
                m.denivelation = Decimal.Parse(TextBoxMapDenivelation.Text);
            }
        }

        public void ButtonRemove_Click(object sender, EventArgs e)
        {
            OnUserControlButtonRemoveClick(); // So the parent page will remove it from it`s lists....
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

        // If the text box field is changed -> keep the new data
        protected void TextBoxMap_TextChanged(object sender, EventArgs e)
        {
            SaveData();
            OnUserControlFieldChanged(); // Updates the paren control for it`s data.
        }

        private void SaveData()
        {
            data = new WebUserControlMapsData();

            data.mapsData.Add(TextBoxMapName.Text);
            data.mapsData.Add(TextBoxMapMapData.Text);
            data.mapsData.Add(TextBoxMapDenivelation.Text);

            data.mapsData.Add(LabelMapNameError.Text);
            data.mapsData.Add(LabelMapMapDataError.Text);
            data.mapsData.Add(LabelMapDenivelationError.Text);
        }

        public void LoadData(WebUserControlMapsData other)
        {
            if (other.mapsData.Count != 6) // Number of text boxes and label error fields 
                throw new Exception("Opppsss");

            TextBoxMapName.Text = other.mapsData[0];
            TextBoxMapMapData.Text = other.mapsData[1];
            TextBoxMapDenivelation.Text = other.mapsData[2];

            LabelMapNameError.Text = other.mapsData[3];
            LabelMapMapDataError.Text = other.mapsData[4];
            LabelMapDenivelationError.Text = other.mapsData[5];

            SaveData();
        }
    }
}