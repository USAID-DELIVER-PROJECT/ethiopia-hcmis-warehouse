using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Woreda")]
    public class Woreda
    {
        [Key][Column("ID")]
        public int WoredaID { get; set; }

        public string WoredaName { get; set; }
        public int? ZoneID { get; set; }
        public string WoredaCode { get; set; }
        public Guid? ZoneGuid { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
        
    }
}
