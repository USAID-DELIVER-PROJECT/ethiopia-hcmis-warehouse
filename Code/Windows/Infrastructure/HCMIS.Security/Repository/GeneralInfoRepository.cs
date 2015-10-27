using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.DataContext;
using HCMIS.Security.Models;

namespace HCMIS.Security.Repository
{
    public class GeneralInfoRepository : GenericRepository<SecurityContext,GeneralInfo>
    {

        public GeneralInfo GetInstance()
        {
            return this.Context.GeneralInfos.FirstOrDefault();
        }

        public GeneralInfoRepository(SecurityContext context)
        {
           this.Context = context;
        }

        public GeneralInfoRepository()
        {
            // TODO: Complete member initialization
        }
    }
}
