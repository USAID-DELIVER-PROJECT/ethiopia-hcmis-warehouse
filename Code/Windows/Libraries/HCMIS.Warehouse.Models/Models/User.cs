using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("User")]
   public class User
    {
        [Key][Column("ID")]
        public int UserID { get; set; }

        public string FullName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? UserType { get; set; }
        [Column("Active")]
        public bool? IsActive { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DepartmentID { get; set; }
        public int? JobTitleID { get; set; }
        [Column("CreatedByID")]
        public int? CreatedBy { get; set; }

        public DateTime? LastLogin { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public char? PasswordExpires { get; set; }
        public DateTime? ExpirationDate { get; set; }

    }
}
