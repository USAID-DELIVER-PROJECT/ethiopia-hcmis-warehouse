using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Requisition")]
    public class Requisition
    {
        [Key][Column("ID")]
        public int RequisitionID { get; set; }
        public Guid? Identifier { get; set; }
        public string BranchIdentifier { get; set; }
        public int? ModeID { get; set; }
        public int? BranchID { get; set; }
        public int? ToBranchID { get; set; }
        public DateTime? RequisitionDate { get; set; }
        public int? RequisitionTypeID { get; set; }
        public int? RequisitionPriorityID { get; set; }
        public int? RequisitionStatusID { get; set; }
        public string Remark { get; set; }

    }
}
