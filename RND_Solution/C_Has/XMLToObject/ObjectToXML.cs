using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace C_Has.XMLToObject
{
    public class ObjectToXML
    {
        public static void Main1(string[] args)
        {
            List<demoValue> p = new List<demoValue>();
            demoValue obj = new demoValue();

            p = obj.getData();

            Console.WriteLine(obj.ObjectToXML(p[0]));

            demoValue p1 = obj.XMLToObject<demoValue>(obj.ObjectToXML(p[0]));

            Console.ReadLine();
        }


        public class demoValue
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }


            public T XMLToObject<T>(string xml)
            {
                using (StringReader stringReader = new StringReader(xml))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(stringReader);
                }
            }

            public string ObjectToXML<T>(T obj)
            {
                using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(stringWriter, obj);
                    return stringWriter.ToString();
                }
            }


            //public static List<T> XmlToObjectList<T>(string xml, string nodePath)
            //{
            //    var xmlDocument = new XmlDocument();
            //    xmlDocument.LoadXml(xml);

            //    var returnItemsList = new List<T>();

            //    foreach (XmlNode xmlNode in xmlDocument.SelectNodes(nodePath))
            //    {
            //        returnItemsList.Add(XmlToObject<T>(xmlNode.OuterXml));
            //    }

            //    return returnItemsList;
            //} 

            public List<demoValue> getData()
            {
                List<demoValue> returnValue = new List<demoValue>();

                returnValue.Add(new demoValue { FirstName = "FirstName1", LastName = "LastName1", Address = "Address1", Phone = "Phone1" });
                returnValue.Add(new demoValue { FirstName = "FirstName2", LastName = "LastName2", Address = "Address2", Phone = "Phone2" });
                returnValue.Add(new demoValue { FirstName = "FirstName3", LastName = "LastName3", Address = "Address3", Phone = "Phone3" });
                returnValue.Add(new demoValue { FirstName = "FirstName4", LastName = "LastName4", Address = "Address4", Phone = "Phone4" });
                returnValue.Add(new demoValue { FirstName = "FirstName5", LastName = "LastName5", Address = "Address5", Phone = "Phone5" });
                returnValue.Add(new demoValue { FirstName = "FirstName6", LastName = "LastName6", Address = "Address6", Phone = "Phone6" });
                returnValue.Add(new demoValue { FirstName = "FirstName7", LastName = "LastName7", Address = "Address7", Phone = "Phone7" });

                return returnValue;
            }
        }
    }

    


}
