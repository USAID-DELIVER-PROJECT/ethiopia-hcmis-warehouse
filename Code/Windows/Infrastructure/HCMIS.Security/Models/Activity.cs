using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Models
{
    [Table("Stores")]
    public class Activity
    {
        [Key]
        [Column("ID")]
        public int ActivityID { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("StoreName")]
        public string Name { get; set; }

        [ForeignKey("SubAccount")]
        [Column("StoreGroupDivisionID")]
        public int? SubAccountID { get; set; }
        public virtual SubAccount SubAccount { get; set; }

        public virtual ICollection<AccountUser> AccountUsers { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                if (this.SubAccount == null)
                    return this.Name;
                return string.Format("{0} - {1} - {2}", this.SubAccount.Account.Name, this.SubAccount.Name, this.Name);
            }
        }
    }
}
