using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ.SampleData;
using LINQ.Common;

namespace LINQ.Chapter_3
{
    class _008_SelectDifferentTypeThenTheSource
    {
        public static void Main1(string[] agru)
        {
            List<Contact> contacts = Contact.SampleData();
            List<CallLog> callLogs = CallLog.SampleData();

            "################ Selecting Using Constructor ################".Output();
            var q = from cont in contacts
                    select new ContactName(cont.FirstName + ", " + cont.LastName, (DateTime.Now - cont.DateOfBirth).Days / 365);
            q.PrintValuesInColumn();
            "".Output();

            "################ Selecting Using Type Initializer syntax ################".Output();
            var q1 = from cont in contacts
                     select new ContactName
                     {
                         FullName = cont.FirstName + ", " + cont.LastName,
                         YearsOfAge = (DateTime.Now - cont.DateOfBirth).Days / 365
                     };
            q1.PrintValuesInColumn();
            "".Output();

            "################ Selecting Using Type Anonymous syntax ################".Output();
            var q2 = from cont in contacts
                     select new
                         {
                             FullName = cont.FirstName + ", " + cont.LastName,
                             YearsOfAge = (DateTime.Now - cont.DateOfBirth).Days / 365
                         };

            q2.PrintValuesInColumn();

            Console.ReadLine();
        }

        private class ContactName
        {
            public string FullName { get; set; }
            public int YearsOfAge { get; set; }

            public ContactName() { }
            public ContactName(string FullName, int YearsOfAge)
            {
                this.FullName = FullName;
                this.YearsOfAge = YearsOfAge;
            }
        }
    }
}
