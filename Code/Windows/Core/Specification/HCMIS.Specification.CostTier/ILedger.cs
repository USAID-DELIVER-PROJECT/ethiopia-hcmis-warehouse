using System;
using System.Collections.Generic;
using HCMIS.Concrete.Models;
using System.Linq;
using System.Text;

namespace HCMIS.Specification.Finance.CostTier
{
    public interface ILedger
    {
        TempLedger PostToTempLedger(int ItemID, int UnitID, int ManufacturerID, int AccountID, decimal UnitCost, decimal Margin, decimal SellingPrice,ChangeType changeType);

        Ledger GetLedger(int ItemID, int UnitID, int ManufacturerID, int AccountID);
        TempLedger GetTempLedger(int ItemID, int UnitID, int ManufacturerID, int AccountID);
        
        Ledger PostToLedger(TempLedger ledger);
    }
}
