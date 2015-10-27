using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class PreviousCostPricingDetails
    {
        private int? ReceiptID;
        private int ItemID;
        private int ItemUnitID;
        private int ManufacturerID;
        private int AccountID;
        private double NewUnitCost;
        private double Margin;
        private double NewSellingPrice;
        public bool HasAverageCostChanged;
        public  DataTable ReceiveDocDetails;
        public DataTable PreviousStock;
        public DataTable Picklist;
        public DataTable DeliveryNote;
        public string StockCode,ItemName;
        public string ItemUnit, ManufacturerName, ActivityName;

        public PreviousCostPricingDetails(CostElement CostElement)
        {
           
            ReceiptID = CostElement.ReceiptID;
            ItemID = CostElement.ItemID;       
            ItemUnitID = CostElement.ItemUnitID;
            ManufacturerID = CostElement.ManufacturerID;
            AccountID = CostElement.MovingAverageID;
            LoadAndBind();
        }

      
        /// <summary>
        /// Load All Neccessary Data and Bind To DataSource
        /// </summary>
  
        void LoadAndBind()
        {
            //Bind
            if (ReceiptID == null)
                return;
            LoadNewSellingPriceAndAverageCost();
            //Load Detail Table To Grid
            PreviousStock = ReceiveDoc.GetRelatedPreviousStockForUnitCostAndSellingPrice((int)ReceiptID, ItemID, ManufacturerID, ItemUnitID, AccountID, NewUnitCost, NewSellingPrice);
            Picklist = ReceiveDoc.GetRelatedPicklistForChangingPrice(ItemID, ManufacturerID, ItemUnitID, AccountID, NewSellingPrice);
            DeliveryNote = ReceiveDoc.GetRelatedDeliveryNotesChangingPrice((int)ReceiptID,ItemID, ManufacturerID, ItemUnitID, AccountID, NewUnitCost, NewSellingPrice);
        }

        public void CompareNewAverageCostWithTheAvgCostToBeSet(double NewAverageCost)
        {
            if (NewUnitCost != NewAverageCost)
                HasAverageCostChanged = true;
            else
                HasAverageCostChanged = false;
            
        }
        private void LoadNewSellingPriceAndAverageCost()
        {
            ReceiveDocDetails = ReceiveDoc.GetRelatedReceiveForFinalPriceSetting(ReceiptID, ItemID, ManufacturerID, ItemUnitID, AccountID);
            //Load Header Information From first row to be displayed
            if (ReceiveDocDetails.Rows.Count > 0)
            {
                DataRow dr = ReceiveDocDetails.Rows[0];
                StockCode =
                ItemName = dr["FullItemName"].ToString();
                ItemUnit = dr["ItemUnitName"].ToString();
                ManufacturerName = dr["ManufacturerName"].ToString();
                ActivityName = dr["ActivityName"].ToString();
                if (dr["NewAverageCost"] != DBNull.Value)
                {
                    NewUnitCost = Math.Round(Convert.ToDouble(dr["NewAverageCost"]), BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
                }
                if (dr["NewSellingPrice"] != DBNull.Value)
                {
                    this.NewSellingPrice = Math.Round(Convert.ToDouble(dr["NewSellingPrice"]), BLL.Settings.NoOfDigitsAfterTheDecimalPoint);

                }
                if (dr["Margin"] != DBNull.Value)
                {
                    this.Margin = Math.Round(Convert.ToDouble(dr["Margin"]), BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
                }
            }
        }
        public void Confirm(int UserId)
        {
            foreach (DataRowView Cursor in PreviousStock.DefaultView)
            {
                int ID = Convert.ToInt32(Cursor["ID"]);
                ReceiveDoc.SetAverageCostByReceiveDoc(ID, NewUnitCost, UserId);
                ReceiveDoc.SetMarginByReceiveDoc(ID, Margin * 100, UserId);
                ReceiveDoc.SetSellingPriceByReceiveDoc(ID, NewSellingPrice, UserId);
            }

      
        }

    }
}
