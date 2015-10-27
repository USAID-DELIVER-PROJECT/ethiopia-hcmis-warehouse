using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class Institution
    {
        [SelectQuery]
        public static string SelectGetApplicableDUs(int itemId, int storeId)
        {
            return String.Format("Select * from Institution where ID  in (Select ReceivingUnitID from IssueDoc where StoreID = {1} AND ItemID = {0})", itemId, storeId);
        }

        [SelectQuery]
        public static string SelectGetReceivingUnitsByZone(int zoneID)
        {
            string query = String.Format("Select * from Institution where Zone={0} and Active = 1  and IsUsedAtFacility = 1 ",
                zoneID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetDistinctInstitutionForIssueDetail()
        {
            string query = String.Format(@"select Distinct i.ID,i.Name 
                                            from IssueDoc id join Institution i on id.ReceivingUnitID = i.ID
                                            where i.Active = 1
                                            order by Name ");
            return query;
        }

        [SelectQuery]
        public static string SelectGetReceivingUnitsByTypeID(int TypeID)
        {
            string query = String.Format("Select * from Institution where RUType={0} and Active = 1 and IsUsedAtFacility = 1 ",
                TypeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetAllReceivingUnits()
        {
            string query = String.Format("Select * from Institution where Active = 1 and IsUsedAtFacility = 1 ");
            return query;
        }

        [SelectQuery]
        public static string SelectGetFacilitiesThatEverReceivedItems()
        {
            return String.Format("Select * from Institution where ID  in (Select ReceivingUnitID from IssueDoc )");
        }

        [SelectQuery]
        public static string SelectGetApplicableDUsAll(int itemId)
        {
            return String.Format("Select * from Institution where ID  in (Select ReceivingUnitID from IssueDoc where ItemID = {0})", itemId);
        }

        [SelectQuery]
        public static string SelectLoadAll()
        {
            string query =
                @"select i.*,w.ID WoredaID,w.WoredaName,z.ID ZoneID,z.ZoneName,rg.ID RegionID,rg.RegionName,it.ID InstitutionTypeID,it.Name InstitutionTypeName,r.Name as RouteName,ot.ID OwnershipID, ot.Name OwnershipName
                                from Institution i 
                                left join [Route] r on i.[Route]= r.RouteID 
                                Join Woreda w on i.Woreda = w.ID
                                join Zone z on w.ZoneID = z.ID
                                join Region rg on z.regionID = rg.ID
                                Join InstitutionType it on i.RUType = it.ID
                                join OwnershipType ot on i.Ownership = ot.ID
                                where i.Active = 1  and i.IsUsedAtFacility = 1  order by i.Name";
            return query;
        }

        [SelectQuery]
        public static string SelectLoadAllActive()
        {
            string query =
                "select *, r.Name as RouteName from Institution ru left join Route r on ru.Route = r.RouteID  where ru.Active = 1  order by ru.Name";
            return query;
        }

        [SelectQuery]
        public static string SelectGetAllHubs()
        {
            string query = String.Format("select * from HUB order by ID");
            return query;
        }

        [SelectQuery]
        public static string SelectGetAllUnderRoute(int route)
        {
            string query =
                String.Format(
                    "select * from Institution where Route = {0} and Active = 1  and IsUsedAtFacility = 1  order by Name", route);
            return query;
        }

        [SelectQuery]
        public static string SelectGetTopReceivingUnits()
        {
            string query =
                @"select  MAX(rus.ID) ID, MAX(rus.Name) FacilityName , COUNT(*) NumberOfRefills from (select distinct Date,ReceivingUnitID from IssueDoc) a join Institution rus on a.ReceivingUnitID = rus.ID group by ReceivingUnitID order by COUNT(*) Desc";
            return query;
        }

        [SelectQuery]
        public static string SelectGetResupplyPerUnit(int recievingUnitID)
        {
            string query =
                String.Format(@"SELECT *
                                 FROM (
                                select v.FullItemName, a.* from (select ItemID,Month([Date])[Month],SUM(Quantity/QtyPerPack) QuantityIssued from IssueDoc where ReceivingUnitID= {0} group by MONTH([Date]),ItemID ) a join vwGetAllItems v on a.ItemID = v.ID 
                                )
                                AS PivotData
                                  PIVOT (
                                    max(QuantityIssued)
                                    FOR [Month] IN ([11],[12],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10]
                                    )
                                  ) AS PivotTable order by FullItemName", recievingUnitID);
            return query;
        }

        [UpdateQuery]
        public static string UpdateSwapReceivingUnitsOrder(int receivingUnitID, int receivingUnitIDTarget)
        {
            string query = String.Format("update [Order] Set RequestedBy={0} WHERE RequestedBy={1}", receivingUnitIDTarget,
                receivingUnitID);
            return query;
        }

        [UpdateQuery]
        public static string UpdateSwapReceivingUnitsIssueDoc(int receivingUnitID, int receivingUnitIDTarget)
        {
            var query = String.Format("update [IssueDoc] Set ReceivingUnitID={0} WHERE ReceivingUnitID={1}", receivingUnitID,
                receivingUnitIDTarget);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadReceivingUnitByFilter(int woredaID, int zoneID, int ruType, int ownershipType, int activeStatus, bool hasBeenIssuedTo, bool inProcess)
        {
            string activeStatusString;
            if ((activeStatus == -1) && (!inProcess))
                activeStatusString = "";
            else if ((activeStatus != -1) && (inProcess))
                activeStatusString = String.Format("and Active = '{0}' and InProcess = '{1}'", activeStatus, inProcess);
            else if (activeStatus != -1)
                activeStatusString = String.Format("and Active = '{0}'", activeStatus);
            else
                activeStatusString = String.Format("and InProcess = '{0}'", inProcess);

            string issuedTo = "";
            if (hasBeenIssuedTo)
            {
                issuedTo = String.Format(" and ru.ID in (select ReceivingUnitID from IssueDoc)");
            }

            string query = String.Format(@"SELECT ru.ID
                                                        ,ROW_NUMBER() OVER(ORDER BY ru.Name) No
							                            ,ru.Name
							                            ,rut.Name RUType
                                                        ,ot.Name Ownership
                                                        ,RegionName
                                                        ,ZoneName
                                                        ,WoredaName  
                                                        ,ro.Name RouteName                    
                                                        ,Active
                                                        ,InProcess
                                                FROM Institution  ru
                                                        Inner join Woreda wo on wo.ID = ru.Woreda
                                                        Inner join Zone zo on zo.ID = wo.ZoneID
                                                        Inner join Region re on re.ID = zo.RegionId
                                                        Inner join InstitutionType rut on rut.ID = ru.RUType
                                                        Inner join OwnershipType ot on ot.ID = ru.Ownership
                                                        Inner join Route ro on ro.RouteID = ru.Route
                                                WHERE ru.Woreda={0} and ru.Zone={1} and ru.Ownership={2} and ru.RUType={3} {4}
                                                            " + activeStatusString, woredaID, zoneID, ownershipType,
                ruType, issuedTo);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadReceivingUnitByFilterByName(int woredaID, int zoneID, int ruType, int ownershipType, int activeStatus, bool hasBeenIssuedTo, bool inProcess, int storeID)
        {
            string activeStatusString;
            if ((activeStatus == -1) && (!inProcess))
                activeStatusString = "";
            else if ((activeStatus != -1) && (inProcess))
                activeStatusString = String.Format("and Active = '{0}' and InProcess = '{1}'", activeStatus, inProcess);
            else if (activeStatus != -1)
                activeStatusString = String.Format("and Active = '{0}'", activeStatus);
            else
                activeStatusString = String.Format("and InProcess = '{0}'", inProcess);

            string issuedTo = "";
            if (hasBeenIssuedTo)
            {
                issuedTo = String.Format(" and ru.ID in (select ReceivingUnitID from IssueDoc where StoreID={0})", storeID);
            }

            string query = String.Format(@"SELECT ru.ID
                                                        ,ROW_NUMBER() OVER(ORDER BY ru.Name) No
							                            ,ru.Name
							                            ,rut.Name RUType
                                                        ,ot.Name Ownership
                                                        ,RegionName
                                                        ,ZoneName
                                                        ,WoredaName  
                                                        ,ro.Name RouteName                    
                                                        ,Active
                                                        ,InProcess
                                                FROM Institution  ru
                                                        Inner join Woreda wo on wo.ID = ru.Woreda
                                                        Inner join Zone zo on zo.ID = wo.ZoneID
                                                        Inner join Region re on re.ID = zo.RegionId
                                                        Inner join InstitutionType rut on rut.ID = ru.RUType
                                                        Inner join OwnershipType ot on ot.ID = ru.Ownership
                                                        Inner join Route ro on ro.RouteID = ru.Route
                                                WHERE ru.Woreda={0} and ru.Zone={1} and ru.Ownership={2} and ru.RUType={3} {4}
                                                            " + activeStatusString, woredaID, zoneID, ownershipType,
                ruType, issuedTo);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadReceivingUnitByFilter(string name)
        {
            string filterQuery = String.Format(@"SELECT  ru.ID
							                ,ROW_NUMBER() OVER(ORDER BY ru.Name) No
                                            ,ru.Name
							                ,rut.Name RUType
                                            ,ot.Name Ownership
                                            ,RegionName
                                            ,ZoneName
                                            ,WoredaName                     
                                            ,Active
                                            ,InProcess
                                    FROM Institution  ru
                                           Inner join Woreda wo on wo.ID = ru.Woreda
                                           Inner join Zone zo on zo.ID = wo.ZoneID
                                           Inner join Region re on re.ID = zo.RegionId
                                           Inner join InstitutionType rut on rut.ID = ru.RUType
                                           Inner join OwnershipType ot on ot.ID = ru.Ownership
                                     WHERE ru.Name Like '{0}%'", name);
            return filterQuery;
        }

        [SelectQuery]
        public static string SelectLoadHubs(int hub)
        {
            string filterQuery = String.Format(@"SELECT  ru.ID      
                                            ,ru.Name
                                            ,ru.Active
                                    FROM Institution  ru
                                    WHERE  ru.RUType = {0}", hub);
            return filterQuery;
        }

        [SelectQuery]
        public static string SelectgetOtherID()
        {
            string filterQuery = String.Format(@"SELECT  ru.ID      
                                    FROM Institution  ru
                                    WHERE  ru.RUType = {0}", 9);
            return filterQuery;
        }

        [SelectQuery]
        public static string SelectValidateNewAddition(string facilityName, int woredaID)
        {
            string query = String.Format("select * from Institution where Name='{0}' and Woreda={1}", facilityName,
                woredaID);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadReceivingUnitByFilter(int woredaID)
        {
            string query =
                String.Format(
                    "select inst.Name InstitutionName, t.Name TypeName from institution inst join InstitutionType t on inst.rutype = t.id where inst.woreda = {0} order by t.name, inst.name ",
                    woredaID);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadAllActiveForDeliverySettingsPage()
        {
            string query =
                "select ru.*,w.WoredaName, z.ZoneName, reg.RegionName from Institution ru JOIN Woreda w on ru.Woreda = w.ID JOIN Zone z on w.ZoneID = z.ID JOIN Region reg on z.RegionID = reg.ID left join Route r on ru.Route = r.RouteID  where ru.Active = 1  order by ru.Name";
            return query;
        }

        [SelectQuery]
        public static string SelectLoadBySN(int facilityID)
        {
            string query = String.Format(@"select * From Institution where SN = {0}", facilityID);
            return query;
        }


        [SelectQuery]
        public static string SelectInstitutionByID(int id)
        {
            string query = String.Format(
@"select i.*,w.ID WoredaID,w.WoredaName,z.ID ZoneID,z.ZoneName,rg.ID RegionID,rg.RegionName,it.ID InstitutionTypeID,it.Name InstitutionTypeName,r.Name as RouteName 
                                from Institution i 
                                left join [Route] r on i.[Route]= r.RouteID 
                                left Join Woreda w on i.Woreda = w.ID
                                left join Zone z on w.ZoneID = z.ID
                                left join Region rg on z.regionID = rg.ID
                                
                                Join InstitutionType it on i.RUType = it.ID
                                where i.ID = {0}", id);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemFacilityDistribution(int ModeID, string StartDate, string EndDate, int RegionID = -1, int ZoneID = -1, int WoredaID = -1)
        {
            var query = @"DECLARE @ModeID INT = {0}
DECLARE @StartDate DATE = '{1}'
DECLARE @EndDate DATE = '{2}'                        
DECLARE @RegionID INT = {3}
DECLARE @ZoneID INT = {4}                                                     
DECLARE @WoredaID INT = {5}          
SELECT  vwg.FullItemName Item ,
        iu.Text Unit ,
        SUM(id.Quantity) Quantity ,
        i.Name Facility ,
        r.RegionName Region ,
        z.ZoneName Zone ,
        w.WoredaName Woreda ,
        SUM(id.Cost) / SUM(id.Quantity) UnitCost,
		SUM(id.Cost) Cost
FROM    IssueDoc id
        JOIN vwGetAllItems vwg ON id.ItemID = vwg.ID
        JOIN ItemUnit iu ON id.UnitID = iu.ID
        JOIN Institution i ON id.ReceivingUnitID = i.ID
        JOIN Woreda w ON i.Woreda = w.ID
        JOIN Zone z ON w.ZoneID = z.ID
        JOIN Region r ON z.RegionID = r.ID
        JOIN vwAccounts vwa ON vwa.ActivityID = id.StoreID
WHERE   ( w.ID = @WoredaID
          OR @WoredaID = -1
        )
        AND ( z.ID = @ZoneID
              OR @ZoneID = -1
            )
        AND ( R.ID = @RegionID
              OR @RegionID = -1
            )
        AND ( vwa.ModeID = @ModeID
              OR @ModeID = -1
            )
        AND id.EurDate BETWEEN @StartDate AND @EndDate
GROUP BY vwg.FullItemName ,
        iu.Text ,
        i.Name ,
        r.RegionName ,
        z.ZoneName ,
        w.WoredaName 
ORDER BY vwg.FullItemName ,
        iu.Text ,
        i.Name ,
        r.RegionName ,
        z.ZoneName ,
        w.WoredaName";
            return String.Format(query, ModeID, StartDate, EndDate, RegionID, ZoneID, WoredaID);
        }
    }
}
