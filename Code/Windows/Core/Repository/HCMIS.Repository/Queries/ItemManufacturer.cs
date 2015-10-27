using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class ItemManufacturer
    {
        [SelectQuery]
        public static string SelectGetAllLevels()
        {
            const string query =
                "SELECT DISTINCT (PackageLevel), ('Level ' + cast(PackageLevel AS varchar)) AS Level FROM ItemManufacturer";
            return query;
        }

        [SelectQuery]
        public static string SelectLevelView2(int itemId, int manufacturerId, int packageLevel)
        {
            return String.Format("select * from ItemManufacturer where ItemID = {0} and ManufacturerID = {1} and PackageLevel <= {2} order by PackageLevel", itemId, manufacturerId, packageLevel);
        }

        [SelectQuery]
        public static string SelectLoadManufacturersFor(int item)
        {
            String query =
                String.Format(
                    "select distinct(ManufacturerID), Name, m.CountryOfOrigin from ItemManufacturer im join Manufacturers m on im.ManufacturerID = m.ID where ItemID = {0}",
                    item);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadManufacturerItemRelationsFor(int item, int manufactuerer)
        {
            String query =
                String.Format(
                    "select * , 'Level ' + CAST(PackageLevel AS VarChar ) as PLevel from ItemManufacturer where ItemID = {0} and ManufacturerID = {1}",
                    item, manufactuerer);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadManufacturerItemLevelRelationsFor(int item, int manufactuerer)
        {
            String query =
                String.Format(
                    "select * , 'Level ' + CAST(PackageLevel AS VarChar ) as PLevel from ItemManufacturer where ItemID = {0} and ManufacturerID = {1}",
                    item, manufactuerer);
            return query;
        }

        [UpdateQuery]
        public static string UpdateSaveReceivingDefault(int itemId, int manufacturerId)
        {
            return String.Format("Update ItemManufacturer set RecevingDefault = 0 where ItemID = {0} and ManufacturerID = {1}", itemId, manufacturerId);
        }

        [SelectQuery]
        public static string SelectLoadDefaultReceiving(int itemid, int manufid)
        {
            String query =
                String.Format(
                    "select * from ItemManufacturer where ItemID = {0} and ManufacturerID = {1} and RecevingDefault = 1", itemid,
                    manufid);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadOuterBoxForItemManufacturer(int itemid, int manufid)
        {
            string query = String.Format("select * from ItemManufacturer where ItemID = {0} and ManufacturerID = {1} ", itemid,
                manufid);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadIMbyLevel(int itemId, int manufId)
        {
            String query = String.Format("select * from ItemManufacturer where ItemID = {0} and ManufacturerID = {1}", itemId,
                manufId);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadLevelsFor2(int itemId, int manufId)
        {
            string query =
                String.Format(
                    "SELECT DISTINCT (PackageLevel), ('Level ' + cast(PackageLevel AS varchar)) AS Level FROM ItemManufacturer where ItemID = {0} and ManufacturerID = {1}",
                    itemId, manufId);
            return query;
        }

        [UpdateQuery]
        public static string UpdateSaveStackStored(int itemId, int manufacturerId, double stackHeight)
        {
            string query =
                String.Format("update ItemManufacturer set stackHeight = {2} where ItemID = {0} and ManufacturerID = {1}",
                    itemId, manufacturerId, stackHeight);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadDefaultSkuItemManufacturer(int itemid)
        {
            string query =
                String.Format(
                    "select * from ItemManufacturer where ItemID = {0} and PackageLevel = 0 and ManufacturerID = (select TOP(1) ManufacturerID from ReceiveDoc where QuantityLeft > 0 and ItemID = {0} order by ExpDate)",
                    itemid);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadDefaultSkuItemManufacturerNotSuppled(int itemid)
        {
            var query = String.Format("select * from ItemManufacturer where ItemID = {0} and PackageLevel = 0 ", itemid);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadSkuUnit(int itemId, int manufacturer)
        {
            string query =
                String.Format(
                    "select * from ItemManufacturer where ItemID = {0} and ManufacturerID = {1} and PackageLevel = 0", itemId,
                    manufacturer);
            return query;
        }

        [SelectQuery]
        public static string SelectHasReceives(int itemId, int manufacturerId)
        {
            string query = String.Format("select * from ReceiveDoc where ItemID = {0} and ManufacturerID = {1}", itemId, manufacturerId);
            return query;
        }

        [UpdateQuery]
        public static string UpdateChangeSKU(int itemID, int manufacturerID, int newQuantity, int previousQuantityPerLevel)
        {
            string query =
                String.Format(
                    "update ReceiveDoc set QtyPerPack = {0}, Quantity = Quantity * {0} / {1}, QuantityLeft = QuantityLeft * {0} / {1} where ItemID = {2} and ManufacturerID = {3}",
                    newQuantity,
                    previousQuantityPerLevel, itemID, manufacturerID);
            return query;
        }

        [UpdateQuery]
        public static string UpdateChangeSKUIssueDoc(int itemID, int manufacturerID, int newQuantity, int previousQuantityPerLevel)
        {
            var query =
                String.Format(
                    "Update IssueDoc set Quantity = Quantity * {2} / {3}, QtyPerPack = {2} where RecievDocID in (select ID from ReceiveDoc where ItemID = {0} and ManufacturerID = {1} )",
                    itemID, manufacturerID, newQuantity, previousQuantityPerLevel);
            return query;
        }

        [UpdateQuery]
        public static string UpdateChangeSKULossAndAdjustment(int itemID, int manufacturerID, int newQuantity, int previousQuantityPerLevel)
        {
            return String.Format(
                "Update LossAndAdjustment set Quantity = Quantity * {2} / {3}  where RecID in (select ID from ReceiveDoc where ItemID = {0} and ManufacturerID = {1})",
                itemID, manufacturerID, newQuantity, previousQuantityPerLevel);
        }

        [UpdateQuery]
        public static string UpdateChangeSKUReceivePallet(int itemID, int manufacturerID, int newQuantity, int previousQuantityPerLevel)
        {
            return String.Format(
                "Update ReceivePallet set ReceivedQuantity = ReceivedQuantity * {2} / {3}, Balance = Balance * {2} / {3}, ReservedStock = ReservedStock * {2} / {3} where ReceiveID in (select ID from ReceiveDoc where ItemID = {0} and ManufacturerID = {1} )",
                itemID, manufacturerID, newQuantity, previousQuantityPerLevel);
        }

        [UpdateQuery]
        public static string UpdateChangeSKUPickListDetail(int itemID, int manufacturerID, int newQuantity, int previousQuantityPerLevel)
        {
            return String.Format(
                "Update PickListDetail set QuantityInBU = QuantityInBU * {2} / {3}, QtyPerPack = {2} where ReceiveDocID in (select ID from ReceiveDoc where ItemID = {0} and ManufacturerID = {1} )",
                itemID, manufacturerID, newQuantity, previousQuantityPerLevel);
        }

        [SelectQuery]
        public static string SelectLoadManufactuererByItemWithReceive(int itemId)
        {
            string query = String.Format(@"select distinct m.ID,m.Name 
                                                from receivedoc rd join Manufacturers m on rd.ManufacturerId = m.ID
                                            where rd.ItemID = {0} ", itemId);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadAllManufacturersByItem(int itemId)
        {
            string query = String.Format(@"select distinct m.ID,m.Name 
                                                from  Manufacturers m where ID in ( select ManufacturerID from ItemManufacturer where ItemID = {0} )",
                itemId);
            return query;
        }
    }
}
