using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("LossAndAdjustment")]
    public class LossAndAdjustment
    {
        public int LossAndAdjustmentID { get; set; }
        public int? ItemID { get; set; }
        [Column("StoreId")]
        public int? StoreID { get; set; }
        [Column("ReasonId")]
        public int? ReasonID { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? Date  { get; set; }
        public string ApprovedBy { get; set; }
        public bool? Losses { get; set; }
        public string BatchNo { get; set; }
        public string Remark { get; set; }
        public double? Cost { get; set; }
        [Column("RefNo")]
        public string ReferenceNumber { get; set; }

        public DateTime? EurDate { get; set; }
        public int? RecID { get; set; }
        public int? InventoryPeriodID { get; set; }
        
    }
}
