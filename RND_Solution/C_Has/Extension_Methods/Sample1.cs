using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_Has.Extension_Methods
{
    public static class MyStringExtensions
    {
        public static string CreateHyperlink(this string text, string toUTL)
        { 
            return String.Format("<a href='{0}'>{1}</a>", toUTL, text);
        }
    }

    public class Sample1
    {
        public static void Main1(string[] args)
        {
            string testing = "Ahmed";
            Console.WriteLine(testing.CreateHyperlink("ok.aspx"));

            Console.ReadLine();
        }
    }
}
