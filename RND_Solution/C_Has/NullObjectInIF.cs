using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_Has
{
    class testing
    {
        public string str { get; set; }
    }
    class NullObjectInIF
    {
        public static void Main1(string[] args)
        {
            try
            {
                List<testing> oobj = null;
                testing obj = null;
                if (obj != null & obj.str == "")
                {

                }
            }
            catch (Exception ex)
            { 
            
            }
        }
    }

    

}
