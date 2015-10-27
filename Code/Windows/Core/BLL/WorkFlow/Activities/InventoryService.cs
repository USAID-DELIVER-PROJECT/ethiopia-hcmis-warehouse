using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class InventoryService
    {



        public static void CommitInventory(int periodId, int activityId, int physicalStoreId,DateTime ethiopianDate, int userId,BackgroundWorker backgroundWorker)
        {
            Inventory inventory = new Inventory();

            if (!InventoryPeriod.HasUnCommited(periodId, activityId))
            {
                throw new Exception("This inventory has been commited already,you are not allow to commit again.");
            }
            if(InventoryPeriod.HasInCompleteReceives(activityId,physicalStoreId))
            {
                throw new Exception("There are incompleted receives,you can only processed after canceling the receives.");
            }
            inventory.LoadByStoreAndActivity(activityId, physicalStoreId, periodId);

            try
            {
                var physicalStore = new PhysicalStore();
                physicalStore.LoadByPrimaryKey(physicalStoreId);
                inventory.InitializeCommit(userId, physicalStore.PhysicalStoreTypeID);

                inventory.Rewind();
                int count = 0;
                while (!inventory.EOF)
                {
                   
                    string itemDetail = inventory.GetColumn("FullItemName")+" - " +inventory.GetColumn("ManufacturerName")
                        + " - " + inventory.GetColumn("Unit") + " - " + inventory.GetColumn("ExpiryDate")
                        + " - " + inventory.GetColumn("BatchNo");
                   
                  
                    
                    if (inventory.IsColumnNull("IsDraft") || inventory.IsDraft)
                    {
                        inventory.Commit(ethiopianDate,backgroundWorker);
                    }

                    inventory.MoveNext();
                    count++;  
                    backgroundWorker.ReportProgress(count,itemDetail);
                }
                
                inventory.FinishCommit();
            }
            catch (Exception exception)
            {
                inventory.CancelCommit(exception);
            }
        }

        public static void CommitSingle(int inventoryId,DateTime ethiopianDate,int userId)
        {
            Inventory inventory = new Inventory();
            inventory.LoadByPrimaryKey(inventoryId);
            if(!inventory.IsColumnNull("isDraft") && !inventory.IsDraft)
            {
                  throw new Exception("This inventory has been commited already,you are not allow to commit again.");

            }

            try
            {
                var physicalStore = new PhysicalStore();
                physicalStore.LoadByPrimaryKey(inventory.PhysicalStoreID);
                inventory.InitializeCommit(userId,physicalStore.PhysicalStoreTypeID);
                inventory.Commit(ethiopianDate);
                inventory.FinishCommit();
            }
            catch (Exception exp)
            {
                inventory.CancelCommit(exp);
            }
       
          
    
        }

        public static void SaveInventoryRow(DataRow dataRow)
        {

            if (dataRow["ID"] != DBNull.Value)
            {
                Inventory inv = new Inventory();
                inv.LoadByPrimaryKey(Convert.ToInt32(dataRow["ID"]));

                inv.SetColumn("InventoryDamagedQuantity", dataRow["InventoryDamagedQuantity"]);
                inv.SetColumn("InventorySoundQuantity", dataRow["InventorySoundQuantity"]);
                inv.SetColumn("InventoryExpiredQuantity", dataRow["InventoryExpiredQuantity"]);
                inv.SetColumn("Remarks", dataRow["Remarks"]);
                if (dataRow["PalletLocationID"] != DBNull.Value)
                {
                    inv.PalletLocationID = Convert.ToInt32(dataRow["PalletLocationID"]);
                }
                if (dataRow["DamagedPalletLocationID"] != DBNull.Value)
                {
                    inv.DamagedPalletLocationID = Convert.ToInt32(dataRow["DamagedPalletLocationID"]);
                }
                inv.IsDraft = true;
                inv.Save();
            }
            else
            {
                Inventory inv = new Inventory();
                inv.AddNew();
                inv.InventoryPeriodID = Convert.ToInt32(dataRow["InventoryPeriodID"]);
                inv.PhysicalStoreID = Convert.ToInt32(dataRow["PhysicalStoreID"]);
                inv.ActivityID = Convert.ToInt32(dataRow["ActivityID"]);
                inv.ItemID = Convert.ToInt32(dataRow["ItemID"]);
                inv.UnitID = Convert.ToInt32(dataRow["UnitID"]);
                inv.ManufacturerID = Convert.ToInt32(dataRow["ManufacturerID"]);
                inv.SetColumn("BatchNo", dataRow["BatchNo"]);
                inv.SetColumn("ExpiryDate", dataRow["ExpiryDate"]);
                inv.SetColumn("InventoryDamagedQuantity", dataRow["InventoryDamagedQuantity"]);
                inv.SetColumn("InventorySoundQuantity", dataRow["InventorySoundQuantity"]);
                inv.SetColumn("InventoryExpiredQuantity", dataRow["InventoryExpiredQuantity"]);
                inv.RecordedDate = DateTimeHelper.ServerDateTime;
                inv.RecordedBy = CurrentContext.UserId;
                inv.IsDraft = true;
                inv.Remarks = "Stock out";
                inv.Save();
            }

        }
    }
}
