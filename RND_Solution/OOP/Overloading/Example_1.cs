using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Overloading
{
    public class Example_1
    {
        public static void Main1(string[] args)
        { 
            SampleClass obj = new SampleClass();
            int ok = obj.MethodName("o");

            Console.ReadLine();
        }

        
    }

    public class SampleClass
    {
        public string MethodName(int o1)
        {
            Console.Write("string MethodName");
            return "ok";
        }

        public int MethodName(string s1)
        {
            Console.Write("int MethodName");
            return 0;
        }
    }
}
