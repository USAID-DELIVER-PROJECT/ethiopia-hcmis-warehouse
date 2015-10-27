using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ItemStorageType")]
    public class ItemStorageType
    {
        [Key][Column("ID")]
        public int ItemStorageTypeID { get; set; }
        public int? ItemID { get; set; }
        public Guid? ItemGuid { get; set; }
        public int StorageTypeID { get; set; }
        public Guid? StorageTypeGuid { get; set; }

    }
}
