using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Modules.Requisition.Domain
{
    public class RequestDetail
    {
        public int RequestDetailId { get; set; }
        public Item Item { get; set; }
        public Unit Unit { get; set; }
        public ActivityGroup ActivityGroup { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public PhysicalStore physicalStore { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool StockedOut { get; set; }
        public decimal RequestedQuantity { get; set; }
        public decimal ApprovedQuantity { get; set; }
        public bool IsFirstLoad { get; set; }
    }
}
