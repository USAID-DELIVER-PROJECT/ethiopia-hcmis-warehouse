using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("IssueDoc")]
    public class IssueDoc
    {
        [Key][Column("ID")]
        public int IssueDocID { get; set; }
        public int? ItemID { get; set; }
        [Column("StoreId")]
        public int? StoreID { get; set; }
        public int? ReceivingUnitID { get; set; }
        public string LocalBatchNo { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? Date { get; set; }
        public bool? IsTransfer { get; set; }
        public string IssuedBy { get; set; }
        public string Remark { get; set; }
        [Column("RefNo")]
        public string ReferenceNumber { get; set; }

        public string BatchNo { get; set; }
        public bool? IsApproved { get; set; }
        public double? Cost { get; set; }
        public decimal? NoOfPack { get; set; }
        public int? QtyPerPack { get; set; }
        public Int64? DUSOH { get; set; }
        public Int64? DURequestedQty { get; set; }
        public Int64? RecomendedQty { get; set; }
        [Column("RecievDocID")]
        public int? ReceiveDocID { get; set; }

        public DateTime? EurDate { get; set; }
        public int? OrderID { get; set; }
        public int? STVID { get; set; }
        public int? PLDetailID { get; set; }
        public bool? DeliveryNote { get; set; }
        public bool? DispatchConfirmed { get; set; }
        public int? DispatchConfirmedByUserID { get; set; }
        public DateTime? DispatchConfirmationDate { get; set; }
        public int? IssueTypeID { get; set; }
        public int? PhysicalStoreID { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? Margin { get; set; }
        public int? UnitID { get; set; }
        public int? ManufacturerID { get; set; }
        public int? InventoryPeriodID { get; set; }
        public decimal? NoOfPackIssued { get; set; }
    
    }
}
