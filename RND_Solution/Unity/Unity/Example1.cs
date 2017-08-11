using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Unity.Objects;


namespace Unity
{
    public class ManagementController
    {
        public ITenantStore tenantStore;


        public ManagementController(ITenantStore tenantStore)
        {
            this.tenantStore = tenantStore;
        }
    }

    public class Example1
    {
        public static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<ITenantStore, TenantStore1>();
            container.RegisterType<ITenantStoreLogo, TenantStore1>();
            ManagementController managementController = container.Resolve<ManagementController>();
            managementController.tenantStore = new TenantStore1();
            var tenantStore1 = container.Resolve<TenantStore1>();
            Console.Read();
        }
    }
}
