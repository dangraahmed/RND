using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace C_Has.XMLToObject
{
    class XMLToObject_2
    {
        public static void Main1(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Datatable));
            FileStream loadStream = new FileStream(@"..\..\XMLToObject\sample_2.xml", FileMode.Open, FileAccess.Read);
            Datatable_2 loadedObject = (Datatable_2)serializer.Deserialize(loadStream);
            loadStream.Close();
        }
    }

    public class Datatable_2
    {
        public Employees_2 Employees_2 { get; set; }
    }

    public class Employees_2
    {
        public List<Employee_2> Employee_2 { get; set; }
    }

    public class Employee_2
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }

    public class Address_2
    {
        public string City { get; set; }

        public string Pin { get; set; }

        public string AddressValue { get; set; }
    }

    public class Contact_2
    {
        public string Mob { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string ContactValue { get; set; }

    }
}
