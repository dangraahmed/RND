using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace C_Has.Yield
{
    class Sample1
    {
        public static void Main1(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3 };

            DataTable table = new DataTable();
            table.Columns.Add("ItemName", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("Price", typeof(float));
            table.Columns.Add("Process", typeof(string));
            //     // Here we add five DataRows.
            // table.Rows.Add("Indocin", 2, 23);
            table.Rows.Add("Enebrel", 1, 10);
            table.Rows.Add(null, null, null);
            table.Rows.Add("Hydralazine", 1, null);
            table.Rows.Add("Combivent", 3, 5);
            table.Rows.Add("Dilantin", 1, 6);

            foreach (DataRow dr in GetRowToProcess(table.Rows))
            {
                if (dr != null)
                {
                    dr["Process"] = "Processed";
                    Console.WriteLine(dr["ItemName"].ToString() + dr["Quantity"].ToString() + " : " + dr["Process"].ToString());
                    //bool test = dr.ItemArray.Any(c => c == DBNull.Value);
                }
            }
            Console.ReadLine();
        }
        private static IEnumerable<DataRow> GetRowToProcess(DataRowCollection dataRowCollection)
        {
            foreach (DataRow dr in dataRowCollection)
            {
                bool isempty = dr.ItemArray.All(x => x == null || (x != null && string.IsNullOrWhiteSpace(x.ToString())));

                if (!isempty)
                {
                    yield return dr;
                    //dr["Process"] = "Processed";
                }
                else
                {
                    yield return null;
                    //dr["Process"] = " Not having data ";
                }
                //yield return dr;
            }
        }
    }
}
