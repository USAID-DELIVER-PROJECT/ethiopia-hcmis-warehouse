using System;
using System.Data;

namespace BLL
{
    public interface ICostCalculator
    {
        bool CalculateFinalCost();
        System.Data.DataView CostAnalysis(string pGRVNo);
      
        double CostCoefficient { get; }

        double GetSubTotal();
        double GrandTotal { get; }
        System.Data.DataTable GRVDetail { get; }
        System.Data.DataTable GRVSoundDetail { get; }
        double Insurance { get; set; }
        DataRow IsItemBeingPricedElsewhere();
        void LoadGRV(int ReceiptID);
        System.Data.DataTable PreviousStock { get; }
        System.Collections.Generic.IList<CostElement> CostElements { get; }
        DataView SRMCostAnalysis(JournalEntry journalEntry,string commodityType,double stock,double costOfSales,int receiptID );
        void LoadCostElements();
        void RecordAverageCostAndSellingPrice(int userID);
        void ReleaseForIssue();
        void SetFinalCostlog(int Userid);
        double SubTotal { get; }
        void SuspendFromIssuing();
        void VoidGRVUnitCost();
        void VoidGRVUnitCostlog(int Userid);
    }
}
