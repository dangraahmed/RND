using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Objects
{
    public class TenantStore1 : ITenantStore, ITenantStoreLogo
    {
        #region ITenantStore Members

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public Tenant GetTenant(string tenant)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetTenantNames()
        {
            throw new NotImplementedException();
        }

        public void SaveTenant(Tenant tenant)
        {
            throw new NotImplementedException();
        }

        public void UploadLogo(string tenant, byte[] logo)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
