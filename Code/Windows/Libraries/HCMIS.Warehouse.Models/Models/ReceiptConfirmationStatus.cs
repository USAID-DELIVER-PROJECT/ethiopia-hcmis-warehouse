using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMIS.Warehouse.Models
{
    [Table("ReceiptConfirmationStatus")]
    public class ReceiptConfirmationStatus
    {
        [Key][Column("ID")]
        public int ReceiptConfirmationStatusID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ReceiptConfirmationStatusCode { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
    }
}
