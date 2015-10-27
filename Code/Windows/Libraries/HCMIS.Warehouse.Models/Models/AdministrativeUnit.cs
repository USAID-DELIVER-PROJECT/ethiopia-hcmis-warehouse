using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("AdministrativeUnit", Schema = "AdministrativeUnit")]
    public class AdministrativeUnit
    {
        [Key]
        public int AdministrativeUnitID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int SN { get; set; }
        public int AdministrativeUnitLevel { get; set; }

       

    }
}
