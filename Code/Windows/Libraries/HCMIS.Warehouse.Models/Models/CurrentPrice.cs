using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("CurrentPrice", Schema = "DW")]
    public class CurrentPrice
    {
        [Key][Column("ID")]
        public int CurrentPriceID { get; set; }

        public Guid ItemGuid { get; set; }
        public Guid UnitGuid { get; set; }
        public Guid ManufacturerGuid { get; set; }
        public Guid AccountGuid { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Margin { get; set; }
        public decimal SelllingPrice { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
