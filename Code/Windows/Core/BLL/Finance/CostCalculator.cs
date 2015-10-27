using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using BLL.Finance;
using HCMIS.Core.Finance.CostTier;
using HCMIS.Specification.Finance.CostTier;

namespace BLL
{
    public class CostCalculator:ICostCalculator{

       //different table required for calculation;
       private DataTable _GRVDetail;
       private DataTable _PreviousStock;

       //ID of The GRV;
       private int ReceiptID;
       readonly BLL.Receipt GRV = new Receipt();
           
       //
       private double _SubTotal = 0;
       private double _Insurance = 0;
       private double _GrandTotal = 0;
       private double _CostCoefficient;
       private double _PriceDifference = 0;
       private double _PriceDifferenceIns = 0;
       private double _GrandTotalCost = 0;
       private string _Supplier;
       private string _CommodityType;
       private bool _isDeliveryNote;
       private double _OtherExpense;
       public int PreviousRowCount=0;
       private string _SubAccount;
       public CostCalculator()
       {

       }

       public void LoadGRV(int ReceiptID)
       {
           this.ReceiptID = ReceiptID;
           LoadGRVDetails();

       }

       public DataTable GRVDetail
       {
           get
           {
               return _GRVDetail;
           }
       }
        //Because i have Removed _GRVSoundDetail and Replace it with GRVDetail
       public DataTable GRVSoundDetail
       {
           get
           {
               return _GRVDetail;
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
               return _Insurance;
           }
           set
           {
               _Insurance = value;
           }
       }
      
       public double OtherExpense
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
           set
           {
               _GrandTotal = value;
           }
       }
        
       public double CostCoefficient
       {
           get
           {
               return _CostCoefficient;
           }
       }
        
       private void LoadGRVDetails()
       {
           GRV.LoadByPrimaryKey(ReceiptID);
           _GRVDetail = GRV.GetGRVDetailsforCosting();
           if (!GRV.IsColumnNull("Insurance"))
           _Insurance = GRV.Insurance;
          //Other Expenses
          if(!GRV.IsColumnNull("Provision"))
          _OtherExpense = GRV.Provision;
           _SubTotal = GetSubTotal();
           _GrandTotal = _SubTotal + _Insurance + _OtherExpense;
        }
      
       public void LoadGRVPreviousStock()
      {
          _PreviousStock = Receipt.GetPreviousStockforMovingCosting(ReceiptID);
      }
       public double GetGrandTotalForSRM()
       {
           double sum = 0;
           if (GRVDetail != null)
               foreach (DataRowView drv in GRVSoundDetail.DefaultView)
               {
                    if (drv["InvoiceCost"] != DBNull.Value && drv["UnitCost"] != DBNull.Value)
                        sum = sum + Convert.ToDouble(drv["UnitCost"]) * Convert.ToDouble(drv["InvoiceQty"]);
               }
           return sum;
       }
 
       public double GetSubTotal()
       {
           double sum = 0;
           if(GRVDetail != null)
               foreach(DataRowView drv in GRVDetail.DefaultView)
               {
                   if(drv["TotalInvoiceCost"] != DBNull.Value)
                        sum = sum + Convert.ToDouble(drv["TotalInvoiceCost"]);
                   if(drv["CommodityTypeName"] != DBNull.Value)
                   _CommodityType = drv["CommodityTypeName"].ToString();
                   if(drv["SupplierName"] != DBNull.Value)
                   _Supplier = drv["SupplierName"].ToString();
                   if (drv["SubAccountName"] != DBNull.Value)
                       _SubAccount = drv["SubAccountName"].ToString();
               }
           return sum;
       }

       public void CalculateCostCoefficient()
       {
           if (_SubTotal != 0)
               _CostCoefficient = Math.Round(_GrandTotal / _SubTotal,6);
           IterateAndCalculateUnitCost();
       }

       public void SaveInsurance()
       {
           Receipt GRV = new Receipt();
           GRV.LoadByPrimaryKey(ReceiptID);
           GRV.Insurance = _Insurance;
           GRV.Provision = _OtherExpense;
           GRV.Save();
       }
       
       public void IterateAndCalculateUnitCost()
       {
             double sum = 0;
             double SumwithoutRounding = 0;
                   _PriceDifferenceIns = 0;
           if (GRVDetail != null)
               foreach (DataRowView drv in GRVDetail.DefaultView)
               {
                   drv["UnitCost"] = Math.Round(Convert.ToDouble(drv["InvoiceCost"]) * CostCoefficient, BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
                   drv["TotalCost"] = Math.Round(Convert.ToInt32(drv["ReceivedQty"]) * Convert.ToDouble(drv["UnitCost"]), 2);
                   sum = sum + Convert.ToDouble(drv["TotalCost"]);
                   SumwithoutRounding = SumwithoutRounding + (Convert.ToDouble(drv["InvoiceCost"]) * CostCoefficient) * Convert.ToDouble(drv["ReceivedQty"]);
               }
           _PriceDifferenceIns = SumwithoutRounding - sum;
           
       }

       public void SaveCostCoefficientAndTotalValue(int userID)
       {
           ReceiveDoc grvFullDetail = new ReceiveDoc();
           grvFullDetail.FlushData();
           grvFullDetail.LoadAllByReceiptID(GRV.ID);

           while (!grvFullDetail.EOF)
           {
                  //Insurance here is costCoefficient
                ReceiveDoc receivedoc = new ReceiveDoc();
                receivedoc.LoadByPrimaryKey(grvFullDetail.ID);
                //Use Custom StoreProcedure for Costing
                receivedoc.Insurance = CostCoefficient;
                receivedoc.Save();
                ReceiveDoc.SetUnitCostByReceiveDoc(grvFullDetail.ID,Math.Round(receivedoc.PricePerPack * CostCoefficient,2),userID);
                ReceiveDoc.SetAverageCostByReceiveDoc(grvFullDetail.ID,Math.Round(receivedoc.PricePerPack * CostCoefficient,2),userID);
                grvFullDetail.MoveNext(); 
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
       
       public DataView GetCostBuildUp()
       {
           DataTable CostBuildup = new DataTable();
           CostBuildup.Columns.Add("Name",System.Type.GetType("System.String"));
           CostBuildup.Columns.Add("Value",System.Type.GetType("System.Double"));

           DataRow NewRow = CostBuildup.NewRow();
           NewRow["Name"] = "Total";
           NewRow["Value"] = _SubTotal;
           CostBuildup.Rows.Add(NewRow);
           
           NewRow = CostBuildup.NewRow();
           NewRow["Name"] = "Insurance";
           NewRow["Value"] = _Insurance;
           CostBuildup.Rows.Add(NewRow);
           
           NewRow = CostBuildup.NewRow();
           NewRow["Name"] = "Total Landed Cost";
           NewRow["Value"] = _GrandTotal;
           CostBuildup.Rows.Add(NewRow);
           
           NewRow = CostBuildup.NewRow();
           NewRow["Name"] = "Cost Coefficient";
           NewRow["Value"] = _CostCoefficient;
           CostBuildup.Rows.Add(NewRow);

           return CostBuildup.DefaultView;
       }

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
            double GIT = _GrandTotalCost;
           //When insurance is included (_TotalLandedCost-_GrandTotal) is the price effect cauzed by rounding

            double PriceDifference = Math.Round(_PriceDifference - _PriceDifferenceIns,Settings.NoOfDigitsAfterTheDecimalPoint);

            if (receiveDoc.ReturnedStock)
            {
                double stock = Math.Round(GetGrandTotalForSRM(), 2);
                return SRMCostAnalysis(UnitCostJournal, _CommodityType, stock, stock,ReceiptID);
            }
                UnitCostJournal.AddNewEntry("Stock (" + _CommodityType + ")",
                                            Math.Round(_GrandTotalCost + PriceDifference,
                                                       Settings.NoOfDigitsAfterTheDecimalPoint), null);
                if (PriceDifference > 0)
                {
                    UnitCostJournal.AddNewEntry("Price Difference", null, Math.Abs(PriceDifference));
                }
                else if (PriceDifference < 0)
                {
                    UnitCostJournal.AddNewEntry("Price Difference", Math.Abs(PriceDifference), null);
                }
                UnitCostJournal.AddNewEntry(
                    "Account Payable (" + GetAccountPayableCorrectNameByAccount(_Supplier) + ")", null,
                    Math.Round(_GrandTotalCost, Settings.NoOfDigitsAfterTheDecimalPoint));
            

           return UnitCostJournal.DefaultView();
       }


       public DataView SRMCostAnalysis(JournalEntry UnitCostJournal, string CommodityType, double Stock, double CostOfSales,int receiptID)
       {
           UnitCostJournal.AddNewEntry(String.Format("Stock ({0})", CommodityType), Stock, null);
           UnitCostJournal.AddNewEntry("Cost of Good Sold", null, CostOfSales);
           return UnitCostJournal.DefaultView();
       }

      public bool CalculateFinalCost()
       {
           CostElements = new List<CostElement>();
           _GrandTotalCost = 0;
           _PriceDifference = 0;
           foreach (DataRowView drv in GRVSoundDetail.DefaultView)
           {
               CostElement costElement = new CostElement(ReceiptID, Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["MovingAverageID"]), Convert.ToInt32(drv["ManufacturerID"]));

               costElement.LoadAverageCostCalculator();
               costElement.Qty = Convert.ToDouble(drv["ReceivedQty"]);
               costElement.UnitCost = Convert.ToDouble(drv["UnitCost"]);
               if (drv["Margin"] != DBNull.Value) costElement.Margin = Convert.ToDouble(drv["Margin"]);
               costElement.PreviousStock = GetPreviousStockDataRowView(costElement.ItemID, costElement.ManufacturerID
                                                                    , costElement.ItemUnitID, costElement.MovingAverageID);

               if (PreviousRowCount > 1)
                   return false;
               costElement.CalculateAverageCost();

               drv["AverageCost"] = costElement.AverageCost;
               drv["SellingPrice"] = costElement.SellingPrice;
               _PriceDifference = _PriceDifference + costElement.AverageCostCalculator.PriceDifference;
               _GrandTotalCost = _GrandTotalCost + Convert.ToDouble(drv["TotalCost"]);

               CostElements.Add(costElement);
           }
           return true;
       }
        [Obsolete("USE CalculateFinalCost")]
 
      public bool CalculateFinalCosts()
       {
           _GrandTotalCost = 0;
           _PriceDifference = 0;
           foreach(DataRowView drv in GRVSoundDetail.DefaultView)
           {
               AverageCostCalculator averageCostCalculator = new AverageCostCalculator();
               averageCostCalculator.LoadbyParameter(ReceiptID,Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ManufacturerID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["AccountID"]),Convert.ToInt32(drv["ActivityID"]));
               
               DataRowView drvPrevious = GetPreviousStockDataRowView(averageCostCalculator.ItemID,averageCostCalculator.ManufacturerID
                                                                    ,averageCostCalculator.ItemUnitID,averageCostCalculator.AccountID);
               if(!BLL.Settings.UseCostTier && PreviousRowCount >2)
                    return false;
               
               double NewUnitCost,NewSellingPrice;
               var recQty = drv["ReceivedQty"];
               var unitCost = drv["UnitCost"];
               if (drvPrevious != null)
               {
                   var prevQty = drvPrevious["PreviousQty"];
                   var prevUnitCost = drvPrevious["UnitCost"];
                   
                   NewUnitCost = averageCostCalculator.CalculateMovingAverage(Convert.ToDouble(prevQty),
                                                                              Convert.ToDouble(prevUnitCost),
                                                                              Convert.ToDouble(recQty),
                                                                              Convert.ToDouble(unitCost));
               }

               else
                   NewUnitCost = averageCostCalculator.CalculateMovingAverage(0,0, Convert.ToDouble(recQty), Convert.ToDouble(unitCost));
               if (BLL.Settings.IsCenter)
                   NewSellingPrice = NewUnitCost;
               else if (drv["Margin"] != DBNull.Value)
                   NewSellingPrice = averageCostCalculator.GetSellingPrice(Convert.ToDouble(drv["Margin"]));
               else
                   NewSellingPrice = averageCostCalculator.GetSellingPrice(0);
              
               drv["AverageCost"] =  NewUnitCost;
               drv["SellingPrice"] = NewSellingPrice;
               _PriceDifference = _PriceDifference  + averageCostCalculator.PriceDifference;
               
               _GrandTotalCost = _GrandTotalCost + Convert.ToDouble(drv["TotalCost"]);
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
               AverageCostCalculator averageCostCalculator = new AverageCostCalculator();
               averageCostCalculator.LoadbyParameter(ReceiptID, Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ManufacturerID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["AccountID"]), Convert.ToInt32(drv["ActivityID"]));
               DataRowView drvPrevious = GetPreviousStockDataRowView(averageCostCalculator.ItemID, averageCostCalculator.ManufacturerID
                                                                    , averageCostCalculator.ItemUnitID, averageCostCalculator.AccountID);

               double NewUnitCost, NewSellingPrice;
               double PreviousQuantity, PreviousUnitCost;

               if (drvPrevious != null)
               {
                   PreviousQuantity = Convert.ToDouble(drvPrevious["PreviousQty"]) + Convert.ToDouble(drv["ReceivedQty"]);
                   PreviousUnitCost = Convert.ToDouble(drvPrevious["UnitCost"]);
                   NewUnitCost = averageCostCalculator.CalculateMovingAverage(PreviousQuantity, PreviousUnitCost, -Convert.ToDouble(drv["ReceivedQty"]), Convert.ToDouble(drv["UnitCost"]));
               }
               else
                   NewUnitCost = averageCostCalculator.CalculateMovingAverage(Convert.ToDouble(drv["ReceivedQty"]), Convert.ToDouble(drv["UnitCost"]), Convert.ToDouble(drv["ReceivedQty"]), Convert.ToDouble(drv["UnitCost"]));

               if (drv["Margin"] != DBNull.Value)
               {
                   NewSellingPrice = averageCostCalculator.GetSellingPrice(Convert.ToDouble(drv["Margin"]));
                   averageCostCalculator.SaveWeightedAverageLog(Userid, ReceiptID, Convert.ToDouble(drv["Margin"]), NewSellingPrice);
               }
               else
               {
                   NewSellingPrice = averageCostCalculator.GetSellingPrice(0);
                   averageCostCalculator.SaveWeightedAverageLog(Userid, ReceiptID, 0, NewSellingPrice);
               }

           }
       }

       public void VoidGRVUnitCost()
       {
           foreach (DataRowView drv in GRVSoundDetail.DefaultView)
           {
               AverageCostCalculator averageCostCalculator = new AverageCostCalculator();
               averageCostCalculator.LoadbyParameter(ReceiptID, Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ManufacturerID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["AccountID"]), Convert.ToInt32(drv["ActivityID"]));
               DataRowView drvPrevious = GetPreviousStockDataRowView(averageCostCalculator.ItemID, averageCostCalculator.ManufacturerID
                                                                    , averageCostCalculator.ItemUnitID, averageCostCalculator.AccountID);

               double NewUnitCost, NewSellingPrice;
               double PreviousQuantity, PreviousUnitCost;

               if (drvPrevious != null)
               {
                   PreviousQuantity = Convert.ToDouble(drvPrevious["PreviousQty"]) + Convert.ToDouble(drv["ReceivedQty"]);
                   PreviousUnitCost = Convert.ToDouble(drvPrevious["UnitCost"]);
                   NewUnitCost = averageCostCalculator.CalculateMovingAverage(PreviousQuantity, PreviousUnitCost, -Convert.ToDouble(drv["ReceivedQty"]), Convert.ToDouble(drv["UnitCost"]));
               }
               else
                   NewUnitCost = averageCostCalculator.CalculateMovingAverage(Convert.ToDouble(drv["ReceivedQty"]), Convert.ToDouble(drv["UnitCost"]), Convert.ToDouble(drv["ReceivedQty"]), Convert.ToDouble(drv["UnitCost"]));

               if (drv["Margin"] != DBNull.Value)
               {
                   NewSellingPrice = averageCostCalculator.GetSellingPrice(Convert.ToDouble(drv["Margin"]));
               }
               else
               {
                   NewSellingPrice = averageCostCalculator.GetSellingPrice(0);
               }

               drv["AverageCost"] = NewUnitCost;
               drv["SellingPrice"] = NewSellingPrice;
           }
       }

       private DataRowView GetPreviousStockDataRowView(int ItemID,int ManufacturerID,int ItemUnitID,int AccountID)
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
                   CostElement costElement = new CostElement();
                   costElement.ItemID = Convert.ToInt32(drv["ItemID"]);
                   costElement.ItemUnitID = Convert.ToInt32(drv["ItemUnitID"]);
                   costElement.MovingAverageID = Convert.ToInt32(drv["MovingAverageID"]);
                   costElement.ManufacturerID = Convert.ToInt32(drv["ManufacturerID"]);
                   costElement.AverageCost = Math.Round(Convert.ToDouble(drv["AverageCost"]), Settings.NoOfDigitsAfterTheDecimalPoint);
                   costElement.SellingPrice = Math.Round(Convert.ToDouble(drv["SellingPrice"]), Settings.NoOfDigitsAfterTheDecimalPoint);
                   costElement.Margin = drv["Margin"] != DBNull.Value ? Convert.ToDouble(drv["Margin"]) : 0;
 
                   ReceiveDocDetails = 
                            ReceiveDoc.GetRelatedReceiveForUnitCostAndSellingPrice(ReceiptID,costElement);
               
                   foreach (DataRowView Cursor in ReceiveDocDetails.AsDataView())
                   {
                       int ID = Convert.ToInt32(Cursor["ID"]);
                       ReceiveDoc.SetAverageCostByReceiveDoc(ID, costElement.AverageCost, userID);
                       ReceiveDoc.SetSellingPriceByReceiveDoc(ID, costElement.SellingPrice, userID);
                   }
                   costElements.Add(costElement);
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

       public string GetAccountPayableCorrectNameByAccount(string SupplierName)
        {
            if (_SubAccount == "Consignment")
                return "Con. " + SupplierName;
            return SupplierName;
        }

        public void LoadGRVForCostAnalysis(int ReceiptID)
        {
            GRV.LoadByPrimaryKey(ReceiptID);
           _GRVDetail = GRV.GetGRVDetailsforCostAnalysis(ReceiptID);
           LoadPreviousStockForCostAnalysis(ReceiptID);
            if (!GRV.IsColumnNull("Insurance"))
           _Insurance = GRV.Insurance;
          //Other Expenses
          if(!GRV.IsColumnNull("Provision"))
          _OtherExpense = GRV.Provision;
           _SubTotal = GetSubTotal();
           _GrandTotal = _SubTotal + _Insurance + _OtherExpense;
           CalculateCostCoefficient();
           CalculateFinalCost();
        }

        public void LoadPreviousStockForCostAnalysis(int ReceiptID)
        {
          _PreviousStock = Receipt.GetPreviousStockforMovingCosting(ReceiptID);
        }
    }
}
