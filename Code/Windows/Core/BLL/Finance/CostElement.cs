using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HCMIS.Specification.Finance.CostTier;
using HCMIS.Core.Finance.CostTier;

namespace BLL
{
    public class CostElement
    {
        //Cost Elements Items that are going to be Averaged together
        //Criteria to be Average Together
        public int ItemID;
        public int MovingAverageID;
        public int ManufacturerID;
        public int ItemUnitID;
        public int? ReceiptID;
        public int? ActivityID;


        public double Qty;
        public double UnitCost;
        public double AverageCost;
        public double Margin;
        public double SellingPrice;

        //Detail Information
        string _ItemName;
        string _ManufacturerName;
        string _ItemUnitName;
        string _AccountName, _ActivityName;
        string _StockCode;
        public DataRowView PreviousStock;

        public String ItemName
        {
            get
            {
                return _ItemName;
            }
        }
        public String AccountName
        {
            get
            {
                return _AccountName;
            }
        }
        public String ActivityName
        {
            get
            {
                return _ActivityName;
            }
        }
        public String ManufacturerName
        {
            get
            {
                return _ManufacturerName;
            }
        }
        public String ItemUnitName
        {
            get
            {
                return _ItemUnitName;
            }
        }
        public String StockCode
        {
            get
            {
                return _StockCode;
            }
        }


        public CostElement()
        {

        }

        public void LoadFromDataRow(DataRow dataRow, int? receiptID = null)
        {
            if (receiptID.HasValue)
            {
                SetCostElementDetails(receiptID.Value, Convert.ToInt32(dataRow["ItemID"]), Convert.ToInt32(dataRow["MovingAverageID"]), Convert.ToInt32(dataRow["ManufacturerID"]), Convert.ToInt32(dataRow["ItemUnitID"]));
            }
            else
            {
                SetCostElementDetails(Convert.ToInt32(dataRow["ItemID"]), Convert.ToInt32(dataRow["MovingAverageID"]), Convert.ToInt32(dataRow["ManufacturerID"]), Convert.ToInt32(dataRow["ItemUnitID"]));

            }
        }
        public DataRow priceChangeReport(DataRow dr)
        {
            var costLedgerService = new LedgerService();
            var ledger = costLedgerService.GetLedger(ItemID, ItemUnitID, ManufacturerID,
                                                     MovingAverageID);

            dr["FullItemName"] = ItemName;
            dr["StockCode"] = StockCode;
            dr["Manufacturer"] = ManufacturerName;
            dr["Account"] = AccountName;
            dr["Unit"] = ItemUnitName;
            dr["PreviousUnitCost"] = ledger.UnitCost;
            dr["PreviousMargin"] = ledger.Margin;
            dr["PreviousSellingPrice"] = ledger.SellingPrice;
            dr["NewUnitCost"] = AverageCost;
            dr["NewMargin"] = Margin;
            dr["NewSellingPrice"] = SellingPrice;

            return dr;
        }

        public CostElement(int ReceiptID, int ItemID, int ItemUnitID, int AccountID, int ManufacturerID)
        {

            SetCostElementDetails(ReceiptID, ItemID, AccountID, ManufacturerID, ItemUnitID);

        }

        public CostElement(int ItemID, int AccountID, int ManufacturerID, int ItemUnitID)
        {

            SetCostElementDetails(ItemID, AccountID, ManufacturerID, ItemUnitID);

        }

        public void SetCostElementDetails(int ReceiptID, int ItemID, int MovingAverageID, int ManufacturerID, int ItemUnitID)
        {
            this.ItemID = ItemID;
            this.MovingAverageID = MovingAverageID;
            this.ManufacturerID = ManufacturerID;
            this.ItemUnitID = ItemUnitID;
            this.ReceiptID = ReceiptID;
            GetDetailInformation();
            LoadPreviousCostDetails();
        }

        public void SetCostElementDetails(int ItemID, int AccountID, int ManufacturerID, int ItemUnitID)
        {
            this.ItemID = ItemID;
            this.MovingAverageID = AccountID;
            this.ManufacturerID = ManufacturerID;
            this.ItemUnitID = ItemUnitID;
            GetDetailInformation();
            LoadPreviousCostDetails();
        }
        public void SetPriceForReceiveDocs()
        {
            ReceiveDoc receiveDoc = new ReceiveDoc();
            receiveDoc.LoadbyItemUnitManufacturerMovingAverageID(ReceiptID.Value,ItemID,ItemUnitID,ManufacturerID,MovingAverageID);
            receiveDoc.Rewind();
            while (!receiveDoc.EOF)
            {
                if(receiveDoc.IsColumnNull("PricePerPack") || !(receiveDoc.PricePerPack > 0))
                    receiveDoc.PricePerPack = AverageCost;   
                if(receiveDoc.IsColumnNull("UnitCost") || !(receiveDoc.PricePerPack > 0))
                    receiveDoc.UnitCost = Convert.ToDecimal(AverageCost);
                receiveDoc.Cost = AverageCost;
                receiveDoc.Margin = Margin;
                receiveDoc.SellingPrice = SellingPrice;
                receiveDoc.MoveNext();
            }
            receiveDoc.Save();
        }
        public void GetDetailInformation()
        {
            DataTable Information
                = ReceiveDoc.GetItemInformation(ItemID, ItemUnitID, ManufacturerID, MovingAverageID);
            if (Information.Rows.Count > 0)
            {
                DataRow dr = Information.Rows[0];
                _StockCode = dr["StockCode"].ToString();
                _ItemName = dr["FullItemName"].ToString();
                _ItemUnitName = dr["ItemUnitName"].ToString();
                _ManufacturerName = dr["ManufacturerName"].ToString();
                _AccountName = dr["AccountName"].ToString();
                _ActivityName = dr["ActivityName"].ToString();
            }
            else
            {
                _StockCode = _ItemName = _ItemUnitName = _ManufacturerName = _AccountName = "UnDefined";
            }
        }

        public PreviousCostPricingDetails PreviousCostDetials
        {
            get;
            private set;
        }

        public void LoadPreviousCostDetails()
        {
            PreviousCostDetials = new PreviousCostPricingDetails(this);
        }

        public AverageCostCalculator AverageCostCalculator
        {
            get;
            private set;
        }

        public void LoadAverageCostCalculator()
        {
            AverageCostCalculator = new AverageCostCalculator(this);
        }

        public void CalculateAverageCost()
        {

            if (PreviousStock != null)
            {
                AverageCost = AverageCostCalculator.CalculateMovingAverage(Convert.ToDouble(PreviousStock["PreviousQty"]), Convert.ToDouble(PreviousStock["UnitCost"]), Qty, UnitCost);
            }
            else
                AverageCost = AverageCostCalculator.CalculateMovingAverage(0, 0, Qty, UnitCost);

            if (!BLL.Settings.IsCenter)
            {
                SellingPrice =
                    AverageCostCalculator.GetSellingPrice(Margin);
            }
            else
            {
                SellingPrice =
                  AverageCostCalculator.GetSellingPrice(0);
            }
        }

        public void CheckMovingAverageCost()
        {
            PreviousCostDetials.CompareNewAverageCostWithTheAvgCostToBeSet(AverageCost);
        }

        public void SavePrice(int userID, string identifier, IJournalService journalService, ChangeType changeType)
        {
            journalService.Record(identifier, ItemID, ItemUnitID, ManufacturerID, MovingAverageID, Convert.ToDecimal(AverageCost), Convert.ToDecimal(Margin), Convert.ToDecimal(SellingPrice), userID, changeType);

        }
        public void ConfirmPrice(int userID, string identifier, IJournalService journalService, ChangeType changeType)
        {
            journalService.Confirm(identifier, ItemID, ItemUnitID, ManufacturerID, MovingAverageID, Convert.ToDecimal(AverageCost), Convert.ToDecimal(Margin), Convert.ToDecimal(SellingPrice), userID, changeType);

        }

        /// <summary>
        /// Fix For Delivery Note When Converting Do not use under any other situation
        /// </summary>
        /// <param name="issueDocID"></param>
        /// <param name="picklistID"></param>
        /// <returns></returns>
        public PickListDetail FixDeliveryNoteCostReceiveDoc(int issueDocID, int picklistID)
        {
            IssueDoc issueDoc = new IssueDoc();
            issueDoc.LoadByPrimaryKey(issueDocID);
            PickListDetail pickList = new PickListDetail();
            pickList.LoadByPrimaryKey(picklistID);
            //safety first 
            if (issueDoc.RecievDocID != pickList.ReceiveDocID)
            {
                Item item = new Item();
                item.LoadByPrimaryKey(picklistID);
                throw new Exception(String.Format("PicklistDetail vs IssueDoc Inconsistancy for Item {0}", item.FullItemName));

            }
            // now we are sure we have one ReceiveDocID
            ReceiveDoc receiveDoc = new ReceiveDoc();
            receiveDoc.LoadByPrimaryKey(pickList.ReceiveDocID);
            ReceiveDocConfirmation receiveDocConfirmation = new ReceiveDocConfirmation();
            receiveDocConfirmation.LoadByReceiveDocID(receiveDoc.ID);
            //Check if it has been Printed and that Selling Price and Cost is set
            if (receiveDocConfirmation.ReceiptConfirmationStatusID == ReceiptConfirmationStatus.Constants.GRV_PRINTED)
            {
                double unitPrice, unitCost, margin;
                if (Settings.IsCenter == true && !receiveDoc.IsColumnNull("Cost") && receiveDoc.Cost != 0)
                {
                    unitPrice = Math.Round(receiveDoc.Cost, 2);
                    unitCost = Math.Round(receiveDoc.Cost, 2);
                    margin = !receiveDoc.IsColumnNull("Margin") ? receiveDoc.Margin : 0;


                }
                else if (!receiveDoc.IsColumnNull("SellingPrice") && receiveDoc.SellingPrice != 0)
                {
                    unitPrice = Math.Round(receiveDoc.SellingPrice, 2);
                    unitCost = Math.Round(receiveDoc.SellingPrice, 2);
                    margin = !receiveDoc.IsColumnNull("Margin") ? receiveDoc.Margin : 0;

                }
                else
                {
                    var item = new Item();
                    item.LoadByPrimaryKey(pickList.ItemID);
                    throw new Exception(String.Format("Price Not set For item: {0}", item.FullItemName));
                }
                pickList.UnitPrice = unitPrice;
                pickList.Cost = Convert.ToDouble(pickList.Packs) * unitPrice;
                issueDoc.SellingPrice = Convert.ToDecimal(unitPrice);
                issueDoc.Cost = Convert.ToDouble(issueDoc.NoOfPack) * unitPrice;
                issueDoc.UnitCost = Convert.ToDecimal(unitCost);
                issueDoc.Margin = Convert.ToDecimal(margin);
                pickList.Save();
                issueDoc.Save();
            }
            else
            {
                var item = new Item();
                item.LoadByPrimaryKey(pickList.ItemID);
                throw new Exception(String.Format("GRV/IGRV Not Printed For Item: {0}", item.FullItemName));
            }
            return pickList;
        }
    }
}
