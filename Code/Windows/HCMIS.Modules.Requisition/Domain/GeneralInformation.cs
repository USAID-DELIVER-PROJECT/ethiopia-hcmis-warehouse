using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HCMIS.Modules.Requisition.Domain
{
    public class GeneralInformation
    {
        public GeneralInformation()
        {
          
        }
        
        public Item Item { get; set; }
        public Unit Unit { get; set; }
        public ICollection<StockInformation> StockInformationDetails { get; set; }
        public ForcastingDetail ForcastingDetail { get; set; }
        public decimal SOH { get { return StockInformationDetails.Sum(s => s.Quantity); } }
        public decimal Amc { get { return ForcastingDetail.getAmc(); }}
        public decimal Mos { get { return ForcastingDetail.getMos(SOH); } }
       
         
    }
}
