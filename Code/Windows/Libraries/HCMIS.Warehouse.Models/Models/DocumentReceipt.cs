using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("DocumentReceipt")]
    public class DocumentReceipt
    {
        [Key][Column("ID")]
        public int DocumentReceiptID { get; set; }
        public int? DocumentID { get; set; }
        public int? ReceiptID { get; set; }

      
    }
}
