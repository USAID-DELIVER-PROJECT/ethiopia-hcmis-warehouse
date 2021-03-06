
// Generated by MyGeneration Version # (1.3.0.3)

using System;
using System.Collections.ObjectModel;
using System.Data;
using BLL.WorkFlow.Issue;
using DAL;
using System.Collections;

namespace BLL
{
    /// <summary>
    /// Pick list features
    /// </summary>
    public class PickList : _PickList
    {
        /// <summary>
        /// loads pick list by order id
        /// </summary>
        /// <param name="orderId">The order id.</param>
        public void LoadByOrderID(int orderId)
        {
            var query = HCMIS.Repository.Queries.PickList.SelectLoadByOrderID(orderId);
            this.LoadFromRawSql(query);
        }

        /// <summary>
        /// Saves issue order details
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="dvPickListMakeup"></param>
        public void SavePickList(int orderID, DataView dvPickListMakeup, int userID)
        {

            //~ Check if This Order has a previous Printed Picklist with detail: Note a header only doesnt affect us! //
            var pickList = new PickList();
            pickList.LoadByOrderID(orderID);
            if(pickList.RowCount>0)
            {
                var pldetail = new PickListDetail();
                pldetail.LoadByPickListID(pickList.ID);
                if (pldetail.RowCount > 0)
                {
                    RemoveFakePartialCommitPickListDetails(orderID);
                      var pickL = new PickList();
                    pickL.LoadByOrderID(orderID);
                    if (pickL.RowCount > 0)
                    {
                        throw new Exception("Picklist has already been printed for this Order ");
                        // This error has been apprearing for the last one year so funny! I hope it won't come again! day: 10/21/2014 @yido  //
                    }
                }
            }
            // Create a pick list entry
            Order ord = new Order();
            ord.LoadByPrimaryKey(orderID);
            PickList pl = new PickList();
            PalletLocation plocation = new PalletLocation();
            plocation.LoadByPrimaryKey(Convert.ToInt32(dvPickListMakeup[0]["PalletLocationID"]));
            pl.AddNew();
            pl.OrderID = orderID;
            pl.PickType = "Pick";
            pl.PickedBy = userID;

            pl.IsConfirmed = false;
            pl.IssuedDate = DateTimeHelper.ServerDateTime;
            pl.SavedDate = DateTimeHelper.ServerDateTime;
            pl.PickedDate = DateTimeHelper.ServerDateTime;
            pl.IsWarehouseConfirmed = 0;
            pl.WarehouseID = plocation.WarehouseID;
            pl.Save();
            PickListDetail pld = new PickListDetail();
            ReceivePallet rp = new ReceivePallet();
            ReceiveDoc rd = new ReceiveDoc();

            PickFace pf = new PickFace();

            foreach (DataRowView drv in dvPickListMakeup)
            {
                pld.AddNew();
                pld.PickListID = pl.ID;
                pld.OrderDetailID = Convert.ToInt32(drv["OrderDetailID"]);

                pld.ItemID = Convert.ToInt32(drv["ItemID"]);
                pld.BatchNumber = (drv["BatchNo"].ToString());
                if (drv["ExpDate"] != DBNull.Value)
                {
                    pld.ExpireDate = Convert.ToDateTime(drv["ExpDate"]);
                }
                pld.ManufacturerID = Convert.ToInt32(drv["ManufacturerID"]);
                pld.BoxLevel = Convert.ToInt32(drv["BoxLevel"]);
                pld.QtyPerPack = Convert.ToInt32(drv["QtyPerPack"]);
                pld.Packs = Convert.ToDecimal(drv["Pack"]);
                pld.PalletLocationID = Convert.ToInt32(drv["PalletLocationID"]);
                pld.QuantityInBU = Convert.ToDecimal(drv["QtyInBU"]);
                pld.ReceiveDocID = Convert.ToInt32(drv["ReceiveDocID"]);
                pld.ReceivePalletID = Convert.ToInt32(drv["ReceivePalletID"]);
                if (drv["CalculatedCost"] != DBNull.Value)
                    pld.Cost = Convert.ToDouble(drv["CalculatedCost"]);
                if (drv["UnitPrice"] != DBNull.Value)
                    pld.UnitPrice = Convert.ToDouble(drv["UnitPrice"]);
                int ReceivePalletID = Convert.ToInt32(drv["ReceivePalletID"]);
                rp.LoadByPrimaryKey(ReceivePalletID);
                pld.StoreID = Convert.ToInt32(drv["StoreID"]);

                if (drv["DeliveryNote"] != null)
                    pld.DeliveryNote = Convert.ToBoolean(drv["DeliveryNote"]);
                else
                    pld.DeliveryNote = false;


                if (rp.IsColumnNull("ReservedStock"))
                {
                    rp.ReservedStock = Convert.ToDecimal(pld.QuantityInBU);
                }
                else
                {
                    rp.ReservedStock += Convert.ToDecimal(pld.QuantityInBU);
                }
                if (drv["UnitID"] != DBNull.Value)
                {
                    pld.UnitID = Convert.ToInt32(drv["UnitID"]);
                }
                plocation.LoadByPrimaryKey(Convert.ToInt32(drv["PalletLocationID"]));
                pld.PhysicalStoreID = plocation.PhysicalStoreID;

                rp.Save();

                if (drv["StorageTypeID"].ToString() == StorageType.PickFace)
                {
                    pf.LoadByPalletLocation(Convert.ToInt32(drv["PalletLocationID"]));
                    //pf.Balance -= Convert.ToDecimal(pld.QuantityInBU);
                    pf.Save();
                }
            }

            pld.Save();
            ord.ChangeStatus(OrderStatus.Constant.PICK_LIST_GENERATED,CurrentContext.UserId);
            ord.Save();

        }

        /// <summary>
        /// This happes when there is plenty of transaction at the same time
        /// and will result a partial commit.
        /// This fake rows should be deleted from DB.
        /// </summary>
        /// <param name="orderID"></param>
        private void RemoveFakePartialCommitPickListDetails(int orderID)
        {
            var order = new Order();
            order.LoadByPrimaryKey(orderID);
            if (order.OrderStatusID == OrderStatus.Constant.ORDER_APPROVED)
            {
                var pickList = new PickList();
                pickList.LoadByOrderID(order.ID);
                if (pickList.RowCount == 0) //~ If there is no picklist, there is nothing to delete. ~//
                    return;

                var picklistDetail = new PickListDetail();
                picklistDetail.LoadByPickListID(pickList.ID);
                picklistDetail.Rewind();
                while (!picklistDetail.EOF)
                {
                    PickListDetailDeleted.AddNewLog(picklistDetail, CurrentContext.UserId);
                    picklistDetail.MarkAsDeleted();
                    picklistDetail.MoveNext();
                }

                picklistDetail.Save();
                pickList.MarkAsDeleted();
                pickList.Save();
            }
        }

        /// <summary>
        /// Undo pick list that has been printed
        /// </summary>
        /// <param name="orderID">The order ID.</param>
        public void CancelOrderWithPickList(int orderID)
        {
            // Create a pick list entry
            Order ord = new Order();
            PickList pl = new PickList();
            PickListDetail pld = new PickListDetail();
            ReceivePallet rp = new ReceivePallet();
            ReceiveDoc rd = new ReceiveDoc();
            PickFace pf = new PickFace();
            PalletLocation palletLocation = new PalletLocation();


            ord.LoadByPrimaryKey(orderID);
            pl.LoadByOrderID(orderID);

            pld.LoadByPickListID(pl.ID);

            while (!pld.EOF)
            {
                rp.LoadByPrimaryKey(pld.ReceivePalletID);
                rp.ReservedStock -= Convert.ToInt32(pld.QuantityInBU);
                if (rp.ReservedStock < 0)
                    rp.ReservedStock = 0; //If there has been no reservation, allow to cancel the picklist too.  No need for it to be blocked by the constraint.
                rp.Save();
                palletLocation.LoadByPrimaryKey(pld.PalletLocationID);
                if (palletLocation.StorageTypeID.ToString() == StorageType.PickFace)
                {
                    pf.LoadByPalletLocation(pld.PalletLocationID);
                    pf.Balance += Convert.ToInt32(pld.QuantityInBU);
                    pf.Save();
                }

                //Delete from picklistDetail and add to pickListDetailDeleted
                PickListDetailDeleted.AddNewLog(pld, BLL.CurrentContext.UserId);
                pld.MarkAsDeleted();
                pld.MoveNext();
            }
            pld.Save();
            ord.ChangeStatus(OrderStatus.Constant.CANCELED,CurrentContext.UserId);
       
            pl.MarkAsDeleted();
            pl.Save();
        }

        /// <summary>
        /// gets pick list detail for item (Used by the Invoice Printing page for one)
        /// </summary>
        /// <param name="ordID">The ord ID.</param>
        /// <returns></returns>
        public DataView GetPickListDetailsForOrder(int ordID)
        {
            this.LoadByOrderID(ordID);
            var query = HCMIS.Repository.Queries.PickList.SelectGetPickListDetailsForOrder(this.ID);
            this.LoadFromRawSql(query);
            // Add important columns
            this.DataTable.Columns.Add("SKUTOPICK", typeof(int));
            this.DataTable.Columns.Add("SKUPICKED", typeof(int));
            this.DataTable.Columns.Add("BUPICKED", typeof(int));
            this.DataTable.Columns.Add("BoxSizeDisplay");
            this.DataTable.Columns.Add("SKUBU", typeof(int));
            this.DataTable.Columns.Add("IsManufacturerLocal", typeof(bool));
            this.DataTable.Columns.Add("PrintedSTVNumber", typeof(string));
            this.DataTable.Columns.Add("PhysicalStoreName", typeof(string));
            this.DataTable.Columns.Add("PhysicalStoreTypeID", typeof(int));
            this.DataTable.Columns.Add("PhysicalStoreTypeName", typeof(string));

            int i = 1;
            while (!this.EOF)
            {
                int packs = Convert.ToInt32(this.GetColumn("Packs"));
                int manufacturer = Convert.ToInt32(this.GetColumn("ManufacturerID"));
                Manufacturer m = new Manufacturer();
                m.LoadByPrimaryKey(manufacturer);
                if (!m.IsColumnNull("CountryOfOrigin") && m.CountryOfOrigin.Contains("Ethiopia"))
                    this.SetColumn("IsManufacturerLocal", true);
                else
                    this.SetColumn("IsManufacturerLocal", false);

                int recPalletID = Convert.ToInt32(this.GetColumn("ReceivePalletID"));
                ReceivePallet rp = new ReceivePallet();
                rp.LoadByPrimaryKey(recPalletID);
                try
                {
                    this.SetColumn("PhysicalStoreName", rp.GetPhysicalStoreName());
                    int physicalStoreTypeID = rp.GetPhysicalStoreTypeID();
                    this.SetColumn("PhysicalStoreTypeID", physicalStoreTypeID);
                    Warehouse phyStoreType = new Warehouse();
                    phyStoreType.LoadByPrimaryKey(physicalStoreTypeID);
                    this.SetColumn("PhysicalStoreTypeName", phyStoreType.Name);

                }
                catch
                {

                }

                int itemId = Convert.ToInt32(this.GetColumn("ItemID"));
                int boxLevel = Convert.ToInt32(this.GetColumn("BoxLevel"));
                int qtyPerPack = this.Getint("QtyPerPack");
                //im.LoadIMbyLevel(itemId, manufacturer, boxLevel);
                this.SetColumn("SKUTOPICK", (packs));
                this.SetColumn("SKUPICKED", this.GetColumn("SKUTOPICK"));
                // TODO:show the box size here for Program store
                this.SetColumn("BoxSizeDisplay", "");
                this.SetColumn("SKUBU", qtyPerPack);
                this.SetColumn("BUPICKED", qtyPerPack * Convert.ToInt32(this.GetColumn("SKUPICKED")));
                this.SetColumn("LineNum", i++);
                if (this.IsColumnNull("DeliveryNote"))
                {
                    this.SetColumn("DeliveryNote", false);
                }
                this.MoveNext();
            }
            return this.DefaultView;
        }

        /// <summary>
        /// Gets the pick list details for order.
        /// </summary>
        /// <param name="ordID">The ord ID.</param>
        /// <param name="Preparedby">The preparedby.</param>
        /// <returns></returns>
        public DataView GetPickListDetailsForOrder(int ordID, string Preparedby)
        {
            this.LoadByOrderID(ordID);
            var query = HCMIS.Repository.Queries.PickList.SelectGetPickListDetailsForOrder(this.ID);
            this.LoadFromRawSql(query);
            // Add important columns
            this.DataTable.Columns.Add("SKUTOPICK", typeof(decimal));
            this.DataTable.Columns.Add("SKUPICKED", typeof(decimal));
            this.DataTable.Columns.Add("BUPICKED", typeof(decimal));
            this.DataTable.Columns.Add("BoxSizeDisplay");
            this.DataTable.Columns.Add("SKUBU", typeof(decimal));
            this.DataTable.Columns.Add("IsManufacturerLocal", typeof(bool));
            this.DataTable.Columns.Add("PrintedSTVNumber", typeof(string));
            this.DataTable.Columns.Add("PhysicalStoreName", typeof(string));
            this.DataTable.Columns.Add("PhysicalStoreTypeID", typeof(int));
            this.DataTable.Columns.Add("PhysicalStoreTypeName", typeof(string));
            this.DataTable.Columns.Add("PreparedBy", typeof(string));
            int i = 1;
            while (!this.EOF)
            {
                decimal packs = Convert.ToDecimal(this.GetColumn("Packs"));
               

                int manufacturer = Convert.ToInt32(this.GetColumn("ManufacturerID"));
                Manufacturer m = new Manufacturer();
                m.LoadByPrimaryKey(manufacturer);
                if (!m.IsColumnNull("CountryOfOrigin") && m.CountryOfOrigin.Contains("Ethiopia"))
                    this.SetColumn("IsManufacturerLocal", true);
                else
                    this.SetColumn("IsManufacturerLocal", false);

                int recPalletID = Convert.ToInt32(this.GetColumn("ReceivePalletID"));
                ReceivePallet rp = new ReceivePallet();
                rp.LoadByPrimaryKey(recPalletID);
                try
                {
                    ReceiveDoc receiveDoc = new ReceiveDoc();
                    Receipt receipt = new Receipt();
                    receiveDoc.LoadByPrimaryKey(rp.ReceiveID);
                    receipt.LoadByPrimaryKey(receiveDoc.ReceiptID);
                    this.SetColumn("PhysicalStoreName", rp.GetPhysicalStoreName());
                    int physicalStoreTypeID = rp.GetPhysicalStoreTypeID();
                    this.SetColumn("PhysicalStoreTypeID", physicalStoreTypeID);
                    Warehouse phyStoreType = new Warehouse();
                    phyStoreType.LoadByPrimaryKey(physicalStoreTypeID);
                    this.SetColumn("PhysicalStoreTypeName", phyStoreType.Name);
                    if (BLL.Settings.PrintUserNameOnInvoice)
                    { 
                        this.SetColumn("PreparedBy", Preparedby); 
                    }

                }
                catch
                {

                }

                int itemId = Convert.ToInt32(this.GetColumn("ItemID"));
                int boxLevel = Convert.ToInt32(this.GetColumn("BoxLevel"));
                decimal qtyPerPack = this.Getint("QtyPerPack");
                //im.LoadIMbyLevel(itemId, manufacturer, boxLevel);
                this.SetColumn("SKUTOPICK", (packs));
                this.SetColumn("SKUPICKED", this.GetColumn("SKUTOPICK"));
                // TODO:show the box size here for Program store
                this.SetColumn("BoxSizeDisplay", "");
                this.SetColumn("SKUBU", qtyPerPack);
                this.SetColumn("BUPICKED", qtyPerPack * Convert.ToDecimal(this.GetColumn("SKUPICKED")));
                this.SetColumn("LineNum", i++);
                if (this.IsColumnNull("DeliveryNote"))
                {
                    this.SetColumn("DeliveryNote", false);
                }
                this.MoveNext();
            }
            return this.DefaultView;
        }

        /// <summary>
        /// Gets picked order detail for item (Used by the IssueLog)
        /// </summary>
        /// <param name="ordID"></param>
        /// <param name="storeid"></param>
        /// <param name="pricedItems">True - For Priced Items Only, False - For Delivery Notes Only</param>
        /// <returns></returns>
        public DataView GetPickedOrderDetailForOrder(int stvLogID, bool includeDeleted)//,bool pricedItems)
        {
            string query;

            // remove this line ...
            // check if this has changed the dn to stv conversion
            // (pld.DeliveryNote is null or pld.DeliveryNote = 0 or (pld.DeliveryNote=1 and pld.UnitPrice<>0)) and
            query = HCMIS.Repository.Queries.PickList.SelectGetPickedOrderDetailForOrder(stvLogID);
            if (includeDeleted)
            {
                query = HCMIS.Repository.Queries.PickList.SelectGetPickedOrderDetailForOrderIncludeDeleted(stvLogID);
            }



            this.LoadFromRawSql(query);
            // Add important columns
            this.DataTable.Columns.Add("SKUTOPICK", typeof(int));
            this.DataTable.Columns.Add("SKUPICKED", typeof(int));
            this.DataTable.Columns.Add("BUPICKED", typeof(int));
            this.DataTable.Columns.Add("BoxSizeDisplay");
            this.DataTable.Columns.Add("SKUBU", typeof(int));
            this.DataTable.Columns.Add("IsManufacturerLocal", typeof(bool));
            this.DataTable.Columns.Add("PrintedSTVNumber", typeof(string));
            this.DataTable.Columns.Add("PhysicalStoreName", typeof(string));
            this.DataTable.Columns.Add("PhysicalStoreTypeID", typeof(int));
            this.DataTable.Columns.Add("PhysicalStoreTypeName", typeof(string));

            ItemManufacturer im = new ItemManufacturer();
            int i = 1;
            while (!this.EOF)
            {
                int packs = Convert.ToInt32(this.GetColumn("Packs"));
                int manufacturer = Convert.ToInt32(this.GetColumn("ManufacturerID"));
                Manufacturer m = new Manufacturer();
                m.LoadByPrimaryKey(manufacturer);
                if (!m.IsColumnNull("CountryOfOrigin") && m.CountryOfOrigin == "Ethiopia")
                    this.SetColumn("IsManufacturerLocal", true);
                else
                    this.SetColumn("IsManufacturerLocal", false);

                int recPalletID = Convert.ToInt32(this.GetColumn("ReceivePalletID"));
                ReceivePallet rp = new ReceivePallet();
                rp.LoadByPrimaryKey(recPalletID);
                try
                {
                    this.SetColumn("PhysicalStoreName", rp.GetPhysicalStoreName());
                    int physicalStoreTypeID = rp.GetPhysicalStoreTypeID();
                    this.SetColumn("PhysicalStoreTypeID", physicalStoreTypeID);
                    Warehouse phyStoreType = new Warehouse();
                    phyStoreType.LoadByPrimaryKey(physicalStoreTypeID);
                    this.SetColumn("PhysicalStoreTypeName", phyStoreType.Name);
                }
                catch
                {
                }

                int itemId = Convert.ToInt32(this.GetColumn("ItemID"));
                int boxLevel = Convert.ToInt32(this.GetColumn("BoxLevel"));
                int qtyPerPack = this.Getint("QtyPerPack");
                //im.LoadIMbyLevel(itemId, manufacturer, boxLevel);
                this.SetColumn("SKUTOPICK", (packs));
                this.SetColumn("SKUPICKED", this.GetColumn("SKUTOPICK"));
                // TODO:show the box size here for Program store
                this.SetColumn("BoxSizeDisplay", "");
                this.SetColumn("SKUBU", qtyPerPack);
                this.SetColumn("BUPICKED", qtyPerPack * Convert.ToInt32(this.GetColumn("SKUPICKED")));
                this.SetColumn("LineNum", i++);
                this.MoveNext();

            }
            return this.DefaultView;
        }


        /// <summary>
        /// List of pick lists for receiving unit
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="issuedTo"></param>
        /// <returns></returns>
        public DataTable GetDistinctPickList(int storeId, int issuedTo)
        {
            this.FlushData();
            var query = HCMIS.Repository.Queries.PickList.SelectGetDistinctPickList(storeId, issuedTo);
            this.LoadFromRawSql(query);
            return this.DataTable;
        }

        /// <summary>
        /// gets picklists under store
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public DataTable GetDistinctPickList(int storeId)
        {
            this.FlushData();
            this.LoadFromRawSql(HCMIS.Repository.Queries.PickList.SelectGetDistinctPickList(storeId));
            return this.DataTable;
        }

        /// <summary>
        /// Returns a table with Date and Wishlist amount entered on that date.
        /// </summary>
        /// <param name="days">For the past how many days (Enter -1 for all)</param>
        /// <returns></returns>
        public static object GetPickListSummary(int days)
        {
            string query;
            if (days == -1)
                query = HCMIS.Repository.Queries.PickList.SelectGetPickListSummary();
            else
                query = HCMIS.Repository.Queries.PickList.SelectGetPickListSummary(days);
            PickList pl = new PickList();
            pl.LoadFromRawSql(query);
            return pl.DefaultView;
        }


        /// <summary>
        /// Gets the picked items on STV.
        /// </summary>
        /// <param name="stvlogID">The stvlog ID.</param>
        /// <returns></returns>
        public static DataView GetPickedItemsOnSTV(int stvlogID, bool includeDeleted)
        {
            Issue stvLog = new Issue();
            stvLog.LoadByPrimaryKey(stvlogID);

            PickList pickList = new PickList();
            pickList.LoadByPrimaryKey(stvLog.PickListID);

            DataView dv = pickList.GetPickedOrderDetailForOrder(stvlogID, includeDeleted);
            dv.RowFilter = "STVID = " + stvlogID;
            return dv;
        }

        /// <summary>
        /// Gets the pick list detail with diagnostics.
        /// </summary>
        /// <param name="orderID">The order ID.</param>
        /// <param name="_itemID">The _item ID.</param>
        /// <param name="_unitID">The _unit ID.</param>
        /// <returns></returns>
        public DataTable GetPickListDetailWithDiagnostics(int orderID, int _itemID, int _unitID)
        {
            var query = HCMIS.Repository.Queries.PickList.SelectGetPickListDetailWithDiagnostics(orderID, _itemID, _unitID);
            this.LoadFromRawSql(query);
            return this.DataTable;
        }

        public static PickList GeneratePickList(int orderId)
        {
            PickList pklist = new PickList();
            pklist.AddNew();
            pklist.OrderID = orderId;
            pklist.PickType = "Pick";
            pklist.IssuedDate = DateTime.Today;
            pklist.IsConfirmed = true;
            pklist.SavedDate = DateTime.Today;
            pklist.IsWarehouseConfirmed = 0;
            pklist.Save();
            return pklist;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ordID"></param>
        /// <param name="returnToApproval">When false, the order is cancelled completely</param>
        /// <returns></returns>
        public static bool ReleaseReservation(int ordID, bool returnToApproval)
        {
            BLL.Order ord = new BLL.Order();
            ord.LoadByPrimaryKey(ordID);
            MyGeneration.dOOdads.TransactionMgr transaction = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
            try
            {
                transaction.BeginTransaction();
                if (ord.RowCount > 0 && (ord.OrderStatusID == OrderStatus.Constant.PICK_LIST_GENERATED || ord.OrderStatusID == OrderStatus.Constant.PICK_LIST_CONFIRMED))
                {
                    ord.ReleaseReservation();
                    if (returnToApproval)
                    {
                        ord.ChangeStatus(OrderStatus.Constant.ORDER_FILLED,CurrentContext.UserId);
                    }
                    else
                    {
                        ord.ChangeStatus(OrderStatus.Constant.CANCELED,CurrentContext.UserId);
                    }
                    ord.Save();
                }

                transaction.CommitTransaction();
                return true;
            }
            catch (Exception exp)
            {
                transaction.RollbackTransaction();
                throw (exp);
            }
        }

        public static void CancelExpiredPicklists()
        {
            var query = HCMIS.Repository.Queries.PickList.SelectCancelExpiredPicklists(BLL.Settings.NoOfDaysPicklistStaysAfterPrinting);
            var pickList = new BLL.PickList();
            pickList.LoadFromRawSql(query);

            while (!pickList.EOF)
            {
                ReleaseReservation(pickList.OrderID, true);
                pickList.MoveNext();
            }
        }

        public static int TotalExpiredPicklists()
        {
            var query = HCMIS.Repository.Queries.PickList.SelectTotalExpiredPicklists(BLL.Settings.NoOfDaysPicklistStaysAfterPrinting);
            var pickList = new BLL.PickList();
            pickList.LoadFromRawSql(query);

            return pickList.RowCount;
        }
    }
}
