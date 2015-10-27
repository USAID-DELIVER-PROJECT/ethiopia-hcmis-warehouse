using System;
using HCMIS.Concrete.Models;
using HCMIS.Specification.Finance.CostTier;
using HCMIS.Concrete.Repository;
using EntityFramework.Patterns;

namespace HCMIS.Core.Finance.CostTier.Services
{
    public class JournalService :IJournalService
    {
        RepositoryFactory repository;
        private IUnitOfWork unitOfWork;

        private HCMIS.Concrete.Models.JournalLite JournalEntry;
        private ILedger LedgerService;

       public JournalService()
       {
           repository = new RepositoryFactory();
       }

       public JournalService(RepositoryFactory repository)
       {
           this.repository = repository;
       }
 
       public void StartRecordingSession()
       {
            unitOfWork = repository.UnitOfWork;
            LedgerService = new LedgerService(repository);
       }

       public void Record(string identifier, int itemID, int unitID, int ManufacturerID, int AccountID, decimal UnitCost, decimal Margin, decimal SellingPrice, int UserID, ChangeType changeType)
       {
           JournalEntry = new HCMIS.Concrete.Models.JournalLite()
                              {
                                  Identifier = identifier,
                                  Description = changeType.Description,
                                  Margin = Margin,
                                  UnitCost = UnitCost,
                                  SellingPrice = SellingPrice,
                                  UserID = UserID,
                                  Ledger = LedgerService.PostToTempLedger(itemID, unitID, ManufacturerID, AccountID, UnitCost, Margin, SellingPrice,changeType)
                              };
           repository.JournalLites.Insert(JournalEntry);
       }

       public void Confirm(string identifier, int itemId, int unitId, int manufacturerId, int accountId, decimal unitCost, decimal margin, decimal sellingPrice, int userId, ChangeType changeType)
     {
           TempLedger ledger = LedgerService.GetTempLedger(itemId, unitId, manufacturerId, accountId);
           if (ValidationService.ValidateLedger(ledger, unitCost, margin, sellingPrice))
           {

           JournalEntry = new HCMIS.Concrete.Models.JournalLite()
                              {
                                  Identifier = identifier,
                                  Description = changeType.Description,
                                  Margin = margin,
                                  UnitCost = unitCost,
                                  SellingPrice = sellingPrice,
                                  UserID = userId,
                                  Ledger = ledger
                              };
               repository.JournalLites.Insert(JournalEntry);
               LedgerService.PostToLedger(ledger);
            
           }
       }

        public void CommitRecordingSession()
        {
            unitOfWork.Commit();
        }
      
    }
}
