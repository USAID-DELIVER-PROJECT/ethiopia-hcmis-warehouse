
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using HCMIS.Extensions;
using HCMIS.Extensions.Binding;
using HCMIS.Extensions.Services;
using HCMIS.Warehouse.Models;
using HCMIS.Enums;
using InventoryStatus = HCMIS.Warehouse.Models.InventoryStatus;
using OrderStatus = HCMIS.Warehouse.Models.OrderStatus;
using ReceiptConfirmationStatus = HCMIS.Warehouse.Models.ReceiptConfirmationStatus;
using ShortageReasons = HCMIS.Warehouse.Models.ShortageReasons;


namespace HCMIS.Desktop.Helpers
{
    class DefaultBindingManager : BindingManager
    {
        public override void Load()
        {
            Bind<Mode>().To<Modes>();  
            Bind<ABC>().To<ABCs>();    
            Bind<VEN>().To<VENs>();
            Bind<DocumentType>().To<DocumentTypes>(); 
            Bind<InstitutionType>().To<InstitutionTypes>();
            Bind<OwnershipType>().To<OwnershipTypes>();
            Bind<PaymentType>().To<PaymentTypes>();
            Bind<HCMIS.Warehouse.Models.OrderStatus>().To<HCMIS.Enums.OrderStatus>();
            Bind<HCMIS.Warehouse.Models.ReceiptConfirmationStatus>().To<HCMIS.Enums.ReceiptConfirmationStatus>();
            Bind<ReceiptType>().To<ReceiptTypes>();
            Bind<HCMIS.Warehouse.Models.ShortageReasons>().To<HCMIS.Enums.ShortageReasons>();
            Bind<RequisitionType>().To<RequisitionTypes>();
            Bind<TransferType>().To<TransferTypes>();
            Bind<HCMIS.Warehouse.Models.InventoryStatus>().To<HCMIS.Enums.InventoryStatus>();
            Bind<Activity>().To<Activities>();
            Bind<OrderType>().To<OrderTypes>();
            Bind<PurchaseOrderType>().To<PurchaseOrderTypes>();
            Bind<PurchaseOrderParentType>().To<PurchaseOrderParentTypes>();
            Bind<InvoiceType>().To<InvoiceTypes>();
            Bind<InstitutionIType>().To<InstitutionITypes>();
            Bind<CommodityType>().To<CommodityTypes>();
            Bind<HCMIS.Warehouse.Models.SupplierType>().To<SupplierTypes>();

            Map<Modes>().SetSchemaName("Account").SetTableName("Mode");
            Map<ABCs>().SetSchemaName("Commodity").SetTableName("ABC");
            Map<VENs>().SetSchemaName("Commodity").SetTableName("VEN");
            Map<DocumentTypes>().SetSchemaName("MessageBroker").SetTableName("DocumentType").SetCodeColumn("DocumentTypesCode");
            Map<InstitutionTypes>().SetTableName("InstitutionType").SetIdColumn("ID");
            Map<InstitutionITypes>().SetTableName("InstitutionIType");
            Map<OwnershipTypes>().SetTableName("OwnershipType").SetIdColumn("ID");
            Map<PaymentTypes>().SetTableName("PaymentType").SetIdColumn("ID"); ;
            Map<Enums.OrderStatus>().SetTableName("OrderStatus").SetIdColumn("ID").SetNameColumn("OrderStatus");
            Map<Enums.ReceiptConfirmationStatus>().SetTableName("ReceiptConfirmationStatus").SetIdColumn("ID");
            Map<ReceiptTypes>().SetTableName("ReceiptType").SetIdColumn("ID");
            Map<Enums.ShortageReasons>().SetTableName("ShortageReasons").SetIdColumn("ID");
            Map<RequisitionTypes>().SetTableName("RequisitionType");
            Map<TransferTypes>().SetTableName("TransferType").SetIdColumn("ID");
            Map<Enums.InventoryStatus>().SetSchemaName("InventoryManagement").SetTableName("InventoryStatus");
            Map<Activities>().SetSchemaName("Account").SetTableName("Activity");
            Map<OrderTypes>().SetTableName("OrderType");
            Map<PurchaseOrderTypes>().SetSchemaName("Procurement").SetTableName("PurchaseOrderType");
            Map<PurchaseOrderParentTypes>().SetSchemaName("Procurement").SetTableName("PurchaseOrderParentType");
            Map<InvoiceTypes>().SetTableName("InvoiceType").SetIdColumn("ID");
            Map<CommodityTypes>().SetTableName("CommodityType").SetIdColumn("ID");

        }
    }

    public class WarehouseContext : DbContext,ILookupRepository
    {
        private IEnumerable<LookUpModel> _lookUpModels;

        public WarehouseContext(string connectionstring):base(connectionstring)
        {
            
        }

        #region Lookup Models DbSets

        public DbSet<Mode> Modes { get; set; }
        public DbSet<ABC> ABCs { get; set; }
        public DbSet<VEN> VENs { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<InstitutionType> InstitutionTypes { get; set; }
        public DbSet<OwnershipType> OwnershipTypes { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<ReceiptConfirmationStatus> ReceiptConfirmationStatus { get; set; }
        public DbSet<ReceiptType> ReceiptTypes { get; set; }
        public DbSet<ShortageReasons> ShortageReasons { get; set; }
        public DbSet<RequisitionType> RequisitionTypes { get; set; }
        public DbSet<InventoryStatus> InventoryStatus { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<TransferType> TransferTypes { get; set; }
        public DbSet<InventoryPeriod> InventoryPeriods { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<PurchaseOrderType> PurchaseOrderTypes { get; set; }
        public DbSet<PurchaseOrderParentType> PurchaseOrderParentTypes { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }
        public DbSet<InstitutionIType> InstitutionITypes { get; set; }
        public DbSet<CommodityType> CommodityTypes { get; set; }

        public DbSet<SupplierType> SupplierTypes { get; set; } 


        #endregion


        #region Implementation of ILookupRepository

        public IQueryable<TType> Get<TType>() where TType : class
        {
            return Set<TType>();
        }

        public ICollection<LookUpModel> GetLookups<TEnum>(EnumDescriptor enumDescriptor) where TEnum : IConvertible
        {
            return _lookUpModels.Where(s => s.SchemaName == enumDescriptor.SchemaName&& s.TableName == enumDescriptor.TableName).ToList();
        }

        public ICollection<LookUpModel> GetLookups<TEnum>() where TEnum : IConvertible
        {
            var enumDescriptor = BindingManager.GetEnumDescriptor<TEnum>();

            if (_lookUpModels == null) CacheAllLookups();

            return _lookUpModels != null
                ? _lookUpModels.Where(
                    s => s.SchemaName == enumDescriptor.SchemaName && s.TableName == enumDescriptor.TableName).ToList()
                : null;

        }

        private void CacheAllLookups()
        {
            var query = "";
            foreach (var enumDiscriptor in BindingManager.EnumDescriptors.Values)
            {
                query += String.Format(" Select '{3}' SchemaName,'{4}' TableName , {0} ID,{1} Name,{2} Code from {3}.{4} ",
                    enumDiscriptor.ID,
                    enumDiscriptor.Name,
                    enumDiscriptor.Code,
                    enumDiscriptor.SchemaName,
                    enumDiscriptor.TableName);
                query += (BindingManager.EnumDescriptors.Values.Last() == enumDiscriptor) ? "" : "UNION";
            }

            //~ Insted Of -> var data = Database.SqlQuery<LookUpModel>(query);  lets use doodads as it is match faster ~//
          
            var data =  QueryHelper.RunQuery(query)
                   .Table.AsEnumerable()
                   .Select(
                       row =>
                           new LookUpModel
                           {
                               SchemaName = row["SchemaName"].ToString(),
                               TableName = row["TableName"].ToString(),
                               ID = Convert.ToInt32(row["ID"]),
                               Name = row["Name"].ToString(),
                               Code = row["Code"].ToString()
                           }).ToList();

            _lookUpModels = data.ToList();
        }

        #endregion

        public BindingManager BindingManager { get; set; }
    }
}
