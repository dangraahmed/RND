using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Interface
{
    public interface IntClass1
    {
        int ook { get; set; }
        int add();
    }

    public interface IntClass2 : IntClass1
    {
        //public abstract int add();
        int add();
    }

    class Example_1 : IntClass2
    {
        #region IntClass2 Members

        public int add()
        {
            throw new NotImplementedException();
        }

        public int ook { get; set; }

        #endregion

    //    public static void main(String args[])
    //    {
            
    //    }
    }
}
