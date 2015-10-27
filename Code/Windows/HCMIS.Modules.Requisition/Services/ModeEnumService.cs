using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace HCMIS.Modules.Requisition.Services
{
    class ModeService:EnumService<Domain.Modes>
    {
        public Domain.Modes GetEnum(int modeID)
        {
            var mode = new Mode();
            mode.LoadByPrimaryKey(modeID);
            return GetEnum(mode.ModeCode);
         
        }     
   }
}
