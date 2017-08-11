using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_Has.Operator
{
    public class And
    {
        public static void Main1(string[] agrs)
        {
            // Each method displays a message and returns a Boolean value. 
            // Method1 returns false and Method2 returns true. When & is used,
            // both methods are called. 
            Console.WriteLine("Regular AND:");
            if (Method1() & Method2())
                Console.WriteLine("Both methods returned true.");
            else
                Console.WriteLine("At least one of the methods returned false.");

            // When && is used, after Method1 returns false, Method2 is 
            // not called.
            Console.WriteLine("\nShort-circuit AND:");
            if (Method1() && Method2())
                Console.WriteLine("Both methods returned true.");
            else
                Console.WriteLine("At least one of the methods returned false.");

            Console.ReadLine();
        }

        static bool Method1()
        {
            Console.WriteLine("Method1 called.");
            return false;
        }

        static bool Method2()
        {
            Console.WriteLine("Method2 called.");
            return true;
        }
    }
}
