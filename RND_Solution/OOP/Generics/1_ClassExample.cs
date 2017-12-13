using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Generics
{
    public class GenericsList<T>
    {
        public void Add(T input)
        {
            Console.WriteLine("Type of This Class Is : " + input.GetType() + " " + this.GetType());
        }
        public void Add()
        {
            Console.WriteLine("Type of This Class Is : " + this.GetType());
        }
    }

    class _1_ClassExample
    {
        public static void Main(string[] args)
        { 
            GenericsList<int> objInt = new GenericsList<int>();
            GenericsList<string> objStr = new GenericsList<string>();
            GenericsList<_1_ClassExample> objExa = new GenericsList<_1_ClassExample>();

            objInt.Add();
            objInt.Add(10);

            objStr.Add();
            objStr.Add("10");

            objExa.Add();
            objExa.Add(new _1_ClassExample());

            Console.ReadLine();
        }
    }
}
