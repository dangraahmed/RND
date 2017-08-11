using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ.SampleData;

namespace LINQ.Chapter_3
{
    class _002_Into
    {
        public static void Main1(string[] args)
        {
            List<Contact> contacts = Contact.SampleData();

            var selContacts = from c in contacts
                              group c by c.State into groups
                              select new
                              {
                                  key = groups.Key,
                                  count = groups.Count()
                              };

            foreach (var c in selContacts)
            {
                Console.WriteLine("State : " + c.key);
                Console.WriteLine("Count : " + c.count);
            }

            Console.ReadLine();
        }
    }
}
