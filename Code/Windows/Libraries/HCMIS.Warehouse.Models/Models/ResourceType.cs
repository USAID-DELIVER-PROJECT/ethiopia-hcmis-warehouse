using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ResourceType")]
    public class ResourceType
    {
        public int ResourceTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ResourceTypeCode { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
    }
}
