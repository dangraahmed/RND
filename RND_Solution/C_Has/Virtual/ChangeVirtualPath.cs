using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;

namespace C_Has.Virtual
{
    class ChangeVirtualPath
    {
        public static void Main1(string[] args)
        {
            ListVirtualDirectories("asdf", 1);
            Console.ReadLine();
        }

        private static void ListVirtualDirectories(string serverName, int siteId)
        {
            DirectoryEntry webService = new DirectoryEntry("IIS://localhost/W3SVC");

            foreach (DirectoryEntry webDir in webService.Children)
            {
                if (webDir.SchemaClassName.Equals("IIsWebVirtualDir"))
                    Console.WriteLine("Found virtual directory {0}", webDir.Name);
            }
        }
    }
}
