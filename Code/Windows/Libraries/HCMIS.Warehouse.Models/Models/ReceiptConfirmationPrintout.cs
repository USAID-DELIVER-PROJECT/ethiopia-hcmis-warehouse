using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMIS.Warehouse.Models
{
    [Table("ReceiptConfirmationPrintout")]
    public class ReceiptConfirmationPrintout
    {
        [Key][Column("ID")]
        public int ReceiptConfirmationPrintoutID { get; set; }

        public DateTime? PrintedDate { get; set; }
        public int? SupplierID { get; set; }
        public int? IsReprintOf { get; set; }
        public string Reason { get; set; }
        public int? UserID { get; set; }
        [Column("StoreID")]
        public int? ActivityID { get; set; }

        public int? IDPrinted { get; set; }
        public bool? VoidRequest { get; set; }
        public DateTime? VoidRequestDateTime { get; set; }
        public int? VoidRequestUserID { get; set; }
        public bool? IsVoided { get; set; }
        public int? VoidApprovedByUserID { get; set; }
        public DateTime? VoidApprovalDateTime { get; set; }
        public int? ReceiptID { get; set; }
        public int? FiscalYearID { get; set; }
        public int AccountID { get; set; }
        public int DocumentTypeID { get; set; }
        public string UniqueIDPrinted { get; set; }
    }
}
