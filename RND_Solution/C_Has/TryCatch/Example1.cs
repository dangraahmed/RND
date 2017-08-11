using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_Has.TryCatch
{
    class Example1
    {
        public static void Main1(string[] ars)
        {
            try
            {
                Console.WriteLine("Befor Exception");
                int zer = 0;
                int ok = 10/zer;

                Console.WriteLine("After Exception");
            }
            finally 
            {
                Console.WriteLine("Finally");
            }
        }
    }
}
