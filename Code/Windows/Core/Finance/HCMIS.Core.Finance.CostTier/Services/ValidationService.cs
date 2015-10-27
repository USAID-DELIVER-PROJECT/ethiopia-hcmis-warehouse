using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Concrete.Models;

namespace HCMIS.Core.Finance.CostTier.Services
{
    public class ValidationService
    {

        internal static bool ValidateStockService(Specification.Finance.DTO.IStock newStock, Specification.Finance.DTO.IStock currentStock)
        {
            if (newStock.ItemId != currentStock.ItemId || newStock.UnitId != currentStock.UnitId || newStock.ManufacturerId != currentStock.ManufacturerId || newStock.MovingAverageId != currentStock.MovingAverageId)
            {
                //throw Different 
                throw new Exception("Stock that are being average. Can be averaged");
            }

            return true;
        }

        internal static bool ValidateLedger(TempLedger ledger,decimal UnitCost,decimal Margin,decimal SellingPrice)
        {
            if (ledger.UnitCost != UnitCost)
            {
                throw new Exception("The Average Cost you are Confirming is Different from the one that has been set,this usually happens when Quantity has changed since the moving Average has been Calculated,please return and recalculate moving average");
            }
            else if(ledger.Margin != Margin )
            {
               throw new Exception("The Margin you are Confirming is Different");
            }
            else if(ledger.SellingPrice != SellingPrice )
            {
                throw new Exception("The SellingPrice you are Confirming is Different");
            }
            return true;
        }
    }
}
