using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class vwPallet
    {
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
    }
}
