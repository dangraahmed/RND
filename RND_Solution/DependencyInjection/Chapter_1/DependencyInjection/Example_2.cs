using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Chapter_1
{
    public class Example_2
    {
        public static void MainFunction()
        {
            var typeName = ConfigurationManager.AppSettings["messageWriter"];
            var type = Type.GetType(typeName, false);

            IMessageWriter writer = (IMessageWriter) Activator.CreateInstance(type);

            var salutation = new Salutation(writer);
            salutation.Exclaim();
        }
    }
}
