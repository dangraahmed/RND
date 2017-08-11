using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInterfaces;

namespace LoggingTypes
{
    public class DBLogging : ILogging
    {
        #region ILogging Members

        public new string GetLoggingType()
        {
            return "Database Logging";
        }

        #endregion
    }
}
