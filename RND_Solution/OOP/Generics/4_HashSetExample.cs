using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Generics
{
    public class _4_HashSetExample
    {
        public static void Main1(string[] agrs)
        {
            HashSet<string> hasSet = new HashSet<string>();
            hasSet.Add("Ahmed");
            hasSet.Add("Dangra");
            hasSet.Add("Ahmed");


            Console.WriteLine(hasSet.Contains("Ahmed1"));
            Console.ReadLine();
        }
    }
}
