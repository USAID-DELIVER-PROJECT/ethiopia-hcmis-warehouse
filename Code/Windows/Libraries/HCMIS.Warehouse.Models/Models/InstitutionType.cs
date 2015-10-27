using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("InstitutionType")]
    public class InstitutionType
    {
        [Key][Column("ID")]
        public int InstitutionTypeID { get; set; }
        public string Name { get; set; }
        public Guid? rowguid { get; set; }
        public Guid? InstitutionParentTypeGuid { get; set; }
        public string InstitutionTypeCode { get; set; }
        public bool IsActive { get; set; }
        public int? InstitutionParentTypeID { get; set; }

    }
}
