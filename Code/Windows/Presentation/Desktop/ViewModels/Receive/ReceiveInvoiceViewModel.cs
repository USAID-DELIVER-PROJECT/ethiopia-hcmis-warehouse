using System;

namespace HCMIS.Desktop.ViewModels.Receive
{
    public class ReceiveInvoiceViewModel
    {
        public int ID { get; set; }
        public int InvoiceTypeID { get; set; }
        public string STVOrInvoiceNo { get; set; }
        public DateTime DateOfEntry { get; set; }
        public double TotalValue { get; set; }
        public DateTime PrintedDate{ get; set; }
        public string  ActivityName { get; set; }
        public string AccountName { get; set; }
        public string SubAccountName { get; set; }
        public string Mode { get; set; }
        public string PONo { get; set; }
        public string SupplierName { get; set; }
        public string Shipper { get; set; }
        public string PrintedDateString { get; set; }
    }
}
