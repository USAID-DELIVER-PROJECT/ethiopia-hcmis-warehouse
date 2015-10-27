using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Modules.Requisition.Domain
{
    public class ApprovedDetail
    { 
        public ApprovedDetail()
        {
            
        }
        public ApprovedDetail(ApprovedDetail approvedDetail)
        {
            Item = approvedDetail.Item;
            Unit = approvedDetail.Unit;
            ActivityGroup = approvedDetail.ActivityGroup;
            Manufacturer = approvedDetail.Manufacturer;
            physicalStore = approvedDetail.physicalStore;
            ExpiryDate = approvedDetail.ExpiryDate;
            Quantity = approvedDetail.Quantity;
        }
        public Item Item { get; set; }
        public Unit Unit { get; set; }
        public ActivityGroup ActivityGroup { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public PhysicalStore physicalStore { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal Quantity { get; set; }

        public int Priority { get { return Convert.ToInt32(Manufacturer == null) + Convert.ToInt32(physicalStore == null) + Convert.ToInt32(ExpiryDate == null); } }

    }
}
