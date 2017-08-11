using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ.SampleData;
using LINQ.Common;

namespace LINQ.Chapter_4
{
    class _001_Group
    {
        public static void Main(string[] agru)
        {
            List<Contact> contacts = Contact.SampleData();

            var q = from con in contacts
                    group con by con.State;

            var q1 = contacts.GroupBy(con=>con.State);

            contacts.PrintValuesInColumn();

            q.PrintValuesInColumn();
            q1.PrintValuesInColumn();

            var ok = "".Input();
            
            Console.Read();


            
        }
    }
}
