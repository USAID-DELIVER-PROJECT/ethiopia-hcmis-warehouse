using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Specification.Finance.DTO;

namespace HCMIS.Core.Finance.CostTier.DTO
{
    public class Stock:IStock
    {
        #region Implementation of IStock

        public Stock(int itemId,int unitId,int manufacturerId,int movingAverageId)
        {
            ItemId = itemId;
            UnitId = unitId;
            ManufacturerId = manufacturerId;
            MovingAverageId = movingAverageId;
        }

        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public int ManufacturerId { get; set; }
        public int MovingAverageId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Margin { get; set; }
        public decimal SellingPrice { get; set; }
        public string Identifier { get; set; }

        #endregion
    }
}
