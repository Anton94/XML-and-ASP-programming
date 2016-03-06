
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xmlToSql
{
    class RoboSimulationElements
    {
        public static string ROOT_ELEMENT = "RoboSimulation";
        public static string ROOT_ELEMENT_XPATH = "/RoboSimulation";
        public static string XML_VERSION = "1.0";
        public static string XML_ENCODING = "utf-8";
        public static string ROBOSIMULATION_ID = "id";
        public static string ROBOSIMULATION_NAME = "SimulationName";
        public static string ROBOSIMULATION_NAME_XPATH = ROOT_ELEMENT_XPATH + "/SimulationName";
        public static string ROBOSIMULATION_OWNER = "SimulationOwner";
        public static string ROBOSIMULATION_OWNER_XPATH = ROOT_ELEMENT_XPATH + "/SimulationOwner";
        public static string ROBOSIMULATION_OWNEREMAIL = "SimulationOwnerEmail";
        public static string ROBOSIMULATION_OWNEREMAIL_XPATH = ROOT_ELEMENT_XPATH + "/SimulationOwnerEmail";
        
        /*Environments*/
        public static string ROBOSIMULATION_ENVIRONMENTS = "Environments";
        public static string ROBOSIMULATION_ENVIRONMENTS_XPATH = ROOT_ELEMENT_XPATH + "/Environments";
        public static string ROBOSIMULATION_ENVIRONMENT = "Environment";
        public static string ROBOSIMULATION_ENVIRONMENT_XPATH = ROBOSIMULATION_ENVIRONMENTS_XPATH + "/Environment";
        public static string ROBOSIMULATION_ENVIRONMENT_ID = "id";
        public static string ROBOSIMULATION_ENVIRONMENT_NAME = "name";
        public static string ROBOSIMULATION_TRAVELCOSTENTER = "TravelCostEnter";
        public static string ROBOSIMULATION_TRAVELCOSTENTER_XPATH = ROBOSIMULATION_ENVIRONMENT_XPATH + "/TravelCostEnter";
        public static string ROBOSIMULATION_TRAVELCOSTIN = "TravelCostIn";
        public static string ROBOSIMULATION_TRAVELCOSTIN_XPATH = ROBOSIMULATION_ENVIRONMENT_XPATH + "/TravelCostIn";
        public static string ROBOSIMULATION_TRAVELCOSTEXIT = "TravelCostExit";
        public static string ROBOSIMULATION_TRAVELCOSTEXIT_XPATH = ROBOSIMULATION_ENVIRONMENT_XPATH + "/TravelCostExit";
        public static string ROBOSIMULATION_TRAVELCOSTDAMAGE = "Damage";
        public static string ROBOSIMULATION_TRAVELCOSTDAMAGE_XPATH = ROBOSIMULATION_ENVIRONMENT_XPATH + "/Damage";
        
        /*Robots*/
        public static string ROBOSIMULATION_ROBOTS = "Robots";
        public static string ROBOSIMULATION_ROBOTS_XPATH = ROOT_ELEMENT_XPATH + "/Robots";
        public static string ROBOSIMULATION_ROBOT = "Robot";
        public static string ROBOSIMULATION_ROBOT_XPATH = ROBOSIMULATION_ROBOTS_XPATH + "/Robot";
        public static string ROBOSIMULATION_ROBOT_ID = "id";
        public static string ROBOSIMULATION_ROBOT_ENVIRONMENTS = "environments";
        public static string ROBOSIMULATION_ROBOT_NAME = "name";
        public static string ROBOSIMULATION_ROBOT_OWNER = "owner";
        public static string ROBOSIMULATION_ROBOT_ROBOTMESHGRID = "RobotMeshGrid";
        public static string ROBOSIMULATION_ROBOT_ROBOTMESHGRID_XPATH = ROBOSIMULATION_ROBOT_XPATH + "/RobotMeshGrid";
        public static string ROBOSIMULATION_ROBOT_SPEED = "Speed";
        public static string ROBOSIMULATION_ROBOT_SPEED_XPATH = ROBOSIMULATION_ROBOT_XPATH + "/Speed";
        public static string ROBOSIMULATION_ROBOT_SPEEDBACK = "SpeedBack";
        public static string ROBOSIMULATION_ROBOT_SPEEDBACK_XPATH = ROBOSIMULATION_ROBOT_XPATH + "/SpeedBack";
        public static string ROBOSIMULATION_ROBOT_TURNINGSPEED = "TurningSpeed";
        public static string ROBOSIMULATION_ROBOT_TURNINGSPEED_XPATH = ROBOSIMULATION_ROBOT_XPATH + "/TurningSpeed";
        public static string ROBOSIMULATION_ROBOT_TURNINGSPEEDBACK = "TurningSpeedBack";
        public static string ROBOSIMULATION_ROBOT_TURNINGSPEEDBACK_XPATH = ROBOSIMULATION_ROBOT_XPATH + "/TurningSpeedBack";

        /*Wheels*/
        public static string ROBOSIMULATION_WHEELS = "Wheels";
        public static string ROBOSIMULATION_WHEELS_XPATH = ROOT_ELEMENT_XPATH + "/Wheels";
        public static string ROBOSIMULATION_WHEEL = "Wheel";
        public static string ROBOSIMULATION_WHEEL_XPATH = ROBOSIMULATION_WHEELS_XPATH + "/Wheel";
        public static string ROBOSIMULATION_WHEEL_DIRIVING = "driving";
        public static string ROBOSIMULATION_WHEEL_WHEELMESHGRID = "WheelMeshGrid";
        public static string ROBOSIMULATION_WHEEL_WHEELMESHGRID_XPATH = ROBOSIMULATION_WHEEL_XPATH + "/WheelMeshGrid";
        public static string ROBOSIMULATION_WHEEL_WHEELMDIAMETER = "WheelDiameter";
        public static string ROBOSIMULATION_WHEEL_WHEELMDIAMETER_XPATH = ROBOSIMULATION_WHEEL_XPATH + "/WheelDiameter";
        public static string ROBOSIMULATION_WHEEL_WHEELWIDTH = "WheelWidth";
        public static string ROBOSIMULATION_WHEEL_WHEELWIDTH_XPATH = ROBOSIMULATION_WHEEL_XPATH + "/WheelWidth";

        /*Sensors*/
        public static string ROBOSIMULATION_SENSORS = "Sensors";
        public static string ROBOSIMULATION_SENSORS_XPATH = ROOT_ELEMENT_XPATH + "/Sensors";
        public static string ROBOSIMULATION_SENSOR = "Wheel";
        public static string ROBOSIMULATION_SENSOR_XPATH = ROBOSIMULATION_SENSORS_XPATH + "/Wheel";
        public static string ROBOSIMULATION_SENSOR_NAME = "name";
        public static string ROBOSIMULATION_SENSOR_VALUETYPE = "valueType";
        public static string ROBOSIMULATION_SENSOR_SENSORMESHGRID = "SensorMeshGrid";
        public static string ROBOSIMULATION_SENSOR_SENSORMESHGRID_XPATH = ROBOSIMULATION_SENSOR_XPATH + "/SensorMeshGrid";
        public static string ROBOSIMULATION_SENSOR_VPS = "NumberOfValusPerSecond";
        public static string ROBOSIMULATION_SENSOR_VPS_XPATH = ROBOSIMULATION_SENSOR_XPATH + "/NumberOfValusPerSecond";

        /*Rotors*/
        public static string ROBOSIMULATION_ROTORS = "Rotors";
        public static string ROBOSIMULATION_ROTORS_XPATH = ROOT_ELEMENT_XPATH + "/Rotors";
        public static string ROBOSIMULATION_ROTOR = "Rotor";
        public static string ROBOSIMULATION_ROTOR_XPATH = ROBOSIMULATION_ROTORS_XPATH + "/Rotor";
        public static string ROBOSIMULATION_ROTOR_ROTORMESHGRID = "RotorMeshGrid";
        public static string ROBOSIMULATION_ROTOR_ROTORMESHGRID_XPATH = ROBOSIMULATION_ROTOR_XPATH + "/RotorMeshGrid";
        public static string ROBOSIMULATION_ROTOR_WHEELMDIAMETER = "RotorLiftingPower";
        public static string ROBOSIMULATION_ROTOR_WHEELMDIAMETER_XPATH = ROBOSIMULATION_ROTOR_XPATH + "/RotorLiftingPower";

        /*Maps*/
        public static string ROBOSIMULATION_MAPS = "Maps";
        public static string ROBOSIMULATION_MAPS_XPATH = ROOT_ELEMENT_XPATH + "/Maps";
        public static string ROBOSIMULATION_MAP = "Map";
        public static string ROBOSIMULATION_MAP_XPATH = ROBOSIMULATION_MAPS_XPATH + "/Map";
        public static string ROBOSIMULATION_MAP_ID = "id";
        public static string ROBOSIMULATION_MAP_ENVIRONMENTS = "environments";
        public static string ROBOSIMULATION_MAPDATA = "MapData";
        public static string ROBOSIMULATION_MAPDATA_XPATH = ROBOSIMULATION_MAP_XPATH + "/MapData";
        public static string ROBOSIMULATION_DENIVELATION = "Denivelation";
        public static string ROBOSIMULATION_TDENIVELATION_XPATH = ROBOSIMULATION_MAP_XPATH + "/Denivelation";
        
        /*Algorithms*/
        public static string ROBOSIMULATION_ALGORITHMS = "Algorithms";
        public static string ROBOSIMULATION_ALGORITHMS_XPATH = ROOT_ELEMENT_XPATH + "/Algorithms";
        public static string ROBOSIMULATION_ALGORITHM = "Algorithm";
        public static string ROBOSIMULATION_ALGORITHM_XPATH = ROBOSIMULATION_ALGORITHMS_XPATH + "/Algorithm";
        public static string ROBOSIMULATION_ALGORITHM_ID = "id";
        public static string ROBOSIMULATION_ALGORITHM_NAME = "name";
        public static string ROBOSIMULATION_ALGORITHM_DIFFENVIRONMENTS = "diffEnvironments";
        public static string ROBOSIMULATION_ALGORITHM_MULTIPLEDESTPOINTS = "multipleDestPoints";
        public static string ROBOSIMULATION_COMPLEXITY = "Complexity";
        public static string ROBOSIMULATION_COMPLEXITY_XPATH = ROBOSIMULATION_ALGORITHM_XPATH + "/Complexity";
        public static string ROBOSIMULATION_DEPTH = "Depth";
        public static string ROBOSIMULATION_DEPTH_XPATH = ROBOSIMULATION_ALGORITHM_XPATH + "/Depth";
    }
}
