using System;
using HCMIS.Modules.Requisition.Domain;

namespace HCMIS.Desktop.ViewModels.Approval
{
    public class StockInformationViewModel
    {
        private readonly StockInformation _stockInformation;

        public StockInformationViewModel(StockInformation stockInformation)
        {
            _stockInformation = stockInformation;
        }

        public string ActivityName { get { return _stockInformation.Activity.Name; } }
        public string ManufacturerName { get { return _stockInformation.Manufacturer.Name; } }
        public string PhysicalStoreName { get { return _stockInformation.PhysicalStore.Name; } }

        public string ActivityID { get { return _stockInformation.Activity.ActivityGroupID; } }
        public int ManufacturerID { get { return _stockInformation.Manufacturer.ManufacturerID; } }
        public int PhysicalStoreID { get { return _stockInformation.PhysicalStore.PhysicalStoreID; } }
        public DateTime? ExpiryDate { get { return _stockInformation.ExpiryDate; } }
        public decimal Quantity { get { return _stockInformation.Quantity; } }
    }
}