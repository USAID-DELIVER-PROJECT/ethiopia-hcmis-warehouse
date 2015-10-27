


using System;
using System.Data;
using DAL;
using MyGeneration.dOOdads;
using System.Threading;
namespace BLL
{
    /// <summary>
    /// These are summary classes that are used as utilities elsewhere.
    /// </summary>
    public class ReceivedSummary
    {
        //Most Important once
        public int StoreID;
        public int ItemID;
        public int ManufacturerID;
        public int? UnitID;
        //Only For hubs I completly don't like.
        public int SupplierID;


        public double NewPricePerPack = 0;

        //New Receives
        public long UnpricedQuantity = 0;
        public double UnPricedTotalCost = 0;
        public Double UnpricedUnitCost;
        //Old Receive Stock
        public int OldQuantity = 0;
        public double OldUnitCost = 0;
        public double OldTotalCost = 0;
        //Old + NEW
        public long NewQuantity = 0;
        public double NewTotalCost = 0;

        //Final Result
        public double NewCost = 0;
        public double NewPrice = 0;
        public double Margin = 0;

        public double BeforeProrate = 0;
        //Hub Only
        public double NewSellingPrice = 0;
        public double TotalSellingPrice = 0;
        public double MarginETB = 0;
        public double NewUnitCost = 0;

        // Log and Reporting Purpose only
        public int? ReceiptID;
        public string RefNo = "";
        public string Remark;
        public double PriceDifference = 0;
        public double AdditionalCost =0;


        /// <summary>
        /// Movings the average table.
        /// </summary>
        /// <param name="itemID">The item ID.</param>
        /// <param name="storeId">The store id.</param>
        /// <param name="supplierID">The supplier ID.</param>
        /// <param name="manufacturerID">The manufacturer ID.</param>
        /// <param name="unitId">The unit id.</param>
        /// <returns></returns>
        
      
        public void Prorate(double AdditionalCost)
        {
            this.AdditionalCost = AdditionalCost;
            NewUnitCost = (AdditionalCost/NewQuantity) + BeforeProrate;


        }

        public DataView MovingAverageTable(int itemID, int storeId, int supplierID, int manufacturerID, int? unitId)
        {

            this.ItemID = itemID;
            this.StoreID = storeId;
            this.ManufacturerID = manufacturerID;
            this.UnitID = unitId;
            this.SupplierID = supplierID;

            DataView dv = ReceiveDoc.LoadForCostSheetDetail(ItemID, StoreID, SupplierID, ManufacturerID, (int)UnitID);

            dv.Table.Columns.Add("CUnitCost", System.Type.GetType("System.Double"));
            dv.Table.Columns.Add("CTotalCost", System.Type.GetType("System.Double"));
            dv.Table.Columns.Add("CQuantity", System.Type.GetType("System.Int32"));
            dv.Table.Columns.Add("NUnitCost", System.Type.GetType("System.Double"));
            dv.Table.Columns.Add("NQuantity", System.Type.GetType("System.Int32"));
            dv.Table.Columns.Add("NTotalCost", System.Type.GetType("System.Double"));
            dv.Table.Columns.Add("NDifference", System.Type.GetType("System.Double"));
            dv.Table.Columns.Add("MarginETB", System.Type.GetType("System.Double"));
            dv.Table.Columns.Add("NUnitPrice", System.Type.GetType("System.Double"));
            dv.Table.Columns.Add("NTotalPrice", System.Type.GetType("System.Double"));


            bool Pending = true;

            foreach (DataRowView drv in dv)
            {
                if (drv["Status"].ToString() == "Pending")
                {
                    Margin = Convert.ToDouble(drv["Margin"]);
                    if (drv["ReceiptID"] != DBNull.Value)
                        ReceiptID = Convert.ToInt32(drv["ReceiptID"]);
                    UnpricedQuantity += Convert.ToInt32(drv["RemainingQuantity"]);
                    UnPricedTotalCost += Convert.ToDouble(drv["TotalRemainingCost"]);
                    if(drv["Margin"] != DBNull.Value)
                        Pending = false;
                    UnpricedUnitCost = Convert.ToDouble(drv["ActualCost"]);
                }
                else
                {
                    if (Pending)
                        Margin = Convert.ToDouble(drv["Margin"]);
                    OldQuantity += Convert.ToInt32(drv["RemainingQuantity"]);
                    OldTotalCost += (Convert.ToDouble(drv["AverageCost"]) * Convert.ToInt32(drv["RemainingQuantity"]));
                    OldUnitCost = Convert.ToDouble(drv["AverageCost"]);

                }
            }

            NewQuantity = UnpricedQuantity + OldQuantity;

            NewTotalCost = Math.Round(OldTotalCost + UnPricedTotalCost, BLL.Settings.NoOfDigitsAfterTheDecimalPoint,MidpointRounding.AwayFromZero);

            BeforeProrate = NewUnitCost = Math.Round(NewTotalCost / NewQuantity, BLL.Settings.NoOfDigitsAfterTheDecimalPoint,MidpointRounding.AwayFromZero);

            PriceDifference = Math.Round(NewTotalCost - (NewUnitCost * NewQuantity), BLL.Settings.NoOfDigitsAfterTheDecimalPoint,MidpointRounding.AwayFromZero);

            //Hub only
            MarginETB = Margin * NewUnitCost;
            NewSellingPrice = Math.Round(MarginETB + NewUnitCost, BLL.Settings.NoOfDigitsAfterTheDecimalPoint, MidpointRounding.AwayFromZero);
            TotalSellingPrice = NewSellingPrice * NewQuantity;



            foreach (DataRowView drv in dv)
            {
                if (drv["Status"].ToString() == "Pending")
                {
                    drv["CQuantity"] = UnpricedQuantity;
                    drv["CUnitCost"] = Convert.ToDouble(drv["ActualCost"]);
                    drv["CTotalCost"] = UnPricedTotalCost;
                }
                else
                {

                    drv["CQuantity"] = Convert.ToInt32(drv["AveragedQty"]);
                    drv["CUnitCost"] = Convert.ToDouble(drv["AverageCost"]);
                    drv["CTotalCost"] = Convert.ToDouble(drv["AveragedTotalCost"]);
                }


                drv["NUnitCost"] = NewUnitCost;
                drv["NQuantity"] = NewQuantity;
                drv["NTotalCost"] = NewTotalCost;
                drv["NDifference"] = PriceDifference;
                drv["Margin"] = Margin;
                drv["MarginETB"] = MarginETB;
                drv["NUnitPrice"] = NewSellingPrice;
                drv["NTotalPrice"] = TotalSellingPrice;

            }
            return dv;
        }

        /// <summary>
        /// Saves the weighted average log.
        /// </summary>
        /// <param name="Userid">The userid.</param>
        public void SaveWeightedAverageLog(int Userid)
        {
            MovingAverageHistory wal = new MovingAverageHistory();
            wal.AddNew();
            if (ReceiptID != null)
                wal.ReceiptId = (int)ReceiptID;
            wal.ItemID = ItemID;
            if (UnitID != null)
                wal.UnitID = (int)UnitID;
            wal.SupplierID = SupplierID;
            wal.ManufacturerID = ManufacturerID;
            wal.UserID = Userid;
            wal.StoreID = StoreID;
            wal.UPQty = UnpricedQuantity;

            if (UnpricedQuantity != 0)
                wal.UPUnitCost = Math.Round(UnPricedTotalCost / UnpricedQuantity, BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
            else
                wal.UPUnitCost = 0;
            wal.UPTotalCost = UnPricedTotalCost;
            wal.PQty = OldQuantity;
            wal.PUnitCost = OldUnitCost;
            wal.PTotalCost = OldTotalCost;
            wal.NQty = NewQuantity;
            wal.NUnitCost = NewUnitCost;
            wal.NTotalCost = NewTotalCost;
            wal.Insurance = AdditionalCost;
            if (!Double.IsNaN(PriceDifference))
                wal.PriceDifference = PriceDifference;
            wal.Margin = Margin;
            wal.Price = NewSellingPrice;
            wal.Date = DateTimeHelper.ServerDateTime;
            //wal.Remark = Remark;
            wal.Save();
        }
    }
}
