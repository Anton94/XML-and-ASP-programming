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

namespace xmlToSql
{
    class Utility
    {
        private ASP_programmingEntities1 entities;
        
        public Utility()
        {

            entities = new ASP_programmingEntities1();
        }

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

        #region insert robo simulation into the DB
        /*insetrs object's data into the DB*/
        public void InsertRoboSimulationToDB(RoboSimulation roboSimulation)
        {
            entities.RoboSimulations.AddObject(roboSimulation);
            entities.SaveChanges();
        }
        #endregion

        #region insert XML into the DB
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


        #region validate XML files
        /*validate the XML files*/
        public static void ValidateXMLFiles(string dir, ref string statusText)
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
        
        #region delete database records
        /*deletes a the whole database values*/
        public void DeleteDatabaseRecords()
        {
            entities.RoboSimulations.Where(c => c.id >= 0).ToList().ForEach(entities.DeleteObject);
            entities.Environments.Where(c => c.id >= 0).ToList().ForEach(entities.DeleteObject);
           // entities.
            entities.SaveChanges();
          
        }
        #endregion
        


       

    }
}