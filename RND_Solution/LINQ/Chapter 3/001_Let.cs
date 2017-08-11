using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ.SampleData;

namespace LINQ.Chapter_3
{
    class _001_Let
    {
        public static void Main1(string[] arg)
        {
            int[] num = new int[] {10,20,30,40,50,60};

            var variance = from element in num
                           let average = num.Average()
                           select element - average;

            foreach (var c in variance)
            {
                Console.WriteLine("C : " + c.ToString());
            }
            Console.ReadLine();
        }
    }
}
