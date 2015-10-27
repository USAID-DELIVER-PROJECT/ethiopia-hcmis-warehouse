using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Specification.Finance.CostTier;
using HCMIS.Concrete.Models;
using HCMIS.Concrete.Repository;

namespace HCMIS.Core.Finance.CostTier
{
    
    public class LedgerService: ILedger
    {
       private RepositoryFactory repository ;

       public LedgerService(RepositoryFactory Repository)
       {
           repository = Repository;
       }

       public LedgerService()
       {
           repository = new RepositoryFactory();
       }

       public Ledger GetLedger(int ItemID,int UnitID,int ManufacturerID,int MovingAverageGroupID)
       {
           IEnumerable<Ledger> Ledgers = repository.LedgerLites.Find(l => l.ItemID == ItemID && l.UnitID == UnitID && l.ManufacturerID == ManufacturerID && l.AccountID == MovingAverageGroupID);
           Ledger Ledger = Ledgers.FirstOrDefault();
           if (Ledger == null)
           {
               Ledger = new Ledger() { ItemID = ItemID, UnitID = UnitID, ManufacturerID = ManufacturerID, AccountID = MovingAverageGroupID };
               repository.LedgerLites.Insert(Ledger);
               //Ledger = repository.LedgerLites.Single(l => l.ItemID == ItemID && l.UnitID == UnitID && l.ManufacturerID == ManufacturerID && l.AccountID == AccountID);
           }
           return Ledger;
       }

       public TempLedger GetTempLedger(int ItemID, int UnitID, int ManufacturerID, int MovingAverageGroupID)
       {
           IEnumerable<TempLedger> ledgers = repository.Ledgers.Find(l => l.ItemID == ItemID && l.UnitID == UnitID && l.ManufacturerID == ManufacturerID && l.AccountID == MovingAverageGroupID);
           TempLedger ledger = ledgers.FirstOrDefault();
           if (ledger == null)
           {
               ledger = new TempLedger() { ItemID = ItemID, UnitID = UnitID, ManufacturerID = ManufacturerID, AccountID = MovingAverageGroupID };
               repository.Ledgers.Insert(ledger);
               //Ledger = repository.LedgerLites.Single(l => l.ItemID == ItemID && l.UnitID == UnitID && l.ManufacturerID == ManufacturerID && l.AccountID == AccountID);
           }
           return ledger;
       }
     
       public TempLedger PostToTempLedger(int ItemID, int UnitID, int ManufacturerID, int AccountID, decimal UnitCost, decimal Margin, decimal SellingPrice,ChangeType changeType)
        {
            TempLedger Ledger = GetTempLedger(ItemID, UnitID, ManufacturerID, AccountID);
            Ledger.UnitCost = UnitCost;
            Ledger.Margin = Margin;
            Ledger.SellingPrice = SellingPrice;
            Ledger.ChangeType = changeType.Id;
            Ledger.IsConfirmed = false;
            return Ledger;
        }
       
       public Ledger PostToLedger(TempLedger ledger)
       {
           Ledger LedgerLite = GetLedger(ledger.ItemID, ledger.UnitID, ledger.ManufacturerID, ledger.AccountID);
           LedgerLite.UnitCost = ledger.UnitCost;
           LedgerLite.Margin = ledger.Margin;
           LedgerLite.SellingPrice = ledger.SellingPrice;
           ledger.IsConfirmed = true;
           repository.Ledgers.Update(ledger);
           return LedgerLite;
       }
   }
}
