using DAL;
using System.Data;

namespace BLL
{
	public class PhysicalStore : _PhysicalStore
	{
        /// <summary>
        /// Does the before save.
        /// </summary>
	    public void DoBeforeSave()
        {
            this.Rewind();
            while (!this.EOF)
            {
                if (IsColumnNull("Height"))
                {
                    Height = 0;
                }
                
                if (IsColumnNull("DoorSide"))
                {
                    DoorSide = 0;
                }
                if (IsColumnNull("DoorSize"))
                {
                    DoorSize = 0;
                }
               
                if (IsColumnNull("DistanceFromCornor"))
                {
                    DistanceFromCornor = 0;
                }
                if (IsColumnNull("Width"))
                {
                    Width = 0;
                }
                if (IsColumnNull("Length"))
                {
                    Length = 0;
                }
                this.MoveNext();
            }
        }

       
        public static object GetAllActive()
        {
            BLL.PhysicalStore phyStore = new PhysicalStore();
            phyStore.Where.IsActive.Value = true;
            phyStore.Query.Load();
            return phyStore.DataTable;
        }
        /// <summary>
        /// Loads for item.
        /// </summary>
        /// <param name="itemId">The item id.</param>
        /// <param name="storeID">The store ID.</param>
        /// <param name="unitID">The unit ID.</param>
        internal void LoadForItem(int userID, int itemId, int storeID, int unitID)
        {
            //string query = String.Format("select phy.* from  PhysicalStore phy where phy.ID in (select distinct(sh.StoreID) from PalletLocation pl join ReceivePallet rp on pl.PalletID=rp.PalletID join Shelf sh on pl.ShelfID=sh.ID where rp.ReceiveID in (select distinct ID from ReceiveDoc where QuantityLeft>0 and UnitID={1} and StoreID={2})) order by Name", itemId, unitID, storeID);
            string query =
                HCMIS.Repository.Queries.PhysicalStore.SelectLoadForItem(userID, itemId, storeID, unitID);
            this.LoadFromRawSql(query);
            string ins = "-1";
            while (!this.EOF)
            {
                ins += "," + this.ID;
                this.MoveNext();
            }
            query = HCMIS.Repository.Queries.PhysicalStore.LoadForItemOther(ins);
            this.LoadFromRawSql(query);
        }

	  


	    /// <summary>
        /// Gets the stores with warehouse and cluster.
        /// </summary>
        /// <returns></returns>
        public static DataView GetStoresWithWarehouseAndCluster()
        {
            string query = HCMIS.Repository.Queries.PhysicalStore.SelectGetStoresWithWarehouseAndCluster();
            BLL.PhysicalStore phStore = new PhysicalStore();
            phStore.LoadFromRawSql(query);
            return phStore.DefaultView;
        }


	    public static DataView GetStoresWithWarehouseAndCluster(int warehouseID)
        {
            string query =
                HCMIS.Repository.Queries.PhysicalStore.SelectGetStoresWithWarehouseAndCluster(warehouseID);
            BLL.PhysicalStore phStore = new PhysicalStore();
            phStore.LoadFromRawSql(query);
            return phStore.DefaultView;
        }

	

	    public static System.Data.DataView LoadByItemID(int ItemID, int UserID)
        {

            string query = HCMIS.Repository.Queries.PhysicalStore.SelectLoadByItemID(ItemID, UserID);
            PhysicalStore stores = new PhysicalStore();
            stores.LoadFromRawSql(query);
            return stores.DefaultView;

        }

	   

	    public static DataView GetWarehousesFor(int ItemID, int unitID, int activityID,int userID)
        {
            string query =
                HCMIS.Repository.Queries.PhysicalStore.SelectGetWarehousesFor(ItemID, unitID, activityID, userID);
            PhysicalStore stores = new PhysicalStore();
            stores.LoadFromRawSql(query);
            return stores.DefaultView;
        }

	  

	    public string WarehouseName
	    {
	        get
	        {
	            if(this.RowCount > 0 && !this.IsColumnNull("PhysicalStoreTypeID"))
	            {
	                Warehouse warehouse= new Warehouse();
	                warehouse.LoadByPrimaryKey(this.PhysicalStoreTypeID);
	                return warehouse.Name;
	            }
	            return "";
	        }
	    }

        public static DataTable GetPhysicalStoreStatus()
        {
            var physicalStore = new BLL.PhysicalStore();
            string query =
                HCMIS.Repository.Queries.PhysicalStore.SelectGetPhysicalStoreStatus();

            physicalStore.LoadFromRawSql(query);
            return physicalStore.DataTable;
        }

	    

	    public void UpdatePhysicalStoreStatusbyWarehouse(int warehouseID,bool IsActive)
        {
            var physicalStore = new BLL.PhysicalStore();
            string query =
                HCMIS.Repository.Queries.PhysicalStore.UpdateUpdatePhysicalStoreStatusbyWarehouse(warehouseID, IsActive);

            physicalStore.LoadFromRawSql(query);
            
        }


	    public void UpdatePhysicalStoreStatusbyCluster(int cluster, bool IsActive)
        {
            var physicalStore = new BLL.PhysicalStore();
            string query =
                HCMIS.Repository.Queries.PhysicalStore.UpdateUpdatePhysicalStoreStatusbyCluster(cluster, IsActive);

            physicalStore.LoadFromRawSql(query);

        }

	   

	    public static DataView GetAllowedPhysicalStoresForUser(int userId,bool isActive = false)
	    {
            
            string query =
                  HCMIS.Repository.Queries.PhysicalStore.SelectGetAllowedPhysicalStoresForUser(userId, isActive);
            PhysicalStore phStore = new PhysicalStore();
            phStore.LoadFromRawSql(query);
            return phStore.DefaultView;
	    }

	

	    public static PhysicalStore GetDefaultPhysicalStoreFor(int userId)
	    {
            string query =
                 HCMIS.Repository.Queries.PhysicalStore.SelectGetDefaultPhysicalStoreFor(userId);
            PhysicalStore phStore = new PhysicalStore();
            phStore.LoadFromRawSql(query);
            return phStore;
	    }

	 

	    public InventoryPeriod AddInventoryPeriod()
        {
           var inventoryPeriod = new InventoryPeriod();
            inventoryPeriod.AddNew();
            inventoryPeriod.PhysicalStoreID = this.ID;
            //ToDo: Remove hardCore
	        inventoryPeriod.InventoryStatusID = BLL.InventoryStatus.Constants.DraftInventorySaved;
            inventoryPeriod.StartDate = FiscalYear.Current.StartDate;
            inventoryPeriod.EndDate = FiscalYear.Current.EndDate;
            inventoryPeriod.Remark = "First Inventory";
            inventoryPeriod.FiscalYearID = FiscalYear.Current.ID;
            inventoryPeriod.Save();
            return inventoryPeriod;
        }

        public void LoadByPalletID(int palletID)
        {   
            var query = HCMIS.Repository.Queries.PhysicalStore.SelectPhysicalStoreByPalletID(palletID);
            this.LoadFromSql(query);

        }
        public void LoadByPalletLocationID(int palletLocationID)
        {
            var query = HCMIS.Repository.Queries.PhysicalStore.SelectPhysicalStoreByPalletLocationID(palletLocationID);
            this.LoadFromRawSql(query);
        }

        public void LoadAllPhysicalStoreswithClusterandWarehouseNames()
        {
            var query = HCMIS.Repository.Queries.PhysicalStore.SelectAllPhysicalStoreswithClusterandWarehouseNames();
            this.LoadFromRawSql(query);
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
	}
}