using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using BLL.Finance;
using HCMIS.Core.Finance.CostTier;
using HCMIS.Specification.Finance.CostTier;

namespace BLL
{
    public class CenterCostCalculator : ICostCalculator
    {
        #region Initialize
        //different table required for calculation;
        private DataTable _GRVDetail;
        private DataTable _GRVDetailSound;
        private DataTable _Discrepancy;
        private DataTable _PreviousStock;
        private CostBuildup _CostBuildup;
        private string _Supplier;
        private string _CommodityType;


        //ID of The GRV;
        private int ReceiptID;
        readonly BLL.Receipt GRV = new Receipt();

        //
        private double _SubTotal = 0;


        private double _PriceDifference = 0;
        private decimal _Bonus = 0;
        private double _TotalLandedCost = 0;

        private double _OtherExpense = 0;
        private double _GrandTotal = 0;
        private double _Freight;
        private int PreviousRowCount;





        public CenterCostCalculator()
        {

        }

        

        public void LoadGRV(int ReceiptID)
        {
            this.ReceiptID = ReceiptID;
            LoadGRVDetails();
            LoadGRVPreviousStock();
            LoadGRVDiscrepancyDetails();
        }
        #endregion

        #region Properties
        public DataTable GRVDetail
        {
            get
            {
                return _GRVDetail;
            }
        }

        public CostBuildup CostBuildUp
        {
            get
            {
                return _CostBuildup;
            }
        }
        
        public DataTable GRVSoundDetail
        {
            get
            {
                return _GRVDetail;
            }
        }

        public DataTable GRVDiscrepancyDetail
        {
            get
            {
                return _Discrepancy;
            }
        }

        public DataTable PreviousStock
        {
            get
            {
                return _PreviousStock;
            }
        }

        public double Insurance
        {
            get
            {
                return _OtherExpense;
            }
            set
            {
                _OtherExpense = value;
            }
        }

        public double SubTotal
        {
            get
            {
                return _SubTotal;
            }
        }

        public double GrandTotal
        {
            get
            {
                return _GrandTotal;
            }
        }
        
        public string _Account;

        public double CostCoefficient
        {
            get
            {
                return Math.Round(_CostBuildup.CostCoefficient, 6);
            }
        }

        public void LoadCostBuilUp(bool AutoProrate,string GRNFString)
        {
          
            //ToDo: Remove the Setting Before Implementation
            _CostBuildup = new CostBuildup();
            ReceiptInvoice invoice = new ReceiptInvoice();
            invoice.LoadByPrimaryKey(GRV.ReceiptInvoiceID);
            _CostBuildup.UseTransitServiceCharge = false;
                _CostBuildup.AutoProrate = AutoProrate;
            _CostBuildup.LoadByReceiptIDInvoiceIDAndPoID(ReceiptID, invoice.ID, invoice.POID, GRNFString,_SubTotal);
        }
        
        private void LoadGRVDetails()
        {
            GRV.LoadByPrimaryKey(ReceiptID);
            _GRVDetail = GRV.GetGRVDetailsforCosting();
                           _SubTotal = GetSubTotalWithoutDamaged();

        }

        private void LoadGRVPreviousStock()
        {
            _PreviousStock = Receipt.GetPreviousStockforMovingCosting(ReceiptID);

        }

        private void LoadGRVDiscrepancyDetails()
        {
            _Discrepancy = Receipt.GetDiscrepancyGRVDetailsforCosting(ReceiptID);
        }
        
        #endregion

        #region Calculate
    
        public double GetSubTotalWithoutDamaged()
        {
            double sum = 0;
            if (GRVDetail != null)
                foreach (DataRowView drv in GRVDetail.DefaultView)
                {
                    if (drv["TotalInvoiceCost"] != DBNull.Value)
                        sum = sum + Convert.ToDouble(drv["TotalInvoiceCost"]);
                    if (drv["CommodityTypeName"] != DBNull.Value)
                        _CommodityType = drv["CommodityTypeName"].ToString();
                    if (drv["SupplierName"] != DBNull.Value)
                        _Supplier = drv["SupplierName"].ToString();

                }
            return sum;
        }

        public double GetSubTotal()
        {
            double sum = 0;
            if (GRVDetail != null)
                foreach (DataRowView drv in GRVSoundDetail.DefaultView)
                {
                    if (drv["TotalInvoiceCost"] != DBNull.Value)
                        sum = sum + Convert.ToDouble(drv["TotalInvoiceCost"]);
                    if (drv["CommodityTypeName"] != DBNull.Value)
                        _CommodityType = drv["CommodityTypeName"].ToString();
                    if (drv["SupplierName"] != DBNull.Value)
                        _Supplier = drv["SupplierName"].ToString();
                     
                }
            return sum;
        }

        public decimal GetTotalDamagedAndShortlanded()
        {
            decimal ClaimSupplier = 0;

            try
            {
                foreach (DataRowView drv in _Discrepancy.DefaultView)
                {
                    if(Convert.ToInt32(drv["ShortageReason"]) == ShortageReasons.Constants.DAMAGED || Convert.ToInt32(drv["ShortageReason"]) == ShortageReasons.Constants.SHORT_LANDED) 
                   ClaimSupplier = ClaimSupplier + GetSupplierClaimPerItem(Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["ManufacturerID"]), Convert.ToInt32(drv["ReceivedQty"]));
                }
                return ClaimSupplier;
            }
            catch
            {
            return 0M;
            }
        }
     
        public double GetGrandTotal()
        {
            double sum = 0;
            double SumwithoutRounding = 0;
            _PriceDifference = 0;
            _Bonus = 0;
            if (GRVDetail != null)
                foreach (DataRowView drv in GRVSoundDetail.DefaultView)
                {
                    decimal InvoiceCost = Convert.ToDecimal(drv["InvoiceCost"]); 
                    decimal ReceivedQty = Convert.ToDecimal(drv["ReceivedQty"]);
                    decimal BonusQty = ReceivedQty - Convert.ToDecimal(drv["InvoiceQty"]); 
                    if (drv["TotalCost"] != DBNull.Value && drv["UnitCost"] != DBNull.Value)
                        sum = sum + Convert.ToDouble(drv["TotalCost"]);

                        SumwithoutRounding = SumwithoutRounding + (Convert.ToDouble(InvoiceCost) * Convert.ToDouble(CostBuildUp.CostCoefficient) * Convert.ToDouble(ReceivedQty));
                       _Bonus = BonusQty > 0M ?(BonusQty * InvoiceCost * Convert.ToDecimal(CostBuildUp.CostCoefficient))+_Bonus:_Bonus;
                                                   
                }         
            _PriceDifference = SumwithoutRounding - sum;
            return sum;
        }

        public double GetGrandTotalForSRM()
        {
           double sum = 0;
           if (GRVDetail != null)
                foreach (DataRowView drv in GRVSoundDetail.DefaultView)
                {
                      if (drv["InvoiceCost"] != DBNull.Value && drv["UnitCost"] != DBNull.Value)
                        sum = sum + Convert.ToDouble(drv["UnitCost"])*Convert.ToDouble(drv["InvoiceQty"]);
                }
            return sum;
        }
            
        public void SaveCostCoefficient(int userID)
        {
            ReceiveDoc grvFullDetail = new ReceiveDoc();
            grvFullDetail.FlushData();
            grvFullDetail.LoadAllByReceiptID(GRV.ID);
            CostBuildUp.SaveChange();
            while (!grvFullDetail.EOF)
            {
                //Insurance here is costCoefficient
                ReceiveDoc receivedoc = new ReceiveDoc();
                receivedoc.LoadByPrimaryKey(grvFullDetail.ID);
                //Use Custom StoreProcedure for Costing
                    receivedoc.Insurance = CostCoefficient;
                    receivedoc.Save();
                    ReceiveDoc.SetUnitCostByReceiveDoc(grvFullDetail.ID, Math.Round(receivedoc.PricePerPack * CostCoefficient, 2), userID);
                    ReceiveDoc.SetAverageCostByReceiveDoc(grvFullDetail.ID, Math.Round(receivedoc.PricePerPack * CostCoefficient, 2), userID);
                grvFullDetail.MoveNext();
            }
        }
 
        public void SaveTotalCost()
        {

            Receipt GRV = new Receipt();
            GRV.LoadByPrimaryKey(ReceiptID);
            GRV.TotalValue = _SubTotal;
            GRV.Save();


        }
     
      

        #endregion

        #region CostAnalysis

        public DataView CostAnalysis(string pGRVNo)
       {

          
           Receipt receipt = new Receipt(ReceiptID);
           PO PO = receipt.ReceiptInvoice.PO;
           ReceiptInvoice receiptInvoice = receipt.ReceiptInvoice;
           ReceiveDoc receiveDoc = new ReceiveDoc();
           receiveDoc.LoadByReceiptID(ReceiptID);
            
           Activity activity = new Activity();
           activity.LoadByPrimaryKey(receiveDoc.StoreID);
           JournalEntry UnitCostJournal = new JournalEntry(activity.AccountName, activity.SubAccountName, activity.Name, PO.Supplier.CompanyName, "", PO.PONumber, pGRVNo, receiptInvoice.STVOrInvoiceNo, receiptInvoice.TransitTransferNo, receiptInvoice.WayBillNo, receiptInvoice.InsurancePolicyNo);
           
            double SupplierClaim = Convert.ToDouble(GetSupplierClaim());
            double InsuranceClaim = Convert.ToDouble(GetInsuranceClaim());
            double Provision = Convert.ToDouble(Math.Round(CostBuildUp.Provision, 2));
            double GrandTotal = Math.Round(GetGrandTotal(), 2);
            double PriceDifference = Math.Round(_PriceDifference, 2);
            double Bonus = Convert.ToDouble(Math.Round(_Bonus,2));
            //Request from Mery Formula Provide by Phone
            //Wednesday October 10
            double GIT = Math.Round(GrandTotal + SupplierClaim + InsuranceClaim + _PriceDifference - Provision - Convert.ToDouble(Bonus), 2);
                
            // trying out Sprout Method to Handle  
            if(receiveDoc.ReturnedStock)
            {
                double stock = Math.Round(GetGrandTotalForSRM(),2);
                return SRMCostAnalysis(UnitCostJournal,_CommodityType, stock, stock,ReceiptID);
            }
        
        
                if(POType.GetModes(PO.PurchaseType) == POType.STANDARD && CostBuildUp.Invoice.InvoiceTypeID != ReceiptInvoiceType.InvoiceType.LOCAL_PURCHASE && CostBuildUp.Invoice.InvoiceTypeID  != ReceiptInvoiceType.InvoiceType.CIP)
                {
                    UnitCostJournal.AddNewEntry(String.Format("Stock ({0})", _CommodityType), GrandTotal, null);
                    UnitCostJournal.AddNewEntry("ClaimFromSupplier", SupplierClaim, null);
                    UnitCostJournal.AddNewEntry("ClaimFromInsurance", InsuranceClaim, null);

                    if (PriceDifference < 0)
                    {
                        UnitCostJournal.AddNewEntry("Price Difference", null, Math.Abs(PriceDifference));
                    }
                    else if (PriceDifference > 0)
                    {
                        UnitCostJournal.AddNewEntry("Price Difference", Math.Abs(PriceDifference), null);
                    }

                    UnitCostJournal.AddNewEntry("GIT", null, GIT);
                    UnitCostJournal.AddNewEntry("Provision", null, Provision);
                    if (Bonus > 0)
                    {
                        UnitCostJournal.AddNewEntry("Other Income", null, Math.Abs(Bonus));
                    }
                }
                else if (activity.IsHealthProgram())
                {
                    UnitCostJournal.AddNewEntry(String.Format("Stock ({0})", _CommodityType), Math.Round(GrandTotal, Settings.NoOfDigitsAfterTheDecimalPoint), null);
                    if (PriceDifference < 0)
                    {
                        UnitCostJournal.AddNewEntry("Price Difference", null, Math.Abs(PriceDifference));
                    }
                    else if (PriceDifference > 0)
                    {
                        UnitCostJournal.AddNewEntry("Price Difference", Math.Abs(PriceDifference), null);
                    }
                    UnitCostJournal.AddNewEntry(String.Format("Net Asset ({0})", _Supplier), null, Math.Round(GrandTotal - PriceDifference - Bonus, Settings.NoOfDigitsAfterTheDecimalPoint));
                    if (Bonus > 0)
                    {
                        UnitCostJournal.AddNewEntry("Other Income", null, Math.Abs(Bonus));
                    }
                }
                else 
                {
                    UnitCostJournal.AddNewEntry(String.Format("Stock ({0})", _CommodityType), Math.Round(GrandTotal, Settings.NoOfDigitsAfterTheDecimalPoint), null);
                    if (PriceDifference > 0)
                    {
                        UnitCostJournal.AddNewEntry("Price Difference", null, Math.Abs(PriceDifference));
                    }
                    else if (PriceDifference < 0)
                    {
                        UnitCostJournal.AddNewEntry("Price Difference", Math.Abs(PriceDifference), null);
                    }
                    UnitCostJournal.AddNewEntry(String.Format("Account Payable ({0})", _Supplier), null, Math.Round(GIT - Convert.ToDouble(GetTotalDamagedAndShortlanded())-Bonus, Settings.NoOfDigitsAfterTheDecimalPoint));
                    if (Bonus > 0)
                    {
                        UnitCostJournal.AddNewEntry("Other Income", null, Math.Abs(Bonus));
                    }
                }
          
            return UnitCostJournal.DefaultView();
        }

        public DataView SRMCostAnalysis(JournalEntry UnitCostJournal,string CommodityType, double Stock, double CostOfSales,int receiptID)
        {
            Receipt receipt = new Receipt();
            string facilityName = receipt.FacilityName(receiptID);
            UnitCostJournal.AddNewEntry(String.Format("Stock ({0})", CommodityType), Stock, null);
            UnitCostJournal.AddNewEntry(String.Format("Account Receivable ({0})",facilityName), null, CostOfSales);
            return UnitCostJournal.DefaultView();
        }

        public double InsuredCoeff
        {
            get
            {
                return CostBuildUp.purchaseOrder.OtherExpense / CostBuildUp.purchaseOrder.TotalValue;
            }
        }

        private decimal GetInsuranceClaimPerItem(int ItemID, int UnitID, int ManufacturerID, int DamagedQty)
        {
            decimal insuredSum = 0;
            decimal totalQty = 0;

            try
            {
                foreach (DataRowView drv in _GRVDetail.DefaultView)
                {
                    if ((drv["InvoiceCost"] != DBNull.Value && Convert.ToInt32(drv["ItemID"]) == ItemID && Convert.ToInt32(drv["ItemUnitID"]) == UnitID && Convert.ToInt32(drv["ManufacturerID"]) == ManufacturerID))
                    {
                        insuredSum = insuredSum + Math.Round(Convert.ToDecimal(drv["InvoiceCost"]) * Convert.ToDecimal(InsuredCoeff) * DamagedQty, BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
                        totalQty = Math.Round(Convert.ToDecimal(drv["ReceivedQty"]), BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
                    }
                }
                return insuredSum;
            }
            catch
            {
                return 0;
            }
        }

        private decimal GetInsuranceClaim()
        {
            decimal ClaimInsurance = 0;
            
            try
            {
                foreach (DataRowView drv in _Discrepancy.DefaultView)
                {
                      if(Convert.ToInt32(drv["ShortageReason"]) == ShortageReasons.Constants.DAMAGED) 
               
                        ClaimInsurance = ClaimInsurance + GetInsuranceClaimPerItem(Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["ManufacturerID"]), Convert.ToInt32(drv["ReceivedQty"]));
                  
                }
                return ClaimInsurance;
            }
            catch
            { 
            return 0M;
            }
        }
    
        private decimal GetSupplierClaimPerItem(int ItemID, int UnitID, int ManufacturerID, int ShortageQty)
        {
            decimal supplierClaim = 0;

            try
            {
                foreach (DataRowView drv in _GRVDetail.DefaultView)
                {
                    if (drv["InvoiceCost"] != DBNull.Value && Convert.ToInt32(drv["ItemID"]) == ItemID && Convert.ToInt32(drv["ItemUnitID"]) == UnitID && Convert.ToInt32(drv["ManufacturerID"]) == ManufacturerID)
                    {
                        supplierClaim = Convert.ToDecimal(drv["InvoiceCost"]) * ShortageQty * Convert.ToDecimal(CostBuildUp.purchaseOrder.ExhangeRate);
                    }
                }
                return supplierClaim;
            }
            catch
            {
                return 0M;
            }
        }
     
        private decimal GetSupplierClaim()
        {
            decimal ClaimSupplier = 0M;

            try
            {
                foreach (DataRowView drv in _Discrepancy.DefaultView)
                {
                    if (Convert.ToInt32(drv["ShortageReason"]) == ShortageReasons.Constants.SHORT_LANDED) 
                             ClaimSupplier = ClaimSupplier + GetSupplierClaimPerItem(Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["ManufacturerID"]), Convert.ToInt32(drv["ReceivedQty"]));
                }
                return ClaimSupplier;
            }
            catch
            {
                return 0M;
            }
        }

        #endregion

        #region Finalize
        
        public bool CalculateFinalCost()
        {
            CostElements = new List<CostElement>();
            _TotalLandedCost = 0;
            _PriceDifference = 0;
            foreach (DataRowView drv in GRVSoundDetail.DefaultView)
            {
               if (Convert.ToDouble(drv["ReceivedQty"]) != 0)
                {
                     CostElement costElement = new CostElement(ReceiptID, Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["MovingAverageID"]), Convert.ToInt32(drv["ManufacturerID"]));
                
                costElement.LoadAverageCostCalculator();
                costElement.Qty = Convert.ToDouble(drv["ReceivedQty"]);
               
                 
                costElement.UnitCost = Convert.ToDouble(drv["UnitCost"]);
                if(drv["Margin"] != DBNull.Value)
                costElement.Margin = Convert.ToDouble(drv["Margin"]); 
                costElement.PreviousStock = GetPreviousStockDataRowView(costElement.ItemID, costElement.ManufacturerID
                                                                     , costElement.ItemUnitID, costElement.MovingAverageID);
             
          
                if (!BLL.Settings.UseCostTier && PreviousRowCount > 1)
                    return false;
               costElement.CalculateAverageCost();

                drv["AverageCost"] = costElement.AverageCost;
                drv["SellingPrice"] = costElement.SellingPrice;
                _PriceDifference = _PriceDifference + costElement.AverageCostCalculator.PriceDifference;
                _TotalLandedCost = _TotalLandedCost + Convert.ToDouble(drv["TotalCost"]);

                CostElements.Add(costElement);

                }
            }
            return true;
        }

        public void SetFinalCostlog(int Userid)
        {
            foreach (CostElement costElement in CostElements)
            {
                costElement.AverageCostCalculator.SaveWeightedAverageLog(Userid, ReceiptID, costElement.Margin, costElement.SellingPrice);
            }
        }

        public void VoidGRVUnitCostlog(int Userid)
        {
            foreach (DataRowView drv in GRVSoundDetail.DefaultView)
            {
              
            }
        }

        public void VoidGRVUnitCost()
        {
            foreach (DataRowView drv in GRVSoundDetail.DefaultView)
            {
               
            }
        }

        private DataRowView GetPreviousStockDataRowView(int ItemID, int ManufacturerID, int ItemUnitID, int AccountID)
        {
            DataRowView PreviousStockRow = null;
            // To Check if any Moving Average has been Change on it
            PreviousRowCount = 0;
            foreach (DataRowView drv in PreviousStock.DefaultView)
            {
                if (Convert.ToInt32(drv["ItemID"]) == ItemID && Convert.ToInt32(drv["ManufacturerID"]) == ManufacturerID && Convert.ToInt32(drv["ItemUnitID"]) == ItemUnitID && Convert.ToInt32(drv["MovingAverageID"]) == AccountID)
                {
                    PreviousStockRow = drv;
                    PreviousRowCount++;
                }
            }
            return PreviousStockRow;
        }

        public void SuspendFromIssuing()
        {
            foreach (DataRowView drv in GRVSoundDetail.DefaultView)
            {
                ReceiveDoc rd = new ReceiveDoc();
                rd.suspendForPricing(Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ManufacturerID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["MovingAverageID"]));

            }

        }

        public void ReleaseForIssue()
        {
            foreach (DataRowView drv in GRVSoundDetail.DefaultView)
            {
                ReceiveDoc rd = new ReceiveDoc();
                rd.releaseForIssue(Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ManufacturerID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["MovingAverageID"]));

            }

        }

        public void SaveAirFreight(double Freight)
        {
            ReceiptInvoice receiptInvoice = new ReceiptInvoice();
            receiptInvoice.LoadByPrimaryKey(GRV.ReceiptInvoiceID);
            if (receiptInvoice.InvoiceTypeID == ReceiptInvoiceType.InvoiceType.INVOICE_SEA)
            {
                _Freight = Freight;
                GRV.SeaFreight = _Freight;
            }
            else if (receiptInvoice.InvoiceTypeID == ReceiptInvoiceType.InvoiceType.INVOICE_AIR)
            {
                _Freight = Freight;
                GRV.AirFreight = _Freight;
            }
            GRV.Save();
            LoadGRV(GRV.ID);
        }

        public void RecordAverageCostAndSellingPrice(int userID)
        {
            MyGeneration.dOOdads.TransactionMgr transaction = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();

            try
            {
                transaction.BeginTransaction();
                DataTable ReceiveDocDetails;
                IList<CostElement> costElements = new List<CostElement>();

                foreach (DataRowView drv in GRVSoundDetail.DefaultView as DataView)
                {

                 double NewUnitCost, NewSellingPrice;
                 if (drv["AverageCost"] != DBNull.Value && drv["SellingPrice"] != DBNull.Value)
                 {

                     CostElement costElement = new CostElement();
                     costElement.ItemID = Convert.ToInt32(drv["ItemID"]);
                     costElement.ItemUnitID = Convert.ToInt32(drv["ItemUnitID"]);
                     costElement.MovingAverageID = Convert.ToInt32(drv["MovingAverageID"]);
                     costElement.ManufacturerID = Convert.ToInt32(drv["ManufacturerID"]);
                     costElement.AverageCost = costElement.SellingPrice = Math.Round(Convert.ToDouble(drv["SellingPrice"]), Settings.NoOfDigitsAfterTheDecimalPoint);
                     costElement.Margin = drv["Margin"] != DBNull.Value ? Convert.ToDouble(drv["Margin"]) : 0;
                     ReceiveDocDetails =
                             ReceiveDoc.GetRelatedReceiveForUnitCostAndSellingPrice(ReceiptID, costElement);


                     foreach (DataRowView Cursor in ReceiveDocDetails.AsDataView())
                     {
                         int ID = Convert.ToInt32(Cursor["ID"]);
                         ReceiveDoc.SetAverageCostByReceiveDoc(ID, costElement.AverageCost, userID);
                         ReceiveDoc.SetSellingPriceByReceiveDoc(ID, costElement.SellingPrice, userID);
                     }
                     costElements.Add(costElement);
                 }
             }
                try
                {
                    CostingService.SavePriceChange(costElements.AsEnumerable(), userID, ChangeMode.Recieve, ReceiptID.ToString());
              
                }
                catch (Exception)
                {
                    
                    //Until Cost Tier Implementation
                }
                transaction.CommitTransaction();
         }
         catch (Exception ex)
         {
             transaction.RollbackTransaction();
             throw ex;
         }
        }
#endregion
      
        #region CostElements

        public IList<CostElement> CostElements
        {
            get;
            private set;
        }

        public void LoadCostElements()
        {
            CostElements = new List<CostElement>();
           foreach (DataRowView drv in PreviousStock.DefaultView)
            {
                CostElements.Add(new CostElement(ReceiptID, Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["MovingAverageID"]), Convert.ToInt32(drv["ManufacturerID"])));
            }
        }


        public DataRow IsItemBeingPricedElsewhere()
        {
            DataTable List;
            foreach (DataRowView drv in GRVDetail.DefaultView)
            {
                List = ReceiveDoc.ListOfItemPendingPrintAndConfirmation(Convert.ToInt32(drv["ItemID"]),
                                                                        Convert.ToInt32(drv["ManufacturerID"]),
                                                                        Convert.ToInt32(drv["ItemUnitID"]),
                                                                        Convert.ToInt32(drv["MovingAverageID"]));
                if (List.Rows.Count>0)
                    return List.Rows[0];

            }
            return null;

        }

       
        #endregion

       
    }
}