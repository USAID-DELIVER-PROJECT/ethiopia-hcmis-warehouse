using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("OwnershipType")]
    public class OwnershipType
    {
        [Key][Column("ID")]
        public int OwnershipTypeID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? rowguid  { get; set; }
        public bool? IsActive { get; set; }
        public string OwnershipTypeCode { get; set; }
    }
}
