using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ReceiveDocDeleted
    {
        public int ID { get; set; }
        public string BatchNo { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<long> Quantity { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> ExpDate { get; set; }
        public Nullable<bool> Out { get; set; }
        public Nullable<int> ReceivedStatus { get; set; }
        public string ReceivedBy { get; set; }
        public string Remark { get; set; }
        public Nullable<int> StoreID { get; set; }
        public string LocalBatchNo { get; set; }
        public string RefNo { get; set; }
        public Nullable<double> Cost { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<int> ManufacturerId { get; set; }
        public Nullable<long> QuantityLeft { get; set; }
        public Nullable<int> NoOfPack { get; set; }
        public Nullable<int> QtyPerPack { get; set; }
        public Nullable<System.DateTime> EurDate { get; set; }
        public Nullable<int> BoxLevel { get; set; }
        public Nullable<double> SellingPrice { get; set; }
        public Nullable<double> PricePerPack { get; set; }
        public Nullable<int> UnitID { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DateDeleted { get; set; }
        public Nullable<bool> DeliveryNote { get; set; }
        public Nullable<bool> Confirmed { get; set; }
        public Nullable<int> ConfirmedByUserID { get; set; }
        public Nullable<System.DateTime> ConfirmedDateTime { get; set; }
        public Nullable<bool> ReturnedStock { get; set; }
        public Nullable<int> ReturnedFromIssueDocID { get; set; }
        public Nullable<int> ReceiptID { get; set; }
        public Nullable<double> Margin { get; set; }
        public Nullable<double> Insurance { get; set; }
        public Nullable<int> InvoicedNoOfPack { get; set; }
        public Nullable<int> ShortageReasonID { get; set; }
        public virtual User User { get; set; }
    }
}
