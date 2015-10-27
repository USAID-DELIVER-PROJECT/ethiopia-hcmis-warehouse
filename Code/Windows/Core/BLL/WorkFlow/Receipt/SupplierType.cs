using System.Data;
using DAL;

namespace BLL
{
    public class SupplierType 
    {
        public static class CONSTANTS
        {
            public static int HOME_OFFICE;
            public static int HUBS;
            public static int FACILITIES;
            public static int ACCOUNTS;
            public static int STORES;
            public static int EXTERNAL_SUPPLIERS;
        }



        //public static DataTable GetSupplierTypes()
        //{
        //    var supplierType = new SupplierType();
        //    supplierType.LoadAll();
        //    return supplierType.DataTable;
        //}
    }
}
