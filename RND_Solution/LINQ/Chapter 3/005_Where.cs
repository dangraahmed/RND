using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ.SampleData;
using LINQ.Common;

namespace LINQ.Chapter_3
{
    class _005_Where
    {
        public static void Main1(string[] args)
        {
            List<Contact> contacts = Contact.SampleData();
            List<CallLog> callLogs = CallLog.SampleData();

            "************ Output using Extension Method ************".Output();

            var q = contacts.Where(con => con.FirstName.StartsWith("A") && con.FirstName.Length <= 5)
                            .Select(con => new
                                                {
                                                    con.FirstName,
                                                    con.LastName
                                                });

            q.PrintValuesInColumn();

            "".Output();
            "************ Output using Query Method ************".Output();

            var q1 = from con in contacts
                     where con.FirstName.StartsWith("A")
                     select new 
                     { 
                        con.FirstName,
                        con.LastName
                     };

            q1.PrintValuesInColumn();

            "".Output();
            "************ Output using Query Method & Using an External Method for Evaluation ************".Output();

            var q2 = from con in contacts
                     where whereCondition(con)
                     select new 
                     { 
                        con.FirstName,
                        con.LastName
                     };

            q2.PrintValuesInColumn();
            
            Console.ReadLine();
        }

        private static bool whereCondition(Contact a)
        {
            if(a.FirstName.StartsWith("A") && a.LastName.Contains("a"))
                return true;
            else
                return false;

        }
    }
}
