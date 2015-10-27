using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMIS.Warehouse.Models
{
    [Table("StorageType")]
    public class StorageType
    {
        [Key][Column("ID")]
        public int StorageTypeID { get; set; }

        public string StorageTypeName { get; set; }
        [Column("IsSubTypeOf")]
        public int? ParentStorageTypeID { get; set; }

        public string Prefix { get; set; }

        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? StorageTypeCode { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
    }
}
