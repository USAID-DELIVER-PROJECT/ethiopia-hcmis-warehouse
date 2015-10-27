using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ItemActivity")]
    public class ItemActivity
    {
        [Key][Column("ID")]
        public int ItemActivityID { get; set; }
        public int? ItemID { get; set; }
        public int? StoreID { get; set; }
        public bool? UsedInThisStore { get; set; }
        public Guid? ItemGuid { get; set; }
        public Guid? ActivityGuid { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        }
}
