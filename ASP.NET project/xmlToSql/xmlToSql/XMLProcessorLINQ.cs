using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace xmlToSql
{
    public class XMLProcessorLINQ
    {
        private RoboSimulation roboSimulation;
        private XElement xRoboSimulation;

        public void LoadFile(String file)
        {
            xRoboSimulation = XElement.Load(file);
        }

        private void InitRoboSimulation()
        {
            IEnumerable<XAttribute> attributes = from node in xRoboSimulation.Attributes()
                                                 select node;
            string id = null;
            foreach (var item in attributes)
            {
                if (item.Name == RoboSimulationElements.ROBOSIMULATION_ID) id = item.Value;
            }

            id.Remove(0, 1);

            this.roboSimulation = new RoboSimulation();
            this.roboSimulation.id = Int32.Parse(id);
        }

        private void SetRoboSimulatuin()
        {
            IEnumerable<XElement> simulationNameElements = from node in xRoboSimulation.Elements(RoboSimulationElements.ROOT_ELEMENT).Single(s => true).Elements()
                                                    select node;
            foreach (var item in simulationNameElements)
            {
                switch (item.Name.ToString())
                {
                    case "SimulationName":
                        roboSimulation.simulation_name = item.Value;
                        break;
                    case "SimulationOwner":
                        roboSimulation.simulation_owner = item.Value;
                        break;
                    case "SimulationOwnerEmail":
                        roboSimulation.simulation_owner_email = item.Value;
                        break;
                }
            }
        }
        /*
        private void SetPhone()
        {
            IEnumerable<XElement> phones = from node in xBookstore.Elements(BookstoreElements.BOOKSTORE_PHONE)
                                           select node;
            XElement p = phones.Single();
            bookstore.phone_number = p.Value;
            bookstore.phone_code = p.Attribute(BookstoreElements.BOOKSTORE_CODE).Value;
        }
        private void SetEmail()
        {
            IEnumerable<XElement> emails = from node in xBookstore.Elements(BookstoreElements.BOOKSTORE_EMAIL)
                                           select node;

            XElement e = emails.Single();
            bookstore.email = e.Value;
        }
        private void SetManager()
        {
            IEnumerable<XElement> managers = from node in xBookstore.Elements(BookstoreElements.BOOKSTORE_MANAGER)
                                             select node;

            XElement m = managers.Single();
            bookstore.Managers = new Managers
            {
                firstname = m.Attribute(BookstoreElements.BOOKSTORE_FIRST_NAME).Value,
                lastname = m.Attribute(BookstoreElements.BOOKSTORE_LAST_NAME).Value
            };
        }

        private void SetWorkingHours()
        {
            IEnumerable<XElement> hours = from node in xBookstore.Elements(BookstoreElements.BOOKSTORE_WORKING_HOURS)
                                          select node;
            XElement hour = hours.Single();
            // bookstore.WorkingDays = new System.Data.Objects.DataClasses.EntityCollection<WorkingDays>();
            try
            {
                bookstore.WorkingDays.Add(new WorkingDays()
                {
                    name = "Понеделник",
                    fromH = hour.Element("monday").Element(BookstoreElements.BOOKSTORE_FROM).Value,
                    toH = hour.Element("monday").Element(BookstoreElements.BOOKSTORE_TO).Value
                });
            }
            catch (Exception) { }
            try
            {
                bookstore.WorkingDays.Add(new WorkingDays()
                {
                    name = "Вторник",
                    fromH = hour.Element("tuesday").Element(BookstoreElements.BOOKSTORE_FROM).Value,
                    toH = hour.Element("tuesday").Element(BookstoreElements.BOOKSTORE_TO).Value
                });
            }
            catch (Exception) { }
            try
            {
                bookstore.WorkingDays.Add(new WorkingDays()
                {
                    name = "Сряда",
                    fromH = hour.Element("wednesday").Element(BookstoreElements.BOOKSTORE_FROM).Value,
                    toH = hour.Element("wednesday").Element(BookstoreElements.BOOKSTORE_TO).Value
                });
            }
            catch (Exception)
            {

            }
            try
            {
                bookstore.WorkingDays.Add(new WorkingDays()
                {
                    name = "Четвъртък",
                    fromH = hour.Element("thursday").Element(BookstoreElements.BOOKSTORE_FROM).Value,
                    toH = hour.Element("thursday").Element(BookstoreElements.BOOKSTORE_TO).Value
                });
            }
            catch (Exception)
            {

            }
            try
            {
                bookstore.WorkingDays.Add(new WorkingDays()
                {
                    name = "Петък",
                    fromH = hour.Element("friday").Element(BookstoreElements.BOOKSTORE_FROM).Value,
                    toH = hour.Element("friday").Element(BookstoreElements.BOOKSTORE_TO).Value
                });
            }
            catch (Exception)
            {

            }
            try
            {
                bookstore.WorkingDays.Add(new WorkingDays()
                {
                    name = "Събота",
                    fromH = hour.Element("saturday").Element(BookstoreElements.BOOKSTORE_FROM).Value,
                    toH = hour.Element("saturday").Element(BookstoreElements.BOOKSTORE_TO).Value
                });
            }
            catch (Exception)
            {

            }
            try
            {
                bookstore.WorkingDays.Add(new WorkingDays()
                {
                    name = "Неделя",
                    fromH = hour.Element("sunday").Element(BookstoreElements.BOOKSTORE_FROM).Value,
                    toH = hour.Element("sunday").Element(BookstoreElements.BOOKSTORE_TO).Value
                });
            }
            catch (Exception)
            {

            }

        }
        private void SetBooks()
        {
            IEnumerable<XElement> books = from node in xBookstore.Element(BookstoreElements.BOOKSTORE_BOOKS)
                                              .Elements(BookstoreElements.BOOKSTORE_BOOK)
                                          select node;

            Books book = null;
            foreach (var item in books)
            {
                book = new Books();
                book.isbn = item.Attribute(BookstoreElements.BOOKSTORE_ISBN).Value;
                book.title = item.Element(BookstoreElements.BOOKSTORE_TITLE).Value;
                book.author = item.Element(BookstoreElements.BOOKSTORE_AUTHOR).Value;
                book.publisher = item.Element(BookstoreElements.BOOKSTORE_PUBLISHER).Value;
                book.language = item.Element(BookstoreElements.BOOKSTORE_LANGUAGE).Value;
                book.year = item.Element(BookstoreElements.BOOKSTORE_YEAR).Value;
                XElement price = item.Element(BookstoreElements.BOOKSTORE_PRICE);
                book.currency = price.Attribute(BookstoreElements.BOOKSTORE_CURRENCY).Value;
                try
                {
                    book.e_price = Decimal.Parse(price.Attribute(BookstoreElements.BOOKSTORE_E_PRICE).Value.Replace('.', ','));
                }
                catch (Exception) { }

                book.price = Decimal.Parse(price.Value.Replace('.', ','));

                bookstore.Books.Add(book);
            }
        }

        public Bookstores GetBookstore()
        {
            InitBookstore();
            SetAddress();
            SetPhone();
            SetEmail();
            SetManager();
            SetWorkingHours();
            SetBooks();
            if (bookstore != null)
            {
                return this.bookstore;
            }
            else
            {
                throw new XMLBookstoreProcessorException("the bookstote is null");
            }
        }
         * 
         * */
    }
}