using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Inventory")]
    public class Inventory
    {
        [Key][Column("ID")]
        public int InventoryID { get; set; }

        public int? InventoryPeriodID { get; set; }
        public int? PhysicalStoreID { get; set; }
        public int? ActivityID { get; set; }
        public int? ItemID { get; set; }
        public int? UnitID { get; set; }
        public int? ManufacturerID { get; set; }
        public int? SupplierID { get; set; }

        public string BatchNo { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal? SystemSoundQuantity { get; set; }
        public decimal? SystemDamagedQuantity { get; set; }
        public decimal? InventorySoundQuantity { get; set; }
        public decimal? InventoryDamagedQuantity { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Margin { get; set; }
        public decimal? SellingPrice { get; set; }
        public DateTime? RecordedDate { get; set; }
        public bool? IsDraft { get; set; }
        public DateTime? ApprovedDate { get; set; }

        public int? RecordedBy { get; set; }
        public int? ApprovedBy { get; set; }
        public decimal? SystemExpiredQuantity { get; set; }
        public decimal? InventoryExpiredQuantity { get; set; }
        public string Remarks { get; set; }
        public int? ReceiveDocID { get; set; }
        public int? PalletLocationID { get; set; }
        public int? DamagedReceiveDocID { get; set; }





    }
}
