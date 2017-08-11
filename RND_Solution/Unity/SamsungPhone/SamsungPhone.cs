using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInterfaces;

namespace SamsungPhone
{
    public class SamsungPhone : IPhone
    {

        #region IPhone Members

        public string GetOSType()
        {
            return "Android";
        }

        #endregion
    }
}
