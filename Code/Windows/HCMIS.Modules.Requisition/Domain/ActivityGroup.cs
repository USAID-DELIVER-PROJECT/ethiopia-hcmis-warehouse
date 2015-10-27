using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Modules.Requisition.Domain
{
    public class ActivityGroup
    {
        public string ActivityGroupID { get
        {
            return IsDeliveryNote
                       ? String.Format("DN-{0}", Activity.ActivityID)
                       : String.Format("N-{0}", Activity.ActivityID);
        } }
        public string Name { get { return Activity.Name; } }
        public Activity Activity { get; set; }
        public bool IsDeliveryNote { get; set; }
       
    }
}
