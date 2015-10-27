using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class InventoryPeriod
    {
        [SelectQuery]
        public static string SelectGetInvetoryPeriods()
        {
            string query = @"select ps.ID
		                        , w.Name as Warehouse
		                        , ps.Name as PhysicalStoreName
		                        , LInv.LastDate CurrentPeriodStartDate
		                        , ip.StartDate
		                        , ip.InventoryStatusID 
                        from PhysicalStore ps 
                          join Warehouse w on w.ID = ps.PhysicalStoreTypeID
                          left join ( select * from InventoryPeriod where InventoryStatusID <> 3) ip on ps.ID = ip.PhysicalStoreID 
										                        and Cast(ip.StartDate as Date) = Cast(ps.CurrentPeriodStartDate as Date)
                          Left join (select PhysicalStoreID,Max(StartDate) LastDate From InventoryPeriod where InventoryStatusID = 3 Group by PhysicalStoreID) LInv on LInv.PhysicalSToreID = ps.ID
                                            order by Warehouse, PhysicalStoreName";
            return query;
        }

        public static string GetInvetoryPeriods(int physicalStoreId)
        {
            return String.Format(@"select * from 
                                                    InventoryPeriod where PhysicalStoreID = {0}",
                physicalStoreId);
        }

        public static string SelectGetInvetoryPeriods(int physicalStoreId, int? Status)
        {
            return String.Format(@"select * from 
                                                    InventoryPeriod where PhysicalStoreID = {0} and InventoryStatusID < {1}",
                physicalStoreId, Status);
        }

        public static string SelectGetInvetoryPeriodByWarehouse(int warehouseId)
        {
            string query = String.Format(@"select StartDate, (select  STUFF ((Select ','+ Cast(xip.ID as VarChar) 
                                                    from InventoryPeriod xip join physicalStore xps on xip.PhysicalStoreID = xps.ID 
                                                        where xps.PhysicalStoreTypeID = {0} and
	                                                          Cast(xip.StartDate as Date) = Cast(ip.StartDate as Date)
                                                        FOR XML PATH('')),1,1,'') InventoryPeriods ) IDs
                                                        from InventoryPeriod ip
                                                        join physicalStore ps on ip.PhysicalStoreID = ps.ID 
                                                        where ps.PhysicalStoreTypeID = {0}
                                                        Group by StartDate", warehouseId);
            return query;
        }

        public static string SelectGetInventoryPeriodDatesByWareHouse(int WarehouseID)
        {
            string query = String.Format(@"select distinct Convert(VarChar(10),StartDate,101) + ' - ' + Convert(VarChar(10),EndDate,101) Name,StartDate,EndDate,Remark 
                                                from InventoryPeriod ip 
                                                        Join PhysicalStore ps on ps.ID=ip.PhysicalStoreID
                                                where PhysicalStoreTypeID = {0}", WarehouseID);
            return query;
        }

        public static string SelectHasUnCommited(int periodID, int activityID)
        {
            string query = String.Format("select count(*) as Count from Inventory where ((IsDraft = 1 or IsDraft is Null) and (InventorySoundQuantity >0 or inventoryDamagedQuantity >0 or InventoryExpiredQuantity >0)) and ActivityID = {0} and InventoryPeriodID = {1}", activityID, periodID);
            return query;  
        }

        public static string SelectHasCommited(int periodID)
        {
            string query = String.Format("select count(*) as Count from Inventory where IsDraft = 0 and InventoryPeriodID = {0}", periodID);
            return query;
        }

        public static string SelectHasInCompleteReceives(int activityID, int physicalStoreID, int grvPrinted)
        {
            return String.Format(@"select count(*) as Count from receivePallet rp 
					                                join receiveDoc rd on rp.ReceiveID = rd.ID
                                                    join vwPallet pl on pl.PalletID = rp.PalletID
					                                join receiveDocConfirmation rdc on rdc.ReceiveDocID = rd.ID
                                                    join ReceiptConfirmationStatus rcs on rcs.ID = rdc.ReceiptConfirmationStatusID
                                                where pl.PhyicalStoreID = {0}
                                                        and rd.StoreID = {1} 
                                                        and rcs.ReceiptConfirmationStatusCode in ('DRRC','REEN','RECC','GRNFP' ,'UCC','PRC','PRCO')  and rd.refno not like 'BeginningBalance'", physicalStoreID, activityID, grvPrinted);
        }
    }
}
