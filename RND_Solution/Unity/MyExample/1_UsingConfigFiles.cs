using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInterfaces;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace MyExample
{
    public class _1_UsingConfigFiles
    {
        public static void Main1(string[] args)
        {
            IUnityContainer container = new UnityContainer();

            container.LoadConfiguration();

            var Phone = container.Resolve<IPhone>();
            //var LoggingType = container.Resolve<ILogging>();

            Console.WriteLine(Phone.GetOSType());
            //Console.WriteLine(LoggingType.GetLoggingType());

            Console.ReadLine();

        }
    }
}
