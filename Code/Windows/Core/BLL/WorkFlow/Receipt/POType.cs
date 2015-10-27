using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BLL.WorkFlow.Receipt;
using DAL;

namespace BLL
{

    public class POType:_PurchaseOrderType
    {
        public POType()
        {
        }

         // THIS CLASS HAS TO BE DELETED:  there is already PurchaseOrderType class on BLL newly Added.
         /*
              1     FOB                     FOB
              2     Cost and Freight        CSFR
              3     CIP                     CIP
              4     Cost and Estimated 2    CEFR
              5     Long Term Contract      LTC
              6     Consignment             CNS
              7     Donation                DNT
              8     Inventory               INVT
              9     Internal                INTR
        */
        #region CONSTANTS

            public static int FOB;            
            public static int COST_AND_FREIGHT; 
            public static int CIP;       
            public static int COST_AND_EST_FREIGHT;
            public static int LONG_TERM; 
            public static int CONSIGNMENT;           
            public static int DONATION;
            public static int INVENTORY;  
            public static int INTERNAL;
            public static int MANUAL_DELIVERYNOTE;
            public static int DIRECT_VENDOR_TRANSFER;
            public static int E_PURCHASE_ORDER;
            public static int INTERNAL_TRANSFER;
            public static int ACCOUNT_TO_ACCOUNT_TRANSFER;
            public static int HUB_TO_HUB_TRANSFER;
            public static int STORE_TO_STORE_TRANSFER;
            public static int ERROR_CORRECTION_TRANSFER;
            public static int STOCK_RETURN_MEMO;

            //Modes
        
            public static int STANDARD;
            public static int NON_STANDARD;
            public static int HUB_ONLY;
     
        #endregion
  


        public static int GetModes(int POTypeID)
        {
            var poType = new POType();
            poType.LoadByPrimaryKey(POTypeID);
            return poType.ParentPurchaseOrderTypeID;
        }

        public static string GetPOTypeNameByID(int id)
        {
            var poType = new POType();
            poType.Where.PurchaseOrderTypeID.Value = id;
            poType.SchemaTableView = "Procurement].[";
            poType.Query.Load();
            poType.SchemaTableView = "";
            return poType.Name;
        }


        public static List<PurchaseOrderType> GetAllPOTypes()

        {
            var query = HCMIS.Repository.Queries.PurchaseOrderType.SelectGetAllPOTypes();
            var poType = new POType();
            poType.LoadFromRawSql(query);
            var potypes = poType.DataTable.AsEnumerable().Select(dr => new PurchaseOrderType
            {
                ID = Convert.ToInt32(dr.Field<int>("PurchaseOrderTypeID")),
                Name = dr.Field<string>("Name"),
                Group = dr.Field<string>("Group")
            }).ToList();

            return potypes;
        }

        public static int PurchaseOrderType(string code)
        {
            var poType = new POType();
            poType.Where.PurchaseOrderTypeCode.Value = code;
            poType.SchemaTableView = "Procurement].[";
            poType.Query.Load();
            poType.SchemaTableView = "";
            return poType.PurchaseOrderTypeID;
        }

        public static List<PurchaseOrderType> GetAllPOTypesForHub()
        {
            var query = HCMIS.Repository.Queries.PurchaseOrderType.SelectGetAllHubPOType();
            var poType = new POType();
            poType.LoadFromRawSql(query);
            var poTypes = poType.DataTable.AsEnumerable().Select(dr => new PurchaseOrderType
            {
                ID = Convert.ToInt32(dr.Field<int>("PurchaseOrderTypeID")),
                Name = dr.Field<string>("Name"),
                Group = dr.Field<string>("Group")
            }).ToList();

            return poTypes;
        }

        public static int GetPurchaseOrderTypeID(string code)
        {
            var poType = new POType();
            poType.Where.PurchaseOrderTypeCode.Value = code;
            poType.SchemaTableView = "Procurement].[";
            poType.Query.Load();
            poType.SchemaTableView = "";
            return poType.PurchaseOrderTypeID;
        }

    }
}