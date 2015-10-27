using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Activity")]
    public class Activity
    {
        [Key][Column("ID")]
        public int ActivityID { get; set; }
        public string Name { get; set; }
        
        public int? SubAccountID { get; set; }
       
        public int? MovingAverageGroupID { get; set; }
       
        public int? HospitalID { get; set; }
        [Column("AccountID")]
        public int? ModeID { get; set; }
        [Column("StoreGroupID")]
        public int? AccountID { get; set; }
       
        public int? CostingMethodID { get; set; }
        public bool? IsActive { get; set; }
        public Guid? SubAccountGuid { get; set; }
        public Guid? MovingAverageGuid { get; set; }
        public Guid? CostingMethodGuid { get; set; }
        public Guid? rowguid { get; set; }
        public int UsesMovingAverage { get; set; }  // the vwActivity has to  be changed for the time being I hv used a fake dataType
        public string ActivityCode  { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
        [ForeignKey("SubAccountID")]
        public SubAccount SubAccount { get; set; }
        [ForeignKey("MovingAverageGroupID")]
        public MovingAverageGroup MovingAverageGroup { get; set; }

        

    }
}
