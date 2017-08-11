using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ.SampleData;
using LINQ.Common;

namespace LINQ.Chapter_3
{
    class _003_QueryExpressionSyntaxVsExtensionMethod
    {
        public static void Main1(string[] args)
        {
            List<Contact> contacts = Contact.SampleData();

            "****************Output Using Query Expression****************".Output();
            var q = contacts.Where(c => c.State == "WA")
                            .OrderBy(c => c.FirstName)
                            .ThenByDescending(c => c.LastName);

            q.PrintValuesInColumn();

            "".Output();
            "".Output();
            "****************Output Using Extension Method****************".Output();

            var q1 = from c in contacts
                    where c.State == "WA"
                     orderby c.FirstName , c.LastName descending
                    select c;

            q1.PrintValuesInColumn();

            Console.ReadLine();
        }
    }
}
