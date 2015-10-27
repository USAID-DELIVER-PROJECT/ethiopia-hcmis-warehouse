using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class Transfer
    {
        public static string SelectGetDetailForStoreTransfer(int PickListID)
        {
            string query = String.Format("select ROW_NUMBER() OVER (ORDER BY FullItemName) AS LineNum, picklistID, vw.FullItemName,pld.Packs QtyInSKU,mf.Name Manufacturer,pld.ExpireDate ExpDate,pld.BatchNumber BatchNo from PickListDetail pld join PickList pl on pld.PickListID=pl.ID join ReceivePallet rp on pld.ReceivePalletID=rp.id join [Order] o on o.id=pl.OrderID Join [Transfer] tr on o.ID = tr.OrderID  Join vwGetAllItems vw on vw.ID = pld.ItemID join ItemUnit iu on iu.ID = pld.UnitID join Manufacturers mf on mf.ID = pld.ManufacturerID where pld.picklistID = {0}", PickListID);
            return query;
        }

        public static string SelectGetStoreTransfer(int PicklistID)
        {
            string query = String.Format("select ps.name FromStore,ps2.Name ToStore,GETDATE() Date,st.StoreName FromAccount, st2.StoreName ToAccount,o.ContactPerson Contact from PickListDetail pld join PickList pl on pld.PickListID=pl.ID join ReceivePallet rp on pld.ReceivePalletID=rp.id join [Order] o on o.id=pl.OrderID Join [Transfer] tr on o.ID = tr.OrderID Join physicalStore ps on ps.ID = tr.FromPhysicalStoreID Join PhysicalStore ps2 on ps2.ID = tr.ToPhysicalStoreID Join Stores st on st.ID = tr.FromStoreID Join Stores st2 on st2.ID = tr.FromStoreID  where picklistId = {0}", PicklistID);
            return query;
        }

        public static string SelectTransferToStore(int PicklistID)
        {
            string query = String.Format("select tr.FromPhysicalStoreID,tr.ToPhysicalStoreID, rp.ID ReceivingPalletID, pld.Packs From PickListDetail pld join PickList pl on pld.PickListID=pl.ID join ReceivePallet rp on pld.ReceivePalletID=rp.id join [Order] o on o.id=pl.OrderID Join [Transfer] tr on o.ID = tr.OrderID", PicklistID);
            return query;
        }

        public static string SelectGetTransferReport()
        {
            string query = @"SELECT vw.FullItemName ItemName,
                                                iu.Text Unit,
	                                            pld.Packs Packs,
	                                            mf.Name Manufacturer,
	                                            pld.ExpireDate ExpiryDate,
	                                            pld.BatchNumber BatchNo,
	                                            stFrom.StoreName [From],
	                                            stTo.StoreName [To],
	                                            pl.SavedDate [Date]
                                           FROM PickListDetail pld join PickList pl ON pld.PickListID=pl.ID JOIN 
	                                            ReceivePallet rp ON pld.ReceivePalletID=rp.id JOIN 
	                                            [Order] o ON o.id=pl.OrderID JOIN 
	                                            [Transfer] tr ON o.ID = tr.OrderID  JOIN 
	                                            Stores stFrom ON stFrom.ID = tr.FromStoreID JOIN
	                                            Stores stTo ON stTo.ID = tr.ToStoreID JOIN
	                                            vwGetAllItems vw ON vw.ID = pld.ItemID JOIN 
	                                            ItemUnit iu ON iu.ID = pld.UnitID JOIN 
	                                            Manufacturers mf ON mf.ID = pld.ManufacturerID
                                                join TransferType tt on tt.ID = tr.TransferTypeID
                                           WHERE tt.TransferTypeCode = 'ACA'";
            return query;
        }

        public static string SelectGetTransferReportForStore()
        {
            string query = @"SELECT vw.FullItemName ItemName,
                                                iu.ItemID itemID,
                                                rp.id PalletID,
                                                pld.QtyPerPack QtyPerPacks,
                                                iu.Text Unit,
	                                            pld.Packs Packs,
	                                            mf.Name Manufacturer,
	                                            pld.ExpireDate ExpiryDate,
	                                            pld.BatchNumber BatchNo,
	                                            stFrom.Name [From],
	                                            stTo.Name [To],
                                                pl.SavedDate [Date],
                                                pld.PalletLocationID PalletLocationID,
                                                pld.ReceivePalletID ReceivePalletID,pld.*
                                           FROM PickListDetail pld join PickList pl ON pld.PickListID=pl.ID JOIN 
	                                            ReceivePallet rp ON pld.ReceivePalletID=rp.id JOIN 
	                                            [Order] o ON o.id=pl.OrderID JOIN 
	                                            [Transfer] tr ON o.ID = tr.OrderID  JOIN 
	                                            PhysicalStore stFrom ON stFrom.ID = tr.FromPhysicalStoreID JOIN
	                                            PhysicalStore stTo ON stTo.ID = tr.ToPhysicalStoreID JOIN
	                                            vwGetAllItems vw ON vw.ID = pld.ItemID JOIN 
	                                            ItemUnit iu ON iu.ID = pld.UnitID JOIN 
	                                            Manufacturers mf ON mf.ID = pld.ManufacturerID
                                                join TransferType tt on tt.ID = tr.TransferTypeID
                                           WHERE	tt.TransferTypeCode = 'STS'";
            return query;
        }
    }
}
