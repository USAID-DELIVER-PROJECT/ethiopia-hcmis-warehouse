using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class InstitutionType
    {
        [SelectQuery]
        public static string SelectGetReceivingUnitTypeByRegionAndNumberRU(int WoredaID, int OwnershipID)
        {
            string query =
                String.Format(
                    @"Select rt.ID,rt.Name,rt.Name+ ' (' + CAST(COUNT(ru.ID) as varchar) + ')' as Count from  Institution ru Join InstitutionType rt  on rt.ID = ru.RUType
                                        WHERE ru.Woreda= {0} and Ownership ={1}
                                        Group by rt.ID,rt.Name
                                        Union
                                        Select rt.ID,rt.Name,rt.Name +'(0)' Count from InstitutionType rt
                                            where rt.ID  Not In (
                                        Select Distinct ru.RUType from  Institution ru  WHERE ru.Woreda= {0} and Ownership ={1})",
                    WoredaID, OwnershipID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetReceivingUnitTypeByRegionAndNumberRUByStore(int WoredaID, int storeID)
        {
            return String.Format(@"Select rt.ID,rt.Name,rt.Name+ ' (' + CAST(COUNT(ru.ID) as varchar) + ')' as Count from  Institution ru Join InstitutionType rt  on rt.ID = ru.RUType
                                        WHERE ru.Woreda = {0} and ru.ID in (select ReceivingUnitID from IssueDoc where StoreID={1})
                                        Group by rt.ID,rt.Name
                                        ", WoredaID, storeID);
        }
    }
}
