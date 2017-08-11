using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ.SampleData;
using LINQ.Common;

namespace LINQ.Chapter_3
{
    class _006_SelectSingleResultValue
    {
        public static void Main1(string[] agru)
        {
            List<Contact> contacts = Contact.SampleData();
            List<CallLog> callLogs = CallLog.SampleData();

            callLogs.PrintValuesInColumn();

            "".Output();
            ("Average : " + callLogs.Average(call => call.Duration).ToString()).Output();
            
            Console.ReadLine();
        }
        


    }
}
