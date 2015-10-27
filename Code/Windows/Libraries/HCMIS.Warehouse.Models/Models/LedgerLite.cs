using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("LedgerLite")]
    public class LedgerLite
    {
        [Key][Column("ID")]
        public int LedgerLiteID { get; set; }

        public int? ItemID { get; set; }
        public int? UnitID { get; set; }
        public int? ManufacturerID { get; set; }
        public int? AccountID { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? Margin { get; set; }
        public decimal? SellingPrice { get; set; }

    }
}
