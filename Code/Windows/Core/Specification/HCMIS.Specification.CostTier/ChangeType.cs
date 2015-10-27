using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Specification.Finance.CostTier
{
    public class ChangeType
    {
        public ChangeType(int id,string description)
        {
            Id = id;
            Description = description;
        }
        public int Id;
        public string Description;
        
    }

    public class ChangeMode
    {
        public static ChangeType Recieve = new ChangeType(1,"Receive");
        public static ChangeType PriceOverride = new ChangeType(2, "PriceOverride");
        public static ChangeType VoidReceive = new ChangeType(3, "VoidReceive");
        public static ChangeType BeginningBalance = new ChangeType(3,"BeginningBalance");
        public static ChangeType ErrorCorrection = new ChangeType(4,"ErrocCorrection");
     
    }
}
