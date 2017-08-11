using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInterfaces;

namespace LoggingTypes
{
    public class TxtLogging : ILogging
    {

        #region ILogging Members

        public new string GetLoggingType()
        {
            return "Text Logging";
        }

        #endregion
    }
}
