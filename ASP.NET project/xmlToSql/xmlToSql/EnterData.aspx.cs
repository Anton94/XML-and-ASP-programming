using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace xmlToSql
{
    public partial class EnterData : System.Web.UI.Page
    {
        private static RoboSimulation rs;
        private static Robot r;

        public static void Init()
        {
            rs = new RoboSimulation();
            r = new Robot();
            xmlToSql.Program.Init();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }


        #region Clearing data

        protected void ButtonClearEnvironmentData_Click(object sender, EventArgs e)
        {
            TextBoxEnvironmentName.Text = "";
            TextBoxEnvironmentCostEnter.Text = "";
            TextBoxEnvironmentCostIn.Text = "";
            TextBoxEnvironmentExit.Text = "";
            TextBoxEnvironmentDamage.Text = "";
        }

        protected void ButtonClearWheelData_Click(object sender, EventArgs e)
        {
            DropDownListWheelDiriving.Text = "ДА";
            TextBoxWheelMesh.Text = "";
            TextBoxWheelDiameter.Text = "";
            TextBoxWheelWidth.Text = "";
        }

        protected void ButtonClearSensorData_Click(object sender, EventArgs e)
        {
            TextBoxSensorName.Text = "";
            TextBoxSensorValueType.Text = "";
            TextBoxSensorMesh.Text = "";
            TextBoxSensorValuesPerSecond.Text = "";
        }

        protected void ButtonClearRotorData_Click(object sender, EventArgs e)
        {
            TextBoxRotorMesh.Text = "";
            TextBoxRotorLiftingPower.Text = "";
        }

        protected void ButtonClearRobotData_Click(object sender, EventArgs e)
        {
            TextBoxRobotName.Text = "";
            TextBoxRobotOwner.Text = "";
            TextBoxRobotMesh.Text = "";
            TextBoxRobotSpeed.Text = "";
            TextBoxRobotSpeedBack.Text = "";
            TextBoxRobotTurningSpeed.Text = "";
            TextBoxRobotTurningSpeedBack.Text = "";
        }

        protected void ButtonClearMapData_Click(object sender, EventArgs e)
        {
            TextBoxMapName.Text = "";
            TextBoxMapMapData.Text = "";
            TextBoxMapDenivelation.Text = "";
        }

        protected void ButtonClearAlgorithmData_Click(object sender, EventArgs e)
        {
            TextBoxAlgorithmName.Text = "";
            DropDownListAlgorithmDiffEnvironments.Text = "ДА";
            DropDownListAlgorighmMultipleDestPoints.Text = "ДА";
            TextBoxAlgorithmComplexity.Text = "";
            TextBoxAlgorithmDepth.Text = "";
        }

        protected void ButtonClearRoboSimulationData_Click(object sender, EventArgs e)
        {
            TextBoxSimulationName.Text = "";
            TextBoxSimulationOwner.Text = "";
            TextBoxSimulationOwnerEmail.Text = "";
            TextBoxSimulationDescription.Text = "";
            TextBoxSimulationRating.Text = "";
        }

        #endregion

        #region Adding data

        // TO DO - validations!!



        protected void ButtonAddEnvironment_Click(object sender, EventArgs e)
        {
            Environment en = new Environment();
            en.name = TextBoxEnvironmentName.Text;
            en.travel_cost_enter = Decimal.Parse(TextBoxEnvironmentCostEnter.Text);
            en.travel_cost_in = Decimal.Parse(TextBoxEnvironmentCostIn.Text);
            en.travel_cost_exit = Decimal.Parse(TextBoxEnvironmentExit.Text);
            en.damage = Decimal.Parse(TextBoxEnvironmentDamage.Text);

            rs.Environments.Add(en);
        }

        protected void ButtonAddRobot_Click(object sender, EventArgs e)
        {
            r.name = TextBoxRobotName.Text;
            r.owner = TextBoxRobotOwner.Text;
            r.robot_mesh_grid = TextBoxRobotMesh.Text;
            r.speed = Decimal.Parse(TextBoxRobotSpeed.Text);
            r.turning_speed_back = Decimal.Parse(TextBoxRobotSpeedBack.Text);
            r.turning_speed = Decimal.Parse(TextBoxRobotTurningSpeed.Text);
            r.turning_speed_back = Decimal.Parse(TextBoxRobotTurningSpeedBack.Text);

            rs.Robots.Add(r);
            r = new Robot();
        }

        protected void ButtonAddWheel_Click(object sender, EventArgs e)
        {
            Wheel w = new Wheel();
            w.driving = DropDownListWheelDiriving.Text;
            w.wheel_mesh_grid = TextBoxWheelMesh.Text;
            w.wheel_diameter = Decimal.Parse(TextBoxWheelDiameter.Text);
            w.wheel_width = Decimal.Parse(TextBoxWheelWidth.Text);

            r.Wheels.Add(w);
        }

        protected void ButtonAddSensor_Click(object sender, EventArgs e)
        {
            Sensor s = new Sensor();

            s.name = TextBoxSensorName.Text;
            s.value_type = TextBoxSensorValueType.Text;
            s.sensor_mesh_grid = TextBoxSensorMesh.Text;
            s.number_of_values_per_second = Decimal.Parse(TextBoxSensorValuesPerSecond.Text);

            r.Sensors.Add(s);
        }

        protected void ButtonAddRotor_Click(object sender, EventArgs e)
        {
            Rotor rotor = new Rotor();

            rotor.rotor_mesh_grid = TextBoxRotorMesh.Text;
            rotor.rotor_lifting_power = Decimal.Parse(TextBoxRotorLiftingPower.Text);

            r.Rotors.Add(rotor);
        }

        protected void ButtonAddMap_Click(object sender, EventArgs e)
        {
            Map m = new Map();

            m.map_name = TextBoxMapName.Text;
            m.map_data = TextBoxMapMapData.Text;
            m.denivelation = Decimal.Parse(TextBoxMapDenivelation.Text);

            rs.Maps.Add(m);
        }

        protected void ButtonAddAlgorithm_Click(object sender, EventArgs e)
        {
            Algorithm a = new Algorithm();

            a.name = TextBoxAlgorithmName.Text;
            a.diffEnvironments = DropDownListAlgorithmDiffEnvironments.Text;
            a.multipleDestPoints = DropDownListAlgorighmMultipleDestPoints.Text;
            a.complexity = TextBoxAlgorithmComplexity.Text;
            a.depth = TextBoxAlgorithmDepth.Text;

            rs.Algorithms.Add(a);
        }

        protected void ButtonSaveToDB_Click(object sender, EventArgs e)
        {
            rs.simulation_name = string.Copy(TextBoxSimulationName.Text);
            rs.simulation_owner = string.Copy(TextBoxSimulationOwner.Text);
            rs.simulation_owner_email = string.Copy(TextBoxSimulationOwnerEmail.Text);
            rs.simulation_description = string.Copy(TextBoxSimulationDescription.Text);
            rs.simulation_rating = Decimal.Parse(TextBoxSimulationRating.Text);

            xmlToSql.Program.InsertRoboSimulationToDB(rs);
        }

        #endregion

        /*
         * 
         * Reset fields
         * 
         */
    }
}