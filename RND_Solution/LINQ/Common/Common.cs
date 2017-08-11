using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ.SampleData;
using System.Reflection;

namespace LINQ.Common
{
    public static class Common
    {
        public static void Output(this string Message)
        {
            Console.WriteLine(Message);
        }

        public static string Input(this string ok)
        {
            return "From Input";
        }

        public static void PrintValuesInRows(this IEnumerable<dynamic> collections)
        {
            foreach (dynamic qContact in collections)
            {
                Type T = qContact.GetType();
                PropertyInfo[] properties = T.GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    Console.WriteLine(string.Format("{0} : {1}", property.Name, property.GetValue(qContact, null)));
                }
                "".Output();
            }
        }

        public static void PrintValuesInColumn<AnonymousType>(this IEnumerable<AnonymousType> collections)
        {
            int i = 0;

            foreach (AnonymousType qContact in collections)
            {
                Type T = qContact.GetType();
                PropertyInfo[] properties = T.GetProperties();

                // for header
                string headerValue;
                if (i == 0)
                {
                    Console.WriteLine("\n----------------------------------------------------------------------------------------------");
                    foreach (PropertyInfo property in properties)
                    {
                        headerValue = property.Name;

                        if (headerValue.Length < 8)
                            Console.Write(string.Format("{0}\t\t", headerValue));
                        else
                            Console.Write(string.Format("{0}\t", headerValue.Substring(0, 8)));
                    }
                    Console.WriteLine("\n----------------------------------------------------------------------------------------------");
                }

                // Actual value
                string columnValue;
                foreach (PropertyInfo property in properties)
                {
                    columnValue = property.GetValue(qContact, null).ToString();

                    if(columnValue.Length < 8)
                        Console.Write(string.Format("{0}\t\t", columnValue));
                    else
                        Console.Write(string.Format("{0}\t", columnValue.Substring(0, 8)));
                }
                "".Output();
                i++;
            }
        }
    }
}
