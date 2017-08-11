using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ.SampleData;
using LINQ.Common;

namespace LINQ.Chapter_3
{
    class _013_Reversing
    {
        //Reversing the Order of a Result Sequence (Reverse)
        public static void Main1(string[] agru)
        {
            List<Contact> contacts = Contact.SampleData();

            var q = contacts[0].FirstName.Reverse();

            foreach (char a in q)
            {
                Console.WriteLine(a);
            }

            Console.ReadLine();
        }
    }
}
