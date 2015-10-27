using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Models
{
    [Table("UserPhysicalStore")]
    public class StoreUser
    {
        [Key]
        [Column("ID")]
        public int StoreUserID { get; set; }
        [ForeignKey("Store")]
        [Column("PhysicalStoreID")]
        public int StoreID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [Column("CanAccess")]
        public bool IsActive { get; set; }

        public bool? IsDefault { get; set; }

        public virtual User User { get; set; }
        public virtual Store Store { get; set; }
    }
}
