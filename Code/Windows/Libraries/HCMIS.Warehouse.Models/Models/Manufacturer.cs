using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Manufacturer")]
    public class Manufacturer
    {
        [Key][Column("ID")]
        public int ManufacturerID { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public string PFSAManufCode { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
    }
}
