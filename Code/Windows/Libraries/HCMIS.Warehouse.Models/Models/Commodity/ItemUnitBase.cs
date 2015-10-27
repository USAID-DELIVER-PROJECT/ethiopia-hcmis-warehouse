using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ItemUnitBase")]
    public class ItemUnitBase
    {
        [Key][Column("ID")]
        public int ItemUnitBaseID { get; set; }
        public int ItemID { get; set; }
        public Guid? ItemGuid { get; set; }
        public Guid? UnitOfIssueGuid { get; set; }
        public int? UnitOfIssueID { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}
