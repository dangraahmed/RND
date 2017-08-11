using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Interface
{
    public interface IAdding1
    {
        int Add(int one, int two);

    }

    public interface IAdding2
    {
        int Add(int one, int two);

    }

    public class FirstClass : IAdding1, IAdding2
    {

        #region IAdding2 Members

        int IAdding2.Add(int one, int two)
        {
            Console.WriteLine("IAdding2.Add: " + (one + two));
            return one + two;
        }

        #endregion

        #region IAdding1 Members

        int IAdding1.Add(int one, int two)
        {
            Console.WriteLine("IAdding1.Add: " + (one + two));
            return one + two;
        }

        #endregion
    }

    public class SecondClass : IAdding1, IAdding2
    {

        public int Add(int one, int two)
        {
            Console.WriteLine("Add: " + (one + two));
            return one + two;
        }
    }

    public class Example_3
    {
        public static void Main1(string[] args)
        {
            FirstClass objFirstClass = new FirstClass();
            SecondClass objSecondClass = new SecondClass();

            ((IAdding1)objFirstClass).Add(1, 2);
            ((IAdding2)objFirstClass).Add(1, 2);

            ((IAdding1)objSecondClass).Add(1, 2);
            ((IAdding2)objSecondClass).Add(1, 2);

            objSecondClass.Add(1, 2);

            Console.ReadLine();

        }


    }
}
