using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
namespace C_Has.XMLToObject
{
    class XMLToObject
    {
        public static void Main1(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Datatable));
            FileStream loadStream = new FileStream(@"..\..\XMLToObject\sample.xml", FileMode.Open, FileAccess.Read);
            Datatable loadedObject = (Datatable)serializer.Deserialize(loadStream);
            loadStream.Close();
        }
    }

    [XmlRoot("Datatable"), Serializable]
    public class Datatable
    {
        [XmlElement("Employees")]
        public Employees Employees { get; set; }
    }

    public class Employees
    {
        [XmlAttribute("Count")]
        public int Count { get; set; }

        [XmlElement("Employee")]
        public List<Employee> Employee { get; set; }
    }

    public class Employee
    {
        [XmlAttribute("Code")]
        public string Code { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlElement("Address")]
        public Address Address { get; set; }

        [XmlElement("Contacts")]
        public Contact Contact { get; set; }
    }

    public class Address
    {
        [XmlAttribute("City")]
        public string City { get; set; }

        [XmlAttribute("Pin")]
        public string Pin { get; set; }

        [XmlText]
        public string AddressValue { get; set; }
    }

    public class Contact
    {
        [XmlAttribute("Mob")]
        public string Mob { get; set; }

        [XmlAttribute("Phone")]
        public string Phone { get; set; }

        [XmlAttribute("Email")]
        public string Email { get; set; }

        [XmlText]
        public string ContactValue { get; set; }

    }
}
