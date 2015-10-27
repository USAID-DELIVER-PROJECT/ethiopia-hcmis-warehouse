using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using HCMIS.Security.Common;
using HCMIS.Security.Helpers;

namespace HCMIS.Security.Models
{
    [Table("User")]
    public class User : IUser
    {
        [Key]
        [Column("ID")]
        public int UserID { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string FullName { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string Mobile { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        // this is deprecated.
        public int? UserType { get; set; }

        [Required]
        [DefaultValue(true)]
        [Column("Active")]

        public bool IsActive { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentID { get; set; }
        [ForeignKey("JobTitle")]
        public int? JobTitleID { get; set; }
        [ForeignKey("CreatedBy")]
        public int? CreatedByID { get; set; }

        public DateTime? LastLogin { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [DefaultValue(true)]
        public bool? PasswordExpires { get; set; }
        public DateTime? ExpirationDate { get; set; }
        

        public void SetPassword(string rawPassword)
        {
            Password = Cryptography.EncryptPassword(Settings.EncryptionAlgorithm, rawPassword);
        }

        public bool CheckPassword(string rawPassword)
        {
            string encriptedPassword = Cryptography.EncryptPassword(Settings.EncryptionAlgorithm, rawPassword);
            string pwd = Convert.ToBase64String(Encoding.GetEncoding(1252).GetBytes(this.Password));
            return (pwd == encriptedPassword || this.Password == encriptedPassword);
        }

        public virtual Department Department { get; set; }
        public virtual JobTitle JobTitle { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
      
        public virtual ICollection<StoreUser> StoreUsers { get; set; }
        public virtual ICollection<AccountUser> AccountUsers { get; set; } 
        

        
    }
}
