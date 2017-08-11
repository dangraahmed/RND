using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ.SampleData;
using LINQ.Common;

namespace LINQ.Chapter_3
{
    class _012_Sort
    {
        //How to Sort the Results
        public static void Main1(string[] agru)
        {
            List<Contact> contacts = Contact.SampleData();

            var q = from cn in contacts
                    orderby cn.State descending, cn.FirstName
                    select cn;

            q.PrintValuesInColumn();

            Console.ReadLine();
        }
    }
}
