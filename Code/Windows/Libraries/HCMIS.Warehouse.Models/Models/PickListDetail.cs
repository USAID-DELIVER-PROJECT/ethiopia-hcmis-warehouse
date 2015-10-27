using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("PickListDetail")]
    public class PickListDetail
    {
        [Key][Column("ID")]
        public int PickListDetailID { get; set; }

        public int? PickListID { get; set; }
        public int? ItemID { get; set; }
        public int? PalletLocationID { get; set; }
        public string BatchNumber { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? ReceiveDocID { get; set; }
        public int? BoxLevel { get; set; }
        public double? Cost { get; set; }
        public int? ManufacturerID { get; set; }
        public decimal? Packs { get; set; }
        public decimal? QtyPerPack { get; set; }
        public decimal? QuantityInBU { get; set; }
        public int? ReceivePalletID { get; set; }
        public double? UnitPrice { get; set; }
        public int? UnitID { get; set; }
        [Column("StoreID")]
        public int? ActivityID { get; set; }

        public bool? DeliveryNote { get; set; }
        public int? OrderDetailID { get; set; }
        public bool? IsApproved { get; set; }
        public int? ApprovedByUserID { get; set; }
        public int? LineNumber { get; set; }
        public int? PhysicalStoreID { get; set; }
    }
}
