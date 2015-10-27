using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMIS.Warehouse.Models
{
    [Table("ReceiveDocConfirmation")]
    public class ReceiveDocConfirmation
    {
        [Key][Column("ID")]
        public int ReceiveDocConfirmationID { get; set; }

        public int? ReceiveDocID { get; set; }
        public int? ReceiptConfirmationStatusID { get; set; }
        public int? ReceivedByUserID { get; set; }
        public int? ReceiptQuantityConfirmedByUserID { get; set; }
        public int? PriceAssignedByUserID { get; set; }
        public int? PriceConfirmedByUserID { get; set; }
        public int? GRVPrintedByUserID { get; set; }
        public int? UnitCostCalculatedByUserID { get; set; }
        public int? GRNFPrintedByUserID { get; set; }


    }
}
