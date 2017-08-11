using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInterfaces;
using Microsoft.Practices.Unity;

namespace MyExample
{
    public class _2_UsingCode
    {
        public static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();

            //container.RegisterInstance(container, IPhone, CreateInstance());
            container.RegisterInstance<IPhone>(CreateInstance());
            var Phone = container.Resolve<IPhone>();
            Console.WriteLine(Phone.GetOSType());

            Console.ReadLine();
        }

        private static IPhone CreateInstance()
        {
            string productRepositryTypeName = ConfigurationManager.AppSettings["PhoneType"];

            var productRepositryType = Type.GetType(productRepositryTypeName, true);
            return (IPhone)Activator.CreateInstance(productRepositryType);
        }
    }
}
