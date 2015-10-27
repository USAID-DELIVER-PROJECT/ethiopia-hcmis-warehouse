using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Models
{
    [Table("StoreGroupDivision")]
    public class SubAccount
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [ForeignKey("Account")]
        [Column("StoreGroupID")]
        public int AccountID { get; set; }

        public virtual ICollection<Activity> Activities { get; set; } 

        public virtual Account Account { get; set; }
    }
}
