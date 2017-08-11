using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ.SampleData;
namespace LINQ.Chapter_1
{
    class Listing_1_1
    {
        public static void Main1(string[] args)
        {
            List<Contact> contacts = Contact.SampleData();

            var query = from c in contacts
                        orderby c.State, c.LastName
                        group c by c.State;

            foreach (var group in query)
            {
                Console.WriteLine("State : " + group.Key);
                foreach (Contact c in group)
                {
                    Console.WriteLine(" {0} {1} ", c.FirstName, c.LastName);
                }
            }
            Console.ReadLine();
        }
    }
}
