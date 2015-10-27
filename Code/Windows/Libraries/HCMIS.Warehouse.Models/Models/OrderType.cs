using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("OrderType")]
    public class OrderType
    {
        [Key]
        public int OrderTypeID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string OrderTypeCode { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
    }
}
