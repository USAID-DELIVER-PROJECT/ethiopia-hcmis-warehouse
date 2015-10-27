using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("FacilityHub")]
    public class FacilityHub
    {
        [Key][Column("ID")]
        public int FacilityHubID { get; set; }
        public int FacilityID { get; set; }
        public int HubID { get; set; }
        public Guid? FacilityGuid { get; set; }
        public Guid? HubGuid { get; set; }
        public Guid? rowguid { get; set; }

       

    }
}
