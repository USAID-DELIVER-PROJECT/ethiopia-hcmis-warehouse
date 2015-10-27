using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("InstitutionIType")]
    public class InstitutionIType
    {
        [Key]
        public int InstitutionITypeID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string InstitutionITypeCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

    }
}
