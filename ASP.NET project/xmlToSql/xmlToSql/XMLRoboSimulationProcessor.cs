using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Schema;

namespace xmlToSql
{
    class XMLRoboSimulationProcessor
    {
        private RoboSimulation roboSimulation;
        private XmlDocument xml = new XmlDocument();
        private string path;
        
        public RoboSimulation RoboSimulation
        {
            get
            {
                //if (roboSimulation != null)
                    return this.roboSimulation;
              //  else throw new XMLBookstoreProcessorException("You must first call the \"LoadBookstoreFromXML(string path)\"" +
              //  " or \"LoadBookstoreFromXMLUsingReader(string path)\" method for your XMLBookStoreProcessor object!");
            }
        }
        public void validateDTDFile(string file)
        {
            try
            {
                XMLValidator val = new XMLValidator();
                val.Validate(file);
            }
            catch (Exception e)
            {
                throw new XMLRoboSimulationProcessorException(e.Message);
            }
        }
       

        //reader using
        public bool LoadRoboSimulationFromXMLUsingReader(string path)
        {
            this.path = path;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.DTD;
            settings.DtdProcessing = DtdProcessing.Parse;


            RoboSimulation rs = null;
            Environment en = null;
            Robot r = null;
            Wheel w = null;
            Sensor s = null;
            Rotor rot = null;
            Map m = null;
            Algorithm a = null;

            try
            {
                XmlReader reader = XmlReader.Create(path, settings);
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                        switch (reader.Name)
                        {
                            case "RoboSimulation":
                                rs = new RoboSimulation();
                                rs.simulation_name = reader.GetAttribute(RoboSimulationElements.ROBOSIMULATION_NAME);
                                rs.simulation_owner = reader.GetAttribute(RoboSimulationElements.ROBOSIMULATION_OWNER);
                                break;
                            case "SimulationOwnerEmail":
                                rs.simulation_owner_email = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "SimulationDescription":
                                rs.simulation_description = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "SimulationRating":
                                rs.simulation_rating = Decimal.Parse((string)reader.ReadElementContentAs(typeof(string), null));
                                break;
                            /* Environment */
                            case "Environment":
                                en = new Environment();
                                en.name = reader.GetAttribute(RoboSimulationElements.ROBOSIMULATION_ENVIRONMENT_NAME);
                                rs.Environments.Add(en);
                                break;
                            case "TravelCostEnter":
                                en.travel_cost_enter = Decimal.Parse((string)reader.ReadElementContentAs(typeof(string), null));
                                break;
                            case "TravelCostIn":
                                en.travel_cost_in = Decimal.Parse((string)reader.ReadElementContentAs(typeof(string), null));
                                break;
                            case "TravelCostExit":
                                en.travel_cost_exit = Decimal.Parse((string)reader.ReadElementContentAs(typeof(string), null));
                                break;
                            case "Damage":
                                en.damage = Decimal.Parse((string)reader.ReadElementContentAs(typeof(string), null));
                                break;
                            /* Robot */
                            case "Robot":
                                r = new Robot();
                                r.name = reader.GetAttribute(RoboSimulationElements.ROBOSIMULATION_ROBOT_NAME);
                                r.owner = reader.GetAttribute(RoboSimulationElements.ROBOSIMULATION_ROBOT_OWNER);
                                rs.Robots.Add(r);
                                break;
                            case "RobotMeshGrid":
                                r.robot_mesh_grid = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "Speed":
                                r.speed = Decimal.Parse((string)reader.ReadElementContentAs(typeof(string), null));
                                break;
                            case "SpeedBack":
                                r.speed_back = Decimal.Parse((string)reader.ReadElementContentAs(typeof(string), null));
                                break;
                            case "TurningSpeed":
                                r.turning_speed = Decimal.Parse((string)reader.ReadElementContentAs(typeof(string), null));
                                break;
                            case "TurningSpeedBack":
                                r.turning_speed_back = Decimal.Parse((string)reader.ReadElementContentAs(typeof(string), null));
                                break;
                            /* Robot Wheels */
                            case "Wheel":
                                w = new Wheel();
                                w.driving = reader.GetAttribute(RoboSimulationElements.ROBOSIMULATION_WHEEL_DIRIVING);
                                r.Wheels.Add(w);
                                break;
                            case "WheelMeshGrid":
                                w.wheel_mesh_grid = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "WheelDiameter":
                                w.wheel_diameter = Decimal.Parse((string)reader.ReadElementContentAs(typeof(string), null));
                                break;
                            case "WheelWidth":
                                w.wheel_width = Decimal.Parse((string)reader.ReadElementContentAs(typeof(string), null));
                                break;
                            /* Robot Sensors */
                            case "Sensor":
                                s = new Sensor();
                                s.name = reader.GetAttribute(RoboSimulationElements.ROBOSIMULATION_SENSOR_NAME);
                                s.value_type = reader.GetAttribute(RoboSimulationElements.ROBOSIMULATION_SENSOR_VALUETYPE);
                                r.Sensors.Add(s);
                                break;
                            case "SensorMeshGrid":
                                s.sensor_mesh_grid = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "NumberOfValusPerSecond":
                                s.number_of_values_per_second = Decimal.Parse((string)reader.ReadElementContentAs(typeof(string), null));
                                break;
                            /* Robot Rotors */
                            case "Rotor":
                                rot = new Rotor();
                                r.Rotors.Add(rot);
                                break;
                            case "RotorMeshGrid":
                                rot.rotor_mesh_grid = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "RotorLiftingPower":
                                rot.rotor_lifting_power = Decimal.Parse((string)reader.ReadElementContentAs(typeof(string), null));
                                break;
                            /* Map */
                            case "Map":
                                m = new Map();
                                m.map_name = reader.GetAttribute(RoboSimulationElements.ROBOSIMULATION_MAP_NAME);
                                rs.Maps.Add(m);
                                break;
                            case "MapData":
                                m.map_data = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "Denivelation":
                                m.denivelation = Decimal.Parse((string)reader.ReadElementContentAs(typeof(string), null));
                                break;
                            /* Algorithm */
                            case "Algorithm":
                                a = new Algorithm();
                                a.name = reader.GetAttribute(RoboSimulationElements.ROBOSIMULATION_ALGORITHM_NAME);
                                a.multipleDestPoints = reader.GetAttribute(RoboSimulationElements.ROBOSIMULATION_ALGORITHM_MULTIPLEDESTPOINTS);
                                a.diffEnvironments = reader.GetAttribute(RoboSimulationElements.ROBOSIMULATION_ALGORITHM_DIFFENVIRONMENTS);
                                rs.Algorithms.Add(a);
                                break;
                            case "Complexity":
                                a.complexity = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "Depth":
                                a.depth = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                        }

                }
                reader.Close();
            }
            catch (Exception e)
            {
                throw new XMLRoboSimulationProcessorException(e.Message);
            }
            this.roboSimulation = rs;
            return true;
        }
    }
}
