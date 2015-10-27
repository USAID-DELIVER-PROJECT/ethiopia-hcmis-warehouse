using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("PickList")]
    public class PickList
    {
        [Key][Column("ID")]
        public int PickListID { get; set; }

        public int? OrderID { get; set; }
        public string PickType { get; set; }
        public DateTime? IssueDate { get; set; }
        public bool? IsConfirmed { get; set; }
        public string Remark { get; set; }
        public DateTime? SavedDate { get; set; }
        public DateTime? PickedDate { get; set; }
        public int? PickedBy { get; set; }
        public int? PrintedBy { get; set; }
        public int? PickListTypeID { get; set; }
        public int? WarehouseID { get; set; }
        public bool IsWarehouseConfirmed { get; set; }
        public int? WarehouseConfirmedByUserID { get; set; }
        public DateTime? WarehouseConfirmedDate { get; set; }
        public int? PrintedID { get; set; }
    }
}
