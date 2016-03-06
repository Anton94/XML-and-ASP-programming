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
    class Program
    {
        static ASP_programmingEntities entities;
        

        public static void Init()
        {
            entities = new ASP_programmingEntities();
        }

        #region insert robo simulation into the DB
        /*insetrs object's data into the DB*/
        public static void InsertRoboSimulationToDB(RoboSimulation roboSimulation)
        {
            entities.RoboSimulations.AddObject(roboSimulation);
            entities.SaveChanges();
        }
        #endregion

        #region insert XML into the DB
        /*inserts xml files' data into the DB*/
        public static void InsertXmlDataToDB(string dir)
        {
            XMLRoboSimulationProcessor processor = new XMLRoboSimulationProcessor();
            //XMLProcessorLINQ processor = new XMLProcessorLINQ();

            string[] files = Directory.GetFiles(dir, "*.xml", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                //try
                {
                    processor.LoadBookstoreFromXMLUsingReader(file);
                    RoboSimulation roboSimulation = processor.RoboSimulation;
                    InsertRoboSimulationToDB(roboSimulation);
                }
                //catch (XMLBookstoreProcessorException pe)
                {
                    //Console.WriteLine(pe.Message);
                }
            }
        }
        #endregion



        #region delete database records
        /*deletes a the whole database values*/
        public static void DeleteDatabaseRecords()
        {
            entities.RoboSimulations.Where(c => c.id >= 0).ToList().ForEach(entities.DeleteObject);
            entities.Environments.Where(c => c.id >= 0).ToList().ForEach(entities.DeleteObject);
           // entities.
            entities.SaveChanges();
          
        }
        #endregion
        


        //The Main method
        public static void Main(string[] args)
        {
            string DirPath = @"\resources\";
            entities = new ASP_programmingEntities();
         

            /*inserts xml files' data into the DB*/
            //try
            //{
             InsertXmlDataToDB(DirPath);
             Console.WriteLine("Success");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.InnerException.Message);
            //}

            /* Updates a bookstore*/
            //try
            //{
            //    UpdateBookstore(entities);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.InnerException.Message);
            //}

            /*deletes a bookstore*/
            //try
            //{
            //    DeleteBookstore(entities);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.InnerException.Message);
            //}

            /*prints bookstores*/
            //try
            //{
            //    ShowsBookstores(entities);
            //    ShowsBookstoresMethods(entities);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.InnerException.Message);
            //}

            /*prints working times*/
            //try
            //{
            //    ShowsWorkingTime(entities);
            //    ShowsWorkingTimeMethods(entities);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.InnerException);
            //}

            /*prints books*/
            //try
            //{
            //    ShowsBooks(entities);
            //    ShowsBooksMethods(entities, "2");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.InnerException);
            //}


            //TODO: change the source to yours server name
            //SqlConnection connection = new SqlConnection(@"Data Source=DICHO-PC\MSSQLEXPRESS;
             //                               Initial Catalog=Bookstores;Integrated Security=True");
            /*win auth
              remote connection
              User ID=someUserName; Password=somePassword;
             */

            /*prints bookstores*/
            //try
            //{
            //   PrintBookstoresDisconnected(connection);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.InnerException);
            //}

            /*prints bookstore's books*/
            //try
            //{
            //    PrintBookstoreBooksDisconnected(connection,"2");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.InnerException);
            //}
        }

    }
}