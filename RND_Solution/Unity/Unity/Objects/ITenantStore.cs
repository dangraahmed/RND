using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Objects
{
    public interface ITenantStore
    {
        void Initialize();
        Tenant GetTenant(string tenant);
        IEnumerable<string> GetTenantNames();
        void SaveTenant(Tenant tenant);
        
    }
}
