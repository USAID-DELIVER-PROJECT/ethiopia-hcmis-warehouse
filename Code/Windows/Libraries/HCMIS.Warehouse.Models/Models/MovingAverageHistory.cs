using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("MovingAverageHistory")]
    public class MovingAverageHistory
    {
        [Key][Column("ID")]
        public int MovingAverageHistoryID { get; set; }

        public int? ItemID { get; set; }
        public int? SupplierID { get; set; }
        public decimal? SOHWhenApplied  { get; set; }
        public double? Price { get; set; }
        public DateTime? Date { get; set; }
        public int? UserID { get; set; }
        [Column("StoreID")]
        public int? ActivityID { get; set; }
        public double? Insurance { get; set; }
        public int? ManufacturerID { get; set; }
        public int? UnitID { get; set; }
        [Column("ReceiptId")]
        public int? ReceiptID { get; set; }

        public double? UPUnitCost { get; set; }
        public decimal? UPQty { get; set; }
        public double? UPTotalCost { get; set; }
        public decimal? PQty  { get; set; }
        public double? PUnitCost { get; set; }
        public double? PTotalCost { get; set; }
        public double? NTotalCost { get; set; }
        public string Remark { get; set; }
        public decimal? NQty { get; set; }
        public double? NUnitCost { get; set; }
        public double? PriceDifference { get; set; }
        public double? Margin { get; set; }

    }
}
