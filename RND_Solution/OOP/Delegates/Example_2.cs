using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Delegates
{
    public delegate void MultiDelegate(int a, int b);
    public class Sampleclass
    {
        public static void Add(int x, int y)
        {
            Console.WriteLine("Addition Value: " + (x + y));
        }
        public static void Sub(int x, int y)
        {
            Console.WriteLine("Subtraction Value: " + (x - y));
        }
        public static void Mul(int x, int y)
        {
            Console.WriteLine("Multiply Value: " + (x * y));
        }
    }
    
    class Example_2
    {
        static void Main1(string[] args)
        {
            Sampleclass sc = new Sampleclass();
            MultiDelegate del = Sampleclass.Add;
            del += Sampleclass.Sub;
            del += Sampleclass.Mul;
            del(10, 5);
            Console.ReadLine();
        }
    }
}
