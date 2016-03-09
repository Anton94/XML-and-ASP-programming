using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xmlToSql
{
    class XMLRoboSimulationProcessorException : Exception
    {
        public XMLRoboSimulationProcessorException(string msg) : base(msg) { }
    }
}

