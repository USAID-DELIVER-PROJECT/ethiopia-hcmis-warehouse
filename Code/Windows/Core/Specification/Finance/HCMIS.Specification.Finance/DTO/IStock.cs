using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Specification.Finance.DTO
{
   public interface IStock
    {
         int ItemId { get; set; }
         int UnitId { get; set; }
         int ManufacturerId { get; set; }
         int MovingAverageId { get; set; }

         decimal Quantity { get; set; }
         decimal UnitCost { get; set; }
         decimal Margin { get; set; }
         decimal SellingPrice { get; set; }
         string Identifier { get; set; }
    }
}
