using System;
using HCMIS.Modules.Requisition.Domain;

namespace HCMIS.Desktop.ViewModels.Approval
{
    public class ActivityViewModel
    {
        public ActivityViewModel()
        {
            
        }
        public ActivityViewModel(ActivityGroup activity)
        {
            ActivityID = activity.ActivityGroupID;
            Name = activity.Name;
        }
        public string ActivityID { get; set; }
        public string NameAndQuantity { get { return String.Format("{0} ({2}{1})", Name,Quantity.ToString("#,##0.##"),IsDeliveryNote?"DN:":""); } }
        public bool IsDeliveryNote { get; set;}
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        
    }
}
