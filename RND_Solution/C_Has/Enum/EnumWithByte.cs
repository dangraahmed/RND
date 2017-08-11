using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_Has.Enum
{
    class EnumWithByte
    {
        [Flags()]
        public enum Weekdays : int
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 4,
            Thursday = 8,
            Friday = 16,
            Saturday = 32,
            Sunday = 64
        }

        public static void Main1(string[] args)
        {
            Update((int)(Weekdays.Friday | Weekdays.Monday));

            Console.ReadLine();
        }

        public static void Update(int Option)
        {
            Console.WriteLine(Convert.ToString((Weekdays)Option));
        }
    }
}
