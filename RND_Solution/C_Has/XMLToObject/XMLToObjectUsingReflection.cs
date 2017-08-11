using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;

namespace C_Has.XMLToObject
{
    class XMLToObjectUsingReflection
    {
        public static string ObjectToString(object o)
        {
            XDocument doc = new XDocument();
            string objectType = o.GetType().ToString();
            doc.AddFirst(new XElement(objectType));

            foreach (PropertyInfo pi in o.GetType().GetProperties())
            {
                doc.Root.Add(new XElement(pi.Name, Convert.ToString(pi.GetValue(o, null))));
            }
            return doc.ToString();
        }
    }
}
