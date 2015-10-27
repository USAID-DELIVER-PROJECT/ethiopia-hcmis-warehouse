using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("GeneralInfo")]
    public class GeneralInfo
    {
        [Key][Column("ID")]
        public int GeneralInfoID { get; set; }
        public string HospitalName { get; set; }
        public int? Woreda { get; set; }
        public int? Zone { get; set; }
        public int? Region { get; set; }
        public string Telephone { get; set; }
        public string HospitalContact { get; set; }
        public int? LeadTime { get; set; }
        public int? Min { get; set; }
        public int? Max { get; set; }
        public int? SafteyStock { get; set; }
        public int? AMCRange { get; set; }
        public int? ReviewPeriod { get; set; }
        public double EOP { get; set; }
        public string Description { get; set; }
        public bool? IsEven { get; set; }
        public string Logo { get; set; }
        public double? DUMin { get; set; }
        public double? DUMax { get; set; }
        public int? DUAMCRange { get; set; }
        public DateTime? LastBackUp { get; set; }
        public int? FacilityID { get; set; }
        public Guid? FacilityGuid { get; set; }
        public byte[] Image { get; set; }
       
        public int? InstitutionITypeID { get; set; }

       



    }
}
