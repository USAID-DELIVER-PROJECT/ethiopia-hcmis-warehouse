using System;
using System.Data;
using BLL.WorkFlow.Issue;
using DAL;
using System.ComponentModel;
using System.Collections.Generic;
using HCMIS.Core.Finance.CostTier;
using BLL.Models;

namespace BLL
{

    /// <summary>
    /// 
    /// </summary>
    public enum PriceSettings
    {
        DELIVERY_NOTE_ONLY = 0,
        PRICED_ONLY = 1,
        BOTH = 2 //Shouldn't be used.  It doesn't make sense to check for a single item in both priced and delivery note.
    }


    /// <summary>
    /// Order class encapsulates all logic concerned with Order processing
    /// This class generates Pick list,
    /// Also confirms pick lists to print out the issue.
    /// </summary>
    public class Order : _Order
    {



        ///<summary>
        /// Members that are used for the only purpose of generating the pick list.
        /// if any entry is in the replenishment list, it means that the order couldn't be fulfilled with out the replenishment of the 
        /// respective items.
        ///</summary>
        public DataTable _pickList;

        /// <summary>
        /// This table is not empty if there are items that need to be replenished after doing the pick list generation
        /// if this table is not null, the ui shouldn't display the save and print button.
        /// </summary>
        public DataTable _replenishmentList;



        /// <summary>
        /// Gets list of outstanding orders that are approved but those that don't have the Pick list generated
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <param name="modeID">The store type ID.</param>
        /// <returns></returns>
        public DataTable GetAllOutstandingOrders(int userID, int modeID)
        {
            FlushData();
            var query = HCMIS.Repository.Queries.Order.SelectGetAllOutstandingOrders(userID, modeID, OrderStatus.Constant.ORDER_FILLED);

            LoadFromRawSql(query);
            return DataTable;
        }


        /// <summary>
        /// Prepares the order detail table.
        /// </summary>
        /// <param name="ordDetail">The ord detail.</param>
        public static void PrepareOrderDetailTable(OrderDetail ordDetail)
        {
            ordDetail.AddColumn("AvailableQuantity", typeof(decimal));
            ordDetail.AddColumn("PricedQuantity", typeof(decimal));
            ordDetail.AddColumn("UsableStock", typeof(decimal));
            ordDetail.AddColumn("PApprovedStock", typeof(decimal));
            ordDetail.AddColumn("RequestedSKU", typeof(decimal));
            ordDetail.AddColumn("SKUBU", typeof(int));
            ordDetail.AddColumn("AvailableSKU", typeof(decimal));
            ordDetail.AddColumn("ApprovedSKU", typeof(decimal));
            ordDetail.AddColumn("Consumption", typeof(decimal));
            ordDetail.AddColumn("FacilityName", typeof(string));
            ordDetail.AddColumn("Region", typeof(string));
            ordDetail.AddColumn("Zone", typeof(string));
            ordDetail.AddColumn("Woreda", typeof(string));
            ordDetail.AddColumn("Warning", typeof(string));
            ordDetail.AddColumn("AvailableStores", typeof(object));
            ordDetail.AddColumn("HasStores", typeof(string));
            ordDetail.AddColumn("AvailableManufacturer", typeof(object));
            ordDetail.AddColumn("AvailableExpiry", typeof(object));
            ordDetail.AddColumn("HasExpiryChoice", typeof(string));
            ordDetail.AddColumn("HasManufacturers", typeof(string));
            ordDetail.AddColumn("AvailablePhysicalStore", typeof(object));
            ordDetail.AddColumn("HasPhysicalStoreChoice", typeof(string));
            ordDetail.AddColumn("ExpiryDateString", typeof(string));
            ordDetail.AddColumn("TextID", typeof(string));
            ordDetail.AddColumn("GIT", typeof (decimal));
            ordDetail.AddColumn("CRequested", typeof (decimal));
            ordDetail.AddColumn("CApproved", typeof(decimal));
            ordDetail.AddColumn("DOS", typeof(int));
            ordDetail.AddColumn("TotalIssued", typeof(decimal));
            ordDetail.AddColumn("FiscalYearDays", typeof(int));
            ordDetail.AddColumn("AMC", typeof(decimal));
            ordDetail.AddColumn("MOS", typeof(decimal));
            ordDetail.AddColumn("TotalRequested", typeof (decimal));

          
         try
            {
                ordDetail.AddColumn("Unit", typeof(string));
                ordDetail.AddColumn("FullItemName", typeof(string));
                ordDetail.AddColumn("StockCode", typeof(string));
                ordDetail.AddColumn("CategoryType", typeof(string));
            }
            catch
            {

            }
        }

        /// <summary>
        /// Determines whether [is order detail table ready] [the specified order detail].
        /// </summary>
        /// <param name="orderDetail">The order detail.</param>
        /// <returns>
        ///   <c>true</c> if [is order detail table ready] [the specified order detail]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsOrderDetailTableReady(OrderDetail orderDetail)
        {
            //We want to check if the required columns have been added.
            return (orderDetail.DefaultView.Table.Columns.IndexOf("AvailableQuantity") > 0);

        }

        /// <summary>
        /// Computes the stock calculations for an order detail.
        /// </summary>
        /// <param name="currentMonth">The current month.</param>
        /// <param name="currentYear">The current year.</param>
        /// <param name="userID">The user ID.</param>
        /// <param name="orderDetail">The order detail.</param>
        /// <returns></returns>
        public DataRow ComputeStockCalculationsForAnOrderDetail(int currentMonth, int currentYear, int userID, OrderDetail orderDetail)
        {
            if (!IsOrderDetailTableReady(orderDetail))
            {
                PrepareOrderDetailTable(orderDetail);
            }

            int? preferredManufacturer;
            int? preferredPhysicalStoreID;
            decimal usableStock;
            decimal approved;
            decimal availableQuantity;

            Balance bal = new Balance();
            ItemManufacturer imf = new ItemManufacturer();
            int? unitid = null;

            PriceSettings priceSettings = BLL.Settings.HandleDeliveryNotes ? PriceSettings.BOTH : PriceSettings.PRICED_ONLY;

            BLL.Order parentOrder = new Order();
            parentOrder.LoadByPrimaryKey(orderDetail.OrderID);

            unitid = orderDetail.UnitID;
            preferredManufacturer = orderDetail.IsColumnNull("PreferredManufacturerID") ? null : new int?(orderDetail.PreferredManufacturerID);
            preferredPhysicalStoreID = orderDetail.IsColumnNull("PreferredPhysicalStoreID") ? null : new int?(orderDetail.PreferredPhysicalStoreID);

            if (orderDetail.IsColumnNull("StoreID"))
            {
                orderDetail.StoreID = BLL.Activity.GetActivityUsingFEFO(this.FromStore, orderDetail.ItemID, orderDetail.UnitID);
                orderDetail.Save();
            }

            Activity storeObject = new Activity();
            availableQuantity = storeObject.LoadOptionsForOrderDetail(userID, orderDetail.ID, priceSettings, bal, false, out usableStock, out approved);
            orderDetail.SetColumn("AvailableStores", storeObject.DefaultView);
            if (storeObject.RowCount == 1)
            {

                orderDetail.StoreID = storeObject.ID;
                // Avoid error if the column IsDeliveryNote doesn't exsit at all.
                orderDetail.DeliveryNote = storeObject.DefaultView.Table.Columns.IndexOf("IsDeliveryNote") >= 0 &&
                                       !storeObject.IsColumnNull("IsDeliveryNote") &&
                                       Convert.ToBoolean(storeObject.GetColumn("IsDeliveryNote"));
                availableQuantity = Convert.ToDecimal(storeObject.GetColumn("AvailableSKU"));
            }
            else if (storeObject.RowCount > 1)
            {
                //TOCLEAN: Lord have mercy.
                // 
                // check if the default activity is selected
                // if it has been selected, then do a good job and select it.
                storeObject.Rewind();

                while (
                            !storeObject.EOF
                            &&
                           (
                               (
                                    storeObject.ID == orderDetail.StoreID
                                        && !orderDetail.IsColumnNull("DeliveryNote")
                                        && orderDetail.DeliveryNote
                                        && !Convert.ToBoolean(storeObject.GetColumn("IsDeliveryNote"))
                               )
                               ||
                               storeObject.ID != orderDetail.StoreID
                          )
                   )
                {
                    storeObject.MoveNext();
                }

                // the selected store is found, don't worry.
                if (!storeObject.EOF)
                {
                    availableQuantity = Convert.ToDecimal(storeObject.GetColumn("AvailableSKU"));
                }
                else
                {
                    // the selected store is not found, please do select the first store.
                    storeObject.Rewind();
                    orderDetail.StoreID = storeObject.ID;
                    orderDetail.DeliveryNote = (storeObject.DefaultView.Table.Columns.IndexOf("IsDeliveryNote") >= 0 &&
                                                !storeObject.IsColumnNull("IsDeliveryNote") &&
                                                Convert.ToBoolean(storeObject.GetColumn("IsDeliveryNote")));
                    availableQuantity = Convert.ToDecimal(storeObject.GetColumn("AvailableSKU"));
                }
            }
            orderDetail.SetColumn("HasStores", (storeObject.RowCount > 1) ? "*" : "");
            // Precaution ... to hide -ve available quantity.
            if (availableQuantity < 0)
            {
                availableQuantity = 0;
            }

            orderDetail.StockedOut = availableQuantity <= 0;
            orderDetail.Save();

            int qinBu = 1;
            if (unitid.HasValue)
            {
                ItemUnit itemUnit = new ItemUnit();
                itemUnit.LoadByPrimaryKey(unitid.Value);
                qinBu = itemUnit.QtyPerUnit;

                //Checking if the columns from the vwGetAllItems have been filled in.
                var fullItemName = orderDetail.GetColumn("FullItemName").ToString();
                if (string.IsNullOrEmpty(fullItemName))
                {
                    BLL.Order temp = new Order();
                    temp.LoadFromRawSql(HCMIS.Repository.Queries.Order.SelectItemDetail(orderDetail.ItemID));
                    orderDetail.SetColumn("Unit", itemUnit.Text);
                    orderDetail.SetColumn("FullItemName", temp.GetColumn("FullItemName"));
                    orderDetail.SetColumn("StockCode", temp.GetColumn("StockCode"));
                    orderDetail.SetColumn("CategoryType", temp.GetColumn("CategoryType"));
                }
            }

            orderDetail.SetColumn("AvailableQuantity", availableQuantity);
            orderDetail.SetColumn("PricedQuantity", usableStock);

            if (orderDetail.IsColumnNull("ApprovedQuantity"))
            {
                if ((orderDetail.Quantity / ((long)qinBu)) < availableQuantity)
                {
                    orderDetail.ApprovedQuantity = orderDetail.Quantity;
                }
                else
                {
                    orderDetail.ApprovedQuantity = availableQuantity * qinBu;
                }
            }

            if (BLL.Settings.AllowPreferredManufacturers)
            {
                Manufacturer manuf = new Manufacturer();
                manuf.LoadForItem(orderDetail.ItemID, orderDetail.StoreID, orderDetail.UnitID, true);
                manuf.AddNew();
                manuf.ID = -1;
                manuf.Name = "Remove Preference";
                orderDetail.SetColumn("AvailableManufacturer", manuf.DefaultView);
                orderDetail.SetColumn("HasManufacturers", (manuf.RowCount > 2) ? "*" : "");

                if (manuf.RowCount == 2)
                {
                    manuf.Rewind();
                    orderDetail.PreferredManufacturerID = manuf.ID;
                }
            }

            if (BLL.Settings.AllowPreferredPhysicalStore)
            {
                PhysicalStore phyStore = new PhysicalStore();
                phyStore.LoadForItem(userID, orderDetail.ItemID, orderDetail.StoreID, orderDetail.UnitID);
                phyStore.AddNew();
                phyStore.Name = "Remove Preference";
                phyStore.ID = -1;
                orderDetail.SetColumn("AvailablePhysicalStore", phyStore.DefaultView);
                orderDetail.SetColumn("HasPhysicalStoreChoice", (phyStore.RowCount > 2) ? "*" : "");

                if (phyStore.RowCount == 2)
                {
                    phyStore.Rewind();
                    orderDetail.PreferredPhysicalStoreID = phyStore.ID;
                }
            }

            if (BLL.Settings.AllowPreferredExpiry)
            {
                ReceiveDoc rd = new ReceiveDoc();
                rd.LoadExpiryDatesForItem(orderDetail.ItemID, orderDetail.StoreID, orderDetail.UnitID, true, preferredManufacturer, preferredPhysicalStoreID);
                rd.AddNew();
                rd.SetColumn("ExpiryDateString", "Remove Preference");
                orderDetail.SetColumn("AvailableExpiry", rd.DefaultView);
                orderDetail.SetColumn("HasExpiryChoice", (rd.RowCount > 2) ? "*" : "");
                if (!orderDetail.IsColumnNull("PreferredExpiryDate"))
                {
                    DateTime expDate = orderDetail.PreferredExpiryDate;
                    string expDateStr = string.Format("{0}-{1:00}-{2:00}", expDate.Year, expDate.Month, expDate.Day, "");
                    orderDetail.SetColumn("ExpiryDateString", expDateStr);
                }
            }
            // do some reseting if the approved quanitty is greater than 
            if (orderDetail.ApprovedQuantity / qinBu > availableQuantity)
            {
                orderDetail.ApprovedQuantity = availableQuantity * qinBu;
            }
            orderDetail.SetColumn("UsableStock", usableStock);
            orderDetail.SetColumn("PApprovedStock", approved);
            orderDetail.SetColumn("SKUBU", qinBu);
            orderDetail.SetColumn("AvailableSKU", availableQuantity);
            string TextID = ((orderDetail.IsColumnNull("DeliveryNote") || !orderDetail.DeliveryNote)
                                ? "N"
                                : "D") + orderDetail.StoreID.ToString();
            orderDetail.SetColumn("TextID", TextID);
            orderDetail.SetColumn("ApprovedSKU", orderDetail.ApprovedQuantity / Convert.ToDecimal(qinBu));
            orderDetail.SetColumn("RequestedSKU", orderDetail.Quantity / Convert.ToDecimal(qinBu));
            if (availableQuantity == 0)
            {
                orderDetail.SetColumnNull("TextID");
                orderDetail.SetColumnNull("StoreID");
              
            }
            Item itm = new Item();
            string warning = (itm.GetItemAllowStatus(orderDetail.ItemID, this.RequestedBy) == 0) ? "Warning" : "";
            orderDetail.SetColumn("Warning", warning);
            //if (!orderDetail.IsColumnNull("StoreID"))
            //{
                // var balance = new Balance();
                //balance.LoadQuantityNotReceive(orderDetail.ItemID, orderDetail.UnitID, parentOrder.FromStore);
                //var totalrequested =balance.GetTotalApprovedQuantityByItem(parentOrder.ID, orderDetail.ItemID, orderDetail.UnitID,parentOrder.FromStore);
                orderDetail.SetColumn("GIT", 0);
                orderDetail.SetColumn("CRequested",0);
                orderDetail.SetColumn("CApproved",0);
                //orderDetail.SetColumn("DOS", balance.DOS);
                //orderDetail.SetColumn("TotalIssued", balance.TotalIssued);
                //orderDetail.SetColumn("FiscalYearDays", balance.FiscalYearDays);

                //decimal amc = 0;
                //decimal mos = 0;

                //var totalissued = balance.TotalIssued;
                //var totaldatediff = balance.FiscalYearDays - balance.DOS;


                //if (totalissued != 0)
                //{
                //    amc = Convert.ToDecimal(totalissued / totaldatediff) * 30;
                //}

                //else if (amc == 0)
                //{
                //    mos = Convert.ToDecimal(balance.FiscalYearDays / 30.0);
                //}

                //else if (amc != 0 && availableQuantity != 0)
                //{
                //    mos = Convert.ToDecimal(availableQuantity / amc);
                //}

                //else if (availableQuantity == 0 && amc != 0)
                //{
                //    mos = 0;
                //}
                //else
                //{
                //    amc = 0;
                //    mos = 0;
                //}
                orderDetail.SetColumn("TotalRequested", 0);
                orderDetail.SetColumn("AMC", 0);
                orderDetail.SetColumn("MOS", 0);


            //}
            return orderDetail.DefaultView.ToTable().Rows[0];
        }

        public static void MakeStockCalculations(int userID, int currentMonth, int currentYear, PriceSettings unpricedOrPricedOrBoth, OrderDetail ordDetail, int storeID, int itemID, Order order, Balance bal, int? unitid, int? preferredManufacturer, DateTime? preferedExpiry, int? preferredPhysicalStoreID, out decimal usableStock, out decimal approved, out decimal availableQuantity, bool markStockoutBit)
        {
            bal.GetItemsAvailableForApproval(unpricedOrPricedOrBoth, currentMonth, currentYear, storeID, itemID, unitid, preferedExpiry, preferredManufacturer, preferredPhysicalStoreID, userID, out  usableStock, out  approved, out  availableQuantity);
        }

        /// <summary>
        /// Gets all approved orders
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public DataView GetAllApprovedOrders(int userID, int modeID)
        {
            var query = HCMIS.Repository.Queries.Order.SelectGetAllApprovedOrders(userID, modeID, BLL.OrderStatus.Constant.ORDER_APPROVED);
            LoadFromRawSql(query);
            return DefaultView;
        }


        /// <summary>
        /// Gets all approved orders in phyiscal store.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public DataView GetAllApprovedOrdersInPhyiscalStore(int userID)
        {
            var query = HCMIS.Repository.Queries.Order.SelectGetAllApprovedOrdersInPhyiscalStore(userID, BLL.OrderStatus.Constant.ORDER_APPROVED);
            LoadFromRawSql(query);
            return DefaultView;
        }

        /// <summary>
        /// Gets orders for which pick list was generated
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <param name="modeID">The mode ID.</param>
        /// <returns></returns>
        public DataView GetPickListedOrders(int userID, int modeID)
        {
            var query = HCMIS.Repository.Queries.Order.SelectGetPickListedOrders(userID, modeID, OrderStatus.Constant.PICK_LIST_CONFIRMED);
            LoadFromRawSql(query);
            return DefaultView;
        }


        /// <summary>
        /// Gets the undispatched issues.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <param name="mode">1-Invoicer Mode, 2-Store Mode, 3-Fund Mode, 4-Admin Mode</param>
        /// <returns></returns>
        public DataView GetUndispatchedIssues(int userID, int mode)
        {
            string additionalFilter = "";
            if (mode == 3)
                additionalFilter = " and VoidRequest=1 and VoidApprovedByUserID is null ";
            var query = HCMIS.Repository.Queries.Order.SelectGetUndispatchedIssues(userID, additionalFilter);
            LoadFromRawSql(query);


            return DefaultView;
        }

        public DataView GetUndispatchedIssuesBySTV(int userID, string stvNo)
        {
            string query = string.Format(@"select * from 
(select  s.ID as STVID
		                            , CASE When reprint.IDPrinted is null 
			                            then RIGHT('00000' + CAST (s.IDPrinted as nvarchar), 5) 
			                            else 'Re-'+ RIGHT('00000' + CAST (reprint.IDPrinted as nvarchar), 5) end as IDPrinted
		                            , acc.AccountName StoreName
		                            , s.VoidRequest
		                            , ru.Name as RequestedBy
                                    , s.VoidApprovalDateTime ConfirmedDate
                                    , s.VoidApprovedByUserID
                            from IssueDoc id 
	                            join STVLog s on id.STVID=s.ID 
	                            join vwAccounts acc on s.StoreID = acc.ActivityID
                                join Institution ru on id.ReceivingUnitID = ru.ID 
	                            left Join(select IsReprintOf ID,Max(IDPRinted) IDPrinted from stvLog where isReprintof is not null Group by IsReprintOf) reprint on reprint.ID = s.ID
                             where id.InventoryPeriodID in (Select CurrentInventoryPeriodID from UserPhysicalStore ups join physicalStore ps on ps.ID = ups.PhysicalStoreID  where UserID={0} and CanAccess=1)  
		                            and (id.DispatchConfirmed is null or id.DispatchConfirmed=0) 
                            Group by s.ID,s.VoidApprovalDateTime, s.VoidApprovedByUserID,acc.AccountName ,s.voidRequest,ru.Name,s.IDPrinted,reprint.IDPrinted 
							) main
							where main.IDPrinted like '%{1}%'
							order by main.STVID", userID, stvNo);
            LoadFromRawSql(query);
            return DefaultView;
        }
        public DataView GetUndispatchedIssues(int userID, int mode, int ActivityID, DateTime datefrom, DateTime dateto)
        {
            string additionalFilter = "";
            if (mode == 3)
                additionalFilter = " and VoidRequest=1 and VoidApprovedByUserID is null ";
            string query =
                String.Format(@"select  s.ID as STVID
		                            , CASE When reprint.IDPrinted is null 
			                            then RIGHT('00000' + CAST (s.IDPrinted as nvarchar), 5) 
			                            else 'Re-'+ RIGHT('00000' + CAST (reprint.IDPrinted as nvarchar), 5) end as IDPrinted
		                            , acc.AccountName StoreName
		                            , s.VoidRequest
		                            , CASE WHEN ru.ID IS NULL THEN 'Transfer' ELSE ru.Name END as RequestedBy
			                        , IsNull(os.OrderStatus, '-') OrderStatus
			                        , IsNull(ot.Name, '-') OrderType
									, s.VoidRequestDateTime
									, vu.FullName VoidRequestedBy
                                    ,s.VoidApprovalDateTime
                                    ,s.VoidApprovedByUserID
                            from IssueDoc id 
	                        join STVLog s on id.STVID=s.ID 
		                    left join [Order] o on id.OrderID = o.ID
		                    left join OrderStatus os on o.OrderStatusID = os.ID
		                    left join OrderType ot on o.OrderTypeID = ot.OrderTypeID
	                        join vwAccounts acc on s.StoreID = acc.ActivityID
                            left join Institution ru on id.ReceivingUnitID = ru.ID 
							left join [User] vu on vu.ID = s.VoidRequestUserID 
	                        left Join(select IsReprintOf ID,Max(IDPRinted) IDPrinted from stvLog where isReprintof is not null Group by IsReprintOf) reprint on reprint.ID = s.ID
                            where id.InventoryPeriodID in (Select CurrentInventoryPeriodID from UserPhysicalStore ups join physicalStore ps on ps.ID = ups.PhysicalStoreID  where UserID={0} and CanAccess=1)  
		                        and (id.DispatchConfirmed is null or id.DispatchConfirmed=0) 
		                        and s.StoreID = {2} and  Cast(id.EurDate as Date) >= '{3}' and Cast(id.EurDate as Date) <= '{4}'
                                    Group by s.ID,ru.ID,s.VoidApprovedByUserID,s.VoidApprovalDateTime,acc.AccountName ,s.voidRequest,ru.Name,s.IDPrinted,reprint.IDPrinted , os.orderstatus, ot.name, vu.FullName, s.VoidRequestDateTime
                                {1}
                                    order by s.ID desc", userID, additionalFilter, ActivityID, datefrom, dateto);
            LoadFromRawSql(query);


            return DefaultView;
        }



        /// <summary>
        /// Gets orders for which pick list was generated
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public DataView GetUnconfirmedPickLists(int userID, int modeID)//, int storeID)
        {
            var query = HCMIS.Repository.Queries.Order.SelectGetUnconfirmedPickLists(userID, modeID, BLL.OrderStatus.Constant.PICK_LIST_GENERATED);
            LoadFromRawSql(query);
            return DefaultView;
        }


        /// <summary>
        /// Adds to pick list for an order detail.
        /// </summary>
        /// <param name="orderDetailID">The order detail ID.</param>
        /// <param name="itemId">The item id.</param>
        /// <param name="unitID">The unit ID.</param>
        /// <param name="initalApprovedQuantity">The inital approved quantity.</param>
        /// <param name="storeID">The store ID.</param>
        /// <param name="preferedManufacturer">The prefered manufacturer.</param>
        /// <param name="preferredPhysicalStore">The preferred physical store.</param>
        /// <param name="isDeliveryNote">if set to <c>true</c> [is delivery note].</param>
        /// <param name="preferredExpiry">The preferred expiry.</param>
        /// <exception cref="System.Exception"></exception>
        private void AddToPickListFor(int userID, int orderDetailID, int itemId, int? unitID, decimal initalApprovedQuantity, int storeID, int preferedManufacturer, int preferredPhysicalStore, bool isDeliveryNote, DateTime? preferredExpiry)
        {
            bool deliveryNoteWarning = false;

            if (isDeliveryNote && !BLL.Settings.HandleDeliveryNotes)
            {
                //If the request is for delivery notes but the delivery notes haven't been enabled, then let's change the delivery note bit but also set a warning bit so that we can report it to the user if there are no priced items available. (i.e. In case the picklist comes out empty, we report an error)
                deliveryNoteWarning = true;
                isDeliveryNote = false;
            }

            decimal approvedQuantity = initalApprovedQuantity;

            bool belowBoxPickedFromRack = false;
            //if (preferedManufacturer == -1)
            //{
            var rp = new ReceivePallet();
            var palletLoc = new PalletLocation();
            var im = new ItemManufacturer();

            var pf = new PickFace();
            int buinsku = 0;

            // no manufacturer is preferred so just do the pick list
            // select items that have balance, with sales price and that do have 
            rp.LoadNonPickFaceAllItemsReadyToDispatch(userID, itemId, unitID, storeID, preferedManufacturer,
                                                      preferredPhysicalStore, isDeliveryNote, preferredExpiry);

            //If the delivery note warning bit has been set and there are no priced items in the databasee, 
            //let's throw an error to the users so that they know the cause of the problem.
            //The solution is to either not choose delivery notes or on the approval stage or enable delivery notes in the settings.
            if (rp.RowCount == 0 && deliveryNoteWarning)
            {
                throw new Exception("Delivery Notes Preference has been set but delivery notes are not enabled for this database.");
            }

            // get how much of it is on the pick face
            //TOFIX: this doesn't have to rely on the quantity on the pick face
            pf.LoadPickFaceFor(itemId, storeID);

            // Just to be safe
            rp.Rewind();
            if (rp.RowCount == 0)
            {
                // this means there is no item to issue other than on the pick face
                // try issuing from the pick face
                LoadFromPickFace(itemId, unitID, approvedQuantity, storeID, isDeliveryNote);
                return;
            }
            while (!rp.EOF)
            {
                // get the current manufacturer
                int manufId = Convert.ToInt32(rp.GetColumn("ManufacturerID"));
                // what is the dispatch able quantity in the current record?
                decimal dispatchableQuantity = Convert.ToDecimal(rp.GetColumn("DispatchableStock"));
                palletLoc.loadByPalletID(rp.PalletID);


                // check if the item is from the rack or the low quantity storage place.
                // if it is from the rack, make sure the packs column counts in cartons
                // if it is not, count in number of packs/SKU or Level 0 only
                if (palletLoc.RowCount > 0 && palletLoc.StorageTypeID.ToString() == StorageType.StackedStorage)
                {
                    im.LoadIMbyLevel(itemId, manufId, 0);
                }
                else if ((palletLoc.RowCount > 0 && palletLoc.StorageTypeID.ToString() != StorageType.BulkStore) ||
                         (pf.RowCount == 0 && palletLoc.StorageTypeID.ToString() == StorageType.BulkStore))
                {
                    im.LoadIMbyLevel(itemId, manufId, 0);
                }
                else
                {
                    im.LoadIMbyLevel(itemId, manufId, Convert.ToInt32(rp.GetColumn("BoxLevel")));
                }
                // just incase there are open cartons on the rack, handle them here.
                if (im.RowCount > 0 && (im.QuantityInBasicUnit > dispatchableQuantity && im.PackageLevel > 0))
                {
                    im.LoadIMbyLevel(itemId, manufId, 0);
                }
                // hold what level we are about to issue, 
                // which level of carton and the basic unit in that carton.

                int bUsinBoxLevel;
                buinsku = Convert.ToInt32(rp.GetColumn("QtyPerPack"));// imff.LoadSKUUnit(im.ItemID, im.ManufacturerID);
                if (unitID != null)
                {
                    ItemUnit iu = new ItemUnit();
                    iu.LoadByPrimaryKey(unitID.Value);
                    bUsinBoxLevel = iu.QtyPerUnit;

                    if (buinsku != bUsinBoxLevel)
                    {
                        // This defintely is an error,
                        //TODO: do something about it ;)
                        buinsku = bUsinBoxLevel;
                    }
                }
                else
                {
                    bUsinBoxLevel = im.QuantityInBasicUnit;
                }

                // get the maximum amount of item that can be fulfilled under the current box level
                decimal dispatch = (approvedQuantity / bUsinBoxLevel) * bUsinBoxLevel;
                if (dispatch > dispatchableQuantity)
                {
                    // if the dispatch able quantity is less than what is requested, 
                    // only give what we have.
                    dispatch = dispatchableQuantity;
                }
                else if (dispatch == 0)
                {
                    break;
                }

                if (dispatchableQuantity > approvedQuantity)
                {
                    // check if the dispatch is possible with existing pick face items

                    decimal remaining = approvedQuantity - dispatch;
                    // TODO: Explain WTF all this condition is
                    // I assume at this point that it is checking if the remaining amount should be fulfilled from the pick face or not
                    //
                    if (((pf.RowCount == 0 || pf.IsColumnNull("Balance")) && remaining == 0) ||
                        ((pf.RowCount > 0 && !pf.IsColumnNull("Balance") && pf.Balance >= remaining)))
                    {
                        // do this if we should go to the pick face for any reason.
                        if (dispatch > 0)
                        {
                            // do the pick list entries here
                            _pickList.ImportRow(rp.CurrentDataRow);
                            // pick the currently inserted entry and adjust all the numbers in it.
                            DataRow dr = _pickList.Rows[_pickList.Rows.Count - 1];
                            dr["OrderDetailID"] = orderDetailID;
                            // only Adjust the entries that matter to the pick list
                            SetPriceAndQuantity(dr, dispatch, buinsku, rp, itemId, isDeliveryNote);
                            approvedQuantity -= dispatch;
                            // add the items from the pick face
                        }
                        //TODO: implement the pick face logic here.
                        LoadFromPickFace(itemId, unitID, approvedQuantity, storeID, isDeliveryNote);
                        return;
                    }
                    else
                    {
                        // do the bulk pick list and  entries here
                        if (dispatch > 0)
                        {
                            _pickList.ImportRow(rp.CurrentDataRow);
                            // pick the currently inserted entry and adjust all the numbers in it.
                            DataRow dr = _pickList.Rows[_pickList.Rows.Count - 1];
                            dr["OrderDetailID"] = orderDetailID;

                            // only Adjust the entries that matter to the pick list
                            SetPriceAndQuantity(dr, dispatch, buinsku, rp, itemId, isDeliveryNote);
                            approvedQuantity -= dispatch;
                            // the order couldn't be done at this time because the pickface has to be reprenished,
                            // Mark the ReplenishmentList and continue with the other pick list items.
                            // return this message to the user and continue to the next level
                            // do the pick list entries here
                        }
                    }
                }
                else
                // if we are here, it means that the dispatch able quantity is equal to  what we have or greater than the request
                {
                    // dispatch the existing quantity and continue with the other entries in the receive pallet
                    _pickList.ImportRow(rp.CurrentDataRow);
                    // pick the currently inserted entry and adjust all the numbers in it.
                    DataRow dr = _pickList.Rows[_pickList.Rows.Count - 1];
                    dr["OrderDetailID"] = orderDetailID;
                    // only Adjust the entries that matter to the pick list
                    SetPriceAndQuantity(dr, dispatch, buinsku, rp, itemId, isDeliveryNote);
                    approvedQuantity -= dispatch;
                    belowBoxPickedFromRack = true;
                }
                rp.MoveNext();
            }

            if (!belowBoxPickedFromRack && approvedQuantity > 0)
            {
                LoadFromPickFace(itemId, unitID, approvedQuantity, storeID, isDeliveryNote);
            }

            if (approvedQuantity > buinsku && approvedQuantity > 0 &&
                ((pf.RowCount == 0 || pf.IsColumnNull("Balance")) || (approvedQuantity > pf.Balance)))
            {
                //TODO: if this was the last entry in the rp pallet, then it means that the pick face needs to be replenished,\
                // Implement that logic here.

                // this means the pick face has been setup.
                DataRowView drv = _replenishmentList.DefaultView.AddNew();
                drv["ItemID"] = itemId;
                drv["StoreID"] = storeID;
                drv.EndEdit();
            }

        }


        private void SetPriceAndQuantity(DataRow dr, decimal dispatch, int buinsku, ReceivePallet rp, int itemId, bool isDeliveryNote)
        {
            dr["DeliveryNote"] = isDeliveryNote;
            dr["BoxLevel"] = 0;
            dr["QtyPerPack"] = buinsku;
            dr["Pack"] = dispatch / buinsku;
            decimal packs = dispatch / buinsku;
            dr["QtyInBU"] = dispatch;
            dr["approvedQuantity"] = dispatch;

            if (isDeliveryNote)// (!Settings.UsesMovingAverage)  //We are taking care of this at the receive page.  Therefore, the selling price would have been set when entering here so for now, I'm disabling this condition
            {
                dr["CalculatedCost"] = 0;
                dr["UnitPrice"] = 0;
            }
            else
            {
                // Apply the cost and selling price from the cost tier.
                if (BLL.Settings.UseCostTier)
                {
                    HCMIS.Specification.Finance.CostTier.ILedger ledgerService = new LedgerService();
                    var ledgerObject = ledgerService.GetLedger(Convert.ToInt32(dr["ItemID"]),
                                                               Convert.ToInt32(dr["UnitID"]),
                                                               Convert.ToInt32(dr["ManufacturerID"]),
                                                               MovingAverageGroup.Convert(Convert.ToInt32(dr["StoreID"]))
                                                               );
                    if (BLL.Settings.IsCenter)
                    {
                        dr["CalculatedCost"] =
                            Math.Round(Convert.ToDouble(ledgerObject.UnitCost)*Convert.ToDouble(packs),
                                       BLL.Settings.NoOfDigitsAfterTheDecimalPoint, MidpointRounding.AwayFromZero);
                        dr["UnitPrice"] = Math.Round(ledgerObject.UnitCost,
                                                     BLL.Settings.NoOfDigitsAfterTheDecimalPoint,
                                                     MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        dr["CalculatedCost"] =
                           Math.Round(Convert.ToDouble(ledgerObject.SellingPrice) * Convert.ToDouble(packs),
                                      BLL.Settings.NoOfDigitsAfterTheDecimalPoint, MidpointRounding.AwayFromZero);
                        dr["UnitPrice"] = Math.Round(ledgerObject.SellingPrice,
                                                     BLL.Settings.NoOfDigitsAfterTheDecimalPoint,
                                                     MidpointRounding.AwayFromZero);
                  
                    }
                }
                else
                {
                    try
                    {
                        //
                        if (BLL.Settings.IsCenter)
                        {
                            //TOFIXXX when selling price is null, it shouldn't be coming here
                            dr["CalculatedCost"] = Convert.ToDouble(packs) * Math.Round(Convert.ToDouble(rp.GetColumn("Cost")), BLL.Settings.NoOfDigitsAfterTheDecimalPoint, MidpointRounding.AwayFromZero);
                            double sPrice = Math.Round(Convert.ToDouble(rp.GetColumn("Cost")), BLL.Settings.NoOfDigitsAfterTheDecimalPoint, MidpointRounding.AwayFromZero);
                            dr["UnitPrice"] = sPrice;
                        }
                        else
                        {
                            //TOFIXXX when selling price is null, it shouldn't be coming here
                            dr["CalculatedCost"] = Convert.ToDouble(packs) * Math.Round(Convert.ToDouble(rp.GetColumn("SellingPrice")), BLL.Settings.NoOfDigitsAfterTheDecimalPoint, MidpointRounding.AwayFromZero);
                            double sPrice = Math.Round(Convert.ToDouble(rp.GetColumn("SellingPrice")), BLL.Settings.NoOfDigitsAfterTheDecimalPoint, MidpointRounding.AwayFromZero);
                            dr["UnitPrice"] = sPrice;
                        }


                    }
                    catch
                    {
                        BLL.Item itm = new Item();
                        itm.LoadByPrimaryKey(itemId);
                        //throw new Exception(string.Format("Selling price not set for {0}", itm.FullItemName));
                    }
                }

            }

            dr["UnitsInSKU"] = buinsku;
        }

        /// <summary>
        /// Loads the pick list from the pick face location
        /// this is only called if a pick face location is set for the item
        /// </summary>
        /// <param name="itemId">The item id.</param>
        /// <param name="unitID">The unit ID.</param>
        /// <param name="innitallyApprovedQuantity">The innitally approved quantity.</param>
        /// <param name="fromstore">The fromstore.</param>
        /// <param name="isDeliveryNote">if set to <c>true</c> [is delivery note].</param>
        private void LoadFromPickFace(int itemId, int? unitID, decimal innitallyApprovedQuantity, int fromstore, bool isDeliveryNote)
        {
            decimal approvedQuantity = innitallyApprovedQuantity;
            var pf = new PickFace();
            pf.LoadPickFaceFor(itemId, fromstore);
            if (pf.RowCount > 0)
            {
                var rp = new ReceivePallet();
                rp.LoadPickFaceAllItemsReadyToDispatch(itemId, unitID, fromstore);
                var im = new ItemManufacturer();
                var imff = new ItemManufacturer();
                if (pf.IsColumnNull("Balance"))
                {
                    pf.Balance = 0;
                    pf.Save();
                }
                if (pf.Balance >= approvedQuantity)
                {
                    while (!rp.EOF)
                    {
                        int manufId = Convert.ToInt32(rp.GetColumn("ManufacturerID"));
                        im.LoadIMbyLevel(itemId, manufId, Convert.ToInt32(rp.GetColumn("BoxLevel")));
                        int boxLevel = im.PackageLevel;
                        int buinsku = Convert.ToInt32(rp.GetColumn("QtyPerPack"));//imff.LoadSKUUnit(itemId, manufId);
                        while (boxLevel >= 0 && approvedQuantity > 0)
                        {
                            long dispatchQuantity = Convert.ToInt32(rp.GetColumn("DispatchableStock"));
                            int bUsinBoxLevel = im.QuantityInBasicUnit;
                            decimal dispatch = (approvedQuantity / bUsinBoxLevel) * bUsinBoxLevel;
                            if (dispatch > dispatchQuantity)
                            {
                                dispatch = dispatchQuantity;
                            }
                            while (dispatch / bUsinBoxLevel < 1 && im.PackageLevel > 0)
                            {
                                im.LoadIMbyLevel(im.ItemID, im.ManufacturerID, im.PackageLevel - 1);
                                bUsinBoxLevel = im.QuantityInBasicUnit;
                            }
                            if (dispatch > 0)
                            {
                                _pickList.ImportRow(rp.CurrentDataRow);
                                // pick the currently inserted entry and adjust all the numbers in it.
                                DataRow dr = _pickList.Rows[_pickList.Rows.Count - 1];

                                // only Adjust the entries that matter to the pick list
                                SetPriceAndQuantity(dr, dispatch, buinsku, rp, itemId, isDeliveryNote);
                                approvedQuantity -= dispatch;
                            }
                            boxLevel--;
                            im.LoadIMbyLevel(itemId, manufId, boxLevel);
                        }
                        rp.MoveNext();
                    }
                }
            }
        }

        /// <summary>
        /// Generate the pick list
        /// </summary>
        /// <param name="orderId">The order id.</param>
        /// <param name="bgWorker">The bg worker.</param>
        /// <returns></returns>
        public DataView GetPalletLocationChoice(int userID, int orderId, BackgroundWorker bgWorker)
        {
            var order = new Order();
            // Load the order

            order.LoadByPrimaryKey(orderId);
            //TODO: check if the order is already approved or not.
            // if not please return from here
            // Load the order details
            var orderDetail = new OrderDetail();
            orderDetail.LoadAllByOrderID(orderId);
            orderDetail.AddColumn("ActivityConcat", typeof(string));
            // prepare the pick list data table with the proper fields
            _pickList = GetPickListTable();
            _replenishmentList = new DataTable();
            _replenishmentList.Columns.Add("ItemID", typeof(int));
            _replenishmentList.Columns.Add("StoreID", typeof(int));

            int count = 0;

            // iterate through the order detail and make the pick list
            while (!orderDetail.EOF)
            {
                DateTime startTime = DateTime.Now;
                System.Console.WriteLine("Processing - " + orderDetail.ItemID);
                // check if there are enough priced items of the same or more quantity in the store
                int? unitID = null;
                if (!orderDetail.IsColumnNull("UnitID"))
                {
                    unitID = orderDetail.UnitID;
                }

                if (!orderDetail.IsColumnNull("StockedOut") && (!orderDetail.StockedOut ||(orderDetail.ApprovedQuantity > 0 && orderDetail.Quantity > orderDetail.ApprovedQuantity)))
                {
                    DateTime? preferredExpiry = new DateTime();

                    if (orderDetail.IsColumnNull("PreferredManufacturerID"))
                        orderDetail.PreferredManufacturerID = -1;

                    if (orderDetail.IsColumnNull("PreferredPhysicalStoreID"))
                        orderDetail.PreferredPhysicalStoreID = -1;

                    if (orderDetail.IsColumnNull("PreferredExpiryDate"))
                        preferredExpiry = null;
                    else
                    {
                        preferredExpiry = orderDetail.PreferredExpiryDate;
                    }
                    if (!orderDetail.IsColumnNull("ApprovedQuantity") && (orderDetail.ApprovedQuantity > 0 && !orderDetail.IsColumnNull("StoreID")))
                    {
                        AddToPickListFor(userID, orderDetail.ID, orderDetail.ItemID, unitID, orderDetail.ApprovedQuantity, orderDetail.StoreID,
                                         orderDetail.PreferredManufacturerID, orderDetail.PreferredPhysicalStoreID,
                                         !orderDetail.IsColumnNull("DeliveryNote") && orderDetail.DeliveryNote,
                                         preferredExpiry);
                    }


                }
                System.Console.WriteLine(string.Format("Took - {0}:{1} for Item ID = {2}", DateTime.Now.Subtract(startTime).Minutes, DateTime.Now.Subtract(startTime).Seconds, orderDetail.ItemID));
                orderDetail.MoveNext();
                count++;
                bgWorker.ReportProgress(count, null);
            }

            // A quick hack just to show the pallet location on the order form

            var pl = new PalletLocation();
            var im = new ItemManufacturer();
            foreach (DataRowView drv in _pickList.DefaultView)
            {
                int plid = Convert.ToInt32(drv["PalletLocationID"]);
                pl.LoadByPrimaryKey(plid);
                drv["PalletLocation"] = pl.FullName;
                im.LoadIMbyLevel(Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ManufacturerID"]),
                                 Convert.ToInt32(drv["BoxLevel"]));
                drv["QtyInSKU"] = im.RowCount > 0
                                     ? Convert.ToDecimal(drv["Pack"]) * im.QuantityInSku
                                     : Convert.ToDecimal(drv["Pack"]);
                drv["BoxSizeDisplay"] = im.RowCount > 0 ? im.LevelView2 : ""; //im.RightName;
                drv["WarehouseName"] = pl.WarehouseName;
                drv["PhysicalStoreName"] = pl.PhysicalStoreName;
                var activity = new Activity();
                activity.LoadByPrimaryKey(Convert.ToInt32(drv["StoreID"]));
                drv["ActivityConcat"] = activity.FullActivityName;
                drv["AccountName"] = activity.AccountName;
            }

            //foreach (DataRowView v in _pickList.DefaultView)
            //{

            //}

            return _pickList.DefaultView;
        }


        /// <summary>
        /// Generate the pick list
        /// </summary>
        /// <param name="orderId">The order id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="bgWorker">The bg worker.</param>
        /// <returns></returns>
        public DataView GetBatchConfirmationChoice(int orderId, int userId, BackgroundWorker bgWorker)
        {
            var order = new Order();
            // Load the order

            order.LoadByPrimaryKey(orderId);
            //TODO: check if the order is already approved or not.
            // if not please return from here
            // Load the order details
            var orderDetail = new OrderDetail();
            //orderDetail.LoadAllByOrderID(orderId);
            orderDetail.LoadForBatchConfirmation(orderId, userId);

            orderDetail.AddColumn("ActivityConcat", typeof(string));
            // prepare the pick list data table with the proper fields
            _pickList = GetPickListTable();
            _replenishmentList = new DataTable();
            _replenishmentList.Columns.Add("ItemID", typeof(int));
            _replenishmentList.Columns.Add("StoreID", typeof(int));

            int count = 0;

            // iterate through the order detail and make the pick list
            while (!orderDetail.EOF)
            {
                // check if there are enough priced items of the same or more quantity in the store
                int? unitID = null;
                if (!orderDetail.IsColumnNull("UnitID"))
                {
                    unitID = orderDetail.UnitID;
                }

                if (!orderDetail.IsColumnNull("StockedOut") && !orderDetail.StockedOut)
                {
                    DateTime? preferredExpiry = new DateTime();

                    if (orderDetail.IsColumnNull("PreferredManufacturerID"))
                        orderDetail.PreferredManufacturerID = -1;

                    if (orderDetail.IsColumnNull("PreferredPhysicalStoreID"))
                        orderDetail.PreferredPhysicalStoreID = -1;

                    if (orderDetail.IsColumnNull("PreferredExpiryDate"))
                        preferredExpiry = null;
                    else
                    {
                        preferredExpiry = orderDetail.PreferredExpiryDate;
                    }
                    if (!orderDetail.IsColumnNull("ApprovedQuantity"))
                    {
                        AddToPickListFor(userId, orderDetail.ID, orderDetail.ItemID, unitID, orderDetail.ApprovedQuantity, orderDetail.StoreID,
                                         orderDetail.PreferredManufacturerID, orderDetail.PreferredPhysicalStoreID,
                                         !orderDetail.IsColumnNull("DeliveryNote") && orderDetail.DeliveryNote,
                                         preferredExpiry);
                    }


                }

                orderDetail.MoveNext();
                count++;
                bgWorker.ReportProgress(count, null);
            }

            // A quick hack just to show the pallet location on the order form

            var pl = new PalletLocation();
            var im = new ItemManufacturer();
            foreach (DataRowView drv in _pickList.DefaultView)
            {
                int plid = Convert.ToInt32(drv["PalletLocationID"]);
                pl.LoadByPrimaryKey(plid);
                drv["PalletLocation"] = pl.FullName;
                im.LoadIMbyLevel(Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ManufacturerID"]),
                                 Convert.ToInt32(drv["BoxLevel"]));
                drv["QtyInSKU"] = im.RowCount > 0
                                     ? Convert.ToInt32(drv["Pack"]) * im.QuantityInSku
                                     : Convert.ToInt32(drv["Pack"]);
                drv["BoxSizeDisplay"] = im.RowCount > 0 ? im.LevelView2 : ""; //im.RightName;
                drv["WarehouseName"] = pl.WarehouseName;
                drv["PhysicalStoreName"] = pl.PhysicalStoreName;
                var activity = new Activity();
                activity.LoadByPrimaryKey(Convert.ToInt32(drv["StoreID"]));
                
                drv["ActivityConcat"] = activity.FullActivityName;
                drv["AccountName"] = activity.AccountName;
            }

            //foreach (DataRowView v in _pickList.DefaultView)
            //{

            //}

            return _pickList.DefaultView;
        }


        /// <summary>
        /// Prepare the Pick list DataTable which we work on Algorithmically
        /// </summary>
        /// <returns></returns>
        private static DataTable GetPickListTable()
        {
            var dtbl = new DataTable();
            dtbl.Columns.Add("OrderDetailID", typeof(int));
            dtbl.Columns.Add("LineNum", typeof(int));
            dtbl.Columns.Add("ItemID", typeof(int));
            dtbl.Columns.Add("Unit", typeof(string));
            dtbl.Columns.Add("UnitID", typeof(int));
            dtbl.Columns.Add("StoreID", typeof(int));

            dtbl.Columns.Add("StockCode");
            dtbl.Columns.Add("ActivityConcat");
            dtbl.Columns.Add("ManufacturerID", typeof(int));
            dtbl.Columns.Add("ManufacturerName");
            dtbl.Columns.Add("FullItemName");
            dtbl.Columns.Add("ReceivePalletID");
            dtbl.Columns.Add("ReceiveDocID");
            dtbl.Columns.Add("StorageTypeID");

            dtbl.Columns.Add("Column", typeof(int));
            dtbl.Columns.Add("Row", typeof(int));
            dtbl.Columns.Add("ShelfID", typeof(int));

            dtbl.Columns.Add("BatchNo", typeof(string));
            dtbl.Columns.Add("ExpDate", typeof(DateTime));
            dtbl.Columns.Add("BoxLevel", typeof(int));
            dtbl.Columns.Add("BoxSizeDisplay");

            dtbl.Columns.Add("PalletLocation");
            dtbl.Columns.Add("PalletID", typeof(int));
            dtbl.Columns.Add("PalletNo");
            dtbl.Columns.Add("PalletLocationID", typeof(int));

            dtbl.Columns.Add("QtyPerPack", typeof(int));
            dtbl.Columns.Add("Pack", typeof(decimal));
            dtbl.Columns.Add("QtyInBU", typeof(decimal));
            dtbl.Columns.Add("QtyInSKU", typeof(decimal));

            dtbl.Columns.Add("ApprovedQuantity", typeof(decimal));
            dtbl.Columns.Add("CalculatedCost", typeof(double));
            dtbl.Columns.Add("UnitPrice", typeof(double));
            dtbl.Columns.Add("UnitsInSKU", typeof(decimal));
            dtbl.Columns.Add("Notes");
            dtbl.Columns.Add("Balance", typeof(decimal));
            dtbl.Columns.Add("ReservedStock", typeof(decimal));
            dtbl.Columns.Add("DeliveryNote", typeof(bool));

            dtbl.Columns.Add("PhysicalStoreName", typeof(string));
            dtbl.Columns.Add("AccountName", typeof(string));
            dtbl.Columns.Add("WarehouseName", typeof(string));
            return dtbl;
        }

        /// <summary>
        /// Gets the name of the StoreType
        /// </summary>
        /// <returns></returns>
        public string GetFromStore()
        {
            var stores = new Mode();
            stores.LoadByPrimaryKey(FromStore);
            // Old data has it in the form of StoreID,
            // What we expect are StoreTypeIDs,
            // HACK: until the old data entered using the old system are cleared, show the store ID
            // TODO: After the data has cleared, delete this condition
            // TODO: Clean the data by converting the RDF Types to ... the appropriate StoreTypeID
            if (stores.RowCount == 0)
            {
                Activity store = new Activity();
                store.LoadByPrimaryKey(FromStore);
                return store.Name;
            }
            return stores.TypeName;
        }
        /// <summary>
        /// returns who requested this order, Receiving units' name
        /// </summary>
        /// <returns></returns>
        public string GetRequestedBy()
        {

            if (!IsColumnNull("RequestedBy"))
            {
                var rus = new Institution();
                rus.LoadByPrimaryKey(RequestedBy);
                return rus.Name;
            }
            return "";

        }

        public string RegionName()
        {
            if (!IsColumnNull("RequestedBy"))
            {
                var rus = new Institution();
                rus.LoadByPrimaryKey(RequestedBy);
                return rus.RegionName;
            }
            return "";

        }

        public string ZoneName()
        {
            if (!IsColumnNull("RequestedBy"))
            {
                var rus = new Institution();
                rus.LoadByPrimaryKey(RequestedBy);
                return rus.ZoneName;
            }
            return "";

        }

        public string WoredaName()
        {
            if (!IsColumnNull("RequestedBy"))
            {
                var rus = new Institution();
                rus.LoadByPrimaryKey(RequestedBy);
                return rus.WoredaName;
            }
            return "";

        }
        public void getFacilityInfo()
        {
             string region, woreda, zone;
            if (!IsColumnNull("RequestedBy"))
            {
                var rus = new Institution();
                rus.LoadByPrimaryKey(RequestedBy);
                 region = rus.RegionName;
                woreda = rus.WoredaName;
                zone = rus.ZoneName;

            }
            

        }
        /// <summary>
        /// Returns the name of the approver
        /// </summary>
        /// <returns></returns>
        public string GetApprovedBy()
        {
            var user = new User();
            if (!this.IsColumnNull("ApprovedBy"))
            {
                user.LoadByPrimaryKey(this.ApprovedBy);
                return user.FullName;
            }
            return "";
        }

        public string GetFilledBy()
        {
            var user = new User();
            if (!this.IsColumnNull("FilledBy"))
            {
                user.LoadByPrimaryKey(this.FilledBy);
                return user.FullName;
            }
            return "";
        }

        /// <summary>
        /// Gets Next order reference number,
        /// this is used instead of implementation on the database because the reference number logic was changed
        /// after the inital design which allowed users to type in the reference number.
        /// </summary>
        /// <returns></returns>
        public static string GetNextOrderReference()
        {
            Order order = new Order();
            var query = HCMIS.Repository.Queries.Order.SelectGetNextOrderReference(FiscalYear.Current.ID);
            order.LoadFromRawSql(query);
            if (order.RowCount == 0 || order.RefNo == "")
            {
                return "1";
            }

            int last = Convert.ToInt32(order.RefNo);
            return (last + 1).ToString();
            ;
        }

        /// <summary>
        /// Releases the reservation.
        /// </summary>
        public void ReleaseReservation()
        {
            PickList pickList = new PickList();
            pickList.LoadByOrderID(this.ID);
            if (pickList.RowCount == 0) //If there is no picklist, there is nothing to release.
                return;
            PickListDetail pld = new PickListDetail();
            pld.LoadByPickListID(pickList.ID);
            pld.Rewind();
            while (!pld.EOF)
            {
                ReceivePallet receivePallet = new ReceivePallet();
                receivePallet.LoadByPrimaryKey(pld.ReceivePalletID);
                ReceiveDoc rdoc = new ReceiveDoc();
                rdoc.LoadByPrimaryKey(pld.ReceiveDocID);


                receivePallet.ReservedStock = receivePallet.ReservedStock - Convert.ToInt32(pld.QuantityInBU);
                if (receivePallet.ReservedStock < 0)
                    receivePallet.ReservedStock = 0;
                receivePallet.Save();
                //Delete from picklistDetail and add to pickListDetailDeleted
                PickListDetailDeleted.AddNewLog(pld, BLL.CurrentContext.UserId);
                pld.MarkAsDeleted();
                pld.MoveNext();

                //Delete issues if the order has any
                    var iss = new Issue();
                    iss.GetIssueByOrderID(this.ID);
                iss.Rewind();
                if (iss.RowCount > 0)
                {
                    while (!iss.EOF)
                    {
                        iss.MarkAsDeleted();
                        iss.MoveNext();
                    }
                    iss.Save();
                }


            }
            pld.Save();
            pickList.MarkAsDeleted();
            pickList.Save();
        }


        /// <summary>
        /// Gets the contact person.
        /// </summary>
        /// <param name="picklistID">The picklist ID.</param>
        /// <returns></returns>
        internal static string GetContactPerson(int picklistID)
        {
            BLL.Order ord = new Order();
            ord.LoadByPickListID(picklistID);
            return ord.ContactPerson;
        }


        /// <summary>
        /// Loads the by pick list ID.
        /// </summary>
        /// <param name="picklistID">The picklist ID.</param>
        /// <returns></returns>
        private int LoadByPickListID(int picklistID)
        {
            var query = HCMIS.Repository.Queries.Order.SelectLoadByPickListId(picklistID);
            this.LoadFromRawSql(query);
            return this.ID;
        }

        /// <summary>
        /// Reorganizes the data view for STV print_ program.
        /// </summary>
        /// <param name="dv">The dv.</param>
        /// <param name="refNo">The ref no.</param>
        /// <param name="pickListId">The pick list id.</param>
        /// <param name="userID">The user ID.</param>
        /// <param name="stvLogID">The STV log ID.</param>
        /// <param name="convertDNtoSTV">if set to <c>true</c> [convert D nto STV].</param>
        /// <param name="generateNewPrintID">if set to <c>true</c> [generate new print ID].</param>
        /// <param name="hasInsurance">if set to <c>true</c> [has insurance].</param>
        /// <returns></returns>
        public static DataTable ReorganizeDataViewForSTVPrint_Program(DataView dv, int orderID, int pickListId, int userID, int? stvLogID, bool convertDNtoSTV, bool generateNewPrintID, bool hasInsurance)
        {
            BLL.Order order = new Order();
            order.LoadByPrimaryKey(orderID);
            int? paymentTypeID = null;

            if (order.PaymentTypeID == PaymentType.Constants.CASH || order.PaymentTypeID == PaymentType.Constants.CREDIT || order.PaymentTypeID == PaymentType.Constants.STV)
            {
                paymentTypeID = order.PaymentTypeID;
            }

            // This is just to make the delivery notes print a separate series of numbers.
            // This section completely asks for a re-write.
            if (dv.Count > 0 && (dv[0]["Cost"] == DBNull.Value || Convert.ToDecimal(dv[0]["Cost"]) == 0M))
            {
                paymentTypeID = PaymentType.Constants.DELIVERY_NOTE;
            }
            else if (stvLogID != null)
            {
                Issue issue = new Issue();
                issue.LoadByPrimaryKey(stvLogID.Value);

                if (!issue.IsColumnNull("IsDeliveryNote") && issue.IsDeliveryNote && !convertDNtoSTV)
                {
                    paymentTypeID = PaymentType.Constants.DELIVERY_NOTE;
                }
            }


            // prepare the pick list for printing. 
            // this method only merges the items that come in different rows but ... 
            // that have same price same item.
            DataTable dtbl = dv.Table.Clone();

            if (!dtbl.Columns.Contains("Supplier"))
            {
                dtbl.Columns.Add("Supplier");
            }
            if (!dtbl.Columns.Contains("SupplierID"))
            {
                dtbl.Columns.Add("SupplierID");
            }
            dtbl.Columns.Add("STVNumber");
            dtbl.Columns.Add("StoreName");
            dtbl.Columns.Add("ContactPerson");
            dtbl.Columns.Add("PhysicalStoreType"); //The virtual store (The grouping for the stores) for the display on the stv

            dtbl.Clear();
            foreach (DataRowView drv in dv)
            {
                if (dtbl.Rows.Count == 0)
                {
                    dtbl.ImportRow(drv.Row);
                }

                else
                {

                    //check if items with same expiry exists in the table
                    //TOFIX: Add the supplier in this mix

                    string qItemID = "", qbatchNumberID = "", qUnitPriceID = "", qPhysicalStoreName = "", qStoreID = "";

                    qItemID = string.Format("ItemID={0} and UnitID={1}", drv["ItemID"].ToString(), drv["UnitID"]);

                    if (drv["BatchNumber"] != DBNull.Value)
                        qbatchNumberID = string.Format(" and BatchNumber='{0}'", drv["BatchNumber"].ToString());
                    if (drv["UnitPrice"] != DBNull.Value)
                        qUnitPriceID = string.Format(" and UnitPrice = {0} ", drv["UnitPrice"].ToString());
                    if (drv["PhysicalStoreName"] != DBNull.Value)
                        qPhysicalStoreName = string.Format(" and PhysicalStoreName= '{0}'",
                                                           drv["PhysicalStoreName"].ToString());
                    if (drv["StoreID"] != DBNull.Value)
                        qStoreID = string.Format(" and StoreID= '{0}'", drv["StoreID"].ToString());

                    string query = string.Format("{0}{1}{2}{3}{4}", qItemID, qbatchNumberID, qUnitPriceID,
                                                 qPhysicalStoreName, qStoreID);
                    DataRow[] ar = dtbl.Select(query);
                    if (ar.Length > 0)
                    {
                        // 
                        foreach (var dataRow in ar)
                        {
                            dataRow["SKUPICKED"] = Convert.ToInt32(dataRow["SKUPICKED"]) +
                                                   Convert.ToInt32(drv["SKUPICKED"]);
                            dataRow["Cost"] = (dataRow["Cost"] != DBNull.Value ? Convert.ToDouble(dataRow["Cost"]) : 0) +
                                              (drv["Cost"] != DBNull.Value ? Convert.ToDouble(drv["Cost"]) : 0);
                            dataRow["IssueDocID"] = dataRow["IssueDocID"].ToString() + ',' +
                                                    drv["IssueDocID"].ToString();
                            dataRow.EndEdit();
                            // If we have been here before, no need to do it again.
                            // this means the same amount is printed duplicated.
                            break;
                        }
                    }
                    else
                    {
                        dtbl.ImportRow(drv.Row);
                    }
                }

            }

            Supplier supplier = new Supplier();
            ReceiveDoc rd = new ReceiveDoc();


            // First sort the Data Table by Supplier
            // then create STV Number for each supplier


            foreach (DataRowView drw in dtbl.DefaultView)
            {
                rd.LoadByPrimaryKey(Convert.ToInt32(drw["ReceiveDocID"]));
                if (rd.RowCount > 0)
                {
                    supplier.LoadByPrimaryKey(rd.SupplierID);
                    // Add the supplier to the table
                    drw["SupplierID"] = supplier.ID;
                    drw["Supplier"] = supplier.CompanyName;
                    drw.EndEdit();
                }
            }

            int supplierId = 0;
            int storeID = 0;
            int phyStoreTypeID = 0;
            bool isManufacturerLocal = false;
            int storeGroupID = 0;
            string storeName = "";

            int lineNumber = 1;
            int rowsOnPaper = 1;
            int maxLinesOnPage = 15;

            string stvNo = "";
            string stvNoForPrint = "";
            int stvID = -1;

            dtbl.DefaultView.Sort = "PhysicalStoreTypeName, StoreGroupID,StoreID,IsManufacturerLocal, CommodityType, FullItemName";

            string commodityType = "";
            foreach (DataRowView drw in dtbl.DefaultView)
            {
                //if ((BLL.Settings.IsRdfMode && (palletLocationID != Convert.ToInt32(drw["PalletLocationID"]) || storeID != Convert.ToInt32(drw["StoreID"]))) || (Convert.ToInt32(drw["SupplierID"]) != supplierId) || lineNumber > 13)

                if (commodityType == "")
                    commodityType = drw["CommodityType"].ToString();

                if ((drw["PhysicalStoreTypeID"] != DBNull.Value) && phyStoreTypeID != Convert.ToInt32(drw["PhysicalStoreTypeID"]) || (commodityType != drw["CommodityType"].ToString() && !BLL.Settings.PrintMultipleCommodityTypesPerPage) || (isManufacturerLocal != bool.Parse(drw["IsManufacturerLocal"].ToString()) || storeGroupID != Convert.ToInt32(drw["StoreGroupID"]) || storeID != Convert.ToInt32(drw["StoreID"]) || (rowsOnPaper + (Convert.ToInt32(drw["FullItemName"].ToString().Length / 32))) > maxLinesOnPage))// lineNumber > 10)
                {

                    lineNumber = 1;
                    rowsOnPaper = 1;

                    supplierId = Convert.ToInt32(drw["SupplierID"]);
                    storeGroupID = Convert.ToInt32(drw["StoreGroupID"]);
                    storeID = Convert.ToInt32(drw["StoreID"]);
                    var activity = new Activity();
                    activity.LoadByPrimaryKey(storeID);
                    storeName = activity.FullActivityName;
                 
                    isManufacturerLocal = Convert.ToBoolean(drw["IsManufacturerLocal"]);

                    if (drw["PhysicalStoreTypeID"] != DBNull.Value)
                    {
                        phyStoreTypeID = Convert.ToInt32(drw["PhysicalStoreTypeID"]);
                    }


                    // Pseudo:
                    // Get hub details from the general info table
                    // prepare the printable data
                    // bind the printable data and GO

                    Issue stvLog = new Issue();
                    if (BLL.Settings.UseHeadedSTV && generateNewPrintID)
                    {
                        stvLog.AddNew();
                        stvLog.PrintedDate = DateTimeHelper.ServerDateTime;
                        stvLog.RefNo = order.RefNo;
                        stvLog.PickListID = pickListId;
                        stvLog.SupplierID = supplierId;
                        stvLog.UserID = userID;
                        stvLog.StoreID = storeID;
                         stvLog.IsDeliveryNote = (paymentTypeID == PaymentType.Constants.DELIVERY_NOTE);
                        stvLog.HasInsurance = hasInsurance;
                        stvLog.FiscalYearID = FiscalYear.Current.ID;
                        stvLog.AccountID = activity.AccountID;
                        if (paymentTypeID == PaymentType.Constants.DELIVERY_NOTE)
                        {
                            stvLog.DocumentTypeID = DocumentType.documentTypes.DeliveryNote.DocumentTypeID;
                        }
                        else if (paymentTypeID == PaymentType.Constants.CASH)
                        {
                            stvLog.DocumentTypeID = DocumentType.documentTypes.Cash.DocumentTypeID;
                        }
                        else if (paymentTypeID == PaymentType.Constants.CREDIT)
                        {
                            stvLog.DocumentTypeID = DocumentType.documentTypes.Credit.DocumentTypeID;
                        }
                        else if(paymentTypeID == PaymentType.Constants.STV)
                        {
                            stvLog.DocumentTypeID = DocumentType.documentTypes.STV.DocumentTypeID;
                        }
                        stvLog.IDPrinted = DocumentType.GetNextSequenceNo(stvLog.DocumentTypeID,stvLog.AccountID,stvLog.FiscalYearID);
                        stvLog.PaymentTypeID = order.PaymentTypeID;

                        if (!order.IsColumnNull("RequestedBy"))
                            stvLog.ReceivingUnitID = order.RequestedBy;
                        if (stvLogID.HasValue)
                        {
                            stvLog.IsReprintOf = stvLogID.Value;
                            //this means the STV is from replaced
                            Issue s = new Issue();
                            s.LoadByPrimaryKey(stvLogID.Value);
                            stvLog.IsDeliveryNote=(!s.IsColumnNull("IsDeliveryNote") && s.IsDeliveryNote && !convertDNtoSTV);
                        }

                        stvLog.Save();

                        stvNo = stvLog.ID.ToString("00000"); //If we wanted  to show just the ID of the sql table on the printout. We Use this
                        stvNoForPrint = FiscalYear.Current.GetCode(stvLog.IDPrinted);
                        stvID = stvLog.ID;
                    }
                    else if (!generateNewPrintID && stvLogID.HasValue)
                    {
                        // this assumes that we don't have to export
                        stvLog.LoadByPrimaryKey(stvLogID.Value);

                        stvNo = stvLog.ID.ToString("00000");//If we wanted  to show just the ID of the sql table on the printout. Use this
                       FiscalYear fiscalYear = new FiscalYear();
                        fiscalYear.LoadByPrimaryKey(stvLog.FiscalYearID);
                        stvNoForPrint = fiscalYear.GetCode(stvLog.IDPrinted);
                    }
                }

                if (commodityType != drw["CommodityType"].ToString()) //Check if the commodity type has changed.  Meaning that there will be a new group on the same paper (Pharmaceuticals, Chemicals, etc.) therefore we have to make the number of items that come to that page lower (Because we have headings for each group)
                {
                    commodityType = drw["CommodityType"].ToString();
                    rowsOnPaper = rowsOnPaper + 5;
                }
                else
                {
                    if (drw["FullItemName"].ToString().Length > 30) //The reason behind this code.  If the item name is a long one, it wraps and goes into the next line, making the number of row numbers more than just 1, so we don't just add one
                        rowsOnPaper += Convert.ToInt32(drw["FullItemName"].ToString().Length / 30) + 1;
                    else
                        rowsOnPaper++;
                }

                drw["STVNumber"] = stvNo;
                drw["LineNum"] = lineNumber++;
                drw["StoreName"] = storeName;
                drw["PrintedSTVNumber"] = stvNoForPrint;

                //Save the STVID into the IssueDoc Table.

                BLL.IssueDoc issDoc = new IssueDoc();

                int itemID = Convert.ToInt32(drw["ItemID"]);
                int receiveDocID = Convert.ToInt32(drw["ReceiveDocID"]);
                int picklistID = Convert.ToInt32(drw["PicklistID"]);
                drw["ContactPerson"] = BLL.Order.GetContactPerson(picklistID);
                BLL.Order orderInfo = new Order();

                // the only time the STVLog ID should be an entry in the Issue Doc should be when this is a fresh printout. 
                if (stvID != -1 && stvLogID == null)
                {
                    SaveSTVIDbyPickListDetails(drw["IssueDocID"].ToString(), stvID);
                    //SaveSTVIDIntoIssueData(supplierId, itemID, stvID, issDoc, orderInfo.LoadByPickListID(picklistID), receiveDocID, storeID);
                }

                if (stvID == -1 && stvLogID == null)
                {
                    throw new Exception("An error occurred during save.  Please contact your administrator if this happens again.");
                }
                //SaveSTVIDIntoIssueData(supplierId, itemID, stvID, issDoc, order.LoadByPickListID(picklistID), receiveDocID);
            }
            return dtbl;
        }

        /// <summary>
        /// Saves the STVI dby pick list details.
        /// </summary>
        /// <param name="plDetailIDs">The pl detail I ds.</param>
        /// <param name="stvID">The STV ID.</param>
        private static void SaveSTVIDbyPickListDetails(string plDetailIDs, int stvID)
        {
            IssueDoc iDoc = new IssueDoc();
            iDoc.LoadByIDs(plDetailIDs);
            while (!iDoc.EOF)
            {
                iDoc.STVID = stvID;
                iDoc.Save();
                iDoc.MoveNext();
            }
        }




        /// <summary>
        /// Gets the weekly invoice summary.
        /// </summary>
        /// <returns></returns>
        public static object GetWeeklyInvoiceSummary()
        {
            var query = HCMIS.Repository.Queries.Order.SelectGetWeeklyInvoiceSummary();
            Order ord = new Order();
            ord.LoadFromRawSql(query);
            return ord.DefaultView;
        }

        /// <summary>
        /// Gets the weekly pick list summary.
        /// </summary>
        /// <returns></returns>
        public static DataView GetWeeklyPickListSummary()
        {
            var query = HCMIS.Repository.Queries.Order.SelectGetWeeklyPickListSummary();
            Order ord = new Order();
            ord.LoadFromRawSql(query);
            return ord.DefaultView;
        }

        /// <summary>
        /// Gets the weekly wish list summary.
        /// </summary>
        /// <returns></returns>
        public static object GetWeeklyWishListSummary()
        {
            var query = HCMIS.Repository.Queries.Order.SelectGetWeeklyWishListSummary();
            Order ord = new Order();
            ord.LoadFromRawSql(query);
            return ord.DefaultView;
        }

        /// <summary>
        /// Returns a table with Date and Wishlist amount entered on that date.
        /// </summary>
        /// <param name="days">For the past how many days (Enter -1 for all)</param>
        /// <returns></returns>
        public static object GetWishListSummary(int days)
        {
            string query;
            if (days == -1)
                query = HCMIS.Repository.Queries.Order.SelectGetWishListSummary();
            else
                query = HCMIS.Repository.Queries.Order.SelectGetWishListSummary(days);
            Order ord = new Order();
            ord.LoadFromRawSql(query);
            return ord.DefaultView;
        }

        /// <summary>
        /// Returns the Date, Order for a specific order status ID
        /// </summary>
        /// <param name="orderStatusID">The order status ID.</param>
        /// <param name="days">For the past how many days (Enter -1 for all)</param>
        /// <returns></returns>
        public static object GetOrdersForReport(int orderStatusID, int days)
        {
            string query;
            if (days == -1)
                query = HCMIS.Repository.Queries.Order.SelectGetOrdersForReport(orderStatusID);
            else
                query = HCMIS.Repository.Queries.Order.SelectGetOrdersForReport(orderStatusID, days);
            Order ord = new Order();
            ord.LoadFromRawSql(query);
            return ord.DefaultView;
        }

        /// <summary>
        /// Right now used only from the invoice to the Approval Page
        /// </summary>
        public void ReturnBacktoPicklistConfirmation()
        {
            if (this.OrderStatusID != OrderStatus.Constant.PICK_LIST_CONFIRMED)
                return;//May need to throw an exception here.            
            this.ChangeStatus(OrderStatus.Constant.PICK_LIST_GENERATED,CurrentContext.UserId);
            this.Save();
            BLL.PickList picklist = new PickList();
            picklist.LoadByOrderID(this.ID);
            picklist.IsConfirmed = false;
            picklist.Save();
        }
        /// <summary>
        /// Returns the list of requisitions with the status specified.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public static DataTable GetRequisitions(string statuscode, int userID)
        {
            string orderStatuses = statuscode == "DRFT" ? "'DRFT'" : " 'DRFT','ORFI','APRD','PIKL','PLCN' ";
            var query = HCMIS.Repository.Queries.Order.SelectGetRequisitions(userID, orderStatuses);
            Order ord = new Order();
            ord.LoadFromRawSql(query);

            while (!ord.EOF)
            {
                EthiopianDate.EthiopianDate eth;

                ord.SetColumn("DateRequested",
                              EthiopianDate.EthiopianDate.GregorianToEthiopian(Convert.ToDateTime(ord.GetColumn("EurDate"))));
                ord.MoveNext();
            }

            return ord.DataTable;
        }

        /// <summary>
        /// Gets the requisition details.
        /// </summary>
        /// <param name="orderID">The order ID.</param>
        /// <returns></returns>
        public static DataTable GetRequisitionDetails(int orderID)
        {
            var query = HCMIS.Repository.Queries.Order.SelectGetRequisitionDetailsQuery(orderID);
            Order ord = new Order();
            ord.LoadFromRawSql(query);
            return ord.DataTable;
        }


        /// <summary>
        /// Counts the of detail items.
        /// </summary>
        /// <returns></returns>
        public int CountOfDetailItems()
        {
            OrderDetail odetail = new OrderDetail();
            odetail.LoadAllByOrderID(this.ID);
            return odetail.RowCount;
        }



        /// <summary>
        /// Gets the insurance value.
        /// </summary>
        /// <param name="orderID">The order ID.</param>
        /// <param name="TotalValue">The total value.</param>
        /// <returns></returns>
        public static double GetInsuranceValue(int orderID, double TotalValue)
        {
            BLL.Order order = new Order();
            order.LoadByPrimaryKey(orderID);
            if (order.FromStore == Mode.Constants.HEALTH_PROGRAM)
                return 0;

            double STVvalue = TotalValue;
            string insuranceformula = BLL.Settings.InsuranceFormula;
            string Formula = String.Format(insuranceformula, STVvalue);
            System.Data.DataTable dt = new System.Data.DataTable();
            double Insurance = Convert.ToDouble(dt.Compute(Formula, ""));
            return Insurance;
        }



        /// <summary>
        /// Gets the order status list.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetOrderStatusList(int modeID)
        {
            var query = HCMIS.Repository.Queries.Order.SelectGetOrderStatusList(modeID);
            Order order = new Order();
            order.LoadFromRawSql(query);
            return order.DataTable;
        }

        /// <summary>
        /// Gets the approved quantity.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="storeId">The store id.</param>
        /// <param name="itemID">The item ID.</param>
        /// <param name="unitid">The unitid.</param>
        /// <param name="preferedExpiry">The prefered expiry.</param>
        /// <param name="preferredManufacturer">The preferred manufacturer.</param>
        /// <param name="preferredPhysicalStoreID">The preferred physical store ID.</param>
        /// <returns></returns>
        internal static int GetApprovedQuantity(PriceSettings setting, int storeId, int itemID, int? unitid, DateTime? preferedExpiry, int? preferredManufacturer, int? preferredPhysicalStoreID)
        {
            var query = HCMIS.Repository.Queries.Order.SelectGetApprovedQuantity(storeId, itemID, unitid, preferedExpiry,
                                                                                 preferredManufacturer,
                                                                                 preferredPhysicalStoreID,
                                                                                 setting ==
                                                                                 PriceSettings.DELIVERY_NOTE_ONLY);
            Order ord = new Order();
            ord.LoadFromRawSql(query);
            if (ord.RowCount > 0 && !ord.IsColumnNull("Approved"))
            {
                return Convert.ToInt32(ord.GetColumn("Approved"));
            }
            return 0;
        }

        public static DataTable GetMissingSTVs(int userID)
        {
            var query = HCMIS.Repository.Queries.Order.SelectGetMissingSTVs();
            Order order = new Order();
            order.LoadFromRawSql(query);
            return order.DataTable;
        }

        public static Order GenerateOrder(int? orderID, int orderTypeID, int orderStatusID, int activityID, int paymentTypeID, string contactPerson, int? requestedBy, int userID, int? refNo = null)
        {
            var requisitionType = new RequisitionType();
            int requisitionTypeID = Convert.ToInt32(requisitionType.LoadIDByCode("DMN")["RequisitionTypeID"]);
            Order or = new Order();
            if (orderID == null)
            {
                or.AddNew();
            }
            else
            {
                or.LoadByPrimaryKey(orderID.Value);
            }

            or.RefNo = refNo == null ? GetNextOrderReference() : refNo.ToString();
            var oldOrderStatus = or.IsColumnNull("OrderStatusID") ? (int?)null : or.OrderStatusID;
            or.OrderStatusID = orderStatusID;
           // or.RequisitionTypeID = RequisitionType.CONSTANTS.DEMAND;
            or.RequisitionTypeID = requisitionTypeID;

            or.EurDate = or.Date = DateTimeHelper.ServerDateTime;

            if (requestedBy != null)
            {
                or.RequestedBy = requestedBy.Value;
            }

            or.FilledBy = userID;
            or.ContactPerson = contactPerson;
            var activity = new Activity();
            activity.LoadByPrimaryKey(activityID);
            or.FromStore = activity.ModeID;
            or.PaymentTypeID = paymentTypeID;
            or.FiscalYearID = FiscalYear.Current.ID;
            or.OrderTypeID = orderTypeID;
            or.Save();
            or.LogRequisitionStatus(or.ID, oldOrderStatus, orderStatusID, CurrentContext.UserId);
            return or;
        }

        public static bool SaveOrderToDatabase(int Status, int userID, int? orderID,int requisitionTypeID, int facilityID, int paymentType,
                                               int modeID, string remarks, string letterNumber, string contactPerson,
                                               DataView _dvOrderTable, int periodID = -1)
        {

            MyGeneration.dOOdads.TransactionMgr mgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
            try
            {
                mgr.BeginTransaction();
                BLL.Order or = new BLL.Order();
                if (orderID == null)
                {
                    or.AddNew();
                    or.RefNo = Order.GetNextOrderReference();
                    or.OrderTypeID = OrderType.CONSTANTS.STANDARD_ORDER;
                    or.FiscalYearID = FiscalYear.Current.ID;
                }
                else
                {
                    or.LoadByPrimaryKey(orderID.Value);
                }

                or.RequisitionTypeID = requisitionTypeID;
                var oldOrderStatus = or.IsColumnNull("OrderStatusID")? (int?) null: or.OrderStatusID;
                or.OrderStatusID = Status;
                or.Remark = remarks;

                or.EurDate = or.Date = DateTimeHelper.ServerDateTime; //Both fields are assigned dates.
                or.RequestedBy = facilityID;
                or.FilledBy = userID;
                or.LetterNo = letterNumber;
                or.PaymentTypeID = paymentType;
                or.ContactPerson = contactPerson;
                or.FromStore = modeID;

                or.Save();
                or.LogRequisitionStatus(or.ID,oldOrderStatus,Status,CurrentContext.UserId);
                // with this Order save RRF.Request 
                //if (periodID != -1)
                //{
                //    BLL.Request request = new BLL.Request();
                //    request.LoadByPrimaryKey(-1);
                //    request.AddNew();
                //    request.RequestID = or.ID;
                //    request.PeriodID = periodID;
                //    request.Save();
                //}


                // this is a kind of initializing the data table.
                OrderDetail ord = new OrderDetail();
                foreach (DataRowView r in _dvOrderTable)
                {
                    int itemID = Convert.ToInt32(r["ItemID"]);
                    int unitID = Convert.ToInt32(r["UnitID"]);

                    ord.LoadByItemUnit(or.ID, itemID, unitID);
                    if (ord.RowCount == 0)
                    {
                        ord.AddNew();
                    }
                    ord.OrderID = or.ID;
                    ord.ItemID = itemID;
                    if (r["Pack"] != DBNull.Value)
                    {
                        ord.Pack = Convert.ToDecimal(r["Pack"]);
                    }
                    if (r["QtyPerPack"] != DBNull.Value)
                    {
                        ord.QtyPerPack = Convert.ToInt32(r["QtyPerPack"]);
                    }

                    if(r["StockOnHand"]!=DBNull.Value)
                    {
                        ord.StockOnHand = Convert.ToDecimal(r["StockOnHand"]);
                    }

                    if(r["ExpiredStock"]!=DBNull.Value)
                    {
                        ord.ExpiredStock = Convert.ToDecimal(r["ExpiredStock"]); 
                    }

                    if(r["DamagedStock"]!=DBNull.Value)
                    {
                        ord.DamagedStock = Convert.ToDecimal(r["DamagedStock"]);
                    }
                    ord.Quantity = Convert.ToDecimal(r["Quantity"]);
                    ord.UnitID = unitID;
                    //ord.StoreID = or.FromStore;
                    ord.Save();

                    //with this OrderDetail save RRF.RequestDetail
                    //BLL.RequestDetail requestDetail = new BLL.RequestDetail();
                    //requestDetail.AddNew();
                    //requestDetail.LoadByPrimaryKey(-1);
                    //requestDetail.RequestDetailID = ord.ID;
                    //if(r["BeginningBalance"]!=DBNull.Value)
                    //{
                    //    requestDetail.BeginningBalance = Convert.ToDecimal(r["BeginningBalance"]);
                    //}
                    //if (r["Adjustment"] != DBNull.Value)
                    //{
                    //    requestDetail.Adjustment = Convert.ToDecimal(r["Adjustment"]);
                    //}
                    //if (r["Loss"] != DBNull.Value)
                    //{
                    //    requestDetail.Loss = Convert.ToDecimal(r["Loss"]);
                    //}
                    //if (r["DOS"] != DBNull.Value)
                    //{
                    //    requestDetail.DOS = Convert.ToInt32(r["DOS"]);
                    //}
                    //requestDetail.Save();

                }
                //this.LogActivity("Save-Requisition", ord.ID);
                mgr.CommitTransaction();


            }
            catch (Exception exp)
            {
                mgr.RollbackTransaction();
                throw;
            }
            //ResetOrder();
            return true;
        }

        public static Order SaveOrderToDB(int Status, int userID, int? orderID, int facilityID, int paymentType,
                                       int modeID, string remarks, string letterNumber, string contactPerson,
                                       DataView _dvOrderTable)
        {

            MyGeneration.dOOdads.TransactionMgr mgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
            try
            {
                mgr.BeginTransaction();
                BLL.Order or = new BLL.Order();
                if (orderID == null)
                {
                    or.AddNew();
                    or.RefNo = Order.GetNextOrderReference();
                    or.OrderTypeID = OrderType.CONSTANTS.STANDARD_ORDER;
                    or.FiscalYearID = FiscalYear.Current.ID;
                }
                else
                {
                    or.LoadByPrimaryKey(orderID.Value);
                }

                var oldOrderStatus = or.IsColumnNull("OrderStatusID") ? (int?)null : or.OrderStatusID;
                or.OrderStatusID = Status;
                or.RequisitionTypeID = RequisitionType.CONSTANTS.DEMAND;
                or.Remark = remarks;

                or.EurDate = or.Date = DateTimeHelper.ServerDateTime; //Both fields are assigned dates.
                or.RequestedBy = facilityID;
                or.FilledBy = userID;
                or.LetterNo = letterNumber;
                or.PaymentTypeID = paymentType;
                or.ContactPerson = contactPerson;
                or.FromStore = modeID;

                or.Save();
                or.LogRequisitionStatus(or.ID, oldOrderStatus, Status, CurrentContext.UserId); //Log OrderStatus Change

                // this is a kind of initializing the data table.
                OrderDetail ord = new OrderDetail();
                foreach (DataRowView r in _dvOrderTable)
                {
                    int itemID = Convert.ToInt32(r["ItemID"]);
                    int unitID = Convert.ToInt32(r["UnitID"]);

                    ord.LoadByItemUnit(or.ID, itemID, unitID);
                    if (ord.RowCount == 0)
                    {
                        ord.AddNew();
                    }
                    ord.OrderID = or.ID;
                    ord.ItemID = itemID;
                    if (r["Pack"] != DBNull.Value)
                    {
                        ord.Pack = Convert.ToDecimal(r["Pack"]);
                    }
                    if (r["QtyPerPack"] != DBNull.Value)
                    {
                        ord.QtyPerPack = Convert.ToInt32(r["QtyPerPack"]);
                    }

                    if (r["StockOnHand"] != DBNull.Value)
                    {
                        ord.StockOnHand = Convert.ToDecimal(r["StockOnHand"]);
                    }

                    //if (r["ExpiredStock"] != DBNull.Value)
                    //{
                    //    ord.ExpiredStock = Convert.ToDecimal(r["ExpiredStock"]);
                    //}

                    //if (r["DamagedStock"] != DBNull.Value)
                    //{
                    //    ord.DamagedStock = Convert.ToDecimal(r["DamagedStock"]);
                    //}
                    ord.Quantity = Convert.ToDecimal(r["Quantity"]);
                    ord.UnitID = unitID;
                    //ord.StoreID = or.FromStore;
                    ord.Save();
                }
                //this.LogActivity("Save-Requisition", ord.ID);
                mgr.CommitTransaction();

                return or;
            }
            catch (Exception exp)
            {
                mgr.RollbackTransaction();
                throw;
            }
            //ResetOrder();
        }

        public static int SavePLITSApprovedOrderToDatabase(int Status, int userID, int? plitsOrderID, int facilityID, int paymentType,
                                              int modeID, string remarks, string letterNumber, string contactPerson,
                                              BLL.OrderDetail _PLITSOrderDetail)
        {

            int hcmisorderid;
            MyGeneration.dOOdads.TransactionMgr mgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
            try
            {
                mgr.BeginTransaction();
                BLL.Order or = new BLL.Order();

                or.AddNew();
                or.RefNo = Order.GetNextOrderReference();
                or.OrderTypeID = OrderType.CONSTANTS.PLITS;
                or.HCTSReferenceID = plitsOrderID.Value;

                or.OrderStatusID = Status;
                
                or.RequisitionTypeID = RequisitionType.CONSTANTS.DEMAND;
                or.Remark = remarks;

                or.EurDate = or.Date = DateTimeHelper.ServerDateTime; //Both fields are assigned dates.
                var institution = new Institution();
                institution.LoadBySN(facilityID);
                or.RequestedBy = institution.ID;
                or.FilledBy = userID;
                or.LetterNo = letterNumber;
                or.PaymentTypeID = paymentType;
                or.ContactPerson = contactPerson;
                or.FromStore = modeID;
                or.FiscalYearID = FiscalYear.Current.ID;
                or.Save();
                or.LogRequisitionStatus(or.ID,null,Status, CurrentContext.UserId); //Log OrderStatus change


                _PLITSOrderDetail.Rewind();
                while (!_PLITSOrderDetail.EOF)
                {
                    _PLITSOrderDetail.OrderID = or.ID;

                    _PLITSOrderDetail.MoveNext();
                }
                _PLITSOrderDetail.Save();


                hcmisorderid = or.ID;
                //this.LogActivity("Save-Requisition", ord.ID);
                mgr.CommitTransaction();


            }
            catch (Exception exp)
            {
                mgr.RollbackTransaction();
                return 0;
                throw (exp);
            }
            //ResetOrder();
            return hcmisorderid;
        }


        public static bool IsItAnOnlineOrder(int orderID)
        {
            var order = new Order();
            order.LoadByPrimaryKey(orderID);
            order.Query.Load();
            return order.RowCount > 0;
        }


        public DataView GetPLITSApprovedOrders(int userID, int modeID)
        {
            var query = HCMIS.Repository.Queries.Order.SelectGetPLITSApprovedOrders(userID, modeID, BLL.OrderStatus.Constant.ORDER_APPROVED, BLL.OrderType.CONSTANTS.PLITS);
            LoadFromRawSql(query);
            return DefaultView;
        }

        public static bool NeedsBackorder(int orderID)
        {
            var query = HCMIS.Repository.Queries.Order.SelectNeedsBackorder(orderID);
            var order = new Order();
            order.LoadFromRawSql(query);
            return order.RowCount > 0;
        }

        //~ This Method is Obsoleted ~//
        public static bool SaveBackOrderToDatabase(BLL.Order _order)
        {
            var _orderDetail = new OrderDetail();
            _orderDetail.LoadAllByOrderID(_order.ID);

            MyGeneration.dOOdads.TransactionMgr mgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
            try
            {
                mgr.BeginTransaction();
                var or = new BLL.Order();

                or.AddNew();
                or.RefNo = Order.GetNextOrderReference();
                or.SetColumn("OrderTypeID", _order.GetColumn("OrderTypeID"));
                or.SetColumn("HCTSReferenceID", _order.GetColumn("HCTSReferenceID"));

                or.OrderStatusID = OrderStatus.Constant.DRAFT_WISHLIST;
                or.RequisitionTypeID = RequisitionType.CONSTANTS.DEMAND;
                or.Remark = _order.ID.ToString(); //Store the Original ID here for the backorder.  We need to have a standard way of marking backorders.

                or.EurDate = or.Date = DateTimeHelper.ServerDateTime; //Both fields are assigned dates.
                or.RequestedBy = _order.RequestedBy;
                or.FilledBy = _order.FilledBy;
                or.LetterNo = _order.LetterNo;
                or.PaymentTypeID = _order.PaymentTypeID;
                or.ContactPerson = _order.ContactPerson;
                or.FromStore = _order.FromStore;
                or.FiscalYearID = FiscalYear.Current.ID;
                or.OrderTypeID = _order.OrderTypeID == OrderType.CONSTANTS.PLITS
                                     ? _order.OrderTypeID
                                     : OrderType.CONSTANTS.BACK_ORDER;


                or.Save();
                or.LogRequisitionStatus(or.ID,null,OrderStatus.Constant.DRAFT_WISHLIST,CurrentContext.UserId);
                _orderDetail.Rewind();
                var orderDetail = new OrderDetail();

                while (!_orderDetail.EOF)
                {
                    if (_orderDetail.ApprovedQuantity >= _orderDetail.Quantity)
                    {
                        _orderDetail.MoveNext();
                        continue; //Backorder is only for those with approved quantity less than the requested quantity.
                    }
                    orderDetail.AddNew();
                    orderDetail.ItemID = _orderDetail.ItemID;
                    orderDetail.OrderID = or.ID;
                    orderDetail.Pack = (_orderDetail.Quantity - _orderDetail.ApprovedQuantity) /
                                       _orderDetail.QtyPerPack;
                    orderDetail.QtyPerPack = _orderDetail.QtyPerPack;
                    orderDetail.Quantity = orderDetail.Pack * orderDetail.QtyPerPack;
                    orderDetail.SetColumn("HACTOrderDetailID", _orderDetail.GetColumn("HACTOrderDetailID"));
                    orderDetail.UnitID = _orderDetail.UnitID;

                    _orderDetail.MoveNext();
                }

                orderDetail.Save();
                mgr.CommitTransaction();
                return true;
            }
            catch (Exception exp)
            {
                mgr.RollbackTransaction();
                return false;
            }
        }


        public static int GetTotalForAnInstitution(int institutionID)
        {
            BLL.Order order = new Order();
            order.Where.RequestedBy.Value = institutionID;
            order.Query.Load();
            return order.RowCount;
        }

        public bool IsPaymentTypeValid()
        {
            return PaymentTypeID == PaymentType.Constants.CASH ||
                   PaymentTypeID == PaymentType.Constants.CREDIT ||
                   PaymentTypeID == PaymentType.Constants.STV ||
                   PaymentTypeID == PaymentType.Constants.DELIVERY_NOTE;
           
        }

        public string GetRegionName()
        {
            if (!IsColumnNull("RequestedBy"))
            {
                var rus = new Institution();
                rus.LoadByPrimaryKey(RequestedBy);
                return rus.RegionName;
            }
            return "";

        }

        public string GetZoneName()
        {
            if (!IsColumnNull("RequestedBy"))
            {
                var rus = new Institution();
                rus.LoadByPrimaryKey(RequestedBy);
                return rus.ZoneName;
            }
            return "";

        }

        public string GetWoredaName()
        {
            if (!IsColumnNull("RequestedBy"))
            {
                var rus = new Institution();
                rus.LoadByPrimaryKey(RequestedBy);
                return rus.WoredaName;
            }
            return "";

        }

        public void ChangeStatus(int toStatusID, int userID)
        {
            this.LogRequisitionStatus(this.ID,this.OrderStatusID,toStatusID,userID);
            this.OrderStatusID = toStatusID;
            this.Save();
        }

        public void LogRequisitionStatus(int requisitionID, int? fromStatusID, int toStatusID, int userID)
        {
            LogRequisitionStatus logRequisitionStatus = new LogRequisitionStatus();
            logRequisitionStatus.AddNew();
            logRequisitionStatus.StatusChangedDate = DateTimeHelper.ServerDateTime;
            logRequisitionStatus.RequisitionID = requisitionID;
            if (fromStatusID.HasValue)
            {
                logRequisitionStatus.FromStatusID = (int) fromStatusID;
            }
            logRequisitionStatus.ToStatusID = toStatusID;
            logRequisitionStatus.UserID = userID;
            logRequisitionStatus.Save();
        }
    }
}
