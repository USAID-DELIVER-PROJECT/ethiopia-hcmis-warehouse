using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
   
    public class StorageType
    {
         [SelectQuery]
        public static string SelectLoadPrimaryStorageTypes(string quaranteen)
        {
            string query = String.Format("select * from StorageType where IsSubTypeOf is null and ID <> {0}", quaranteen);
            return query;
        }

        public static string SelectLoadByPhysicalStoreID(int physicalStoreID)
        {
            string query = String.Format("Select * from StorageType st where st.ID in (Select ShelfStorageType from shelf where StoreID={0})", physicalStoreID);
            return query;
        }
        public static string SelectDistictStoreTypeForPhysicalStore(int physicalStoreID)
        {
            string query = String.Format(@"select Distinct st.StorageTypeID,st.Name TypeName 
                                            from InventoryManagement.SectionUnit su
                                                  join PalletLocation pl on pl.ShelfID = su.SectionUnitID
                                                  join InventoryManagement.StorageType st on pl.StorageTypeID= st.StorageTypeID 
                                            where PhysicalStoreID = {0} and st.StorageTypeCode <> 'SA'
                                                                    ", physicalStoreID);
            return query;
        }
    }
}
