using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ItemOwnershipType")]
    public class ItemOwnershipType
    {
        [Key][Column("ID")]
        public int ItemOwnershipTypeID { get; set; }
        public int? ItemID { get; set; }
        public int? RUOwnershipTypeID { get; set; }
        public bool? AllowFully { get; set; }
        public bool? Warning { get; set; }
        public bool? Restriction { get; set; }
        public Int64? MaxIssueQty { get; set; }
        public int MaxIssueQtyGapDays { get; set; }

    }
}
