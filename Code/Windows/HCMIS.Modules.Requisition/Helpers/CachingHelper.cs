using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace HCMIS.Modules.Requisition.Helpers
{
    public class CachingHelper
    {
        public static  void ClearCaching()
        {
            EnterpriseLibraryContainer.Current.GetInstance<ICacheManager>().Flush();
        }
    }
}
