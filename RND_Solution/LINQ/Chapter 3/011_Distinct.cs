using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ.SampleData;
using LINQ.Common;

namespace LINQ.Chapter_3
{
    class _011_Distinct
    {
        //How to Remove Duplicate Results

        public static void Main1(string[] agru)
        {
            List<Contact> contacts = Contact.SampleData();

            var q = (from m in contacts
                     //select m.FirstName.Substring(0, 1)).Distinct();
                     select m.FirstName.Substring(0, 1));

            //foreach (var arr in q)
            foreach (var arr in q.Distinct())
            {
                arr.Output();
            }



            string[] names = new string[] { "Peter", "Paul", "Mary", "Peter", "Paul", "Mary", "Janet" };

            var q1 = (from s in names
                      where s.Length > 3
                      select s).Distinct();

            foreach (var name in q1)
            {
                name.Output();
            }

            Console.ReadLine();
        }
    }
}
