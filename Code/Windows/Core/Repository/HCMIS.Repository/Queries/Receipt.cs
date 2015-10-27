using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;
using Microsoft.SqlServer.Server;

namespace HCMIS.Repository.Queries
{
    public class Receipt
    {
        [SelectQuery]
        public static string SelectGetWarehouse(int id)
        {
            string query = String.Format(@"Select WarehouseName from ReceivePallet rp 
                                                join ReceiveDoc rd on rp.ReceiveID = rd.ID  
                                                join receipt r on r.ID = rd.ReceiptID 
                                                join vwReceiptPallet vw on vw.ReceivedocID = rd.ID
                                            where r.ID ={0}", id);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadSoundpGRV(int id)
        {
            string query =
                String.Format(
                    @"Select  rd.ItemID,rd.UnitID,rd.ManufacturerID,iu.text Unit,vw.Name CommodityType,vw.StockCode, vw.FullItemName ,sum(rd.InvoicedNoOfPack) InvoicedQuantity , sum(rd.NoOfPack) NoOfPack,Avg(rd.PricePerPack) PricePerPack, Avg(rd.Cost) as UnitCost, Sum(rd.InvoicedNoOfPack * rd.Cost) as TotalCost,Sum(rd.InvoicedNoOfPack * rd.PricePerPack)as TotalReceived, m.Name as Manufacturer,Max(rd.Margin) Margin 
                                                from ReceivePallet rp join ReceiveDoc rd on rp.ReceiveID = rd.ID  join receipt r on r.ID = rd.ReceiptID Join Stores s on s.ID = rd.StoreID join Manufacturers m on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join Pallet p on p.ID = rp.PalletID join PalletLocation pl on pl.PalletID = p.ID left join Supplier su on su.ID = rd.SupplierID join Receipt rt on rt.ID = rd.ReceiptID join itemUnit iu on rd.unitID = iu.ID 
                                               join StorageType st on st.ID = pl.StorageTypeID 
                                                where (st.StorageTypeCode <> 'SA' or pl.StorageTypeID is Null) and rt.ID = {0} 
                                           group by  rd.ItemID,rd.UnitID,rd.ManufacturerId, vw.FullItemName,vw.Name,m.Name,iu.Text,vw.StockCode",
                    id);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadByReceiptInvoiceId(int id)
        {
            string query = String.Format("select * from receipt where ReceiptInvoiceID = {0}", id);
            return query;
        }

        [SelectQuery]
        public static string SelectGetDataTable()
        {
            string query =
                String.Format(
                    @"select * from receipt rt  join ReceiptInvoice ri on rt.receiptInvoiceID = ri.ID join PO po on ri.POID = po.ID where po.PurchaseType is not null");
            return query;
        }

        [SelectQuery]
        public static string SelectGetReceiptInformationForGRN(int receiptID)
        {
            string query =
                String.Format(
                    @"select ROW_NUMBER() over (order by i.FullItemName) LineNumber,r.WayBillNo,r.InsurancePolicyNo,r.TransitTransferNo,r.STVOrInvoiceNo,ps.Name StoreName, psT.Name Warehouse,rd.ItemID, 
                                            i.FullItemName ItemName,rd.InvoicedNoOfPack InvoicedQty,rd.NoOfPack ReceivedQty,rd.ManufacturerId,m.Name Manufacturer,rd.BatchNo,cast(rd.ExpDate as date) ExpiryDate,
                                            cast(rd.[Date] as date) ReceivedDate,iu.[Text] Unit, i.StockCode, s.CompanyName SupplierName,cl.Name as ClusterName,PO.PONumber, sg.Name as Account,sdiv.Name SubAccount,sr.StoreName as Activity, tp.Name as CommodityType
                                            from Stores sr 
                                            join StoreGroupDivision sdiv on sr.StoreGroupDivisionID=sdiv.ID
                                            join StoreGroup sg on sdiv.StoreGroupID=sg.ID
                                            join ReceiveDoc rd on rd.StoreID = sr.ID                                            
                                            join Receipt r on rd.ReceiptID = r.ID
                                            join ReceivePallet rp on rd.ID=rp.ReceiveID 
                                            join PalletLocation pl on rp.PalletLocationID=pl.ID join Shelf sh on pl.ShelfID=sh.ID 
                                            join PhysicalStore ps on sh.StoreID=ps.ID 
                                            join PhysicalStoreType psT on ps.PhysicalStoreTypeID=psT.ID
                                            join Cluster cl on cl.ID = psT.ClusterID join vwGetAllItems i on rd.ItemID=i.ID 
                                            join Type tp on tp.ID = i.TypeID
                                            join Manufacturers m on rd.ManufacturerId=m.ID
                                            join ItemUnit iu on rd.UnitID=iu.ID 
                                            join Supplier s on rd.SupplierID=s.ID 
                                            join ReceiptInvoice ri on ri.ID = r.ReceiptInvoiceID 
                                            join PO on po.ID = ri.POID
                                             where r.ID = {0}",
                    receiptID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetInventoryListByAccountandWarehouse(int AccountID, int WarehouseID, int TypeID, int recieveQuantityConfirmed, int grnfPrinted, int priceCalculated)
        {
            string query = String.Format(@"Select rd.ItemID
                                                           , rd.UnitID
                                                           , rd.ManufacturerID
                                                           , rp.MovingAverageID
                                                           , rp.ItemUnitName Unit
                                                           , rp.FullItemName as FullItemName 
                                                           , sum(rd.NoOfPack) NoOfPack
                                                           , sum(rd.NoOfPack * rd.UnitCost)as TotalReceived
														   , (select UnitCost from ledgerlite where AccountID = rd.StoreID and itemID = rd.ItemID and UnitID = rd.UnitID and ManufacturerID = rd.ManufacturerID)as CurrentCost 
                                                           , rd.UnitCost PricePerPack
                                                           , rd.Margin  * 100 Margin
                                                           , rp.ManufacturerName as Manufacturer
                                                           , rp.WarehouseName Warehouse
                                                           , rp.ClusterName Cluster
                                                           , rp.AccountName  Account
                                                           , Case 
                                                                 When rp.AccountName=rp.SubAccountName 
                                                                        and rp.SubAccountName=rp.ActivityName 
                                                                    then 'N/A' 
                                                                    else rp.ActivityName 
                                                             end SubSubAccount
                                                           , Case When rp.AccountName=rp.SubAccountName 
                                                                        and rp.SubAccountName=rp.ActivityName 
                                                                    then 'N/A' 
                                                                    else rp.SubAccountName 
                                                             end SubAccount
                                                           , rp.CommodityTypeName commodityType
                                                           , rp.StockCode
                                                           , rp.Remark
                                                           , Case When rdc.ReceiptConfirmationStatusID={3} then Cast(0 as bit) else Cast(1 as bit) end IsConfirmed
                                                           , Case When rdc.ReceiptConfirmationStatusID={5} then Cast(1 as bit) else Cast(0 as bit) end pendingAverage
				                                           , STUFF ((Select ','+ Cast(xrd.ID as VarChar) 
				                                            from vwReceiptPallet xrp 
						                                            join ReceiveDoc xrd on xrp.ReceiveDocID = xrd.ID  
						                                            join receiveDocConfirmation xrdc on xrdc.ReceiveDocID = xrd.ID
				                                            Where  xrd.refNo like 'BeginningBalance' 
						                                            and xrd.StoreID ={0}
						                                            and xrp.WarehouseID = {1} 
						                                            and xrdc.ReceiptConfirmationStatusID = rdc.ReceiptConfirmationStatusID
						                                            and xrd.ItemID = rd.ItemID
						                                            and xrd.UnitID = rd.UnitID 
						                                            and xrd.ManufacturerId = rd.ManufacturerId
						                                            and (xrd.Margin = rd.Margin or (xrd.Margin is Null and rd.Margin is null))
						                                            and (xrd.UnitCost = rd.UnitCost or (xrd.UnitCost is Null and rd.UnitCost is null))
						                                            and xrp.Remark =rp.Remark
				                                            FOR XML PATH('')),1,1,'') ReceiveDocIDs
                                                 from vwReceiptPallet rp 
                                                      join ReceiveDoc rd on rp.ReceiveDocID = rd.ID  
                                                      join receiveDocConfirmation rdc on rdc.ReceiveDocID = rd.ID
                                                 Where  rd.refNo like 'BeginningBalance' 
                                                            and rp.ActivityID = {0} 
                                                            and rp.WarehouseID = {1} {2}
                                                            and rdc.ReceiptConfirmationStatusID in ({3},{4},{5})
                                                 Group by  rd.ItemID, rd.UnitID, rd.ManufacturerId, rp.SubAccountName, rp.AccountName
                                                            , rp.ActivityName, rp.FullItemName, rp.ManufacturerName, rp.ItemUnitName
                                                            , rp.WareHouseName, rp.ClusterName, rp.Stockcode, rp.CommodityTypeName
                                                            , rp.StorageTypeID, rd.Margin, rd.UnitCost
                                                            , rp.Remark,rdc.ReceiptConfirmationStatusID
                                                           , rp.MovingAverageID,rd.StoreID", AccountID, WarehouseID,
                TypeID == 0 ? " " : String.Format("and CommodityTypeID = {0}", TypeID)
                , recieveQuantityConfirmed,
                grnfPrinted, priceCalculated);
            return query;
        }

        [SelectQuery]
        public static string SelectGetMarginByAccount(int AccountID, int TypeID)
        {
            string query =
                String.Format(
                    @"Select  rd.ItemID,rd.UnitID,rd.ManufacturerID,iu.text Unit, vw.FullItemName , sum(rd.NoOfPack) NoOfPack,rd.PricePerPack PricePerPack,Sum(rd.NoOfPack * rd.Cost)as TotalReceived, m.Name as Manufacturer,pst.Name Warehouse,cl.Name Cluster,sg.Name Account,s.StoreName SubSubAccount,sgDiv.Name SubAccount,t.Name commodityType, vw.StockCode ,rd.Margin Margin from ReceivePallet rp join ReceiveDoc rd on rp.ReceiveID = rd.ID  join receipt r on r.ID = rd.ReceiptID Join Stores s on s.ID = rd.StoreID join Manufacturers m on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join PalletLocation pl on rp.PalletLocationID = pl.ID left join Supplier su on su.ID = rd.SupplierID join Receipt rt on rt.ID = rd.ReceiptID join itemUnit iu on rd.unitID = iu.ID Join Shelf sh on pl.ShelfID = sh.ID  join PhysicalStore ps on Ps.ID = sh.StoreID Join PhysicalStoreType pst on pst.ID = ps.PhysicalStoreTypeID join Cluster cl on cl.ID = pst.ClusterID join StoreGroupDivision sgDiv on sgDiv.ID=s.StoreGroupDivisionID join StoreGroup sg on sg.ID = sgDiv.StoreGroupID join [type] t on t.ID = vw.TypeId 
                                                where s.ID = {0} and vw.TypeId ={1} and rd.SellingPrice is not null
                                               group by  rd.ItemID,rd.UnitID,rd.ManufacturerId,sg.Name,sgDiv.Name, vw.FullItemName,m.Name,iu.Text,pst.Name,cl.Name,s.StoreName,t.Name, vw.StockCode,rd.PricePerPack,rd.Margin",
                    AccountID, TypeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetMarginByAccount(int AccountID)
        {
            string query =
                String.Format(
                    @"Select  rd.ItemID,rd.UnitID,rd.ManufacturerID,iu.text Unit, vw.FullItemName , sum(rd.NoOfPack) NoOfPack,rd.PricePerPack PricePerPack,Sum(rd.NoOfPack * rd.Cost)as TotalReceived, m.Name as Manufacturer,pst.Name Warehouse,cl.Name Cluster,sg.Name Account,s.StoreName SubSubAccount,sgDiv.Name SubAccount,t.Name commodityType, vw.StockCode ,rd.Margin Margin from ReceivePallet rp join ReceiveDoc rd on rp.ReceiveID = rd.ID  join receipt r on r.ID = rd.ReceiptID Join Stores s on s.ID = rd.StoreID join Manufacturers m on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join PalletLocation pl on rp.PalletLocationID = pl.ID left join Supplier su on su.ID = rd.SupplierID join Receipt rt on rt.ID = rd.ReceiptID join itemUnit iu on rd.unitID = iu.ID Join Shelf sh on pl.ShelfID = sh.ID  join PhysicalStore ps on Ps.ID = sh.StoreID Join PhysicalStoreType pst on pst.ID = ps.PhysicalStoreTypeID join Cluster cl on cl.ID = pst.ClusterID join StoreGroupDivision sgDiv on sgDiv.ID=s.StoreGroupDivisionID join StoreGroup sg on sg.ID = sgDiv.StoreGroupID join [type] t on t.ID = vw.TypeId 
                                                where s.ID = {0} and rd.SellingPrice is not null
                                               group by  rd.ItemID,rd.UnitID,rd.ManufacturerId,sg.Name,sgDiv.Name, vw.FullItemName,m.Name,iu.Text,pst.Name,cl.Name,s.StoreName,t.Name, vw.StockCode,rd.PricePerPack,rd.Margin",
                    AccountID);
            return query;
        }

        [SelectQuery]
        public static string SelectConfirm(int StoreID, int WarehouseID, int receiveEntered, bool handleGrv, int recieveQuantityConfirmed, int grvPrinted)
        {
            return String.Format(

                @"Begin Transaction
                        update ReceiveDoc set Confirmed = 1 where QuantityLeft > 0 
                                and ID in (select rp.ReceiveID 
                                            from ReceivePallet rp join PalletLocation pl on rp.PalletLocationID = pl.ID
                                                              Join Shelf sh on pl.ShelfID = sh.ID  
                                                                Join PhysicalStore ps on Ps.ID = sh.StoreID 
                                                                Join ReceiveDocConfirmation rdc on rdc.ReceiveDocID = rp.ReceiveID
                                                    where ps.PhysicalStoreTypeID = {1}  and ReceiveDoc.StoreID = {0} and rdc.ReceiptConfirmationStatusID= {2} and RefNo like 'BeginningBalance')
                        
                        Update ReceiveDocConfirmation 
                                set ReceiptConfirmationStatusID = {3}
                        where ReceiveDocID in (select rp.ReceiveID from ReceivePallet rp 
                                    join PalletLocation pl on rp.PalletLocationID = pl.ID
                                     join receiveDoc rd on rd.ID = rp.ReceiveID
                                    Join Shelf sh on pl.ShelfID = sh.ID  
                                    Join PhysicalStore ps on Ps.ID = sh.StoreID 
                           Join ReceiveDocConfirmation rdc on rdc.ReceiveDocID = rp.ReceiveID
                        where ps.PhysicalStoreTypeID = {1}  and rd.StoreID = {0} and rdc.ReceiptConfirmationStatusID= {2}  and rd.RefNo like 'BeginningBalance')
                        
                         Update PalletLocation
                                Set Confirmed = 1
                        Where ID in (Select pl.ID from ReceivePallet rp join PalletLocation pl on rp.PalletLocationID = pl.ID
                                     join receiveDoc rd on rd.ID = rp.ReceiveID
                                    Join Shelf sh on pl.ShelfID = sh.ID  
                                    Join PhysicalStore ps on Ps.ID = sh.StoreID  
                                    Join ReceiveDocConfirmation rdc on rdc.ReceiveDocID = rp.ReceiveID
                                   
                                where ps.PhysicalStoreTypeID = {1}  and rd.StoreID = {0} and rdc.ReceiptConfirmationStatusID= {2} and rd.RefNo like 'BeginningBalance')
                        COMMIT
                        ", StoreID, WarehouseID, receiveEntered, handleGrv ? recieveQuantityConfirmed : grvPrinted);
        }

        [SelectQuery]
        public static string SelectConfirmbyStore(int StoreID, int WarehouseID)
        {
            return String.Format(

                @"Begin Transaction
                        update ReceiveDoc set Confirmed = 1 where QuantityLeft > 0 
                                and ID in (select rp.ReceiveID from ReceivePallet rp join PalletLocation pl on rp.PalletLocationID = pl.ID
                                    Join Shelf sh on pl.ShelfID = sh.ID  
                                    Join PhysicalStore ps on Ps.ID = sh.StoreID where ps.ID = {1}  and ReceiveDoc.StoreID = {0} and RefNo like 'BeginningBalance')
                        
                        Update ReceiveDocConfirmation 
                                set ReceiptConfirmationStatusID = (select ID from ReceiptConfirmationStatus where ReceiptConfirmationStatusCode = 'RECC')
                        where ReceiveDocID in (select rp.ReceiveID from ReceivePallet rp join PalletLocation pl on rp.PalletLocationID = pl.ID
                                    Join Shelf sh on pl.ShelfID = sh.ID  
                                    Join PhysicalStore ps on Ps.ID = sh.StoreID Join Receivedoc rd on rd.ID = rp.ReceiveID  where ps.Id = {1}  and rd.StoreID = {0} and rd.RefNo like 'BeginningBalance')
                        
                         Update PalletLocation
                                Set Confirmed = 1
                        Where ID in (Select rp.ReceiveID from ReceivePallet rp join PalletLocation pl on rp.PalletLocationID = pl.ID
                                    Join Shelf sh on pl.ShelfID = sh.ID  
                                    Join PhysicalStore ps on Ps.ID = sh.StoreID Join Receivedoc rd on rd.ID = rp.ReceiveID  where ps.ID = {1}  and rd.StoreID = {0} and rd.RefNo like 'BeginningBalance')
                        COMMIT
                        ", StoreID, WarehouseID);
        }

        [SelectQuery]
        public static string SelectGetInventoryCountbyAccountandWarehouse(int AccountID, int WarehouseID, int TypeID, int ReceiptConfirmationStatusID)
        {
            string query =
                String.Format(@"Select  max(rd.Id) as Id,rd.ItemID, rd.UnitID,rd.ManufacturerID,iu.text Unit, vw.FullItemName + ' : ' + iu.text as FullItemName , sum(rd.NoOfPack) NoOfPack,rd.BatchNo Batch,rd.Expdate Expiredate, m.CountryOfOrigin Country,
                                                    m.Name as Manufacturer,pst.Name Warehouse,
                                                    cl.Name Cluster,sg.Name  Account ,
                                                    case When sg.Name=sgDiv.Name and sgDiv.Name=s.StoreName then 'N/A' else s.StoreName end SubSubAccount,
                                                    case When sg.Name=sgDiv.Name and sgDiv.Name=s.StoreName then 'N/A' else sgDiv.Name end SubAccount,
                                                    t.Name commodityType, vw.StockCode,'Sound' Remark

                                            from ReceivePallet rp join ReceiveDoc rd on 
                                            rp.ReceiveID = rd.ID  join receipt r on r.ID = rd.ReceiptID Join Stores s on s.ID = rd.StoreID join Manufacturers m 
                                            on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join PalletLocation pl on rp.PalletLocationID = pl.ID 
                                            join StorageType st on st.ID = pl.StorageTypeID
                                            left join Supplier su on su.ID = rd.SupplierID join Receipt rt on rt.ID = rd.ReceiptID join itemUnit iu on rd.unitID = iu.ID 
                                            Join Shelf sh on pl.ShelfID = sh.ID  join PhysicalStore ps on Ps.ID = sh.StoreID Join PhysicalStoreType pst on 
                                            pst.ID = ps.PhysicalStoreTypeID join Cluster cl on cl.ID = pst.ClusterID join StoreGroupDivision sgDiv on sgDiv.ID=s.StoreGroupDivisionID 
                                            join StoreGroup sg on sg.ID = sgDiv.StoreGroupID join [type] t on t.ID = vw.TypeId
                                            join ReceiveDocConfirmation rdc on rdc.ReceiveDocID = rd.ID
                                            where refNo like 'BeginningBalance' and s.ID = {0} and ps.PhysicalStoreTypeID = {1} and rdc.ReceiptConfirmationStatusID = {2} {3}
                                            and (rd.ExpDate > getdate() or rd.ExpDate is null) and st.StorageTypeCode<>'SA'                              
                                            group by  rd.ItemID,rd.UnitID,rd.ManufacturerId,sg.Name,sgDiv.Name, vw.FullItemName,m.Name,iu.Text,pst.Name,cl.Name,s.StoreName,t.Name, m.CountryOfOrigin,Cost,
                                                                                        vw.StockCode,rd.Expdate,rd.BatchNo
                    union
                    Select max(rd.Id) as Id,  rd.ItemID,rd.UnitID,rd.ManufacturerID,iu.text Unit, vw.FullItemName + ' : ' + iu.text as FullItemName , sum(rd.NoOfPack) NoOfPack,rd.BatchNo Batch,rd.Expdate Expiredate, m.CountryOfOrigin Country , 
                                            m.Name as Manufacturer,pst.Name Warehouse,cl.Name Cluster,sg.Name  Account ,
		                                    case When sg.Name=sgDiv.Name and sgDiv.Name=s.StoreName then 'N/A' else s.StoreName end SubSubAccount,
		                                    case When sg.Name=sgDiv.Name and sgDiv.Name=s.StoreName then 'N/A' else sgDiv.Name end SubAccount,t.Name commodityType, vw.StockCode,'Expired' Remark
		                                    from ReceivePallet rp join ReceiveDoc rd on 
		                                    rp.ReceiveID = rd.ID  join receipt r on r.ID = rd.ReceiptID Join Stores s on s.ID = rd.StoreID join Manufacturers m 
		                                    on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join PalletLocation pl on rp.PalletLocationID = pl.ID 
                                            join StorageType st on st.ID = pl.StorageTypeID
		                                    left join Supplier su on su.ID = rd.SupplierID join Receipt rt on rt.ID = rd.ReceiptID join itemUnit iu on rd.unitID = iu.ID 
		                                    Join Shelf sh on pl.ShelfID = sh.ID  join PhysicalStore ps on Ps.ID = sh.StoreID Join PhysicalStoreType pst on 
		                                    pst.ID = ps.PhysicalStoreTypeID join Cluster cl on cl.ID = pst.ClusterID join StoreGroupDivision sgDiv on sgDiv.ID=s.StoreGroupDivisionID 
		                                    join StoreGroup sg on sg.ID = sgDiv.StoreGroupID join [type] t on t.ID = vw.TypeId 
		                                    join ReceiveDocConfirmation rdc on rdc.ReceiveDocID = rd.ID
		                                    where refNo like 'BeginningBalance' and s.ID = {0} and ps.PhysicalStoreTypeID = {1} and rdc.ReceiptConfirmationStatusID = {2} {3}
		                                    and rd.ExpDate<=getdate() and st.StorageTypeCode<>'SA'
group by  rd.ItemID,rd.UnitID,rd.ManufacturerId,sg.Name,sgDiv.Name, vw.FullItemName,m.Name,iu.Text,pst.Name,cl.Name,s.StoreName,t.Name, m.CountryOfOrigin,Cost,
                                                                                        vw.StockCode,rd.Expdate,rd.BatchNo
                                 union

                                    Select max(rd.Id) as Id, rd.ItemID,rd.UnitID,rd.ManufacturerID,iu.text Unit, vw.FullItemName + ' : ' + iu.text as FullItemName , sum(rd.NoOfPack) NoOfPack,rd.BatchNo Batch,rd.Expdate Expiredate, m.CountryOfOrigin Country,
                                    m.Name as Manufacturer,pst.Name Warehouse,cl.Name Cluster,sg.Name  Account ,
                                    case When sg.Name=sgDiv.Name and sgDiv.Name=s.StoreName then 'N/A' else s.StoreName end SubSubAccount,
                                    case When sg.Name=sgDiv.Name and sgDiv.Name=s.StoreName then 'N/A' else sgDiv.Name end SubAccount,t.Name commodityType, vw.StockCode,'Damaged' Remark
                                          
                                    from ReceivePallet rp join ReceiveDoc rd on rp.ReceiveID = rd.ID  join receipt r on r.ID = rd.ReceiptID Join Stores s on s.ID = rd.StoreID join Manufacturers m 
                                    on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join PalletLocation pl on rp.PalletLocationID = pl.ID 
                                    join StorageType st on st.ID = pl.StorageTypeID
                                    left join Supplier su on su.ID = rd.SupplierID join Receipt rt on rt.ID = rd.ReceiptID join itemUnit iu on rd.unitID = iu.ID 
                                    Join Shelf sh on pl.ShelfID = sh.ID  join PhysicalStore ps on Ps.ID = sh.StoreID Join PhysicalStoreType pst on 
                                    pst.ID = ps.PhysicalStoreTypeID join Cluster cl on cl.ID = pst.ClusterID join StoreGroupDivision sgDiv on sgDiv.ID=s.StoreGroupDivisionID 
                                    join StoreGroup sg on sg.ID = sgDiv.StoreGroupID join [type] t on t.ID = vw.TypeId 
                                    join ReceiveDocConfirmation rdc on rdc.ReceiveDocID = rd.ID
                                    where refNo like 'BeginningBalance' and s.ID = {0} and ps.PhysicalStoreTypeID = {1} and rdc.ReceiptConfirmationStatusID = {2} {3}
                                    and st.StorageTypeCode = 'SA'
group by  rd.ItemID,rd.UnitID,rd.ManufacturerId,sg.Name,sgDiv.Name, vw.FullItemName,m.Name,iu.Text,pst.Name,cl.Name,s.StoreName,t.Name, m.CountryOfOrigin,Cost,
                                                                                        vw.StockCode,rd.Expdate,rd.BatchNo
Order by FullItemName", AccountID, WarehouseID, ReceiptConfirmationStatusID,
                    TypeID == 0 ? " " : String.Format("and TypeID = {0}", TypeID));
            return query;
        }

        [SelectQuery]
        public static string SelectGetInventoryCountbyInventoryPeriodID(int inventoryPeriodId, int physicalStoreId, int activityId)
        {
            string query = String.Format(@"select		iv.ID,iu.text Unit
			                                            ,vw.FullItemName  
			                                            ,iv.InventorySoundQuantity NoOfPack
			                                            ,iv.BatchNo Batch
			                                            ,iv.Expirydate Expiredate
			                                            ,m.CountryOfOrigin Country
			                                            ,m.Name as Manufacturer
			                                            ,pst.Name Warehouse
			                                            ,cl.Name Cluster
			                                            ,acc.AccountName  Account
			                                            ,case When acc.ActivityName = acc.SubAccountName then 'N/A' else acc.ActivityName end SubSubAccount
			                                            ,case When acc.AccountName = acc.SubAccountName then 'N/A' else acc.SubAccountName end SubAccount
			                                            ,t.Name commodityType
			                                            ,vw.StockCode
                                                        ,Case when m.CountryOfOrigin like 'Ethiopia' then 'Local' else 'Tender' end LocalvsTender
			                                            ,'Sound' Remark
                                            From Inventory iv join Manufacturers m on m.ID = iv.ManufacturerID 
	                                            join vwGetAllItems vw  on vw.ID = iv.ItemID 
	                                            join itemUnit iu on iv.unitID = iu.ID 
	                                            join PhysicalStore ps on Ps.ID = iv.PhysicalStoreID 
	                                            join PhysicalStoreType pst on  pst.ID = ps.PhysicalStoreTypeID 
	                                            join Cluster cl on cl.ID = pst.ClusterID 
	                                            join vwAccounts acc on acc.ActivityID = iv.ActivityID
	                                            join [type] t on t.ID = vw.TypeId
                                            Where iv.InventorySoundQuantity > 0 and InventoryPeriodID = {0} and iv.PhysicalStoreID = {1} and iv.ActivityID ={2}
                                            UNION
                                            select		iv.ID,iu.text Unit
			                                            ,vw.FullItemName
			                                            ,iv.InventoryDamagedQuantity NoOfPack
			                                            ,iv.BatchNo Batch
			                                            ,iv.Expirydate Expiredate
			                                            ,m.CountryOfOrigin Country
			                                            ,m.Name as Manufacturer
			                                            ,pst.Name Warehouse
			                                            ,cl.Name Cluster
			                                            ,acc.AccountName  Account
			                                            ,case When acc.ActivityName = acc.SubAccountName then 'N/A' else acc.ActivityName end SubSubAccount
			                                            ,case When acc.AccountName = acc.SubAccountName then 'N/A' else acc.SubAccountName end SubAccount
			                                            ,t.Name commodityType
			                                            ,vw.StockCode
                                                        ,Case when m.CountryOfOrigin like 'Ethiopia' then 'Local' else 'Tender' end LocalvsTender
			                                            ,'Damaged' Remark
                                            From Inventory iv join Manufacturers m on m.ID = iv.ManufacturerID 
	                                            join vwGetAllItems vw  on vw.ID = iv.ItemID 
	                                            join itemUnit iu on iv.unitID = iu.ID 
	                                            join PhysicalStore ps on Ps.ID = iv.PhysicalStoreID 
	                                            join PhysicalStoreType pst on  pst.ID = ps.PhysicalStoreTypeID 
	                                            join Cluster cl on cl.ID = pst.ClusterID 
	                                            join vwAccounts acc on acc.ActivityID = iv.ActivityID
	                                            join [type] t on t.ID = vw.TypeId
                                            Where iv.InventoryDamagedQuantity > 0 and InventoryPeriodID = {0} and iv.PhysicalStoreID = {1} and iv.ActivityID ={2}
                                            UNION
                                            select		iv.ID,iu.text Unit
			                                            ,vw.FullItemName 
			                                            ,iv.InventoryExpiredQuantity NoOfPack
			                                            ,iv.BatchNo Batch
			                                            ,iv.Expirydate Expiredate
			                                            ,m.CountryOfOrigin Country
			                                            ,m.Name as Manufacturer
			                                            ,pst.Name Warehouse
			                                            ,cl.Name Cluster
			                                            ,acc.AccountName  Account
			                                            ,case When acc.ActivityName = acc.SubAccountName then 'N/A' else acc.ActivityName end SubSubAccount
			                                            ,case When acc.AccountName = acc.SubAccountName then 'N/A' else acc.SubAccountName end SubAccount
			                                            ,t.Name commodityType
			                                            ,vw.StockCode
                                                        ,Case when m.CountryOfOrigin like 'Ethiopia' then 'Local' else 'Tender' end LocalvsTender
			                                            ,'Expired' Remark
                                            From Inventory iv join Manufacturers m on m.ID = iv.ManufacturerID 
	                                            join vwGetAllItems vw  on vw.ID = iv.ItemID 
	                                            join itemUnit iu on iv.unitID = iu.ID 
	                                            join PhysicalStore ps on Ps.ID = iv.PhysicalStoreID 
	                                            join PhysicalStoreType pst on  pst.ID = ps.PhysicalStoreTypeID 
	                                            join Cluster cl on cl.ID = pst.ClusterID 
	                                            join vwAccounts acc on acc.ActivityID = iv.ActivityID
	                                            join [type] t on t.ID = vw.TypeId
                                            Where iv.InventoryExpiredQuantity > 0 and InventoryPeriodID = {0} and iv.PhysicalStoreID = {1} and iv.ActivityID ={2}",
                inventoryPeriodId, physicalStoreId, activityId);
            return query;
        }

        [SelectQuery]
        public static string SelectGetInventoryCountbyAccountandPhysicalStore(int AccountID, int PhysicalStoreID, int TypeID)
        {
            string query =
                String.Format(@"Select  max(rd.Id) as Id,rd.ItemID, rd.UnitID,rd.ManufacturerID,iu.text Unit, vw.FullItemName + ' : ' + iu.text as FullItemName , sum(rd.NoOfPack) NoOfPack,rd.BatchNo Batch,rd.Expdate Expiredate, m.CountryOfOrigin Country,
                                            m.Name as Manufacturer,pst.Name Warehouse,
                                            cl.Name Cluster,sg.Name  Account,
                                            case When sg.Name=sgDiv.Name and sgDiv.Name=s.StoreName then 'N/A' else s.StoreName end SubSubAccount,
                                            case When sg.Name=sgDiv.Name and sgDiv.Name=s.StoreName then 'N/A' else sgDiv.Name end SubAccount,
                                            t.Name commodityType, vw.StockCode,'Sound' Remark  ,   
                                            case When Cost is not Null then Cast(1 as bit) else Cast(0 as bit) end IsPriceConfirmed
                                            from ReceivePallet rp join ReceiveDoc rd on 
                                            rp.ReceiveID = rd.ID  join receipt r on r.ID = rd.ReceiptID Join Stores s on s.ID = rd.StoreID join Manufacturers m 
                                            on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join PalletLocation pl on rp.PalletLocationID = pl.ID 
                                            join StorageType st on st.ID = pl.StorageTypeID
                                            left join Supplier su on su.ID = rd.SupplierID join Receipt rt on rt.ID = rd.ReceiptID join itemUnit iu on rd.unitID = iu.ID 
                                            Join Shelf sh on pl.ShelfID = sh.ID  join PhysicalStore ps on Ps.ID = sh.StoreID Join PhysicalStoreType pst on 
                                            pst.ID = ps.PhysicalStoreTypeID join Cluster cl on cl.ID = pst.ClusterID join StoreGroupDivision sgDiv on sgDiv.ID=s.StoreGroupDivisionID 
                                            join StoreGroup sg on sg.ID = sgDiv.StoreGroupID join [type] t on t.ID = vw.TypeId 
                                            where refNo like 'BeginningBalance' and s.ID = {0} and ps.ID = {1} and (rd.ExpDate > getdate() or rd.ExpDate is null) and st.StorageTypeCode<>'SA' {2} 
                                            group by  rd.ItemID,rd.UnitID,rd.ManufacturerId,sg.Name,sgDiv.Name, vw.FullItemName,m.Name,iu.Text,pst.Name,cl.Name,s.StoreName,t.Name, m.CountryOfOrigin, 
                                            vw.StockCode,rd.Expdate,rd.BatchNo,cost

                                            union

                                            Select max(rd.Id) as Id,  rd.ItemID,rd.UnitID,rd.ManufacturerID,iu.text Unit, vw.FullItemName + ' : ' + iu.text as FullItemName , sum(rd.NoOfPack) NoOfPack,rd.BatchNo Batch,rd.Expdate Expiredate, m.CountryOfOrigin Country , 
                                             m.Name as Manufacturer,pst.Name Warehouse,cl.Name Cluster,sg.Name  Account ,
                                             case When sg.Name=sgDiv.Name and sgDiv.Name=s.StoreName then 'N/A' else s.StoreName end SubSubAccount,
                                            case When sg.Name=sgDiv.Name and sgDiv.Name=s.StoreName then 'N/A' else sgDiv.Name end SubAccount,t.Name commodityType, vw.StockCode,'Expired' Remark,   
                                            case When Cost is not Null then Cast(1 as bit) else Cast(0 as bit) end IsPriceConfirmed  from ReceivePallet rp join ReceiveDoc rd on 
                                            rp.ReceiveID = rd.ID  join receipt r on r.ID = rd.ReceiptID Join Stores s on s.ID = rd.StoreID join Manufacturers m 
                                            on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join PalletLocation pl on rp.PalletLocationID = pl.ID 
                                            join StorageType st on st.ID = pl.StorageTypeID
                                            left join Supplier su on su.ID = rd.SupplierID join Receipt rt on rt.ID = rd.ReceiptID join itemUnit iu on rd.unitID = iu.ID 
                                            Join Shelf sh on pl.ShelfID = sh.ID  join PhysicalStore ps on Ps.ID = sh.StoreID Join PhysicalStoreType pst on 
                                            pst.ID = ps.PhysicalStoreTypeID join Cluster cl on cl.ID = pst.ClusterID join StoreGroupDivision sgDiv on sgDiv.ID=s.StoreGroupDivisionID 
                                            join StoreGroup sg on sg.ID = sgDiv.StoreGroupID join [type] t on t.ID = vw.TypeId 
                                            where refNo like 'BeginningBalance' and s.ID = {0} and ps.ID = {1}  and rd.ExpDate<=getdate() and st.StorageTypeCode<>'SA' {2} 
                                            group by  rd.ItemID,rd.UnitID,rd.ManufacturerId,sg.Name,sgDiv.Name, vw.FullItemName,m.Name,iu.Text,pst.Name,cl.Name,s.StoreName,t.Name, m.CountryOfOrigin,
                                            vw.StockCode,rd.Expdate,rd.BatchNo,cost
                                            union

                                            Select max(rd.Id) as Id, rd.ItemID,rd.UnitID,rd.ManufacturerID,iu.text Unit, vw.FullItemName + ' : ' + iu.text as FullItemName , sum(rd.NoOfPack) NoOfPack,rd.BatchNo Batch,rd.Expdate Expiredate, m.CountryOfOrigin Country,
                                             m.Name as Manufacturer,pst.Name Warehouse,cl.Name Cluster,sg.Name  Account ,
                                             case When sg.Name=sgDiv.Name and sgDiv.Name=s.StoreName then 'N/A' else s.StoreName end SubSubAccount,
                                            case When sg.Name=sgDiv.Name and sgDiv.Name=s.StoreName then 'N/A' else sgDiv.Name end SubAccount,t.Name commodityType, vw.StockCode,'Damaged' Remark,   
                                            case When Cost is not Null then Cast(1 as bit) else Cast(0 as bit) end IsPriceConfirmed  from ReceivePallet rp join ReceiveDoc rd on 
                                            rp.ReceiveID = rd.ID  join receipt r on r.ID = rd.ReceiptID Join Stores s on s.ID = rd.StoreID join Manufacturers m 
                                            on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join PalletLocation pl on rp.PalletLocationID = pl.ID 
                                            join StorageType st on st.ID = pl.StorageTypeID
                                            left join Supplier su on su.ID = rd.SupplierID join Receipt rt on rt.ID = rd.ReceiptID join itemUnit iu on rd.unitID = iu.ID 
                                            Join Shelf sh on pl.ShelfID = sh.ID  join PhysicalStore ps on Ps.ID = sh.StoreID Join PhysicalStoreType pst on 
                                            pst.ID = ps.PhysicalStoreTypeID join Cluster cl on cl.ID = pst.ClusterID join StoreGroupDivision sgDiv on sgDiv.ID=s.StoreGroupDivisionID 
                                            join StoreGroup sg on sg.ID = sgDiv.StoreGroupID join [type] t on t.ID = vw.TypeId 
                                            where refNo like 'BeginningBalance' and s.ID = {0} and ps.ID = {1}  and st.StorageTypeCode = 'SA' {2}
                                            group by  rd.ItemID,rd.UnitID,rd.ManufacturerId,sg.Name,sgDiv.Name, vw.FullItemName,m.Name,iu.Text,pst.Name,cl.Name,s.StoreName,t.Name, m.CountryOfOrigin,
                                            vw.StockCode,rd.Expdate,rd.BatchNo,Cost
                                             Order by FullItemName,Manufacturer", AccountID, PhysicalStoreID,
                    TypeID == 0 ? " " : String.Format("and TypeID = {0}", TypeID));
            return query;
        }

        [SelectQuery]
        public static string SelectGetRawInventoryCountbyAccountandPhysicalStoreItem(int AccountID, int PhysicalStoreID, int ItemID, int UnitID)
        {
            string query =
                String.Format(@"Select  rd.Id as Id,rd.ItemID,rd.UnitID,rd.ManufacturerID,iu.text Unit, vw.FullItemName + ' : ' + iu.text as FullItemName , sum(rd.NoOfPack) NoOfPack,rd.BatchNo Batch,rd.Expdate Expiredate, m.CountryOfOrigin Country,
                                            m.Name as Manufacturer,pst.Name Warehouse,cl.Name Cluster,sg.Name Account,
                                            s.StoreName SubSubAccount,sgDiv.Name SubAccount,t.Name commodityType, vw.StockCode,'Sound' Remark  from ReceivePallet rp join ReceiveDoc rd on 
                                            rp.ReceiveID = rd.ID  join receipt r on r.ID = rd.ReceiptID Join Stores s on s.ID = rd.StoreID join Manufacturers m 
                                            on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join PalletLocation pl on rp.PalletLocationID = pl.ID 
                                            join StorageType st on st.ID = pl.StorageTypeID
                                            left join Supplier su on su.ID = rd.SupplierID join Receipt rt on rt.ID = rd.ReceiptID join itemUnit iu on rd.unitID = iu.ID 
                                            Join Shelf sh on pl.ShelfID = sh.ID  join PhysicalStore ps on Ps.ID = sh.StoreID Join PhysicalStoreType pst on 
                                            pst.ID = ps.PhysicalStoreTypeID join Cluster cl on cl.ID = pst.ClusterID join StoreGroupDivision sgDiv on sgDiv.ID=s.StoreGroupDivisionID 
                                            join StoreGroup sg on sg.ID = sgDiv.StoreGroupID join [type] t on t.ID = vw.TypeId 
                                            where s.ID = {0} and ps.ID = {1} and (rd.ExpDate>getdate() or rd.ExpDate is null) and st.StorageTypeCode<>'SA' and rd.ItemID = {2} and rd.UnitID = {3}
                                            group by  rd.ItemID,rd.UnitID,rd.ManufacturerId,sg.Name,sgDiv.Name, vw.FullItemName,m.Name,iu.Text,pst.Name,cl.Name,s.StoreName,t.Name, m.CountryOfOrigin, 
                                            vw.StockCode, rd.Expdate, rd.BatchNo, rd.Id

                                            union

                                            Select rd.Id as Id,  rd.ItemID,rd.UnitID,rd.ManufacturerID,iu.text Unit, vw.FullItemName + ' : ' + iu.text as FullItemName , sum(rd.NoOfPack) NoOfPack,rd.BatchNo Batch,rd.Expdate Expiredate, m.CountryOfOrigin Country , 
                                             m.Name as Manufacturer,pst.Name Warehouse,cl.Name Cluster,sg.Name Account,
                                            s.StoreName SubSubAccount,sgDiv.Name SubAccount,t.Name commodityType, vw.StockCode,'Expired' Remark  from ReceivePallet rp join ReceiveDoc rd on 
                                            rp.ReceiveID = rd.ID  join receipt r on r.ID = rd.ReceiptID Join Stores s on s.ID = rd.StoreID join Manufacturers m 
                                            on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join PalletLocation pl on rp.PalletLocationID = pl.ID 
                                            join StorageType st on st.ID = pl.StorageTypeID
                                            left join Supplier su on su.ID = rd.SupplierID join Receipt rt on rt.ID = rd.ReceiptID join itemUnit iu on rd.unitID = iu.ID 
                                            Join Shelf sh on pl.ShelfID = sh.ID  join PhysicalStore ps on Ps.ID = sh.StoreID Join PhysicalStoreType pst on 
                                            pst.ID = ps.PhysicalStoreTypeID join Cluster cl on cl.ID = pst.ClusterID join StoreGroupDivision sgDiv on sgDiv.ID=s.StoreGroupDivisionID 
                                            join StoreGroup sg on sg.ID = sgDiv.StoreGroupID join [type] t on t.ID = vw.TypeId 
                                            where s.ID = {0} and ps.ID = {1}  and rd.ExpDate<=getdate() and st.StorageTypeCode<>'SA' and rd.ItemID = {2} and rd.UnitID = {3}
                                            group by  rd.ItemID,rd.UnitID,rd.ManufacturerId,sg.Name,sgDiv.Name, vw.FullItemName,m.Name,iu.Text,pst.Name,cl.Name,s.StoreName,t.Name, m.CountryOfOrigin,
                                            vw.StockCode, rd.Expdate, rd.BatchNo, rd.Id
                                            union

                                            Select rd.Id as Id, rd.ItemID,rd.UnitID,rd.ManufacturerID,iu.text Unit, vw.FullItemName + ' : ' + iu.text as FullItemName , sum(rd.NoOfPack) NoOfPack,rd.BatchNo Batch,rd.Expdate Expiredate, m.CountryOfOrigin Country,
                                             m.Name as Manufacturer,pst.Name Warehouse,cl.Name Cluster,sg.Name Account,
                                            s.StoreName SubSubAccount,sgDiv.Name SubAccount,t.Name commodityType, vw.StockCode,'Damaged' Remark  from ReceivePallet rp join ReceiveDoc rd on 
                                            rp.ReceiveID = rd.ID  join receipt r on r.ID = rd.ReceiptID Join Stores s on s.ID = rd.StoreID join Manufacturers m 
                                            on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join PalletLocation pl on rp.PalletLocationID = pl.ID 
                                            join StorageType st on st.ID = pl.StorageTypeID
                                            left join Supplier su on su.ID = rd.SupplierID join Receipt rt on rt.ID = rd.ReceiptID join itemUnit iu on rd.unitID = iu.ID 
                                            Join Shelf sh on pl.ShelfID = sh.ID  join PhysicalStore ps on Ps.ID = sh.StoreID Join PhysicalStoreType pst on 
                                            pst.ID = ps.PhysicalStoreTypeID join Cluster cl on cl.ID = pst.ClusterID join StoreGroupDivision sgDiv on sgDiv.ID=s.StoreGroupDivisionID 
                                            join StoreGroup sg on sg.ID = sgDiv.StoreGroupID join [type] t on t.ID = vw.TypeId 
                                            where s.ID = {0} and ps.ID = {1}  and st.StorageTypeCode='SA' and rd.ItemID = {2} and rd.UnitID = {3}
                                            group by  rd.ItemID,rd.UnitID,rd.ManufacturerId,sg.Name,sgDiv.Name, vw.FullItemName,m.Name,iu.Text,pst.Name,cl.Name,s.StoreName,t.Name, m.CountryOfOrigin,
                                            vw.StockCode,rd.Expdate,rd.BatchNo,rd.Id", AccountID, PhysicalStoreID,
                    ItemID, UnitID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetRawInventoryCountbyAccountandWarehouseItem(int AccountID, int WarehouseID, int ItemID, int UnitID)
        {
            string query =
                String.Format(@"Select  rd.Id as Id,rd.ItemID,rd.UnitID,rd.ManufacturerID,iu.text Unit, vw.FullItemName + ' : ' + iu.text as FullItemName , sum(rd.NoOfPack) NoOfPack,rd.BatchNo Batch,rd.Expdate Expiredate, m.CountryOfOrigin Country,
                                            m.Name as Manufacturer,pst.Name Warehouse,cl.Name Cluster,sg.Name Account,
                                            s.StoreName SubSubAccount,sgDiv.Name SubAccount,t.Name commodityType, vw.StockCode,'Sound' Remark  from ReceivePallet rp join ReceiveDoc rd on 
                                            rp.ReceiveID = rd.ID  join receipt r on r.ID = rd.ReceiptID Join Stores s on s.ID = rd.StoreID join Manufacturers m 
                                            on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join PalletLocation pl on rp.PalletLocationID = pl.ID 
                                            join StorageType st on st.ID = pl.StorageTypeID
                                            left join Supplier su on su.ID = rd.SupplierID join Receipt rt on rt.ID = rd.ReceiptID join itemUnit iu on rd.unitID = iu.ID 
                                            Join Shelf sh on pl.ShelfID = sh.ID  join PhysicalStore ps on Ps.ID = sh.StoreID Join PhysicalStoreType pst on 
                                            pst.ID = ps.PhysicalStoreTypeID join Cluster cl on cl.ID = pst.ClusterID join StoreGroupDivision sgDiv on sgDiv.ID=s.StoreGroupDivisionID 
                                            join StoreGroup sg on sg.ID = sgDiv.StoreGroupID join [type] t on t.ID = vw.TypeId 
                                            where s.ID = {0} and ps.PhysicalStoreTypeID = {1} and (rd.ExpDate>getdate() or rd.ExpDate is null) and st.StorageTypeCode<>'SA' and rd.ItemID = {2} and rd.UnitID = {3}
                                            group by  rd.ItemID,rd.UnitID,rd.ManufacturerId,sg.Name,sgDiv.Name, vw.FullItemName,m.Name,iu.Text,pst.Name,cl.Name,s.StoreName,t.Name, m.CountryOfOrigin, 
                                            vw.StockCode, rd.Expdate, rd.BatchNo, rd.Id

                                            union

                                            Select rd.Id as Id,  rd.ItemID,rd.UnitID,rd.ManufacturerID,iu.text Unit, vw.FullItemName + ' : ' + iu.text as FullItemName , sum(rd.NoOfPack) NoOfPack,rd.BatchNo Batch,rd.Expdate Expiredate, m.CountryOfOrigin Country , 
                                             m.Name as Manufacturer,pst.Name Warehouse,cl.Name Cluster,sg.Name Account,
                                            s.StoreName SubSubAccount,sgDiv.Name SubAccount,t.Name commodityType, vw.StockCode,'Expired' Remark  from ReceivePallet rp join ReceiveDoc rd on 
                                            rp.ReceiveID = rd.ID  join receipt r on r.ID = rd.ReceiptID Join Stores s on s.ID = rd.StoreID join Manufacturers m 
                                            on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join PalletLocation pl on rp.PalletLocationID = pl.ID 
                                            left join Supplier su on su.ID = rd.SupplierID join Receipt rt on rt.ID = rd.ReceiptID join itemUnit iu on rd.unitID = iu.ID 
                                            Join Shelf sh on pl.ShelfID = sh.ID  join PhysicalStore ps on Ps.ID = sh.StoreID Join PhysicalStoreType pst on 
                                            pst.ID = ps.PhysicalStoreTypeID join Cluster cl on cl.ID = pst.ClusterID join StoreGroupDivision sgDiv on sgDiv.ID=s.StoreGroupDivisionID 
                                            join StoreGroup sg on sg.ID = sgDiv.StoreGroupID join [type] t on t.ID = vw.TypeId 
                                            join StorageType st on st.ID = pl.StorageTypeID
                                            where s.ID = {0} and ps.PhysicalStoreTypeID = {1}  and rd.ExpDate<=getdate() and st.StorageTypeCode<>'SA' and rd.ItemID = {2} and rd.UnitID = {3}
                                            group by  rd.ItemID,rd.UnitID,rd.ManufacturerId,sg.Name,sgDiv.Name, vw.FullItemName,m.Name,iu.Text,pst.Name,cl.Name,s.StoreName,t.Name, m.CountryOfOrigin,
                                            vw.StockCode, rd.Expdate, rd.BatchNo, rd.Id
                                            union

                                            Select rd.Id as Id, rd.ItemID,rd.UnitID,rd.ManufacturerID,iu.text Unit, vw.FullItemName + ' : ' + iu.text as FullItemName , sum(rd.NoOfPack) NoOfPack,rd.BatchNo Batch,rd.Expdate Expiredate, m.CountryOfOrigin Country,
                                             m.Name as Manufacturer,pst.Name Warehouse,cl.Name Cluster,sg.Name Account,
                                            s.StoreName SubSubAccount,sgDiv.Name SubAccount,t.Name commodityType, vw.StockCode,'Damaged' Remark  from ReceivePallet rp join ReceiveDoc rd on 
                                            rp.ReceiveID = rd.ID  join receipt r on r.ID = rd.ReceiptID Join Stores s on s.ID = rd.StoreID join Manufacturers m 
                                            on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join PalletLocation pl on rp.PalletLocationID = pl.ID 
                                            left join Supplier su on su.ID = rd.SupplierID join Receipt rt on rt.ID = rd.ReceiptID join itemUnit iu on rd.unitID = iu.ID 
                                            Join Shelf sh on pl.ShelfID = sh.ID  join PhysicalStore ps on Ps.ID = sh.StoreID Join PhysicalStoreType pst on 
                                            pst.ID = ps.PhysicalStoreTypeID join Cluster cl on cl.ID = pst.ClusterID join StoreGroupDivision sgDiv on sgDiv.ID=s.StoreGroupDivisionID 
                                            join StoreGroup sg on sg.ID = sgDiv.StoreGroupID join [type] t on t.ID = vw.TypeId 
                                            join StorageType st on st.ID = pl.StorageTypeID
                                            where s.ID = {0} and ps.PhysicalStoreTypeID = {1}  and st.StorageTypeCode = 'SA' and rd.ItemID = {2} and rd.UnitID = {3}
                                            group by  rd.ItemID,rd.UnitID,rd.ManufacturerId,sg.Name,sgDiv.Name, vw.FullItemName,m.Name,iu.Text,pst.Name,cl.Name,s.StoreName,t.Name, m.CountryOfOrigin,
                                            vw.StockCode,rd.Expdate,rd.BatchNo,rd.Id", AccountID, WarehouseID, ItemID,
                    UnitID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetReceiptStatusList()
        {
            return String.Format(@"select rt.ID
		                                , vw.ActivityID
		                                , rcs.ID StatusID
		                                , IsDeleted=0
		                                , PO.PONumber OrderNo
		                                , ri.ID InvoiceID
		                                , ri.STVOrInvoiceNo InvoiceNo
		                                , vw.WarehouseName
		                                , rcs.Name Status
		                                , isNull(Cast(rcpGRNF.IDPrinted as varchar),'Not Printed') GRNF
		                                , isNull(Cast(rcpGRV.IDPrinted as varchar),'Not Printed') GRV
		                                , isNull(Cast((Select Max(IDPrinted) from ReceiptConfirmationPrintout where reason = 'PGRV' and ReceiptID = rt.ID)as varchar),'Not Printed') ActiveGRNF
		                                , isNull(Cast((Select Max(IDPrinted) from ReceiptConfirmationPrintout where reason in ('GRV','IGRV','SRM') and ReceiptID = rt.ID)as varchar),'Not Printed')  ActiveGRV
	                                from Receipt rt 
		                                join ReceiveDoc rd on rd.ReceiptID = rt.ID 
                                        Join vwReceiptPallet vw on vw.ReceiveDocID = rd.ID
                                        join ReceiptInvoice ri on ri.ID = rt.ReceiptInvoiceID
                                        join PO on po.ID = ri.POID
                                        left join ReceiveDocConfirmation rdc on rdc.ReceiveDocID  = rd.ID
                                        left join ReceiptConfirmationStatus rcs on rcs.ID = rdc.ReceiptConfirmationStatusID
                                        left Join(Select * from ReceiptConfirmationPrintout where reason = 'PGRV') rcpGRNF on rcpGRNF.ReceiptID = rt.ID
                                        left Join(Select * from ReceiptConfirmationPrintout where reason = 'GRV' or reason = 'IGRV' or reason = 'SRM') rcpGRV on rcpGRV.ReceiptID = rt.ID
                                where rd.refno not in('BeginningBalance','AccountToAccountTransfer')
                                Group by rt.ID, PO.PONumber,rcpGRNF.IDPrinted,rcpGRV.IDPrinted,ri.ID,ri.STVOrInvoiceNo,vw.WarehouseName,rcs.Name,rcs.ID,vw.ActivityID");
        }

        [SelectQuery]
        public static string SelectGetReceiptStatusList2()
        {
            return String.Format(@"select rt.ID,vw.ActivityID, IsDeleted=1, StatusID=-1 ,PO.PONumber OrderNo,ri.ID InvoiceID,ri.STVOrInvoiceNo InvoiceNo,isNull(Cast(Max(rcpGRNF.IDPrinted) as varchar),'Not Printed') GRNF,isNull(Cast(Max(rcpGRV.IDPrinted) as varchar),'Not Printed') GRV,isNull(Cast(Max(rcpGRNF.IDPrinted) as varchar),'Not Printed') ActiveGRNF,isNull(Cast(Max(rcpGRV.IDPrinted) as varchar),'Not Printed') ActiveGRV  from Receipt rt 
                                        join ReceiveDocDeleted rd on rd.ReceiptID = rt.ID 
                                        join ReceiptInvoice ri on ri.ID = rt.ReceiptInvoiceID
	                                    join vwAccounts vw on rd.StoreID=vw.ActivityID
                                        join PO on po.ID = ri.POID
                                        left Join(Select * from ReceiptConfirmationPrintout where reason = 'PGRV') rcpGRNF on rcpGRNF.ReceiptID = rt.ID
                                        left Join(Select * from ReceiptConfirmationPrintout where reason = 'GRV' or reason = 'IGRV') rcpGRV on rcpGRV.ReceiptID = rt.ID
                                    where ri.STVOrInvoiceNo not in('BeginningBalance','AccountToAccountTransfer')
                                    Group by rt.ID, PO.PONumber,rcpGRNF.ID,ri.ID,ri.STVOrInvoiceNo,vw.ActivityID
                                    ");
        }

        [SelectQuery]
        public static string SelectGetListOfGRVByUserIDForCostConfirmation(int userID, int priceCalculated)
        {
            return String.Format(@"select ri.ID,
	                                rd.ReceiptID, 
	                                Max(rcp.IDPrinted) RefNo,
                                    ri.STVOrInvoiceNo InvoiceNumber,
	                                PO.PONumber,
                                    Max(rd.Date)as Date,
                                    rd.StoreID,
                                    rd.SupplierID,
                                    s.CompanyName SupplierName,      
                                    ri.InsurancePolicyNo InsuranceNumber,
                                    ri.WayBillNo WayBillNumber,
                                    r.TransitTransferNo TransitNumber,
									m.TypeName Mode,
									vwa.AccountName,
									vwa.SubAccountName,
									vwa.ActivityName,
									vwp.WarehouseName,
									vwp.ClusterName,
									rt.Name ReceiveType,
									rcs.Name ReceiveStatus,
	                                r.DateOfEntry ReceivedTime,
									rd.ReceivedBy,
									Max(rd.ConfirmedDateTime) ConfirmedTime,
									u.FullName ConfirmedBy 
                                From 
	                                    ReceiveDoc rd join 
	                                    ReceiveDocConfirmation rdc on rd.ID = rdc.ReceivedocID join 
	                                    ReceiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID
                                        join Receipt r on r.ID = rd.ReceiptID Join
                                        ReceiptInvoice ri on r.ReceiptInvoiceID = ri.ID join
		                                PO on PO.ID = ri.POID join
                                        Supplier s on s.ID = rd.SupplierID  left Join
                                        ReceiptConfirmationPrintOut rcp on rcp.ReceiptID = r.ID 
									    join vwAccounts vwa on vwa.ActivityID = rd.StoreID
										join Mode m on vwa.ModeID = m.ID
										left join vwPhysicalStore vwp on vwp.PhysicalStoreid = rd.PhysicalStoreID
										join ReceiptType rt on r.ReceiptTypeID = rt.ID
                                        left join [User] u on rd.ConfirmedByUserID = u.ID
                                where
	                                    rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1) and 
		                                rcp.Reason IN ('PGRV' ,'SRM')
		                                and rd.ID in (select ReceiveDocID from ReceiveDocConfirmation  where ReceiptConfirmationStatusID = {1}) 
                                Group by rd.ReceiptID,rd.RefNo,rd.StoreID,ReceiptConfirmationStatusID,rcs.Name,rd.SupplierID,ri.STVOrInvoiceNo,ri.ID,s.CompanyName,PO.PONumber,ri.InsurancePolicyNo ,
                                    ri.WayBillNo ,
                                    r.TransitTransferNo , m.TypeName, vwa.ActivityName, vwa.SubAccountName, vwa.AccountName, vwp.WarehouseName, vwp.ClusterName, rt.Name,	r.DateOfEntry,
									rd.ReceivedBy,
									u.FullName 
                            ", userID, priceCalculated);
        }

        [SelectQuery]
        public static string SelectGetListOfGRVByUserIDForCosting(int userID, int grnfPrinted)
        {
            return String.Format(@"select ri.ID,
	                                rd.ReceiptID, 
	                                Max(rcp.IDPrinted) RefNo,
                                    Case When (rd.returnedStock = 1 AND rd.ReturnedStock is Not Null) Then 'SRM: ' + ri.STVOrInvoiceNo else ri.STVOrInvoiceNo end InvoiceNumber,
	                                Case When (rd.returnedStock = 1 AND rd.ReturnedStock is Not Null) Then 'SRM: ' + PO.PONumber else PO.PONumber end PONumber,
                                    Max(rd.Date)as Date,
                                    rd.StoreID,
                                    po.SupplierID,
                                    s.CompanyName SupplierName,
                                    ri.InsurancePolicyNo InsuranceNumber,
                                    ri.WayBillNo WayBillNumber,
                                    r.TransitTransferNo TransitNumber,
									m.TypeName Mode,
									vwa.AccountName,
									vwa.SubAccountName,
									vwa.ActivityName,
									vwp.WarehouseName,
									vwp.ClusterName,
									rt.Name ReceiveType,
									rcs.Name ReceiveStatus,
	                                r.DateOfEntry ReceivedTime,
									rd.ReceivedBy,
									Max(rd.ConfirmedDateTime) ConfirmedTime,
									u.FullName ConfirmedBy
                                From 
	                                    ReceiveDoc rd join 
	                                    ReceiveDocConfirmation rdc on rd.ID = rdc.ReceivedocID join 
	                                    ReceiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID join
                                        Receipt r on r.ID = rd.ReceiptID Join
                                        ReceiptInvoice ri on r.ReceiptInvoiceID = ri.ID join
		                                PO on PO.ID = ri.POID join
                                        Supplier s on s.ID = po.SupplierID  left Join
                                        ReceiptConfirmationPrintOut rcp on rcp.ReceiptID = r.ID join vwreceiptPallet rp on rd.ID = rp.receivedocID
										join vwAccounts vwa on vwa.ActivityID = rd.StoreID
										join Mode m on vwa.ModeID = m.ID
										left join vwPhysicalStore vwp on vwp.PhysicalStoreid = rd.PhysicalStoreID
										join ReceiptType rt on r.ReceiptTypeID = rt.ID
								        left join [User] u on rd.ConfirmedByUserID = u.ID
                                where
	                                   rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1) and 
		                                rcp.Reason IN ('PGRV' ,'SRM') 
		                                and rd.ID in (select ReceiveDocID from ReceiveDocConfirmation where ReceiptConfirmationStatusID = {1}) 

                                Group by   ri.InsurancePolicyNo , ri.WayBillNo ,r.TransitTransferNo ,rd.ReceiptID,rd.RefNo,rd.StoreID,ReceiptConfirmationStatusID,rcs.Name,po.SupplierID,ri.STVOrInvoiceNo,ri.ID,s.CompanyName,PO.PONumber,rd.ReturnedStock, m.TypeName, vwa.ActivityName, vwa.SubAccountName, vwa.AccountName, vwp.WarehouseName, vwp.ClusterName, rt.Name,	r.DateOfEntry,
									rd.ReceivedBy,u.FullName", userID, grnfPrinted);

        }
        [SelectQuery]
        public static string GetListOfReceipt(int receiptTypeID,int receiptStatusID,int userID)
        {
            return String.Format(@"Select Distinct ri.STVOrInvoiceNo DocumentNo,rt.ID,rt.ReceiptStatusID, rd.StoreID ActivityID  
                                    from ReceiveDoc rd 
		                                    join Receipt rt on rt.Id = rd.ReceiptID 
		                                    join ReceiptInvoice ri on ri.ID = rt.ReceiptInvoiceID
		                                    Join (select StoreID from UserStore where UserID = {2} and CanAccess=1) us on rd.StoreID =us.StoreID 
                                    where rt.ReceiptTypeID ={0} and rt.ReceiptStatusID = {1}",receiptTypeID,receiptStatusID, userID);
        }

        [SelectQuery]
        public static string SelectGetGRVDetailsforCosting(int ID)
        {
            string query = String.Format(@"select *, InvoiceCost OriginalInvoiceCost,
                                            Margin OriginalMargin,
                                            TotalInvoiceCost OriginalTotalInvoiceCost  from vwAggregateReceiveDoc where ReceiptID = {0}", ID);
            return query;
        }

        public static string SelectGetGRVDetailsforCostingDeliveryNoteElectronic(int ID)
        {
            string query = string.Format(@"select
                                            rid.UnitPrice OriginalInvoiceCost,
                                            rid.UnitPrice InvoiceCost,
                                            rid.Margin OriginalMargin,
                                            rid.Margin,
                                            (ReceivedQty * rid.UnitPrice) OriginalTotalInvoiceCost,
                                            (ReceivedQty * rid.UnitPrice) TotalInvoiceCost,
                                             agg.*                                           
                                             from vwAggregateReceiveDoc agg
                                            Join Receipt r on agg.ReceiptID = r.ID
                                            Join ReceiptType rt on r.ReceiptTypeID = rt.ID
                                            Join ReceiptInvoice ri on r.ReceiptInvoiceID = ri.ID
                                            Join ItemUnitBase iub on agg.ItemUnitID = iub.ID
                                            Left Join (Select * From ReceiptInvoice Where IsReprintOf is not null) rep 
                                                    ON rep.IsReprintOf = Case When
                                                      ri.IsReprintOf is Null Then ri.ID Else ri.IsReprintOf END 
                                                    And (rep.ID = (Select Max(ID) 
                                                               From ReceiptInvoice 
                                                    Where IsReprintOf = Case When ri.IsReprintOf is Null Then ri.ID Else ri.IsReprintOf END))
                                            Left Join (SELECT  ReceiptInvoiceID,ItemID, UnitOfIssueID,ManufacturerID,UnitPrice, Margin,Sum(Quantity) Quantity
													     FROM ReceiptInvoiceDetail 
														    Group By  ReceiptInvoiceID,ItemID, UnitOfIssueID, ManufacturerID,UnitPrice,Margin
												      ) rid on rid.ReceiptInvoiceID = Case When rep.IsReprintOf Is Null  Then ri.ID  Else rep.ID End
                                            and agg.ItemID = rid.ItemID and iub.UnitOfIssueID = rid.UnitOfIssueID and agg.ManufacturerID = rid.ManufacturerID
                                            where ReceiptID = {0}", ID);
            return query;
        }
        public static string SelectGetGRVDetailsforCostingDeliveryNoteManual(int ID)
        {
            string query = string.Format(@"SELECT * FROM vwAggregateReceiveDoc  WHERE ReceiptID = {0}", ID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetGRVDetailsforCostAnalysis(int ID, int noOfDigitsAfterTheDecimalPoint)
        {
            return String.Format(@" Select rd.ItemID, vw.StockCode StackCode,vw.FullItemName,  Manufacturers.ID AS ManufacturerID, 
                         Manufacturers.Name AS ManufacturerName, ItemUnit.ID AS ItemUnitID, ItemUnit.Text AS ItemUnitName, 
						 vwAccounts.ActivityID, 
                         dbo.vwAccounts.ActivityName,vwAccounts.SubAccountName, dbo.vwAccounts.MovingAverageID, dbo.vwAccounts.MovingAverageName, 
                         dbo.vwAccounts.ModeID, vw.TypeID AS CommodityTypeID, vw.Name AS CommodityTypeName, vw.StockCode,
						 sum(rd.InvoicedNoOfPack) InvoiceQty,
						 rd.PricePerPack,
						 sum(rd.InvoicedNoOfPack - isNULL(DamagedQty,0)-isNull(ShortlandedQty,0)- isNull(NotReceivedQty,0)) ReceivedQty,
						 sum(rd.InvoicedNoOfPack - isNull(NotReceivedQty,0)) Quantity,
						 sum(DamagedQty) DamagedQty,
						 sum(ShortlandedQty) ShortlandedQty,
						 sum(NotReceivedQty) NotReceivedQty,
						 sum(rd.InvoicedNoOfPack - isNULL(DamagedQty,0)-isNull(ShortlandedQty,0)- isNull(NotReceivedQty,0)) * Round(rd.PricePerPack * rd.Insurance,2)  TotalCost,
						 rd.PricePerPack InvoiceCost, sum(rd.InvoicedNoOfPack -isNull(NotReceivedQty,0)) * rd.PricePerPack TotalInvoiceCost,
						Round(rd.PricePerPack * rd.Insurance,{1}) UnitCost,rd.Margin,Cost AverageCost, SellingPrice SellingPrice,CompanyName SupplierName
                    from  dbo.ReceiveDoc AS rd INNER JOIN
                         dbo.vwGetAllItems AS vw ON rd.ItemID = vw.ID INNER JOIN
                         dbo.Manufacturers ON rd.ManufacturerId = dbo.Manufacturers.ID INNER JOIN
                         dbo.ItemUnit ON rd.UnitID = dbo.ItemUnit.ID INNER JOIN Supplier s on s.ID  = rd.SupplierID Inner join
                         dbo.vwAccounts ON rd.StoreID = dbo.vwAccounts.ActivityID Left Join (select ReceiveDocID,sum(case When sr.ShortageReasonsCode = 'DA' then isNull(NoOfPacks,0) else 0 end) DamagedQty,sum(case When sr.ShortageReasonsCode = 'SL' then isNull(NoOfPacks,0) else 0 end) ShortlandedQty,sum(case when sr.ShortageReasonsCode = 'NREC' then ISNULL(NoOfPacks,0) else 0 end) NotReceivedQty from ReceiveDocShortage join ShortageReasons as sr on sr.ID = ShortageReasonID Group by ReceiveDocID) as sdr on sdr.ReceiveDocID = rd.ID 
                    where ReceiptID = {0}
						 Group by vw.FullItemName,rd.ItemID,Manufacturers.ID,Manufacturers.Name,ItemUnit.ID,ItemUnit.Text,vwAccounts.ActivityID, 
                         dbo.vwAccounts.ActivityName, dbo.vwAccounts.AccountID, dbo.vwAccounts.MovingAverageName,vw.TypeID,vw.Name, vw.StockCode,
						 rd.PricePerPack,rd.Insurance,rd.Margin,vwAccounts.ModeID,
						 Cost, SellingPrice,CompanyName,vwAccounts.SubAccountName,vw.Name, vw.StockCode, vwAccounts.MovingAverageID,rd.UnitCost ", ID, noOfDigitsAfterTheDecimalPoint);
        }


        public static string SelectGetPreviousStockforMovingCosting(int ReceiptID)
        {
            return String.Format(
                @"select rd.ItemID
		                ,rp.StockCode StackCode
		                ,rp.ManufacturerID
		                ,rp.ItemUnitID
		                ,rp.MovingAverageID
		                ,rp.FullItemName
		                ,rp.ManufacturerName
		                ,rp.ItemUnitName
		                ,rp.MovingAverageName
		                ,sum(Case when rd.ExpDate <= GETDATE() then rp.packs else 0 end ) ExpiredQty
		                ,sum(Case when st.StorageTypeCode = 'SA' then rp.packs else 0 end ) DamagedQty
		                ,sum(Case when st.StorageTypeCode <> 'SA' 
				                and (rd.ExpDate > GETDATE() or rd.ExpDate is Null) 
				                then rp.packs else 0 end ) PreviousQty
		                , sum(Case when st.StorageTypeCode <> 'SA' 
				                and (rd.ExpDate > GETDATE() or rd.ExpDate is Null) 
				                then rp.packs else 0 end ) ReceivedQty
		                ,rd.Cost UnitCost
		                ,(sum(Case when st.StorageTypeCode <> 'SA' 
				                and (rd.ExpDate > GETDATE() or rd.ExpDate is Null) 
				                then rp.packs else 0 end )  * rd.Cost) TotalCost
                 from ReceiveDoc rd 
	                join vwReceiptPallet rp on rp.ReceiveDocID = rd.ID 
                    join StorageType st on st.ID = rp.StorageTypeID
                    join PhysicalStore ps on rp.PhyicalStoreID = ps.ID
                    Join ReceiveDocConfirmation rdc on rdc.ReceiveDocID = rd.ID
                    join ReceiptConfirmationStatus rcs on rcs.ID = rdc.ReceiptConfirmationStatusID   
	                Join (
			                select distinct rd.ItemID
				                ,rp.ManufacturerID
				                ,rp.ItemUnitID
				                ,rp.MovingAverageID
				                ,rp.FullItemName
				                ,rp.ManufacturerName
				                ,rp.ItemUnitName
				                ,rp.MovingAverageName		
			                from ReceiveDoc rd 
				                join vwReceiptPallet rp on rp.ReceiveDocID = rd.ID
			                where ReceiptID= {0}
			                ) as grv on grv.ItemID = rd.ItemID 
				                and grv.ManufacturerID = rp.ManufacturerID 
				                and grv.ItemUnitID = rp.ItemUnitID 
				                and grv.MovingAverageID = rp.MovingAverageID
			                where rd.SellingPrice is Not Null 
				                and rd.Confirmed = 1  
				                and rcs.ReceiptConfirmationStatusCode in ('GRVP','SREC','CANC','GRNFP') and (rd.ExpDate > GetDate() or rd.Expdate is Null) and st.StorageTypeCode = 'SA' and ps.IsActive = 1
                                Group by rd.ItemID,rp.StockCode,rp.ManufacturerID,rp.ItemUnitID,rp.MovingAverageID,rp.FullItemName,
 		                                rp.ManufacturerName,rp.ItemUnitName,rp.MovingAverageName,rd.Cost
                                Having sum(rp.Packs) > 0", ReceiptID);
        }

        [SelectQuery]
        public static string SelectGetPreviousStockforMovingCostingUseCostTier(int ReceiptID)
        {
            return String.Format(
                @"select rd.ItemID
		                ,rp.StockCode StackCode
		                ,rp.ManufacturerID
		                ,rp.ItemUnitID
		                ,rp.MovingAverageID
		                ,rp.FullItemName
		                ,rp.ManufacturerName
		                ,rp.ItemUnitName
		                ,rp.MovingAverageName
		                ,sum(Case when rd.ExpDate <= GETDATE() then rp.packs else 0 end ) ExpiredQty
		                ,sum(Case when st.StorageTypeCode = 'SA'  then rp.packs else 0 end ) DamagedQty
		                ,sum(Case when st.StorageTypeCode <> 'SA'  
				                and (rd.ExpDate > GETDATE() or rd.ExpDate is Null) 
				                then rp.packs else 0 end ) PreviousQty
		                , sum(Case when st.StorageTypeCode <> 'SA'  
				                and (rd.ExpDate > GETDATE() or rd.ExpDate is Null) 
				                then rp.packs else 0 end ) ReceivedQty
		                ,Cast(0 as Decimal) UnitCost
		                ,Cast(0 as Decimal) TotalCost
                 from ReceiveDoc rd 
	                join vwReceiptPallet rp on rp.ReceiveDocID = rd.ID 
                    join StorageType st on st.ID = rp.StorageTypeID
                    join PhysicalStore ps on rp.PhyicalStoreID = ps.ID
                    Join ReceiveDocConfirmation rdc on rdc.ReceiveDocID = rd.ID
                    join ReceiptConfirmationStatus rcs on rcs.ID = rdc.ReceiptConfirmationStatusID   
	                Join (
			                select distinct rd.ItemID
				                ,rp.ManufacturerID
				                ,rp.ItemUnitID
				                ,rp.MovingAverageID
				                ,rp.FullItemName
				                ,rp.ManufacturerName
				                ,rp.ItemUnitName
				                ,rp.MovingAverageName		
			                from ReceiveDoc rd 
				                join vwReceiptPallet rp on rp.ReceiveDocID = rd.ID
			                where ReceiptID= {0}
			                ) as grv on grv.ItemID = rd.ItemID 
				                and grv.ManufacturerID = rp.ManufacturerID 
				                and grv.ItemUnitID = rp.ItemUnitID 
				                and grv.MovingAverageID = rp.MovingAverageID
			                where rd.SellingPrice is Not Null 
				                and rd.Confirmed = 1  
				                and rcs.ReceiptConfirmationStatusCode in ('GRVP','SREC','CANC','GRNFP') and (rd.ExpDate > GetDate() or rd.Expdate is Null) and st.StorageTypeCode <> 'SA'  
                                Group by rd.ItemID,rp.StockCode,rp.ManufacturerID,rp.ItemUnitID,rp.MovingAverageID,rp.FullItemName,
 		                                rp.ManufacturerName,rp.ItemUnitName,rp.MovingAverageName
                                Having sum(rp.Packs) > 0", ReceiptID);
        }

        [SelectQuery]
        public static string SelectGetPreviousStockforCostAnalysisPrintout(int ReceiptID)
        {
            return String.Format(
                @"select rd.ItemID
		                ,rp.StockCode StackCode
		                ,rp.ManufacturerID
		                ,rp.ItemUnitID
		                ,rp.MovingAverageID
		                ,rp.FullItemName
		                ,rp.ManufacturerName
		                ,rp.ItemUnitName
						,rp.AccountName Activity
		                ,rp.MovingAverageName
		                ,sum(Case when  ps.IsActive =1 and rd.ExpDate <= GETDATE() then rp.packs else 0 end ) ExpiredQty
		                ,sum(Case when ps.IsActive =1 and st.StorageTypeCode = 'SA' then rp.packs else 0 end ) DamagedQty
		                ,sum(Case when ps.IsActive =1 and st.StorageTypeCode <> 'SA'   
				                and (rd.ExpDate > GETDATE() or rd.ExpDate is Null) 
				                then rp.packs else 0 end ) PreviousQty
                        , sum(Case when ps.IsActive = 0 then rp.packs else 0 end) FrozenQty
		                , sum(Case when ps.IsActive =1 and st.StorageTypeCode <> 'SA' 
				                and (rd.ExpDate > GETDATE() or rd.ExpDate is Null) 
				                then rp.packs else 0 end ) ReceivedQty
		                ,rd.Cost UnitCost
		                ,(sum(Case when ps.IsActive =1 and st.StorageTypeCode <> 'SA' and ps.IsActive =1
				                and (rd.ExpDate > GETDATE() or rd.ExpDate is Null) 
				                then rp.packs else 0 end )  * rd.Cost) TotalCost
                 from ReceiveDoc rd 
	                join vwReceiptPallet rp on rp.ReceiveDocID = rd.ID 
                    join StorageType st on st.ID = rp.StorageTypeID
                    join PhysicalStore ps on rp.PhyicalStoreID = ps.ID
                    Join ReceiveDocConfirmation rdc on rdc.ReceiveDocID = rd.ID
                    join ReceiptConfirmationStatus rcs on rcs.ID = rdc.ReceiptConfirmationStatusID   
	                Join (
			                select distinct rd.ItemID
				                ,rp.ManufacturerID
				                ,rp.ItemUnitID
				                ,rp.MovingAverageID
				                ,rp.FullItemName
				                ,rp.ManufacturerName
				                ,rp.ItemUnitName
				                ,rp.MovingAverageName		
			                from ReceiveDoc rd 
				                join vwReceiptPallet rp on rp.ReceiveDocID = rd.ID
			                where ReceiptID= {0}
			                ) as grv on grv.ItemID = rd.ItemID 
				                and grv.ManufacturerID = rp.ManufacturerID 
				                and grv.ItemUnitID = rp.ItemUnitID 
				                and grv.MovingAverageID = rp.MovingAverageID
			                where rd.SellingPrice is Not Null 
				                and rd.Confirmed = 1  
				                and rd.ReceiptID <>{0}
                                and rcs.ReceiptConfirmationStatusCode in ('GRVP','SREC','CANC','GRNFP') 
                                Group by rd.ItemID,rp.StockCode,rp.ManufacturerID,rp.ItemUnitID,rp.MovingAverageID,rp.FullItemName,
 		                                rp.ManufacturerName,rp.ItemUnitName,rp.MovingAverageName,rd.Cost,rp.AccountName
                                Having sum(rp.Packs) > 0", ReceiptID);
        }

        [SelectQuery]
        public static string SelectGetPreviousStockforCostAnalysisPrintoutUseCostTier(int ReceiptID)
        {
            return String.Format(
                @"select rd.ItemID
		                ,rp.StockCode StackCode
		                ,rp.ManufacturerID
		                ,rp.ItemUnitID
		                ,rp.MovingAverageID
		                ,rp.FullItemName
		                ,rp.ManufacturerName
		                ,rp.ItemUnitName
						,rp.AccountName Activity
		                ,rp.MovingAverageName
		                ,sum(Case when rd.ExpDate <= GETDATE() then rp.packs else 0 end ) ExpiredQty
		                ,sum(Case when st.StorageTypeCode = 'SA' then rp.packs else 0 end ) DamagedQty
		                ,sum(Case when st.StorageTypeCode <> 'SA' 
				                and (rd.ExpDate > GETDATE() or rd.ExpDate is Null) 
				                then rp.packs else 0 end ) PreviousQty
		                , sum(Case when st.StorageTypeCode <> 'SA'
				                and (rd.ExpDate > GETDATE() or rd.ExpDate is Null) 
				                then rp.packs else 0 end ) ReceivedQty
		                ,Cast(0 as Decimal) UnitCost
		                ,Cast(0 as Decimal) TotalCost
                 from ReceiveDoc rd 
	                join vwReceiptPallet rp on rp.ReceiveDocID = rd.ID 
                    join StorageType st on st.ID = rp.StorageTypeID    
                    join PhysicalStore ps on rp.PhyicalStoreID = ps.ID
                    Join ReceiveDocConfirmation rdc on rdc.ReceiveDocID = rd.ID
                    join ReceiptConfirmationStatus rcs on rcs.ID = rdc.ReceiptConfirmationStatusID 
	                Join (
			                select distinct rd.ItemID
				                ,rp.ManufacturerID
				                ,rp.ItemUnitID
				                ,rp.MovingAverageID
				                ,rp.FullItemName
				                ,rp.ManufacturerName
				                ,rp.ItemUnitName
				                ,rp.MovingAverageName		
			                from ReceiveDoc rd 
				                join vwReceiptPallet rp on rp.ReceiveDocID = rd.ID
			                where ReceiptID= {0}
			                ) as grv on grv.ItemID = rd.ItemID 
				                and grv.ManufacturerID = rp.ManufacturerID 
				                and grv.ItemUnitID = rp.ItemUnitID 
				                and grv.MovingAverageID = rp.MovingAverageID
			                where rd.SellingPrice is Not Null 
				                and rd.Confirmed = 1  
				                and rd.ReceiptID <>{0}
                                and rcs.ReceiptConfirmationStatusCode in ('GRVP','SREC','CANC','GRNFP') 
                                Group by rd.ItemID,rp.StockCode,rp.ManufacturerID,rp.ItemUnitID,rp.MovingAverageID,rp.FullItemName,
 		                                rp.ManufacturerName,rp.ItemUnitName,rp.MovingAverageName,rp.AccountName
                                Having sum(rp.Packs) > 0", ReceiptID);
        }

        [SelectQuery]
        public static string SelectGetDiscrepancyGRVDetailsforCosting(int ReceiptID, string quaranteen, int shortLanded, int damaged)
        {
            return String.Format(@"
                                           Select rd.ItemID,vw.StockCode StackCode, vw.FullItemName,  Manufacturers.ID AS ManufacturerID, 
                                                 Manufacturers.Name AS ManufacturerName, ItemUnit.ID AS ItemUnitID, ItemUnit.Text AS ItemUnitName, 
						                         vwAccounts.ActivityID, 
                                                 dbo.vwAccounts.ActivityName, dbo.vwAccounts.AccountID, dbo.vwAccounts.AccountName, 
                                                 dbo.vwAccounts.ModeID, vw.TypeID AS CommodityTypeID, vw.Name AS CommodityTypeName, vw.StockCode,
						                         sum( rd.InvoicedNoOfPack) InvoiceQty,
						                         rd.PricePerPack,
						                         sum(isNull(sdr.NoOfPacks,0)) ReceivedQty,
						                         sum(NoOfPack - isNull(sdr.NoOfPacks,0)) * Round(rd.PricePerPack * rd.Insurance,2)  TotalCost,
						                         rd.PricePerPack InvoiceCost,sr.Name Remark,sdr.ShortageReasonID ShortageReason
                                            from  dbo.ReceiveDoc AS rd INNER JOIN
                                                 dbo.vwGetAllItems AS vw ON rd.ItemID = vw.ID INNER JOIN
                                                 dbo.Manufacturers ON rd.ManufacturerId = dbo.Manufacturers.ID INNER JOIN
                                                 dbo.ItemUnit ON rd.UnitID = dbo.ItemUnit.ID INNER JOIN Supplier s on s.ID  = rd.SupplierID Inner join
                                                 dbo.vwAccounts ON rd.StoreID = dbo.vwAccounts.ActivityID Left Join ReceiveDocShortage sdr on sdr.ReceiveDocID = rd.ID join ShortageReasons sr on sdr.ShortageReasonID = sr.ID
                                            where ReceiptID = {0} and sdr.NoOfPacks is Not Null
						                         Group by vw.FullItemName,rd.ItemID,Manufacturers.ID,Manufacturers.Name,ItemUnit.ID,ItemUnit.Text,vwAccounts.ActivityID, 
                                                 dbo.vwAccounts.ActivityName, dbo.vwAccounts.AccountID, dbo.vwAccounts.AccountName,vw.TypeID,vw.Name, vw.StockCode,InvoicedNoOfPack,
						                         rd.PricePerPack,rd.Insurance,rd.Margin,vwAccounts.ModeID,
						                         rd.Cost, SellingPrice,CompanyName,vw.Name, vw.StockCode, vwAccounts.AccountID,rd.UnitCost,sr.Name,sdr.ShortageReasonID
                                            ", ReceiptID, quaranteen, shortLanded, damaged);
        }

        [SelectQuery]
        public static string SelectGetDetailsForReceipt(int id)
        {
             return String.Format(@"Select * From (
                SELECT 
                ItemID, 
                FullItemName,
                ManufacturerID,
                ManufacturerName, 
                ItemUnitID,
                ItemUnitName Unit, 
                ActivityID StoreID,
                ExpiryDate, 
                BatchNumber,
                SUM(InvoiceQty) InvoicedQty, 
                SUM(ReceivedQty) ReceivedQtyPacks,
                SUM(InvoiceQty * InvoiceCost) TotalInvoiceCost ,
                SUM(ReceivedQty * UnitCost) TotalCost,
                Min(ReceiveDocID) ReceiveDocID
                        FROM      vwReceiveDetail r
                        WHERE     r.ReceiptID = {0}
		                group by ItemID, FullItemName, ManufacturerID ,manufacturerName,ItemUnitID, ItemUnitName,ActivityID, ExpiryDate, BatchNumber) rec

		                JOIN (
		                SELECT DISTINCT rp.ReceiveID , rd.itemid, rd.UnitID, rd.ManufacturerId, rd.storeid, rd.expDate, rd.BatchNo, 
                            phS.Name PhysicalStoreName ,
                            phSType.Name PhysicalStoreTypeName
                    FROM     ReceivePallet rp
                            JOIN PalletLocation pl ON rp.PalletLocationID = pl.ID
                            JOIN ReceiveDoc rd ON rd.ID = rp.ReceiveID
                            JOIN Shelf sh ON sh.ID = pl.ShelfID
                            JOIN PhysicalStore phS ON phS.ID = sh.StoreID
                            JOIN PhysicalStoreType phSType ON phSType.ID = phS.PhysicalStoreTypeID
                    WHERE    rd.ReceiptID = {0}) phs 
	                ON rec.ReceivedocID = phs.ReceiveID 
	                JOIN vwReceiveDetail rd on rec.ReceiveDocID = rd.ReceiveDocID
	                JOIN vwGetAllItems it on rec.ItemID = it.id
	                JOIN CommodityType ct on it.TypeID = ct.ID", id);
        }


        [SelectQuery]
        public static string SelectGetDiscrepancyForGRNF(int id)
        {
            return String.Format(@"Select i.FullItemName,i.StockCode, m.Name ManufacturerName, s.CompanyName SupplierName,s.ID SupplierID,
						 sum(case When sr.ShortageReasonsCode = 'DA' then IsNull(sdr.NoOfPacks,0)else 0 end) DamagedQtyPacks,
						 sum(case When sr.ShortageReasonsCode = 'SL' then IsNull(sdr.NoOfPacks,0)else 0 end) ShortlandedQtyPacks,
						 sum(case when sr.ShortageReasonsCode = 'NREC' then ISNULL(sdr.NoOfPacks,0)else 0 end) NotReceivedQtyPacks,
						  rct.WayBillNo, rct.TransitTransferNo,rct.InsurancePolicyNo, rct.STVOrInvoiceNo, purchaseO.PONumber PONumber,
                                        i.Name as CommodityType, rd.RefNo, rd.StoreID, iu.[Text] Unit, cast(rd.[Date] as Date) ReceiveDate
										, rd.ReceiptID
                                        from ReceiveDoc rd join vwGetAllItems i on i.ID=rd.ItemID 
                                        join Manufacturers m on m.ID=rd.ManufacturerId join ItemUnit iu on iu.ID=rd.UnitID
                                        join Receipt rct on rd.ReceiptID=rct.ID
                                        join ReceiptInvoice rctInvoice on rct.ReceiptInvoiceID=rctInvoice.ID
                                        left join PO purchaseO on rctInvoice.POID=purchaseO.ID
                                        left join Supplier s on rd.SupplierID=s.ID join ReceiveDocShortage sdr on sdr.ReceiveDocID = rd.ID
                                        join ShortageReasons sr on sr.ID = sdr.ShortageReasonID
										Where rd.ReceiptID ={0}
                                        group by 
                                        i.FullItemName,i.StockCode, m.Name, s.CompanyName,s.ID, i.Name,rd.refno, rd.StoreID, iu.[Text], cast(rd.[Date] as Date),
                                        rd.ReceiptID, rct.WayBillNo, rct.TransitTransferNo,rct.InsurancePolicyNo, rct.STVOrInvoiceNo, purchaseO.PONumber
                                        order by CommodityType, ManufacturerName, FullItemName", id);
        }

        [SelectQuery]
        public static string SelectLoadSearchDetailsForReceipt(int receiptID)
        {
            return String.Format(
                @"select rct.ID,rt.Name ReceiptType,rct.STVOrInvoiceNo,rcS.Name CurrentStatus, rdc.ReceivedByUserID,rdc.ReceiptQuantityConfirmedByUserID,rdc.PriceAssignedByUserID,rdc.PriceConfirmedByUserID,rdc.GRVPrintedByUserID,rdc.UnitCostCalculatedByUserID
                        from Receipt rct left join ReceiveDoc rd on rct.ID=rd.ReceiptID left join receivedocconfirmation rdc on rd.ID=rdc.ReceiveDocID
                        left join ReceiptConfirmationStatus rcS on rcS.ID=rdc.ReceiptConfirmationStatusID
                        left join ReceiptType rt on rct.ReceiptTypeID=rt.ID where rct.ID={0}",
                receiptID);
        }

        [SelectQuery]
        public static string SelectGetlistOfPrints(int ID)
        {
            return String.Format(@"select ID, Type,Reference,PrintedDate from PrintLog where Reference = '{0}'", ID);
        }

        [SelectQuery]
        public static string SelectFacilityName(int receiptID)
        {
            return String.Format(@"Select Top (1) i.Name FacilityName from ReceiveDoc rd join IssueDoc id on rd.ReturnedFromIssueDocID = id.ID join Institution i on i.id=id.ReceivingUnitID where rd.ReceiptID = {0} ", receiptID);
        }

        [SelectQuery]
        public static string SelectGetPriceListFromCostTier(int MovingAverageGroupID)
        {
            return String.Format(
                @"Select pl.* ,ct.Name CommodityType,TypeID 
		                        from vwPriceList pl 
				                        join vwgetallItems i on i.ID = pl.ItemID 
				                        Join CommodityType ct on ct.ID = i.TypeID
				                        Join (select ItemID,UnitID,ManufacturerID  
						                        from CurrentReceiveDoc 
							                        Group by ItemID,UnitID,ManufacturerID) 
				                        rd on pl.ItemID = rd.ItemID 
				                and pl.UnitID = rd.UnitID and rd.ManufacturerID = pl.ManufacturerID   where MovingAverageGroupID = {0}",
                MovingAverageGroupID);
        }

        [SelectQuery]
        public static string SelectGetPriceListFromCostTierShowAll(int MovingAverageGroupID)
        {
            return String.Format(
                @"Select pl.* ,ct.Name CommodityType,TypeID from vwPriceList pl join vwgetallItems i on i.ID = pl.ItemID Join CommodityType ct on ct.ID = i.TypeID where MovingAverageGroupID = {0}",
                MovingAverageGroupID);
        }

        [SelectQuery]
        public static string SelectGetPriceConfirmationListFromCostTier(int MovingAverageGroupID, int priceOverrideId)
        {
            return String.Format(@"Select pl.*,TypeID from [vwPriceListPendingConfirmation] pl join vwgetallItems i on i.ID = pl.ItemID where MovingAverageGroupID = {0} and ChangeType = {1}", MovingAverageGroupID, priceOverrideId);
        }

        [SelectQuery]
        public static string SelectGetInventoryListByAccount(int movingAverageID, int statusID)
        {
            return String.Format(@"Select distinct rd.ItemID
                                                           , rd.UnitID
                                                           , rd.ManufacturerID
                                                           , rp.MovingAverageID
                                                           , rp.ItemUnitName Unit
                                                           , rp.FullItemName as FullItemName 
                                                           , rp.StockCode                                              
                                                from vwReceiptPallet rp 
                                                      join ReceiveDoc rd on rp.ReceiveDocID = rd.ID  
                                                      join receiveDocConfirmation rdc on rdc.ReceiveDocID = rd.ID
                                                 Where  rd.refNo like 'BeginningBalance' 
                                                            and rp.MovingAverageID = {0} 
                                                            and rdc.ReceiptConfirmationStatusID ={1}", movingAverageID, statusID);
        }
//        [SelectQuery]
//        public static string SelectItemPriceHistory( int itemID, int unitID, int manufacturerID)
//        {
//            var query = string.Format(@"SELECT itm.FullItemName,
//                                           u.Text Unit,
//                                           ac.Name Activity,
//                                           m.Name Manufacturer,
//                                           s.CompanyName Supplier,
//                                           h.*
//                                    FROM MovingAverageHistory h
//                                    LEFT JOIN vwGetAllItems itm ON itm.ID = h.ItemID
//                                    LEFT JOIN ItemUnitBase iu ON iu.ItemID = h.ItemID
//                                    LEFT JOIN UnitofIssue u ON u.ID = iu.UnitOfIssueID
//                                    LEFT JOIN Supplier s ON s.ID = h.SupplierID
//                                    LEFT JOIN Account.Activity ac ON ac.ActivityID = h.StoreID
//                                    LEFT JOIN Manufacturer m ON m.ID = h.ManufacturerID
//                                    WHERE h.ItemID = {0}
//                                      AND UnitID = {1}
//                                      AND ManufacturerID = {2}
//                                    ORDER BY h.Date DESC", itemID, unitID, manufacturerID);
//            return query;
//        }
         [SelectQuery]
        public static string SelectGetItemPriceHistoryByDate( DateTime date, int userID)
         {
             var query = String.Format(@"SELECT it.FullItemName,
                                           iu.[Text] Unit,
                                           m.Name Manufacturer,
                                           a.Name Activity,
                                           a.ActivityID,
                                           h.[Date],
                                           RIGHT('00000' + cast( max(rcp.IDPrinted) as varchar),5) GRV,
                                           h.ItemID,
                                           h.unitID,
                                           h.ManufacturerID,
                                           h.StoreID,
										   h.Price,
                                           h.PUnitCost,
                                           h.NUnitCost,
                                           h.Margin,
                                           ac.ModeID
                                    FROM MovingAverageHistory h
                                    LEFT JOIN ReceiveDoc rd ON rd.ReceiptID = h.ReceiptId
                                    JOIN vwGetAllItems it ON it.ID = h.ItemID
                                    JOIN ItemUnit iu ON iu.ItemID = h.ItemID AND iu.ID = h.UnitID
                                    JOIN Manufacturer m ON m.ID = h.ManufacturerID
								   LEFT JOIN Account.Activity a on a.CostGroupID = h.StoreID
								   LEFT JOIN Account.SubAccount sa on a.SubAccountID = sa.SubAccountID
								   LEFT JOIN Account.Account ac on sa.AccountID = ac.AccountID	
								   LEFT JOIN ReceiptConfirmationPrintout rcp ON rcp.ReceiptID = h.ReceiptId               --                                                     

                                        WHERE ( h.ReceiptID is null or (h.ReceiptID is not null and rcp.Reason IN ('GRV', 'iGRV')))
									     AND (h.ReceiptID is null or  rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1))
                                         AND dateadd(dd,0, datediff(dd,0, h.[Date]))>='{1}'
                                    GROUP BY it.FullItemName,
                                             iu.Text,
                                             m.Name,
                                             a.Name, 
                                             a.ActivityID,
                                             h.ItemID,
                                             h.UnitID,
                                             h.ManufacturerID,
                                             h.StoreID,
                                             h.Date,
                                             h.PUnitCost,
                                             h.NUnitCost,
                                             h.Margin,
											 h.Price,
                                             ac.ModeID,
											 rcp.IDPrinted 
                                             order by h.Date desc", userID, date.ToShortDateString());
                                                     return query;

        }

         public static string SelectGetItemPriceHistoryByDate(DateTime StartDate, DateTime Enddate, int userID)
         {
             var query = String.Format(@"SELECT it.FullItemName,
                                           iu.[Text] Unit,
                                           m.Name Manufacturer,
                                           h.[Date],
                                           RIGHT('00000' + cast( max(rcp.IDPrinted) as varchar),5) GRV,
                                           h.ItemID,
                                           h.unitID,
                                           h.ManufacturerID,
                                           h.StoreID,
										   h.Price,
                                           h.PUnitCost,
                                           h.NUnitCost,
                                           h.Margin,
                                           ac.ModeID,
                                           vwa.MovingAverageName
                                    FROM MovingAverageHistory h
                                    LEFT JOIN ReceiveDoc rd ON rd.ReceiptID = h.ReceiptId
                                    JOIN vwGetAllItems it ON it.ID = h.ItemID
                                    JOIN ItemUnit iu ON iu.ItemID = h.ItemID AND iu.ID = h.UnitID
                                    JOIN Manufacturer m ON m.ID = h.ManufacturerID
								   LEFT JOIN Account.Activity a on a.CostGroupID = h.StoreID
								   LEFT JOIN Account.SubAccount sa on a.SubAccountID = sa.SubAccountID
								   LEFT JOIN Account.Account ac on sa.AccountID = ac.AccountID	
                                   LEFT JOIN [vwAccounts] vwa on sa.SubAccountID = vwa.SubAccountID
								   LEFT JOIN ReceiptConfirmationPrintout rcp ON rcp.ReceiptID = h.ReceiptId               --                                                     

                                        WHERE ( h.ReceiptID is null or (h.ReceiptID is not null and rcp.Reason IN ('GRV', 'iGRV')))
									     AND (h.ReceiptID is null or  rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1))
                                         AND dateadd(dd,0, datediff(dd,0, h.[Date]))>='{1}'
                                         AND dateadd(dd,0, datediff(dd,0, h.[Date]))<='{2}'
                                    GROUP BY it.FullItemName,
                                             iu.Text,
                                             m.Name,
                                             h.ItemID,
                                             h.UnitID,
                                             h.ManufacturerID,
                                             h.StoreID,
                                             h.Date,
                                             h.PUnitCost,
                                             h.NUnitCost,
                                             h.Margin,
											 h.Price,
                                             ac.ModeID,
                                             vwa.MovingAverageName,
											 rcp.IDPrinted 
                                             order by h.Date desc", userID, StartDate.ToShortDateString(), Enddate.ToShortDateString());
             return query;

         }

        [SelectQuery]
        public static string SelectGetReceiptStatusDetails(int receiptID, int receiptStatusID)
        {
            string query = string.Format(@"Select ReceiptID, UserID, StatusChangedDate From(
                                            Select ReceiptID, UserID, StatusChangedDate, ROW_NUMBER()
                                            OVER(Partition by ReceiptID Order by StatusChangedDate Desc) R From LogReceiptStatus Where ReceiptID = {0} and ToStatusID = {1} 
                                            )x Where x.R = 1", receiptID,receiptStatusID);
            return query;
        }
    }
}
