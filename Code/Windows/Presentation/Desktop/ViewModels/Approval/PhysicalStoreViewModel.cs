using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Desktop.ViewModels.Approval
{
    public class PhysicalStoreViewModel
    {
        public int PhysicalStoreID { get; set; }
        public string NameAndQuantity { get { return String.Format("{0} ({1})", Name, Quantity.ToString("#,##0.##")); } }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
    }
}
