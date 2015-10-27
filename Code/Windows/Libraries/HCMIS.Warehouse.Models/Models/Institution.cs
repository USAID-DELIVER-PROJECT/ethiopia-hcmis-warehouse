using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Institution")]
    public class Institution
    {
        [Key][Column("ID")]
        public int InstitutionID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public int? WoredaID { get; set; }
        public int? Route { get; set; }
        public int? RouteSequence { get; set; }
        public int? PaymentTypeID { get; set; }
        public string LicenseNo { get; set; }
        public string VATNo { get; set; }
        public string TinNo { get; set; }
        public DateTime? DateOfRegistration { get; set; }
        public string Town { get; set; }
        public string Kebele { get; set; }
        public int? RUType { get; set; }
        public int? Ownership { get; set; }
        [Column("Zone")]
        public int? ZoneID { get; set; }
        [Column("Active")]
        public bool? IsActive { get; set; }

        public bool? InProcess { get; set; }
        public Guid? rowguid { get; set; }
        public Guid? WoredaGuid { get; set; }
        public Guid? OwnershipTypeGuid { get; set; }
        public Guid? InstitutionTypeGuid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
        public bool? IsUsedAtFacility { get; set; }
        public bool? IsDraft { get; set; }
        public bool? IsLocalSite { get; set; }
        public int? AdministrativeUnitID { get; set; }

       
    }
}
