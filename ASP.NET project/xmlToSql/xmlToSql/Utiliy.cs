using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Data;
using System.IO;
using System.Globalization;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace xmlToSql
{
    class Utility
    {
        private ASP_programmingEntities1 entities;
        
        public Utility()
        {
            entities = new ASP_programmingEntities1();
        }

        #region Validate String and Decimal

        // Checks if the given string @s `s length is less than (or equal) to the given number @size.
        public bool checkLenghtLessEqualThan(string s, int size, ref string output)
        {
            if (s.Length <= 0)
            {
                output = "<- задължително поле";
                return false;
            }
            else if (s.Length > size)
            {   
                output = "<- въведения низ е над " + size.ToString() + " символа!";
                return false;
            }

            return true;
        }

        // Checks if the given string could be parsed to decimal and if this decimal is more or equal to zero.
        public bool checkDecimalValidAndRange(string s, ref string output, decimal max)
        {
            decimal num = 0M;
            try
            {
                num = Decimal.Parse(s);
            }
            catch (ArgumentNullException ane)
            {
                output = "<- ooopSss";
                return false;
            }
            catch (FormatException fe)
            {
                if (s.Length <= 0)
                    output = "<- задължително поле";
                else
                    output = "<- невалиден формат";
                return false;
            }

            if (num < 0M)
            {
                output = "<- число по-голямо от 0";
                return false;
            }
            else if (num > max)
            {
                output = "<- число по-малко от " + max.ToString();
                return false;
            }

            return true;
        }

        // Checks if the given string could be parsed to decimal
        public bool checkDecimalValid(string s, ref string output)
        {
            try
            {
                Decimal.Parse(s);
            }
            catch (ArgumentNullException ane)
            {
                output = "<- ooopSss";
                return false;
            }
            catch (FormatException fe)
            {
                if (s.Length <= 0)
                    output = "<- задължително поле";
                else
                    output = "<- невалиден формат";
                return false;
            }

            return true;
        }

        #endregion

        #region Insert RoboSimulation object to XML document

        public void InsertRoboSimulationToXML(RoboSimulation rs, string filePath)
        {
            XDocument roboSimulationXml = new XDocument(new XDocumentType("RoboSimulation", null, "RoboSim.dtd", null));          
            XElement xRoot = new XElement("RoboSimulation");

            // Simulation attributes and elements(not nested once)
            xRoot.SetAttributeValue("id", "S" + rs.id.ToString());
            xRoot.SetAttributeValue("name", rs.simulation_name);
            xRoot.SetAttributeValue("owner", rs.simulation_owner);
            XElement xRootChildElement = new XElement("SimulationOwnerEmail", rs.simulation_owner_email);
            xRoot.Add(xRootChildElement);
            xRootChildElement = new XElement("SimulationDescription", rs.simulation_description);
            xRoot.Add(xRootChildElement);
            xRootChildElement = new XElement("SimulationRating", rs.simulation_rating);
            xRoot.Add(xRootChildElement);

            // Environments
            xRootChildElement = new XElement("Environments", "");
            foreach (Environment en in rs.Environments)
            {
                XElement xEnvironment= new XElement("Environment");
                xEnvironment.SetAttributeValue("id", "I" + en.id.ToString());
                xEnvironment.SetAttributeValue("name", en.name);

                XElement xEnvironmetChildElement = new XElement("TravelCostEnter", en.travel_cost_enter);
                xEnvironment.Add(xEnvironmetChildElement);
                xEnvironmetChildElement = new XElement("TravelCostIn", en.travel_cost_in);
                xEnvironment.Add(xEnvironmetChildElement);
                xEnvironmetChildElement = new XElement("TravelCostExit", en.travel_cost_exit);
                xEnvironment.Add(xEnvironmetChildElement);
                xEnvironmetChildElement = new XElement("Damage", en.damage);
                xEnvironment.Add(xEnvironmetChildElement);

                xRootChildElement.Add(xEnvironment);
            }
            xRoot.Add(xRootChildElement);

            // Robots
            xRootChildElement = new XElement("Robots", "");
            foreach (Robot r in rs.Robots)
            {
                XElement xRobot = new XElement("Robot");
                xRobot.SetAttributeValue("id", "R" + r.id.ToString());
                xRobot.SetAttributeValue("name", r.name);
                xRobot.SetAttributeValue("owner", r.owner);

                XElement xRobotChildElement = new XElement("RobotMeshGrid", r.robot_mesh_grid);
                xRobot.Add(xRobotChildElement);
                xRobotChildElement = new XElement("Speed", r.speed);
                xRobot.Add(xRobotChildElement);
                xRobotChildElement = new XElement("SpeedBack", r.speed_back);
                xRobot.Add(xRobotChildElement);
                xRobotChildElement = new XElement("TurningSpeed", r.turning_speed);
                xRobot.Add(xRobotChildElement);
                xRobotChildElement = new XElement("TurningSpeedBack", r.turning_speed_back);
                xRobot.Add(xRobotChildElement);

                // Robot wheels
                XElement xRobotWheels = new XElement("Wheels", "");
                foreach (Wheel w in r.Wheels)
                {
                    XElement xWheel = new XElement("Wheel");
                    xWheel.SetAttributeValue("driving", w.driving);

                    XElement xWheelChildElement = new XElement("WheelMeshGrid", w.wheel_mesh_grid);
                    xWheel.Add(xWheelChildElement);
                    xWheelChildElement = new XElement("WheelDiameter", w.wheel_diameter);
                    xWheel.Add(xWheelChildElement);
                    xWheelChildElement = new XElement("WheelWidth", w.wheel_width);
                    xWheel.Add(xWheelChildElement);

                    xRobotWheels.Add(xWheel);
                }
                xRobot.Add(xRobotWheels);

                // Robot sensors
                XElement xRobotSensors = new XElement("Sensors", "");
                foreach (Sensor s in r.Sensors)
                {
                    XElement xSensor = new XElement("Sensor");
                    xSensor.SetAttributeValue("name", s.name);
                    xSensor.SetAttributeValue("valueType", s.value_type);

                    XElement xSensorChildElement = new XElement("SensorMeshGrid", s.sensor_mesh_grid);
                    xSensor.Add(xSensorChildElement);
                    xSensorChildElement = new XElement("NumberOfValusPerSecond", s.number_of_values_per_second);
                    xSensor.Add(xSensorChildElement);

                    xRobotSensors.Add(xSensor);
                }
                xRobot.Add(xRobotSensors);

                // Robot rotor
                XElement xRobotRotors = new XElement("Rotors", "");
                foreach (Rotor rotor in r.Rotors)
                {
                    XElement xRotor = new XElement("Rotor");

                    XElement xRotorChildElement = new XElement("RotorMeshGrid", rotor.rotor_mesh_grid);
                    xRotor.Add(xRotorChildElement);
                    xRotorChildElement = new XElement("RotorLiftingPower", rotor.rotor_lifting_power);
                    xRotor.Add(xRotorChildElement);

                    xRobotRotors.Add(xRotor);
                }
                xRobot.Add(xRobotRotors);


                xRootChildElement.Add(xRobot);
            }
            xRoot.Add(xRootChildElement);

            // Maps
            xRootChildElement = new XElement("Maps", "");
            foreach (Map m in rs.Maps)
            {
                XElement xMap = new XElement("Map");
                xMap.SetAttributeValue("id", "M" + m.id.ToString());
                xMap.SetAttributeValue("name", m.map_name);

                XElement xMapChildElement = new XElement("MapData", m.map_data);
                xMap.Add(xMapChildElement);
                xMapChildElement = new XElement("Denivelation", m.denivelation);
                xMap.Add(xMapChildElement);

                xRootChildElement.Add(xMap);
            }
            xRoot.Add(xRootChildElement);

            // Algorithms
            xRootChildElement = new XElement("Algorithms", "");
            foreach (Algorithm a in rs.Algorithms)
            {
                XElement xAlgorithm = new XElement("Algorithm");
                xAlgorithm.SetAttributeValue("id", "A" + a.id.ToString());
                xAlgorithm.SetAttributeValue("name", a.name);
                xAlgorithm.SetAttributeValue("diffEnvironments", a.diffEnvironments);
                xAlgorithm.SetAttributeValue("multipleDestPoints", a.multipleDestPoints);

                XElement xAlgorithmChildElement = new XElement("Complexity", a.complexity);
                xAlgorithm.Add(xAlgorithmChildElement);
                xAlgorithmChildElement = new XElement("Depth", a.depth);
                xAlgorithm.Add(xAlgorithmChildElement);

                xRootChildElement.Add(xAlgorithm);
            }
            xRoot.Add(xRootChildElement);

            // Add the root element to the document
            roboSimulationXml.Add(xRoot);
            // Save the document in the given path(Maybe needed virtual server or such stuff to be the given path, be carefull!)
            roboSimulationXml.Save(filePath);


            //try
            //{
            //    roboSimulationXml.Save(filePath);
            //}
            //catch (Exception e)
            //{
            //    string msg = e.Message; ???
            //}
        }

        #endregion

        #region Insert RoboSimulation object into the DB
        /*insetrs object's data into the DB*/
        public void InsertRoboSimulationToDB(RoboSimulation roboSimulation)
        {
            entities.RoboSimulations.AddObject(roboSimulation);
            entities.SaveChanges();
            // If here is some error - try to stop SQL server(from SQL manager) and start it again...
        }
        #endregion

        #region Insert XML files into the DB
        /*inserts xml files' data into the DB*/
        public void InsertXmlDataToDB(string dir, ref string statusText)
        {
            XMLRoboSimulationProcessor processor = new XMLRoboSimulationProcessor();

            string[] files = Directory.GetFiles(dir, "*.xml", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                try
                {
                    processor.validateDTDFile(file); // IF the file is not valid it throw exeption
                    processor.LoadRoboSimulationFromXMLUsingReader(file);
                    RoboSimulation roboSimulation = processor.RoboSimulation;
                    InsertRoboSimulationToDB(roboSimulation);
                }
                catch (XMLRoboSimulationProcessorException pe)
                {
                    statusText += pe.Message;
                }
            }
        }
        #endregion

        #region Validate XML files
        /*validate the XML files*/
        public void ValidateXMLFiles(string dir, ref string statusText)
        {
            XMLRoboSimulationProcessor processor = new XMLRoboSimulationProcessor();
            string[] byDirPaths;
            string[] files = Directory.GetFiles(dir, "*.xml", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                //statusText += "Валидирам файл [" + file + "] - ";
                byDirPaths = file.Split('\\');
                statusText += "Валидирам файл [" + byDirPaths.Last() + "] - ";
                try
                {
                    processor.validateDTDFile(file);
                    statusText += "валиден!";
                }
                catch (XMLRoboSimulationProcessorException pe)
                {
                    statusText += "не е валиден!\n";
                    statusText += "Грешка: " + pe.Message;
                }
                catch (XmlSchemaValidationException xsve)
                {
                    statusText += "не е валиден!\n";
                    statusText += "Грешка в данните: " + xsve.Message;
                }
                statusText += "\n\n";
            }
        }
        #endregion
        
        #region Delete database records
        /*deletes a the whole database values*/
        public void DeleteDatabaseRecords()
        {
            entities.RoboSimulations.Where(c => c.id >= 0).ToList().ForEach(entities.DeleteObject);
            entities.SaveChanges();
          
        }
        #endregion

    }
}