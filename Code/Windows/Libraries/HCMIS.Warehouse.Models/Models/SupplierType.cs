using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("SupplierType")]
    public class SupplierType
    {
        [Key]
        public int SupplierTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public Guid rowguid { get; set; }
        public string SupplierTypeCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        

    }
}
