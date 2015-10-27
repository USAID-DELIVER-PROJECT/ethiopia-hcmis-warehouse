using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("InvoiceStatus", Schema = "Procurement")]
    public class InvoiceStatus
    {
        [Key]
        public int InvoiceStatusID { get; set; }
        public string Name { get; set; }
        public string InvoiceStatusCode { get; set; }
    }
}