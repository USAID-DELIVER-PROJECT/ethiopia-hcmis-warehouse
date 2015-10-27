using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Models
{
    [Table("StoreGroup")]
    public class Account
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubAccount> SubAccounts { get; set; } 
    }
}
