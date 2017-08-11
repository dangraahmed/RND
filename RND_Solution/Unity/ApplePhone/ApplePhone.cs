using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInterfaces;

namespace ApplePhone
{
    public class ApplePhone : IPhone
    {
        public ApplePhone(ILogging logging)
        {

        }

        #region IPhone Members

        public string GetOSType()
        {
            return "iOS";
        }

        #endregion
    }
}
