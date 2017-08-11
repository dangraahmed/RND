using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace MyExample
{
    class _3_UsingAutoRegistration
    {
        public static void Main1(string[] args)
        {
            IUnityContainer container = new UnityContainer();

            //container.RegisterType(AllClasses.FromAssemblies().Where(t=>t.Namespace.StartsWith("MyExample.")),WithMappings.FromAllInterfaces(),)



            //container.Configure()

            
            //var Phone = container.Resolve<IPhone>();
            //Console.WriteLine(Phone.GetOSType());

            //Console.ReadLine();
        }


    }
}
