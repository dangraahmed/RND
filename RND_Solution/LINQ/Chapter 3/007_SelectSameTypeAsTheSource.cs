using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ.SampleData;
using LINQ.Common;

namespace LINQ.Chapter_3
{
    class _007_SelectSameTypeAsTheSource
    {
        public static void Main1(string[] agru)
        {
            List<Contact> contacts = Contact.SampleData();
            List<CallLog> callLogs = CallLog.SampleData();

            IEnumerable<Contact> q = from cont in contacts
                                     orderby cont.State, cont.FirstName descending
                                     select cont;

            q.PrintValuesInColumn();
            q.PrintValuesInRows();

            Console.ReadLine();
        }
    }
}
