using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("PharmaceuticalClassification")]
    public class PharmaceuticalClassification
    {
        [Key][Column("ID")]
        public int PharmaceuticalClassificationID { get; set; }
        public string Name { get; set; }
        public string CategoryCode { get; set; }
        public int? ParentID { get; set; }
        public Guid? ParentGuid { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
    }
}
