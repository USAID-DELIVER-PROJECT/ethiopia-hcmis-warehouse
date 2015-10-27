using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("JournalLite")]
    public class JournalLite
    {
        [Key][Column("ID")]
        public int JournalLiteID { get; set; }

        public string Description { get; set; }
        public string Identifier { get; set; }
        public int AffectedLedgerID { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? Margin { get; set; }
        public decimal? SellingPrice { get; set; }
        public int UserID { get; set; }
    }
}
