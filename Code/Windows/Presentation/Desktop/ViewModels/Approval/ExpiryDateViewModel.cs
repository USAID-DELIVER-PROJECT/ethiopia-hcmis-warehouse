using System;

namespace HCMIS.Desktop.ViewModels.Approval
{
    public class ExpiryDateViewModel
    {
        public string ValueAndQuantity { get { return String.Format("{0} ({1})", Text, Quantity.ToString("#,##0.##")); } }
        public string DaysAgoAndQuantity { get { return String.Format("{0} ({1})", DaysAgo, Quantity.ToString("#,##0.##")); } }
        public DateTime? Value { get; set; }
        public string Text { get; set; }
        public string DaysAgo { get; set; }
        public decimal Quantity { get; set; }
    }
}
