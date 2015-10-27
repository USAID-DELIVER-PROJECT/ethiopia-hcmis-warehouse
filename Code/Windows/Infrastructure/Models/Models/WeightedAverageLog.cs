using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class WeightedAverageLog
    {
        public int ID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<int> SOHWhenApplied { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<double> Insurance { get; set; }
        public Nullable<int> ManufacturerID { get; set; }
        public Nullable<int> UnitID { get; set; }
        public Nullable<int> ReceiptId { get; set; }
        public Nullable<double> UPUnitCost { get; set; }
        public Nullable<long> UPQty { get; set; }
        public Nullable<double> UPTotalCost { get; set; }
        public Nullable<long> PQty { get; set; }
        public Nullable<double> PUnitCost { get; set; }
        public Nullable<double> PTotalCost { get; set; }
        public Nullable<double> NTotalCost { get; set; }
        public string Remark { get; set; }
        public Nullable<long> NQty { get; set; }
        public Nullable<double> NUnitCost { get; set; }
        public Nullable<double> PriceDifference { get; set; }
        public Nullable<double> Margin { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual StoreGroup StoreGroup { get; set; }
    }
}
