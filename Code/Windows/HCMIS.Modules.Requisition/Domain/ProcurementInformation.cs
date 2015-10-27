using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMIS.Modules.Requisition.Domain
{
    class ProcurementInformation
    {
        public Item Item { get; set; }
        public Unit UnitOfIssue { get; set; }
        public decimal Git { get; set; }
        public decimal Approved { get; set; }
        public decimal Requested { get; set; }
    }
}
