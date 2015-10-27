using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class Supplier
    {
        public static string SelectGetSuppliersWithTransaction()
        {
            string query = String.Format("SELECT * FROM Supplier WHERE ID IN (SELECT SupplierID FROM ReceiveDoc)");
            return query;
        }

        public static string SelectGetAllSuppliersFor(int ItemID, int unitID)
        {
            string query = String.Format("select * from Supplier where ID in (select distinct SupplierID from ReceiveDoc where ItemID = {0} and UnitID={1}) order by CompanyName", ItemID, unitID);
            return query;
        }

        public static string SelectGetList()
        {
            string query = String.Format("select * from Supplier order by CompanyName");
            return query;
        }

        public static string SelectGetAllSuppliersWithCountry()
        {
            string query = string.Format(@"select Supplier.*, Country.ShortName CountryName, Country.* from Supplier 
                                           join Country on Supplier.CountryID = Country.CountryID ");
            return query;
        }

        public static string SelectIsHomeOffice(int supplierID, string environmentGroupCode)
        {
            string query = string.Format(@"Select s.SupplierID from Commodity.Supplier s
                                            Join Commodity.SupplierType st on s.SupplierTypeID = st.SupplierTypeID
                                            Join Usm.Environment e on e.rowguid = s.rowguid
                                            Join Usm.EnvironmentGroup eg on e.EnvironmentGroupID = eg.EnvironmentGroupID
                                            Where s.SupplierID = {0} and st.SupplierTypeCode = 'HO' and eg.EnvironmentGroupCode = '{1}'",
                supplierID, environmentGroupCode);
            return query;
        }

        public static string SelectHomeOffice(string environmentGroupCode)
        {
            string query = string.Format(@"Select s.SupplierID from Commodity.Supplier s
                                            Join Commodity.SupplierType st on s.SupplierTypeID = st.SupplierTypeID
                                            Join Usm.Environment e on e.rowguid = s.rowguid
                                            Join Usm.EnvironmentGroup eg on e.EnvironmentGroupID = eg.EnvironmentGroupID
                                            Where st.SupplierTypeCode = 'HO' and eg.EnvironmentGroupCode = '{0}'",environmentGroupCode);
            return query;
        }

        public static string SelectDirectDeliverySuppliers()
        {
            string query =
                string.Format(@"select s.SupplierID ID,s.*, Country.ShortName CountryName, Country.* from Commodity.Supplier s
                                JOIN Country on s.CountryID = Country.CountryID
                                JOIN Commodity.SupplierType st ON s.SupplierTypeID = St. SupplierTypeID
                                where  st.SupplierTypeCode = 'ES' and s.isactive = 1 and s.isdirectdelivery = 1 ");
                                            return query;
        }

        public static string SelectSuppliersByPOType(int poTypeID)
        {
            string query = string.Format(@"Select s.SupplierID ID,s.*, s.Name CompanyName, Country.ShortName CountryName, Country.* 
                                            FROM Procurement.SupplierTypePOType stpt
                                            JOIN Commodity.SupplierType st on stpt.SupplierTypeID = st.SupplierTypeID
                                            JOIN Procurement.PurchaseOrderType pot on Stpt.PurchaseOrderTypeID =  POT.PurchaseOrderTypeID
                                            JOIN Commodity.Supplier s on st.SupplierTypeID = s.SupplierTypeID 
                                            JOIN Country on s.CountryID = Country.CountryID
                                            WHERE pot.isactive = 1 and st.isactive = 1 and pot.PurchaseOrderTypeID = {0}
                                            ORDER by s.Name", poTypeID);
            return query;
        }

        public static string SelectGetHubHeadOffice()
        {
            string query = string.Format(@"select s.* from commodity.Supplier s
                                                join commodity.suppliertype st on s.suppliertypeid = st.suppliertypeid
                                                join usm.environment e on s.rowguid = e.rowguid
                                                join usm.environmentgroup eg on e.environmentGroupid = eg.environmentgroupid                                                                                                
                                                Where st.SupplierTypeCode = 'HO' and eg.EnvironmentGroupCode = 'hub'");
            return query;
        }
    }
}
