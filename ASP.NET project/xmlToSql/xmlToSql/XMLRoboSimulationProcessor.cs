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
        private XmlNode node;
        private string path;

        private string _GetNodeValue(XmlNode fromNode, string xPath)
        {
            return fromNode.SelectSingleNode(xPath).InnerText;
        }

        private string _GetAttributeValue(XmlNode fromNode, string xPath, string attribute)
        {
            return fromNode.SelectSingleNode(xPath).Attributes[attribute].Value;
        }
        /*
        private void _LoadXML(string path)
        {
            this.xml.Load(path);
        }

        private void _InitBookstore()
        {
            this.roboSimulation = new RoboSimulation();
            node = xml.SelectSingleNode(RoboSimulationElements.ROOT_ELEMENT_XPATH);
            string id = node.Attributes[RoboSimulationElements.ROBOSIMULATION_ID].Value;
            id.Remove(0, 1);
            this.roboSimulation.id = Int32.Parse(id);

        }
        /*
        private void _GetAddress()
        {
            this.bookstore.city = _GetNodeValue(node, BookstoreElements.BOOKSTORE_CITY_XPATH);
            this.bookstore.postal_code = _GetAttributeValue(node, BookstoreElements.BOOKSTORE_CITY_XPATH, BookstoreElements.BOOKSTORE_POSTAL_CODE);
            this.bookstore.street = _GetNodeValue(node, BookstoreElements.BOOKSTORE_ADDRESS_XPATH + "/" + BookstoreElements.BOOKSTORE_STR);
            this.bookstore.str_number = _GetNodeValue(node, BookstoreElements.BOOKSTORE_ADDRESS_XPATH + "/" + BookstoreElements.BOOKSTORE_NUMBER);

            try
            {
                this.bookstore.note = _GetNodeValue(node, BookstoreElements.BOOKSTORE_ADDRESS_XPATH + "/" + BookstoreElements.BOOKSTORE_NOTE);
            }
            catch (NullReferenceException nre)
            {
                this.bookstore.note = null;
            }
        }

        private void _GetPhone()
        {
            this.bookstore.phone_number = _GetNodeValue(node, BookstoreElements.BOOKSTORE_PHONE_XPATH);
            this.bookstore.phone_code = _GetAttributeValue(node, BookstoreElements.BOOKSTORE_PHONE_XPATH, BookstoreElements.BOOKSTORE_CODE);

        }
        */
        private void _GetSimulationName()
        {
            this.roboSimulation.simulation_name = _GetNodeValue(node, RoboSimulationElements.ROBOSIMULATION_NAME_XPATH);
        }

        private void _GetSimulationOwner()
        {
            this.roboSimulation.simulation_owner = _GetNodeValue(node, RoboSimulationElements.ROBOSIMULATION_OWNER_XPATH);
        }
        private void _GetSimulationOwnerEmail()
        {
            this.roboSimulation.simulation_owner_email = _GetNodeValue(node, RoboSimulationElements.ROBOSIMULATION_OWNEREMAIL_XPATH);
        }

        /*
        private void _GetManager()
        {
            this.bookstore.Managers = new Managers()
            {
                firstname = _GetAttributeValue(node, BookstoreElements.BOOKSTORE_MANAGER_XPATH, BookstoreElements.BOOKSTORE_FIRST_NAME),
                lastname = _GetAttributeValue(node, BookstoreElements.BOOKSTORE_MANAGER_XPATH, BookstoreElements.BOOKSTORE_LAST_NAME)
            };
        }

        private WorkingDays DayWorkingTime(XmlNode n)
        {
            WorkingDays day = new WorkingDays();
            switch (n.Name.ToString())
            {
                case "monday":
                    day.name = "Понеделник";
                    break;
                case "tuesday":
                    day.name = "Вторник";
                    break;
                case "wednesday":
                    day.name = "Сряда";
                    break;
                case "thursday":
                    day.name = "Четвъртък";
                    break;
                case "friday":
                    day.name = "Петък";
                    break;
                case "saturday":
                    day.name = "Събота";
                    break;
                case "sunday":
                    day.name = "Неделя";
                    break;
            }
            try
            {
                node = n.SelectSingleNode(BookstoreElements.BOOKSTORE_WORKING_HOURS_XPATH + "/" + n.Name + "/" +
                    BookstoreElements.BOOKSTORE_FROM);
                day.fromH = node.InnerText;
            }
            catch (NullReferenceException nre)
            {
                day.fromH = null;
            }
            try
            {
                node = n.SelectSingleNode(BookstoreElements.BOOKSTORE_WORKING_HOURS_XPATH + "/" + n.Name + "/" +
                    BookstoreElements.BOOKSTORE_TO);
                day.toH = node.InnerText;
            }
            catch (NullReferenceException nre)
            {
                day.toH = null;
            }
            return day;
        }
        private void _GetWorkingHours()
        {
            node = xml.SelectSingleNode(BookstoreElements.BOOKSTORE_WORKING_HOURS_XPATH);
            foreach (XmlNode n in node.ChildNodes)
            {
                bookstore.WorkingDays.Add(this.DayWorkingTime(n));
            }
        }

        private Books GetBook(XmlNode n)
        {
            Books book = new Books();
            book.isbn = n.Attributes[BookstoreElements.BOOKSTORE_ISBN].Value;
            XmlNodeList list = n.ChildNodes;
            foreach (XmlNode nod in list)
            {
                switch (nod.Name.ToString())
                {
                    case "title":
                        book.title = nod.InnerText;
                        break;
                    case "author":
                        book.author = nod.InnerText;
                        break;
                    case "publisher":
                        book.publisher = nod.InnerText;
                        break;
                    case "language":
                        book.language = nod.InnerText;
                        break;
                    case "year":
                        book.year = nod.InnerText;
                        break;
                    case "price":
                        book.price = Decimal.Parse(nod.InnerText.Replace('.', ','));
                        book.currency = nod.Attributes[BookstoreElements.BOOKSTORE_CURRENCY].Value;
                        XmlAttribute attr = nod.Attributes[BookstoreElements.BOOKSTORE_E_PRICE];
                        if (attr != null)
                            book.e_price = Decimal.Parse(attr.Value.Replace('.', ','));
                        else book.e_price = null;
                        break;
                }
            }
            return book;
        }

        private void _GetBooks()
        {
            XmlNodeList booksNodes = xml.GetElementsByTagName(BookstoreElements.BOOKSTORE_BOOK);
            foreach (XmlNode n in booksNodes)
            {

                bookstore.Books.Add(this.GetBook(n));
            }
        }
        
        */
        /*
        public bool LoadBookstoreFromXML(string path)
        {
            try
            {
                //XMLValidator val = new XMLValidator();
               // val.Validate(path);

                this.path = path;

                _LoadXML(path);
                _InitBookstore();
                _GetSimulationName();
                _GetSimulationOwner();
                _GetSimulationOwnerEmail();
               // _GetAddress();
                //_GetPhone();
                //_GetEmail();
                //_GetManager();
               // _GetWorkingHours();
                //_GetBooks();
            }
            catch (Exception e)
            {
                //throw new XMLBookstoreProcessorException(e.Message);
            }
            return true;
        }
        */
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
        
        // TO DO USE THIS SHIT
        //reader using
        public bool LoadBookstoreFromXMLUsingReader(string path)
        {
            this.path = path;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.DTD;
            settings.DtdProcessing = DtdProcessing.Parse;


            RoboSimulation rs = null;
            //WorkingDays wh = null;
            //Books book = null;
            Environment en = null;

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
                                break;
                            case "SimulationName":
                                rs.simulation_name = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "SimulationOwner":
                                rs.simulation_owner = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "SimulationOwnerEmail":
                                rs.simulation_owner_email = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "Environment":
                                en = new Environment();
                                en.name = reader.GetAttribute(RoboSimulationElements.ROBOSIMULATION_ENVIRONMENT_NAME);
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
                                rs.Environments.Add(en);
                                break;
                               
                        }

                }
                reader.Close();
            }
            catch (Exception e)
            {
               // throw new XMLBookstoreProcessorException(e.Message);
            }
            this.roboSimulation = rs;
            return true;
        }
    }
}
