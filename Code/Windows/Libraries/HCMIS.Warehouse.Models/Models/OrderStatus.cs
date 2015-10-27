using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("OrderStatus")]
    public class OrderStatus
    {
        [Key][Column("ID")]
        public int OrderStatusID { get; set; }
        [Column("OrderStatus")]
        public string OrderStatusName { get; set; }

        public string OrderStatusCode { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
    }
}
