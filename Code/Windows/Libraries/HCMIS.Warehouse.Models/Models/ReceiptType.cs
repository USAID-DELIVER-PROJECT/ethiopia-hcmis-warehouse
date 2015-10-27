using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMIS.Warehouse.Models
{
    [Table("ReceiptType")]
    public class ReceiptType
    {
        [Key][Column("ID")]
        public int ReceiptTypeID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public bool? IsSystemReceiptType { get; set; }
        public string ReceiptTypeCode { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
    }
}
