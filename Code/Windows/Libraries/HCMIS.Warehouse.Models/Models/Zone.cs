using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Zone")]
    public class Zone
    {
        [Key][Column("ID")]
        public int ZoneID { get; set; }
        public string ZoneName { get; set; }
       
        public string ZoneCode { get; set; }
        public Guid? RegionGuid { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
    }
}
