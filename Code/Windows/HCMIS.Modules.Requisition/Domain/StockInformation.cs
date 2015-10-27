using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Modules.Requisition.Domain
{
    public class StockInformation
    {
        public StockInformation()
        {
            
        }
        public StockInformation(StockInformation stockInformation)
        {
            Item = stockInformation.Item;
            Unit = stockInformation.Unit;
            Activity = stockInformation.Activity;
            Manufacturer = stockInformation.Manufacturer;
            PhysicalStore = stockInformation.PhysicalStore;
            ExpiryDate = stockInformation.ExpiryDate;
            Quantity = stockInformation.Quantity;
        }
        public Item Item { get; set; }
        public Unit Unit { get; set; }
        public ActivityGroup Activity { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public PhysicalStore PhysicalStore { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal Quantity { get; set; }
    }
}
