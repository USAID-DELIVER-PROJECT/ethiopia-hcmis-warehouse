using System;

namespace HCMIS.Desktop.ViewModels.Approval
{
    public class ManufacturerViewModel
    {
        public int ManufacturerID { get; set; }
        public string NameAndQuantity { get { return String.Format("{0} ({1})", Name, Quantity.ToString("#,##0.##")); } }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public decimal Quantity { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}