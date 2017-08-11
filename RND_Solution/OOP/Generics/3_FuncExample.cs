using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Generics
{

    class _3_FuncExample
    {
        public static TResult RunTheMethod<T, TResult>(Func<T, TResult> pluginFunction, T parameter)
        {
            return pluginFunction(parameter);
        }

        public static string Method1(string input)
        {
            //... do something
            return "Method1 " + input;
        }

        public static string Method2(string input)
        {

            return "Method2 " + input;
        }

        public static int Method3(int input1)
        {

            return 100 + input1;
        }

        public static int Method4(int input1, int input2)
        {

            return 100 + input1 + input2;
        }

        public static int Method4(int[] input1)
        {

            return 100 + input1[0] + input1[1];
        }

        public static void Main1(string[] args)
        {
            Console.WriteLine(RunTheMethod(Method1, "okok"));
            Console.WriteLine(RunTheMethod(Method2, "okok"));
            Console.WriteLine(RunTheMethod(Method3, 100));
            //Console.WriteLine(RunTheMethod(Method4, 100));

            int[] okInts = { 100, 200 };

            Console.Read();
        }
    }
}
