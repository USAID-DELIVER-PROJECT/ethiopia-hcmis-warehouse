using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Supplier")]
    public class Supplier
    {
        [Key][Column("ID")]
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string ContactPerson { get; set; }
        public string Mobile { get; set; }
        public string CompanyInfo { get; set; }
        public bool? IsActive { get; set; }
        public string Email { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
    }
}
