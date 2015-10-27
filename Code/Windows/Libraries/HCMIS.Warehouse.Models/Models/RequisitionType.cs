using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("RequisitionType")]
    public class RequisitionType
    {
        [Key]
        public int RequisitionTypeID { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string RequisitionTypeCode { get; set; }
    }
}
