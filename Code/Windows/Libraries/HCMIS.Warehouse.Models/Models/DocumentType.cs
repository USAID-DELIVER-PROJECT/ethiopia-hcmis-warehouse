using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("DocumentType", Schema = "MessageBroker")]
    public class DocumentType
    {
        [Key]
        public int DocumentTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public Guid rowguid { get; set; }
        public string DocumentCode { get; set; }
        public string DocumentTypesCode { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
    }
}
