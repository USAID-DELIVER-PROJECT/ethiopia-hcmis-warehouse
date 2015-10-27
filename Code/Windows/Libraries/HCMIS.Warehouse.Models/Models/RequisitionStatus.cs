using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("RequisitionStatus")]
    public class RequisitionStatus
    {
        [Key][Column("ID")]
        public int RequisitionStatusID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string RequisitionStatusCode { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }

    }
}
