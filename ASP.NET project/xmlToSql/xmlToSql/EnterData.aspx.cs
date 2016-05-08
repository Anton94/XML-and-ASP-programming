using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/*
 * 
 * IMPORTANT
 * Every action(postback) will reload everything again, so static or view state to keep the information!
 * ViewState can`t save Controls -> serializable problem
 * IDs for every dynamicly added control -> otherwise problem with twise asking user control buttons and such
 * Event -> every postback had to add event handdles again (and controls)
 * Make new user controls and set data or keep the user controls and bind the events for their buttons again
 * Sometimes you will have to restart the SQL server (from SQL managment program... for example..)
 * ViewState is loaded after Page_init->so I can`t use it there
 */

namespace xmlToSql
{
   
    public partial class EnterData : System.Web.UI.Page
    {
        private Utility utilities;

        #region Data holders for user controls

        // Environments data
        public List<WebUserControlEnvironmentsData> EnvironmentsData
        {
            get { return (List<WebUserControlEnvironmentsData>)ViewState["EnvironmentsData"]; }
            set { ViewState["EnvironmentsData"] = value; }
        }

        // Robots data
        public List<WebUserControlRobotsData> RobotsData
        {
            get { return (List<WebUserControlRobotsData>)ViewState["RobotsData"]; }
            set { ViewState["RobotsData"] = value; }
        }

        // Maps data
        public List<WebUserControlMapsData> MapsData
        {
            get { return (List<WebUserControlMapsData>)ViewState["MapsData"]; }
            set { ViewState["MapsData"] = value; }
        }

        // Algorithms data
        public List<WebUserControlAlgorithmsData> AlgorithmsData
        {
            get { return (List<WebUserControlAlgorithmsData>)ViewState["AlgorithmsData"]; }
            set { ViewState["AlgorithmsData"] = value; }
        }

        #endregion

        #region Page Load (every postback load the data to the user controls)
        // Page_Load, because ViewState in Page_Init is not done yet.

        private void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;

            List<WebUserControlEnvironmentsData> enData = EnvironmentsData;
            if (enData != null)
            {
                LoadEnvironmentsControls();
                LoadEnvironmentsEvents();
            }
            else
            {
                enData = new List<WebUserControlEnvironmentsData>();
                EnvironmentsData = enData;
            }

            List<WebUserControlRobotsData> rData = RobotsData;
            if (rData != null)
            {
                LoadRobotsControls();
                LoadRobotsEvents();
            }
            else
            {
                rData = new List<WebUserControlRobotsData>();
                RobotsData = rData;
            }

            List<WebUserControlMapsData> mData = MapsData;
            if (mData != null)
            {
                LoadMapsControls();
                LoadMapsEvents();
            }
            else
            {
                mData = new List<WebUserControlMapsData>();
                MapsData = mData;
            }

            List<WebUserControlAlgorithmsData> aData = AlgorithmsData;
            if (aData != null)
            {
                LoadAlgorithmsControls();
                LoadAlgorithmsEvents();
            }
            else
            {
                aData = new List<WebUserControlAlgorithmsData>();
                AlgorithmsData = aData;
            }

            utilities = new Utility();
        }

        #endregion

        #region Event handlers from web user controls

        public void Environment_UserControlButtonRemoveClicked(object sender, EventArgs e)
        {
            // TO DO cast..
            WebUserControlEnvironments toDel = (WebUserControlEnvironments)sender;
           
            if (toDel != null)
            {
                // Find the index of the control
                int indexToDel = PlaceHolderEnvironments.Controls.IndexOf(toDel);
                if (indexToDel >= 0)
                {
                    List<WebUserControlEnvironmentsData> enData = EnvironmentsData; // Get it out of the viewstate
                    enData.RemoveAt(indexToDel);
                    EnvironmentsData = enData; 

                    LoadEnvironmentsControls();
                    LoadEnvironmentsEvents();
                }
            }
        }

        public void Robot_UserControlButtonRemoveClicked(object sender, EventArgs e)
        {
            // TO DO cast..
            WebUserControlRobots toDel = (WebUserControlRobots)sender;

            if (toDel != null)
            {
                // Find the index of the control
                int indexToDel = PlaceHolderRobots.Controls.IndexOf(toDel);
                if (indexToDel >= 0)
                {
                    List<WebUserControlRobotsData> rData = RobotsData; // Get it out of the viewstate
                    rData.RemoveAt(indexToDel);
                    RobotsData = rData;

                    LoadRobotsControls();
                    LoadRobotsEvents();
                }
            }
        }

        public void Map_UserControlButtonRemoveClicked(object sender, EventArgs e)
        {
            // TO DO cast..
            WebUserControlMaps toDel = (WebUserControlMaps)sender;

            if (toDel != null)
            {
                // Find the index of the control
                int indexToDel = PlaceHolderMaps.Controls.IndexOf(toDel);
                if (indexToDel >= 0)
                {
                    List<WebUserControlMapsData> mData = MapsData; // Get it out of the viewstate
                    mData.RemoveAt(indexToDel);
                    MapsData = mData;

                    LoadMapsControls();
                    LoadMapsEvents();
                }
            }
        }

        public void Algorithm_UserControlButtonRemoveClicked(object sender, EventArgs e)
        {
            // TO DO cast..
            WebUserControlAlgorithms toDel = (WebUserControlAlgorithms)sender;

            if (toDel != null)
            {
                // Find the index of the control
                int indexToDel = PlaceHolderAlgorithms.Controls.IndexOf(toDel);
                if (indexToDel >= 0)
                {
                    List<WebUserControlAlgorithmsData> aData = AlgorithmsData; // Get it out of the viewstate
                    aData.RemoveAt(indexToDel);
                    AlgorithmsData = aData;

                    LoadAlgorithmsControls();
                    LoadAlgorithmsEvents();
                }
            }
        }

        public void Environment_UserControlFieldChanged(object sender, EventArgs e)
        {          
            WebUserControlEnvironments en = (WebUserControlEnvironments)sender;

            if (en != null)
            {
                // Find the control.
                int indexOfControl = PlaceHolderEnvironments.Controls.IndexOf(en);
                if (indexOfControl >= 0)
                {
                    List<WebUserControlEnvironmentsData> enData = EnvironmentsData; // Get it out of the viewstate
                    
                    if (enData.Count <= indexOfControl)
                        throw new ExecutionEngineException("Ooopps");
                    
                    enData[indexOfControl] = ((EnvironmentDataEventArgs)e).Data;
                    EnvironmentsData = enData; 
                }
            }
        }

        public void Robot_UserControlFieldChanged(object sender, EventArgs e)
        {
            WebUserControlRobots r = (WebUserControlRobots)sender;

            if (r != null)
            {
                // Find the control.
                int indexOfControl = PlaceHolderRobots.Controls.IndexOf(r);
                if (indexOfControl >= 0)
                {
                    List<WebUserControlRobotsData> rData = RobotsData; // Get it out of the viewstate

                    if (rData.Count <= indexOfControl)
                        throw new ExecutionEngineException("Ooopps");

                    rData[indexOfControl] = ((RobotDataEventArgs)e).Data;
                    RobotsData = rData;
                }
            }
        }

        public void Map_UserControlFieldChanged(object sender, EventArgs e)
        {
            WebUserControlMaps m = (WebUserControlMaps)sender;

            if (m != null)
            {
                // Find the control.
                int indexOfControl = PlaceHolderMaps.Controls.IndexOf(m);
                if (indexOfControl >= 0)
                {
                    List<WebUserControlMapsData> mData = MapsData; // Get it out of the viewstate

                    if (mData.Count <= indexOfControl)
                        throw new ExecutionEngineException("Ooopps");

                    mData[indexOfControl] = ((MapDataEventArgs)e).Data;
                    MapsData = mData;
                }
            }
        }

        public void Algorithm_UserControlFieldChanged(object sender, EventArgs e)
        {
            WebUserControlAlgorithms m = (WebUserControlAlgorithms)sender;

            if (m != null)
            {
                // Find the control.
                int indexOfControl = PlaceHolderAlgorithms.Controls.IndexOf(m);
                if (indexOfControl >= 0)
                {
                    List<WebUserControlAlgorithmsData> aData = AlgorithmsData; // Get it out of the viewstate

                    if (aData.Count <= indexOfControl)
                        throw new ExecutionEngineException("Ooopps");

                    aData[indexOfControl] = ((AlgorithmDataEventArgs)e).Data;
                    AlgorithmsData = aData;
                }
            }
        }

        #endregion  

        #region Load controls and events

        // Push the environments in the panelHolder again
        void LoadEnvironmentsControls()
        {
            List<WebUserControlEnvironmentsData> enData = EnvironmentsData; // Get it out of the viewstate

            if (enData != null)
            {              
                PlaceHolderEnvironments.Controls.Clear();

                int countID = 0;
                foreach (WebUserControlEnvironmentsData en in enData)
                {
                    WebUserControlEnvironments environment = (WebUserControlEnvironments)LoadControl("~/WebUserControlEnvironments.ascx");
                    environment.LoadData(en);
                    environment.ID = countID.ToString() + "_Environment";
                    ++countID;

                    PlaceHolderEnvironments.Controls.Add(environment);
                }
            }

            EnvironmentsData = enData; 
        }

        // Push the maps in the panelHolder again
        void LoadRobotsControls()
        {
            List<WebUserControlRobotsData> rData = RobotsData; // Get it out of the viewstate

            if (rData != null)
            {
                PlaceHolderRobots.Controls.Clear();

                int countID = 0;
                foreach (WebUserControlRobotsData r in rData)
                {
                    WebUserControlRobots robot = (WebUserControlRobots)LoadControl("~/WebUserControlRobots.ascx");
                    robot.LoadData(r);
                    robot.ID = countID.ToString() + "_Robot";
                    ++countID;

                    PlaceHolderRobots.Controls.Add(robot);
                }
            }

            RobotsData = rData;
        }

        // Push the maps in the panelHolder again
        void LoadMapsControls()
        {
            List<WebUserControlMapsData> mData = MapsData; // Get it out of the viewstate

            if (mData != null)
            {
                PlaceHolderMaps.Controls.Clear();

                int countID = 0;
                foreach (WebUserControlMapsData m in mData)
                {
                    WebUserControlMaps map = (WebUserControlMaps)LoadControl("~/WebUserControlMaps.ascx");
                    map.LoadData(m);
                    map.ID = countID.ToString() + "_Map";
                    ++countID;

                    PlaceHolderMaps.Controls.Add(map);
                }
            }

            MapsData = mData;
        }

        // Push the algorithms in the panelHolder again
        void LoadAlgorithmsControls()
        {
            List<WebUserControlAlgorithmsData> aData = AlgorithmsData; // Get it out of the viewstate

            if (aData != null)
            {
                PlaceHolderAlgorithms.Controls.Clear();

                int countID = 0;
                foreach (WebUserControlAlgorithmsData a in aData)
                {
                    WebUserControlAlgorithms algorithm = (WebUserControlAlgorithms)LoadControl("~/WebUserControlAlgorithms.ascx");
                    algorithm.LoadData(a);
                    algorithm.ID = countID.ToString() + "_Algorithm";
                    ++countID;

                    PlaceHolderAlgorithms.Controls.Add(algorithm);
                }
            }

            AlgorithmsData = aData;
        }

        // Push the environment events
        void LoadEnvironmentsEvents()
        {
            if (PlaceHolderEnvironments.Controls != null)
            {
                foreach (WebUserControlEnvironments en in PlaceHolderEnvironments.Controls)
                {
                    // hook up event handler for exposed user control event Remove button click...
                    en.UserControlButtonRemoveClicked += new EventHandler(Environment_UserControlButtonRemoveClicked);

                    // hook up the event for field updates
                    en.UserControlFieldChanged += new EventHandler(Environment_UserControlFieldChanged);
                   
                    
                    //Button btn = (Button)en.FindControl("ButtonRemove");
                    //if (btn != null) btn.Click += en.ButtonRemove_Click;
                    //Button btn2 = (Button)en.FindControl("ButtonClearData");
                    //if (btn2 != null) btn2.Click += en.ButtonClearData_Click;
                }
            }
        }

        // Push the robot events
        void LoadRobotsEvents()
        {
            if (PlaceHolderRobots.Controls != null)
            {
                foreach (WebUserControlRobots r in PlaceHolderRobots.Controls)
                {
                    // hook up event handler for exposed user control event Remove button click...
                    r.UserControlButtonRemoveClicked += new EventHandler(Robot_UserControlButtonRemoveClicked);

                    // hook up the event for field updates
                    r.UserControlFieldChanged += new EventHandler(Robot_UserControlFieldChanged);
                }
            }
        }

        // Push the map events
        void LoadMapsEvents()
        {
            if (PlaceHolderMaps.Controls != null)
            {
                foreach (WebUserControlMaps m in PlaceHolderMaps.Controls)
                {
                    // hook up event handler for exposed user control event Remove button click...
                    m.UserControlButtonRemoveClicked += new EventHandler(Map_UserControlButtonRemoveClicked);

                    // hook up the event for field updates
                    m.UserControlFieldChanged += new EventHandler(Map_UserControlFieldChanged);
                }
            }
        }

        // Push the map events
        void LoadAlgorithmsEvents()
        {
            if (PlaceHolderAlgorithms.Controls != null)
            {
                foreach (WebUserControlAlgorithms a in PlaceHolderAlgorithms.Controls)
                {
                    // hook up event handler for exposed user control event Remove button click...
                    a.UserControlButtonRemoveClicked += new EventHandler(Algorithm_UserControlButtonRemoveClicked);

                    // hook up the event for field updates
                    a.UserControlFieldChanged += new EventHandler(Algorithm_UserControlFieldChanged);
                }
            }
        }
        #endregion

        #region Clearing simulation fields

        protected void ButtonClearRoboSimulationData_Click(object sender, EventArgs e)
        {
            TextBoxSimulationName.Text = "";
            TextBoxSimulationOwner.Text = "";
            TextBoxSimulationOwnerEmail.Text = "";
            TextBoxSimulationDescription.Text = "";
            TextBoxSimulationRating.Text = "";
        }

        #endregion

        #region Adding web user controls (Environment, Robot, Map, Algorithm)       

        protected void ButtonAddEnvironment_Click(object sender, EventArgs e)
        {
            WebUserControlEnvironments en = (WebUserControlEnvironments)LoadControl("~/WebUserControlEnvironments.ascx");
            en.ID = PlaceHolderEnvironments.Controls.Count.ToString() + "_Environment";

            PlaceHolderEnvironments.Controls.Add(en);

            List<WebUserControlEnvironmentsData> environData = EnvironmentsData; // Get it out of the viewstate

            WebUserControlEnvironmentsData enData = new WebUserControlEnvironmentsData();
            
            enData = en.Data;
            environData.Add(enData);

            EnvironmentsData = environData;
        }

        protected void ButtonAddRobot_Click(object sender, EventArgs e)
        {
            WebUserControlRobots r = (WebUserControlRobots)LoadControl("~/WebUserControlRobots.ascx");
            r.ID = PlaceHolderRobots.Controls.Count.ToString() + "_Robot";

            PlaceHolderRobots.Controls.Add(r);

            List<WebUserControlRobotsData> rData = RobotsData; // Get it out of the viewstate

            WebUserControlRobotsData robotData = new WebUserControlRobotsData();
            robotData = r.Data;

            rData.Add(robotData);

            RobotsData = rData;
        }

        protected void ButtonAddMap_Click(object sender, EventArgs e)
        {
            WebUserControlMaps m = (WebUserControlMaps)LoadControl("~/WebUserControlMaps.ascx");
            m.ID = PlaceHolderMaps.Controls.Count.ToString() + "_Map";

            PlaceHolderMaps.Controls.Add(m);

            List<WebUserControlMapsData> mapData = MapsData; // Get it out of the viewstate

            WebUserControlMapsData newData = new WebUserControlMapsData();

            newData = m.Data;
            mapData.Add(newData);

            MapsData = mapData;
        }

        protected void ButtonAddAlgorithm_Click(object sender, EventArgs e)
        {
            WebUserControlAlgorithms a = (WebUserControlAlgorithms)LoadControl("~/WebUserControlAlgorithms.ascx");
            a.ID = PlaceHolderAlgorithms.Controls.Count.ToString() + "_Algorithm";

            PlaceHolderAlgorithms.Controls.Add(a);

            List<WebUserControlAlgorithmsData> algorithmData = AlgorithmsData; // Get it out of the viewstate

            WebUserControlAlgorithmsData newData = new WebUserControlAlgorithmsData();

            newData = a.Data;
            algorithmData.Add(newData);

            AlgorithmsData = algorithmData;
        }

        #endregion

        #region Save to XML

        void SaveToXML()
        {
            RoboSimulation rs = new RoboSimulation();

            bool valid = ValidateRoboSimulation(rs);

            if (valid)
            {
                string filePath = Server.MapPath("~/resources/Generated/" + rs.simulation_name + " " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".xml");
                utilities.InsertRoboSimulationToXML(rs, filePath);
             //   LabelValidationError.Text = "Данните бяха добавени успешно в ХМЛ документ! :)";
             //   LabelValidationError.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00CC00");
            }
        }

        #endregion

        #region Save to DataBase

        // If all fields are correct-> save the data to the database
        protected void ButtonSaveToDBAndXML_Click(object sender, EventArgs e)
        {
            RoboSimulation rs = new RoboSimulation();

            bool valid = ValidateRoboSimulation(rs);

            if (valid)
            {
                utilities.InsertRoboSimulationToDB(rs);
                LabelValidationStatus.Text = "Данните бяха успешно записани! :)";
                LabelValidationStatus.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00CC00");
            }
            else
            {
                LabelValidationStatus.Text = "Грешка: Данните не са записани, има невалидно попълнени полета!";
                LabelValidationStatus.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF5050");
            }

            SaveToXML();
        }

        #endregion

        #region Validate whole robo simulation fields

        // Validates every field in the robo simulation and if everything is correct returns true (and the data is in the given RoboSimulation object)
        bool ValidateRoboSimulation(RoboSimulation rs)
        {
            bool valid = true;
            int idCounter = 0;

            // Validate simulation elements(not nested)
            if (!Validate())
            {
                valid = false;
            }
            else
            {
                rs.simulation_name = string.Copy(TextBoxSimulationName.Text);
                rs.simulation_owner = string.Copy(TextBoxSimulationOwner.Text);
                rs.simulation_owner_email = string.Copy(TextBoxSimulationOwnerEmail.Text);
                rs.simulation_description = string.Copy(TextBoxSimulationDescription.Text);
                rs.simulation_rating = Decimal.Parse(TextBoxSimulationRating.Text);
            }

            // Validate environments
            idCounter = 0;
            foreach (WebUserControlEnvironments en in PlaceHolderEnvironments.Controls)
            {
                Environment environment = null;

                // If the fields are wrong, the environment object will be null
                en.WriteToEnvironment(ref environment);

                if (environment == null)
                {
                    valid = false;
                }
                else
                {
                    environment.id = idCounter++;
                    rs.Environments.Add(environment);
                }
            }

            // Validate environments
            idCounter = 0;
            foreach (WebUserControlRobots r in PlaceHolderRobots.Controls)
            {
                Robot robot = null;

                // If the fields are wrong, the environment object will be null
                r.WriteToRobot(ref robot);

                if (robot == null)
                {
                    valid = false;
                }
                else
                {
                    robot.id = idCounter++;
                    rs.Robots.Add(robot);
                }
            }

            // Validate maps
            idCounter = 0;
            foreach (WebUserControlMaps m in PlaceHolderMaps.Controls)
            {
                Map map = null;

                // If the fields are wrong, the environment object will be null
                m.WriteToMap(ref map);

                if (map == null)
                {
                    valid = false;
                }
                else
                {
                    map.id = idCounter++;
                    rs.Maps.Add(map);
                }
            }

            // Validate algorithms
            idCounter = 0;
            foreach (WebUserControlAlgorithms a in PlaceHolderAlgorithms.Controls)
            {
                Algorithm algorithm = null;

                // If the fields are wrong, the environment object will be null
                a.WriteToAlgorithm(ref algorithm);

                if (algorithm == null)
                {
                    valid = false;
                }
                else
                {
                    algorithm.id = idCounter++;
                    rs.Algorithms.Add(algorithm);
                }
            }

            return valid;
        }

        #endregion

        #region Validate simulation fields

        // Validates the fields of the simulation(only first level fields, like name and such..)
        // Sets the error msg-s if the fields are wrong
        public bool Validate()
        {
            string output = "";

            bool result = true;

            if (!utilities.checkLenghtLessEqualThan(TextBoxSimulationName.Text, 64, ref output))
            {
                LabelSimulationNameError.Text = output;
                result = false;
            }
            else
                LabelSimulationNameError.Text = "";

            if (!utilities.checkLenghtLessEqualThan(TextBoxSimulationOwner.Text, 64, ref output))
            {
                LabelSimulationOwnerError.Text = output;
                result = false;
            }
            else
                LabelSimulationOwnerError.Text = "";


            if (!utilities.checkLenghtLessEqualThan(TextBoxSimulationOwnerEmail.Text, 32, ref output))
            {
                LabelSimulationOwnerEmailError.Text = output;
                result = false;
            }
            else
                LabelSimulationOwnerEmailError.Text = "";

            if (!utilities.checkLenghtLessEqualThan(TextBoxSimulationDescription.Text, 1024, ref output))
            {
                LabelSimulationDescriptionError.Text = output;
                result = false;
            }
            else
                LabelSimulationDescriptionError.Text = "";           



            if (!utilities.checkDecimalValidAndRange(TextBoxSimulationRating.Text, ref output, 6M))
            {
                LabelSimulationRatimgError.Text = output;
                result = false;
            }
            else
                LabelSimulationRatimgError.Text = "";

            return result;
        }

        #endregion

    }
}