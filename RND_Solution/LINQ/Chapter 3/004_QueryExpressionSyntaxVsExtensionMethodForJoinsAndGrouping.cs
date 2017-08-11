using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ.SampleData;
using LINQ.Common;

namespace LINQ.Chapter_3
{
    class _004_QueryExpressionSyntaxVsExtensionMethodForJoinsAndGrouping
    {
        public static void Main1(string[] args)
        {
            List<Contact> contacts = Contact.SampleData();
            List<CallLog> callLogs = CallLog.SampleData();

            "************ Output using Extension Method ************".Output();

            var q = callLogs.Join(contacts,
                                    call=>call.Number,
                                    contact=>contact.Phone,
                                    (call, contact) => new
                                    {
                                        contact.FirstName,
                                        contact.LastName,
                                        call.When,
                                        call.Duration
                                    }).OrderBy(call=> call.When).Take(5);

            q.PrintValuesInRows();

            "".Output();
            "".Output();
            "************ Output using Query Method ************".Output();

            var q1 = (from call in callLogs
                      join contact in contacts
                      on call.Number equals contact.Phone
                      orderby call.When
                      select new
                      {
                          contact.FirstName,
                          contact.LastName,
                          call.When,
                          call.Duration
                      }).Take(5);

            q1.PrintValuesInRows();
            Console.ReadLine();
        }
        
    }
}
