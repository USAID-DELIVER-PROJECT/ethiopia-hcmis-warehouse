using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class OwnershipType
    {
        public static string SelectGetOwnershipTypeByRegionAndNumberRU(int WoredaID)
        {
            string query = String.Format(@"Select ot.ID,ot.Name,ot.Name+ ' (' + CAST(COUNT(ru.ID) as varchar) + ')' as Count from  Institution ru Join OwnershipType ot  on ot.ID = ru.Ownership
                                            WHERE ru.Woreda={0} 
                                            Group by ot.ID,ot.Name
                                            Union
                                            Select ot.ID,ot.Name,ot.Name +'(0)' Count from OwnershipType ot
                                            where ot.ID  Not In (
                                            Select Distinct ru.Ownership from  Institution ru WHERE ru.Woreda={0} )", WoredaID);
            return query;
        }

        public static string SelectGetOwnershipTypeByRegionAndNumberRU(int receivingUnitTypeID, int storeID)
        {
            string query = String.Format(@"Select ot.ID,ot.Name,ot.Name+ ' (' + CAST(COUNT(ru.ID) as varchar) + ')' as Count from  Institution ru Join OwnershipType ot  on ot.ID = ru.Ownership
                                            WHERE ru.RUType={0} and ru.ID in (select ReceivingUnitID from IssueDoc where StoreID={1})
                                            Group by ot.ID,ot.Name ", receivingUnitTypeID, storeID);
            return query;
        }
    }
}
