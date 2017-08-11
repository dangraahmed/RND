using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ.SampleData;
using LINQ.Common;

namespace LINQ.Chapter_3
{
    class _010_SelectIndexPosition
    {
        //How to Get the Index Position of the Results
        public static void Main1(string[] agru)
        {
            List<CallLog> callLogs = CallLog.SampleData();

            "************ Output using Extension Method ************".Output();
            var q = callLogs.OrderBy(call => call.Number)
                            .Select((call, index) => new
                            {
                                Number = call.Number,
                                Duration = call.Duration,
                                When = call.When,
                                Rank = index
                            });
            q.PrintValuesInColumn();

            "".Output();
            int iind = 0;
            "************ Output using Query Method ************".Output();
            var q1 = from call in callLogs
                     orderby call.Number
                     select new
                     {
                        Number = call.Number,
                        Duration = call.Duration,
                        When = call.When,
                        Index = callLogs.IndexOf(call),
                        Rank = iind++
                     };

            q1.PrintValuesInColumn();

            "".Output();
            callLogs.PrintValuesInColumn();
            Console.ReadLine();
        }
    }
}
