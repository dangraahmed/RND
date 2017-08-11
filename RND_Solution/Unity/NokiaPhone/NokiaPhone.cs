using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInterfaces;

namespace NokiaPhone
{
    public class NokiaPhone : IPhone
    {
        #region IPhone Members

        public string GetOSType()
        {
            return "Windows";
        }

        #endregion
    }
}
