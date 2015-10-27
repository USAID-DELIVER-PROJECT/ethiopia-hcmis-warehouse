using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HCMIS.Concrete.Models
{
    [Table("JournalLite")]
    public class JournalLite
    {
      
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
        public string Identifier { get; set; }

        [ForeignKey("Ledger")]
        public int AffectedLedgerID { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Margin { get; set; }
        public decimal SellingPrice { get; set; }

        public int UserID { get; set; }
        public virtual TempLedger Ledger{ get; set; }
    }
}
