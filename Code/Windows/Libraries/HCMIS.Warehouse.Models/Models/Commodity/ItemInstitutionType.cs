using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ItemInstitutionType")]
    public class ItemInstitutionType
    {
        [Key][Column("ID")]
        public int ItemInstitutionTypeID { get; set; }
        public int? ItemID { get; set; }
        public int? InstitutionTypeID { get; set; }
        public bool? AllowFully { get; set; }
        public bool? Warning { get; set; }
        public bool? Restriction { get; set; }
        public Int64? MaxIssueQty { get; set; }
        public int? MaxIssueQtyGapDays { get; set; }

    }
}
