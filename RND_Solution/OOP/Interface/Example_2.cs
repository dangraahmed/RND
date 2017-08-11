using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Interface
{
    public interface IAdd1
    {
        int Add(int one, int two);

    }

    public interface IAdd2
    {
        int Add(int one, int two);

    }

    public class UseInterface : IAdd1, IAdd2
    {

        #region IAdd1 Members

        public int Add(int one, int two)
        {
            Console.WriteLine("IAdd1.Add: " + (one + two));
            return one + two;
        }

        #endregion

        #region IAdd2 Members

        int IAdd2Add(int one, int two)
        {
            Console.WriteLine("IAdd2.Add: " + (one + two));
            return one + two;
        }

        #endregion
    }

    public class Example_2
    {

        public static void Main1(string[] args)
        {
            IAdd1 obj1 = new UseInterface();

            obj1.Add(1, 2);

            IAdd2 obj2 = new UseInterface();

            obj2.Add(1, 2);

            Console.ReadLine();
        }
    }
}
