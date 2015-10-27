using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class vwReceiptPallet
    {
        public int ID { get; set; }
        public Nullable<int> ReceiveDocID { get; set; }
        public Nullable<long> BalanceBU { get; set; }
        public Nullable<long> ReceivedQuantityBU { get; set; }
        public Nullable<int> QtyPerPack { get; set; }
        public Nullable<long> ReceivedPacks { get; set; }
        public Nullable<long> Packs { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string FullItemName { get; set; }
        public Nullable<int> PalletID { get; set; }
        public int PalletLocationID { get; set; }
        public string Label { get; set; }
        public string PhysicalStoreName { get; set; }
        public string WarehouseName { get; set; }
        public string ClusterName { get; set; }
        public int PhyicalStoreID { get; set; }
        public int WarehouseID { get; set; }
        public int ClusterID { get; set; }
        public Nullable<int> StorageTypeID { get; set; }
        public int ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
        public int ItemUnitID { get; set; }
        public string ItemUnitName { get; set; }
        public int ActivityID { get; set; }
        public string ActivityName { get; set; }
        public Nullable<int> SubAccountID { get; set; }
        public string SubAccountName { get; set; }
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public Nullable<int> ModeID { get; set; }
        public Nullable<int> CommodityTypeID { get; set; }
        public string CommodityTypeName { get; set; }
        public string StockCode { get; set; }
    }
}
