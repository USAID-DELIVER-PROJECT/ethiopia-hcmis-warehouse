using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [Column("ID")]
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public decimal? Pack  { get; set; }
        public int? QtyPerPack { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? ApprovedQuantity { get; set; }
        public string Remark { get; set; }
        public int? HACTOrderDetailID { get; set; }
        public int? UnitID { get; set; }
        [Column("StoreID")]
        public int? ActivityID { get; set; }

        public bool? StockedOut { get; set; }
        public bool? DeliveryNote { get; set; }
        public int? PreferredManufacturerID { get; set; }
        public DateTime? PreferredExpiryDate { get; set; }
        public int? PreferedPhysicalStoreID { get; set; }
        public int? JTransactionGroupID { get; set; }

    }
}
