using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Modules.Requisition.Domain
{
    public class ConsumptionSetting
    {
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public decimal SafetyStock { get; set; }
        public decimal EOP { get; set; }
        public decimal LeadTime { get; set; }
    }

    public enum Stockstatus
    {
        Excess = 1,
        Normal = 2,
        BelowEOP = 3,
        NearEOP = 4,
        StockOut = 5,

    }
}
