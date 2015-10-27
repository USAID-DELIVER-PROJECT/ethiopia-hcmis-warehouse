using DAL;
using System.Data;
using System;

namespace BLL
{
    public class Activity : _Activity
    {
        public class Constants
        {
            public static int RDF_REGULAR;
            public static int RDF_PBS;
            public static int RDF_MDG;
        }

       
        #region Properties
       
        public string SubAccountName
        {
            get { return Getstring("SubAccountName"); }
        }
        
        public string AccountName
        {
            get { return Getstring("AccountName"); }
        }

        public string FullActivityName
        {
            get { return Getstring("FullActivityName"); }
        }

        public bool IsSubsidized
        {
            get { return ID == Constants.RDF_PBS || ID == Constants.RDF_MDG; }
        }
        public int ModeID
        {
            get { return Getint("ModeID"); }
        }

        public string ModeName
        {
            get { return Getstring("ModeName"); }
        }
        
        public new int MovingAverageGroupID
        {
            get { return Getint("MovingAverageID"); }
        }
        #endregion

        public bool IsHealthProgram()
        {
            return ModeID == Mode.Constants.HEALTH_PROGRAM;
        }

        public int SupplierID
        {
            get
            {
                var supplier = new Supplier();
                supplier.LoadByRowGuid(this.Rowguid);
                return supplier.ID;
            }
        }

        public int InstitutionID
        {
            get
            {
                var institution = new Institution();
                institution.LoadByRowGuid(this.Rowguid);
                return institution.ID;
            }
        }
        #region Load Methods
        //Load Activities From vwAccounts
        public new void LoadAll()
        {
            LoadFromRawSql(HCMIS.Repository.Queries.Activity.SelectAllFromVwAccounts());
        }

       //Load Activity from vwAccounts
        public new void LoadByPrimaryKey(int activityID)
        {
            LoadFromRawSql(HCMIS.Repository.Queries.Activity.SelectFromVwAccountsByID(activityID)); 
        }
       
        /// <summary>
        /// Load Allowed Activities For User.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
    
        public void LoadByUserID(int userID)
        {
            LoadFromRawSql(HCMIS.Repository.Queries.Activity.SelectAllWhereUserHasAccess(userID));

        }

        public void LoadFirstActivityByMode(int modeID)
        {
            LoadFromRawSql(HCMIS.Repository.Queries.Activity.SelectFirstByMode(modeID));
        }

        /// <summary>
        /// Gets the default store.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public void LoadDefaultByUser(int userID)
        {
            LoadFromRawSql(HCMIS.Repository.Queries.Activity.SelectDefaultStoreByUserID(userID));
        }  
 
        /// <summary>
        /// Loads the Activities by ModeID.
        /// </summary>
        /// <param name="modeID">The mode ID.</param>
        public void LoadByMode(int modeID)
        {
            var query = HCMIS.Repository.Queries.Activity.SelectByMode(modeID);
            LoadFromRawSql(query);
        }
        
        #endregion

        #region Major Refactory needed
 
       

         //TODO: If possible move it some place else or modify the implementation
        /// <summary>
        /// Needs to be implemented better
        /// </summary>
        /// <param name="modeID">The mode ID.</param>
        /// <param name="itemID">The Item's ID</param>
        /// <param name="unitID">The Unit's ID</param>
        /// <returns></returns>
        public static int GetActivityUsingFEFO(int modeID,int itemID, int unitID)
        {
            var activity = new Activity();
            activity.LoadFromRawSql(HCMIS.Repository.Queries.Activity.SelectFirstActivityUsingFEFO(itemID, unitID));
            
            if (activity.RowCount == 0) //If there is no stock, then just return the first activity
            {
               activity.LoadFirstActivityByMode(modeID);  
            }
            return activity.ID;

            /*
             * TODO: This Should not be implemented this way we are suppose to load All activity Sorted by FEFO 
             * we need to change this as soon as possible i believe we can speed up approval page by removing really unnecessary trip
             * to the Database
             */
        }

        /// <summary>
        /// The code supports manufacturer preference here too but we choose not to prefer manufacturers when looking into the stores.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="orderDetailID"></param>
        /// <param name="pricedUnpricedBoth"></param>
        /// <param name="bal"> </param>
        /// <param name="markStockoutBit"> </param>
        /// <param name="usableStock"> </param>
        /// <param name="approved"> </param>
        public decimal LoadOptionsForOrderDetail(int userID, int orderDetailID, PriceSettings pricedUnpricedBoth, Balance bal, bool markStockoutBit, out decimal usableStock, out decimal approved)
        {
            decimal avQuantity = 0;
          
            BLL.OrderDetail orderDetail = new OrderDetail();
            orderDetail.LoadByPrimaryKey(orderDetailID);
            BLL.Order order = new Order();
            order.LoadByPrimaryKey(orderDetail.OrderID);
            
            Institution ru = new Institution();
            ru.LoadByPrimaryKey(order.RequestedBy);

            int month = EthiopianDate.EthiopianDate.Now.Month;
            int year = EthiopianDate.EthiopianDate.Now.Year;

            decimal availableQty = 0;
            usableStock = 0;
            approved = 0;
            int? manufacturerPrefrence = null, unitID = null;
            if (!orderDetail.IsColumnNull("PreferredManufacturerID"))
            {
                manufacturerPrefrence = orderDetail.PreferredManufacturerID;
            }

            DateTime? expPreferrence = null;
            if(!orderDetail.IsColumnNull("PreferredExpiryDate"))
            {
                expPreferrence = orderDetail.PreferredExpiryDate;
            }

            int? preferredPhysicalStoreID = null;
            if (!orderDetail.IsColumnNull("PreferredPhysicalStoreID"))
            {
                preferredPhysicalStoreID = orderDetail.PreferredPhysicalStoreID;
            }

            //--------------------------------------------------------------------------
            //manufacturerPrefrence = null; //We are overriding the manufacturer preference.
            //expPreferrence = null;
            //--------------------------------------------------------------------------
            if (!orderDetail.IsColumnNull("UnitID"))
            {
                unitID = orderDetail.UnitID;
            }

            BLL.UserActivity userStore = new UserActivity();

            // Definitely a danger zone
            userStore.LoadByUserIDAndStoreType(userID, order.FromStore, orderDetail.ItemID, unitID.Value);
            

            while (!userStore.EOF)
            {
                var activity = new Activity();
                 activity.LoadByPrimaryKey(userStore.ActivityID);
                
                if(order.FromStore == Mode.Constants.RDF && !BLL.Settings.IsCenter && !BLL.Settings.PrivateCanGetFromMDGAndPBS && ru.Ownership == OwnershipType.Constants.Private && activity.IsSubsidized ){
                    userStore.MoveNext();
                    continue;
                }


              
               // Load the Activity Selection that has PRiced Commodities.
                Balance balance = new Balance();
                if (pricedUnpricedBoth == PriceSettings.PRICED_ONLY || pricedUnpricedBoth == PriceSettings.BOTH)
                {
                    BLL.Order.MakeStockCalculations(userID, month, year, PriceSettings.PRICED_ONLY, orderDetail,
                                                    userStore.ActivityID, orderDetail.ItemID, order, balance, unitID,
                                                    manufacturerPrefrence, expPreferrence, preferredPhysicalStoreID, out usableStock, out approved,
                                                    out availableQty, markStockoutBit);
                    avQuantity += availableQty;
                 
                    if (availableQty > 0)
                    {
                        
                        this.AddNew();
                        this.ID = userStore.ActivityID;
                        this.Name = string.Format("{0} ({1})", activity.FullActivityName, availableQty.ToString("#,##0"));
                        PrepareColumnsForApproval();
                        this.SetColumn("AvailableSKU", availableQty);
                        this.SetColumn("IsDeliveryNote", false);
                        this.SetColumn("TextID",string.Format("N{0}",this.ID));
                    }
                }



                // Load Activity Selections for Delivery Note Items.
                if (pricedUnpricedBoth == PriceSettings.DELIVERY_NOTE_ONLY || pricedUnpricedBoth == PriceSettings.BOTH)
                {
                    BLL.Order.MakeStockCalculations(userID, month, year, PriceSettings.DELIVERY_NOTE_ONLY, orderDetail,
                                                    userStore.ActivityID, orderDetail.ItemID, order, balance, unitID,
                                                    manufacturerPrefrence, expPreferrence, preferredPhysicalStoreID, out usableStock, out approved,
                                                    out availableQty, markStockoutBit);

                    avQuantity += availableQty;
                    
                    if (availableQty > 0)
                    {
                        this.AddNew();
                        this.ID = userStore.ActivityID; //Just to give it a different ID so we know there is a change only.
                        this.Name = string.Format("+-- {0} - Delivery Notes - ({1})", userStore.GetColumn("ActivityName"),
                                                       availableQty.ToString("#,##0"));
                        PrepareColumnsForApproval();
                        this.SetColumn("AvailableSKU", availableQty);
                        this.SetColumn("IsDeliveryNote", true);
                        this.SetColumn("TextID", string.Format("D{0}", this.ID));

                    }

                }
                userStore.MoveNext();
            }
            return avQuantity;
           
        }

        /// <summary>
        /// Prepares the columns for approval.
        /// </summary>
        private void PrepareColumnsForApproval()
        {
            if (this.DataTable.Columns.IndexOf("AvailableSKU") < 0)
            {
                // prepare the data table
                this.AddColumn("AvailableSKU", typeof (decimal));
                this.AddColumn("IsDeliveryNote", typeof (bool));
                this.AddColumn("TextID", typeof (string));
            }
        }
        #endregion

        #region DataView

        /// <summary>
        /// Gets all with text ID.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllWithTextID()
        {
            //TODO: figure out what this does and Delete it if it is not useful
            var stores = new Activity();
            var query = HCMIS.Repository.Queries.Activity.SelectGetAllWithTextID();
            stores.LoadFromRawSql(query);
            return stores.DataTable;
        }

        /// <summary>
        /// Gets the account tree.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        
        public static DataView GetAccountTree(int userID)
        {
            var query = HCMIS.Repository.Queries.Activity.SelectGetAccountTree(userID);
            return SqlClient.Run(query);
        }
  
        public static DataView GetTreeByItem(int ItemID, int UserID)
        {

            return SqlClient.Run( HCMIS.Repository.Queries.Activity.SelectTreeByItem(ItemID, UserID));
        }

        public static DataView GetActivitiesForItem(int itemID, int unitID, int userID)
        {
            return SqlClient.Run(HCMIS.Repository.Queries.Activity.SelectByItemAndUnit(itemID, unitID, userID));
        }

        #endregion
    }
}