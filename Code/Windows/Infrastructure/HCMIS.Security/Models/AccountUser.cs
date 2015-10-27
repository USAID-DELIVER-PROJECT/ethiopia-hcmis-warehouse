using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Models
{
    [Table("UserStore")]
    public class AccountUser
    {
        [Key]
        [Column("ID")]
        public int AccountUserID { get; set; }
        [ForeignKey("Account")][Column("StoreID")]
        public int AccountID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [Column("CanAccess")]
        public bool IsActive { get; set; }

        public bool IsDefault { get; set; }

        public virtual User User { get; set; }
        public virtual Activity Account { get; set; }
    }
}
