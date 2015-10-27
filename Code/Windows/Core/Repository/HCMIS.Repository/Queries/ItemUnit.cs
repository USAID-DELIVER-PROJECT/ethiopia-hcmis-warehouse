using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class ItemUnit
    {
        [SelectQuery]
        public static string SelectLoadAllForItem(int itemId)
        {
            string query = String.Format("select * from ItemUnit where ItemID = {0}", itemId);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadReceivedByItemId(int itemId)
        {
            string query = String.Format(@"select distinct iu.ID,iu.Text,iu.QtyPerUnit
                                                    from receivedoc rd join ItemUnit iu on rd.UnitID = iu.ID
                                            where rd.ItemID = {0} ", itemId);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadAllForItemNotInYearEnd(int itemId)
        {
            string query =
                String.Format(
                    "Select * from ItemUnit where ItemID={0} and ID not in (Select UnitID from YearEnd where ItemID={0} )",
                    itemId);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadAllForItemInYearEnd(int itemId)
        {
            string query =
                String.Format(
                    "Select * from ItemUnit where ItemID={0} and ID in (Select UnitID from YearEnd where ItemID={0} )", itemId);
            return query;
        }

        [SelectQuery]
        public static string SelectChangeItemUnit(int storeId, int itemId, int iuFromId)
        {
            string receiveTableFilterQuery =
                String.Format("select ID from ReceiveDoc where ItemID = {0} and UnitID = {1} and StoreID={2}", itemId, iuFromId,
                    storeId);
            return receiveTableFilterQuery;
        }

        [UpdateQuery]
        public static string UpdateChangeItemUnitIssueDoc(int iuToQtyPerUnit, int iuFromQtyPerUnit, string receiveTableFilterQuery)
        {
            return String.Format(
                "Update IssueDoc set Quantity = Quantity * {0} / {1}, QtyPerPack = {0} where RecievDocID in ({2})",
                iuToQtyPerUnit, iuFromQtyPerUnit, receiveTableFilterQuery);
        }

        [UpdateQuery]
        public static string UpdateChangeItemUnitLossAndAdjustment(int iuToQtyPerUnit, int iuFromQtyPerUnit, string receiveTableFilterQuery)
        {
            return String.Format(
                "Update LossAndAdjustment set Quantity = Quantity * {0} / {1}  where RecID in ({2})",
                iuToQtyPerUnit, iuFromQtyPerUnit, receiveTableFilterQuery);
        }

        [UpdateQuery]
        public static string UpdateChangeItemUnitOrderDetail(int itemId, int iuFromId, int iuFromQtyPerUnit, int iuToQtyPerUnit)
        {
            return String.Format(
                "Update OrderDetail set Quantity = Quantity * {2} / {3}, QtyPerPack = {2} where UnitID ={1} and ItemID={0}",
                itemId, iuFromId, iuToQtyPerUnit, iuFromQtyPerUnit);
        }

        [UpdateQuery]
        public static string UpdateChangeItemUnitPickListDetail(int iuToQtyPerUnit, int iuFromQtyPerUnit, string receiveTableFilterQuery)
        {
            return String.Format(
                "Update PickListDetail set QuantityInBU = QuantityInBU * {0} / {1}, QtyPerPack = {0} where ReceiveDocID in ({2})",
                iuToQtyPerUnit, iuFromQtyPerUnit, receiveTableFilterQuery);
        }

        [UpdateQuery]
        public static string UpdateChangeItemUnitMovingAverageHistory(int storeID, int iuToId, int iuFromId)
        {
            return String.Format("update MovingAverageHistory set UnitID = {0} where UnitID = {1} and StoreID = {2}",
                iuToId, iuFromId, storeID);
        }

        [UpdateQuery]
        public static string UpdateCorrectUnitQtyPerUnitInconsistenciesRd()
        {
            string query;
            query = @"update rd
                        set rd.Quantity=rd.NoOfPack*iu.QtyPerUnit,rd.QtyPerPack=iu.QtyPerUnit
                        from ReceiveDoc rd join ItemUnit iu on iu.ID=rd.UnitID
                        where iu.QtyPerUnit<>rd.QtyPerPack";
            return query;
        }

        [UpdateQuery]
        public static string UpdateCorrectUnitQtyPerUnitInconsistenciesId()
        {
            var query = @"update id
                        set id.Quantity=id.NoOfPack*rd.QtyPerPack,id.QtyPerPack=rd.QtyPerPack
                        from IssueDoc id join ReceiveDoc rd on id.RecievDocID=rd.ID join ItemUnit iu on iu.ID=rd.UnitID
                        where id.QtyPerPack<>rd.QtyPerPack";
            return query;
        }

        [UpdateQuery]
        public static string UpdateCorrectUnitQtyPerUnitInconsistenciesOdd()
        {
            var query = @"update odd
                        set odd.Quantity=odd.Pack*iu.QtyPerUnit, odd.QtyPerPack=iu.QtyPerUnit, odd.UnitID=iu.ID
                        from OrderDetail odd join ItemUnit iu on iu.ID=odd.UnitID
                        where odd.QtyPerPack<>iu.QtyPerUnit";
            return query;
        }

        [UpdateQuery]
        public static string UpdateCorrectUnitQtyPerUnitInconsistenciesIdPld()
        {
            var query = @"update pld
                        set pld.UnitID=rd.UnitID
                        from ReceiveDoc rd join PicklistDetail pld
                        on rd.ID=pld.ReceiveDocID
                        Where rd.UnitID<>pld.UnitID";
            return query;
        }

        [UpdateQuery]
        public static string UpdateCorrectUnitQtyPerUnitInconsistenciesIdPld2()
        {
            var query = @"update pld
                        set pld.QuantityInBU=pld.Packs*iu.QtyPerUnit, pld.QtyPerPack=iu.QtyPerUnit, pld.UnitID=iu.ID
                        from PickListDetail pld join ItemUnit iu on iu.ID=pld.UnitID
                        where pld.QtyPerPack<>iu.QtyPerUnit";
            return query;
        }

        [UpdateQuery]
        public static string UpdateCorrectUnitQtyPerUnitInconsistenciesIdDisp()
        {
            var query = @"update disp
                        set disp.Quantity=disp.NoOfPack*rd.QtyPerPack,disp.QtyPerPack=rd.QtyPerPack
                        from IssueDoc disp join ReceiveDoc rd on disp.RecievDocID=rd.ID join ItemUnit iu on iu.ID=rd.UnitID
                        where disp.QtyPerPack<>rd.QtyPerPack";
            return query;
        }

        [UpdateQuery]
        public static string UpdateCorrectUnitQtyPerUnitInconsistenciesIdIssueDoc()
        {
            var query = @"update IssueDoc Set Quantity=NoOfPack*QtyPerPack";
            return query;
        }

        [UpdateQuery]
        public static string UpdateCorrectUnitQtyPerUnitInconsistenciesIdReceiveDoc()
        {
            var query = @"update ReceiveDoc Set Quantity=NoOfPack*QtyPerPack";
            return query;
        }

        [UpdateQuery]
        public static string UpdateCorrectUnitQtyPerUnitInconsistenciesRd(int itemID)
        {
            return String.Format(
                @"update rd
                        set rd.Quantity=rd.NoOfPack*iu.QtyPerUnit,rd.quantityleft =(rd.quantityleft/rd.QtyPerPack)*iu.QtyPerUnit
                        from ReceiveDoc rd join ItemUnit iu on iu.ID=rd.UnitID
                        where iu.QtyPerUnit<>rd.QtyPerPack and rd.ItemID={0}",
                itemID);
        }

        [UpdateQuery]
        public static string UpdateCorrectUnitQtyPerUnitInconsistenciesRp(int itemID)
        {
            return String.Format(
                @"update rp
                        set rp.Balance =(rp.Balance/rd.QtyPerPack)*iu.QtyPerUnit, rp.ReceivedQuantity=(ReceivedQuantity/rd.QtyPerPack) * iu.QtyPerUnit
                        from ReceiveDoc rd Join ReceivePallet rp on rd.ID = rp.ReceiveID join ItemUnit iu on iu.ID=rd.UnitID
                        where iu.QtyPerUnit<>rd.QtyPerPack and rd.ItemID={0}",
                itemID);
        }

        [UpdateQuery]
        public static string UpdateCorrectUnitQtyPerUnitInconsistenciesRd2(int itemID)
        {
            return String.Format(
                @"update rd
                        set rd.QtyPerPack=iu.QtyPerUnit
                        from ReceiveDoc rd join ItemUnit iu on iu.ID=rd.UnitID
                        where iu.QtyPerUnit<>rd.QtyPerPack and rd.ItemID={0}",
                itemID);
        }

        [UpdateQuery]
        public static string UpdateCorrectUnitQtyPerUnitInconsistenciesId(int itemID)
        {
            return String.Format(@"update id
                        set id.Quantity=id.NoOfPack*rd.QtyPerPack,id.QtyPerPack=rd.QtyPerPack
                        from IssueDoc id join ReceiveDoc rd on id.RecievDocID=rd.ID join ItemUnit iu on iu.ID=rd.UnitID
                        where id.QtyPerPack<>rd.QtyPerPack and rd.ItemID={0}", itemID);
        }

        [UpdateQuery]
        public static string UpdateCorrectUnitQtyPerUnitInconsistenciesOdd(int itemID)
        {
            return String.Format(@"update odd
                        set odd.Quantity=odd.Pack*iu.QtyPerUnit, odd.QtyPerPack=iu.QtyPerUnit, odd.UnitID=iu.ID
                        from OrderDetail odd join ItemUnit iu on iu.ID=odd.UnitID
                        where odd.QtyPerPack<>iu.QtyPerUnit and odd.ItemID={0}", itemID);
        }

        [UpdateQuery]
        public static string UpdateCorrectUnitQtyPerUnitInconsistenciesPid(int itemID)
        {
            return String.Format(@"update pld
                        set pld.UnitID=rd.UnitID
                        from ReceiveDoc rd join PicklistDetail pld
                        on rd.ID=pld.ReceiveDocID
                        Where rd.UnitID<>pld.UnitID and rd.ItemID={0}", itemID);
        }

        [UpdateQuery]
        public static string UpdateCorrectUnitQtyPerUnitInconsistenciesPid2(int itemID)
        {
            return String.Format(@"update pld
                        set pld.QuantityInBU=pld.Packs*iu.QtyPerUnit, pld.QtyPerPack=iu.QtyPerUnit, pld.UnitID=iu.ID
                        from PickListDetail pld join ItemUnit iu on iu.ID=pld.UnitID
                        where pld.QtyPerPack<>iu.QtyPerUnit and pld.ItemID={0}", itemID);
        }

        [UpdateQuery]
        public static string UpdateCorrectUnitQtyPerUnitInconsistenciesDisp(int itemID)
        {
            return String.Format(@"update disp
                        set disp.Quantity=disp.NoOfPack*rd.QtyPerPack,disp.QtyPerPack=rd.QtyPerPack
                        from IssueDoc disp join ReceiveDoc rd on disp.RecievDocID=rd.ID join ItemUnit iu on iu.ID=rd.UnitID
                        where disp.QtyPerPack<>rd.QtyPerPack and disp.ItemID={0}", itemID);
        }

        [UpdateQuery]
        public static string UpdateCorrectUnitQtyPerUnitInconsistenciesIssueDoc(int itemID)
        {
            return String.Format(@"update IssueDoc Set Quantity=NoOfPack*QtyPerPack WHERE ItemID={0}", itemID);
        }

        [UpdateQuery]
        public static string UpdateCorrectUnitQtyPerUnitInconsistenciesReceiveDoc(int itemID)
        {
            return String.Format(@"update ReceiveDoc Set Quantity=NoOfPack*QtyPerPack WHERE ItemID={0}", itemID);
        }
    }
}
