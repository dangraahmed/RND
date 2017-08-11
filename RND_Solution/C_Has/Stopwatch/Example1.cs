using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diog = System.Diagnostics;

namespace C_Has.Stopwatch
{
    class Example1
    {
        public static void Main1(string[] args)
        {
            Diog.Stopwatch sw = new Diog.Stopwatch();
            sw.Start();
            for (int i = 0; i <= 1000000000; i++)
            { 
            
            }
            sw.Stop();

            Console.WriteLine(String.Format("Elapsed time: {0} Days", sw.Elapsed.Days));
            Console.WriteLine(String.Format("Elapsed time: {0} Hours", sw.Elapsed.Hours));
            Console.WriteLine(String.Format("Elapsed time: {0} Milliseconds", sw.Elapsed.Milliseconds));
            Console.WriteLine(String.Format("Elapsed time: {0} Minutes", sw.Elapsed.Minutes));
            Console.WriteLine(String.Format("Elapsed time: {0} Seconds", sw.Elapsed.Seconds));
            Console.WriteLine(String.Format("Elapsed time: {0} Ticks", sw.Elapsed.Ticks));
            Console.WriteLine(String.Format("Elapsed time: {0} TotalDays", sw.Elapsed.TotalDays));
            Console.WriteLine(String.Format("Elapsed time: {0} TotalHours", sw.Elapsed.TotalHours));
            Console.WriteLine(String.Format("Elapsed time: {0} TotalMilliseconds", sw.Elapsed.TotalMilliseconds));
            Console.WriteLine(String.Format("Elapsed time: {0} TotalMinutes", sw.Elapsed.TotalMinutes));
            Console.WriteLine(String.Format("Elapsed time: {0} TotalSeconds", sw.Elapsed.TotalSeconds));


            Console.Read();
 
        }
    }
}
