using System;

namespace HCMIS.Specification.Finance.CostTier
{
    public interface IJournalService
    {
        void CommitRecordingSession();
     
        void Record(string identifier, int itemId, int unitID, int ManufacturerID, int AccountID, decimal UnitCost, decimal Margin, decimal SellingPrice, int UserID,ChangeType changeType);
        void Confirm(string identifier, int itemId, int unitId, int manufacturerId, int accountId, decimal unitCost, decimal margin, decimal sellingPrice, int userId, ChangeType changeType);
     
        void StartRecordingSession();

    }
}
