using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Models
{
    [Table("UserAccount")]
    public class UserAccount
    {
        [Key]
        public int UserAccountID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("Account")]
        public int AccountID { get; set; }
        public bool AccountStatus { get; set; }

        public virtual User User { get; set; }
        public virtual Account Account { get; set; }
    }
}
