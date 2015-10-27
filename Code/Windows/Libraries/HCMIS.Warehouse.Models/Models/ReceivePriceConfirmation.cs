using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMIS.Warehouse.Models
{
    [Table("ReceivePriceConfirmation")]
    public class ReceivePriceConfirmation
    {
        [Key][Column("ID")]
        public int ReceivePriceConfirmationID { get; set; }

        public int? ReceiveDocID { get; set; }
        [Column("isCostConfirmed")]
        public bool? IsCostConfirmed { get; set; }
        public int? UserID { get; set; }
        public DateTime? Date { get; set; }
    }
}
