using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class OrderDetail
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public Nullable<int> Pack { get; set; }
        public Nullable<int> QtyPerPack { get; set; }
        public Nullable<long> Quantity { get; set; }
        public Nullable<long> ApprovedQuantity { get; set; }
        public string Remark { get; set; }
        public Nullable<int> HACTOrderDetailID { get; set; }
        public Nullable<int> UnitID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<bool> StockedOut { get; set; }
        public Nullable<bool> DeliveryNote { get; set; }
        public Nullable<int> PreferredManufacturerID { get; set; }
        public Nullable<System.DateTime> PreferredExpiryDate { get; set; }
        public Nullable<int> PreferredPhysicalStoreID { get; set; }
        public virtual Item Item { get; set; }
        public virtual Item Item1 { get; set; }
        public virtual ItemUnit ItemUnit { get; set; }
        public virtual Order Order { get; set; }
        public virtual PhysicalStore PhysicalStore { get; set; }
        public virtual Store Store { get; set; }
    }
}
