using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMIS.Warehouse.Models
{
    [Table("ReceiveDoc")]
    public class ReceiveDoc
    {
        [Key][Column("ID")]
        public int ReceiveDocID { get; set; }

        public string BatchNo { get; set; }
        public int? ItemID { get; set; }
        public int? SupplierID { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? ExpDate { get; set; }
        public bool? Out { get; set; }
        public int? ReceivedStatus { get; set; }
        public string ReceivedBy { get; set; }
        public string Remark { get; set; }
        public int? StoreID { get; set; }
        public string LocalBatchNo { get; set; }
        public string RefNo { get; set; }
        public double?  Cost { get; set; }
        public bool? IsApproved { get; set; }
        [Column("ManufacturerId")]
        public int? ManufacturerID { get; set; }

        public decimal? QuantityLeft { get; set; }
        public decimal? NoOfPack { get; set; }
        public int? QtyPerPack { get; set; }
        public DateTime? EurDate { get; set; }
        public int? BoxLevel { get; set; }
        public double? SellingPrice { get; set; }
        public double? PricePerPack { get; set; }
        public int? UnitID { get; set; }
        public bool? DeliveryNote { get; set; }
        public bool? Confirmed { get; set; }
        public int? ConfirmedByUserID { get; set; }
        public DateTime? ConfirmedDateTime { get; set; }
        public bool? ReturnedStock { get; set; }
        public int? ReturnedFromIssueDocID { get; set; }
        public int? ReceiptID { get; set; }
        public double? Margin { get; set; }
        public double? Insurance { get; set; }
        public decimal? InvoiceNoOfPack { get; set; }
        public int? ShortageReasonID { get; set; }
        public decimal? UnitCost { get; set; }
        public int? PhysicalStoreID { get; set; }
        public int? InventoryPeriodID { get; set; }
    }
}
