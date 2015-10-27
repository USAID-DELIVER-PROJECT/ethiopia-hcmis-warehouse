using System;
using System.Collections.Generic;
using System.Data;
using HCMIS.Core.Finance.CostTier;
using HCMIS.Core.Finance.CostTier.Services;
using HCMIS.Specification.Finance.CostTier;

namespace BLL.Finance
{
    public class CostingService
    {
        public static DataTable SetPrice(DataTable dataTable)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var ledgerService = new LedgerService();
                var ledgerObject = ledgerService.GetLedger(Convert.ToInt32(dataRow["ItemID"])
                                                               , Convert.ToInt32(dataRow["ItemUnitID"])
                                                               , Convert.ToInt32(dataRow["ManufacturerID"])
                                                               , Convert.ToInt32(dataRow["MovingAverageID"]));
                dataRow["UnitCost"] = Math.Round(ledgerObject.UnitCost, Settings.NoOfDigitsAfterTheDecimalPoint,
                                                 MidpointRounding.AwayFromZero);
                dataRow["TotalCost"] = Math.Round(ledgerObject.UnitCost * Convert.ToDecimal(dataRow["PreviousQty"]),
                                                  Settings.NoOfDigitsAfterTheDecimalPoint,
                                                  MidpointRounding.AwayFromZero);
            }
            return dataTable;
        }

       
        public static void SavePriceChange(IEnumerable<CostElement> costElements, int userId,ChangeType changeType,string identifier = "")
        {
            var journalService = new JournalService();
            journalService.StartRecordingSession();
           
            foreach (var costElement in costElements)
            {
                journalService.Record(identifier, costElement.ItemID, costElement.ItemUnitID,
                                      costElement.ManufacturerID, costElement.MovingAverageID,
                                      Convert.ToDecimal(costElement.AverageCost),
                                      Convert.ToDecimal(costElement.Margin),
                                      Convert.ToDecimal(costElement.SellingPrice), userId, changeType);
            }   
                   
            journalService.CommitRecordingSession();

        }

        public static void ConfirmPriceChange(IEnumerable<CostElement> costElements, int userId, ChangeType changeType, string identifier = "")
        {
            var journalService = new JournalService();
            journalService.StartRecordingSession();

            foreach (var costElement in costElements)
            {
                journalService.Confirm(identifier, costElement.ItemID, costElement.ItemUnitID,
                                      costElement.ManufacturerID, costElement.MovingAverageID,
                                      Convert.ToDecimal(costElement.AverageCost),
                                      Convert.ToDecimal(costElement.Margin),
                                      Convert.ToDecimal(costElement.SellingPrice), userId, changeType);
            }

            journalService.CommitRecordingSession();
        }
    }
}
