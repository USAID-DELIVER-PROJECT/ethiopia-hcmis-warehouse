using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("InstitutionParentType")]
    public class InstitutionParentType
    {
        [Key][Column("ID")]
        public int InstitutionParentTypeID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }

    }
}
