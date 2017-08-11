using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Objects
{
    public interface ITenantStoreLogo
    {
        void UploadLogo(string tenant, byte[] logo);
    }
}
