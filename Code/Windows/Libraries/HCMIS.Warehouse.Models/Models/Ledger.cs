using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Ledger")]
  public  class Ledger
    {
        [Key][Column("ID")]
        public int LedgerID { get; set; }

        public int? ItemID { get; set; }
        public int? UnitID { get; set; }
        public int? ManufacturerID { get; set; }
        public int? AccountID { get; set; }
        public bool? IsConfirmed { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? Margin { get; set; }
        public decimal? SellingPrice { get; set; }
        public int? ChangeType { get; set; }
    }
}
