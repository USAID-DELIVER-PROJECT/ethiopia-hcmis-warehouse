using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace HCMIS.Warehouse.Models
{
    [Table("JTransaction", Schema = "Core")]
    public class JTransaction
    {
        [Key]
        public int JTransactionID { get; set; }
        public int JTransactionGroupID { get; set; }
        public int CoreAccountID { get; set; }
        public int ItemID { get; set; }
        public int? ManufacturerID { get; set; }
        public int UnitOfIssueID { get; set; }
        public int ModeID { get; set; }
        public int? ActivityID { get; set; }
        public int PaymentTypeID { get; set; }
        public int? PalletLocationID { get; set; }
        public string BatchNumber { get; set; }
        public DateTime? ExpireDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? InstitutionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime RecordedDate { get; set; }

    }
}
