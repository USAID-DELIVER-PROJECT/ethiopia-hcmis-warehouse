using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using HCMIS.Concrete.Models.Mapping;

namespace HCMIS.Concrete.Models
{
	public class HcmisContext : DbContext
	{
		static HcmisContext()
		{
			Database.SetInitializer<HcmisContext>(null);
		}

		public HcmisContext()
			: base(ConnectionManager.ConnectionString)
		{
		}

		public DbSet<ABC> ABCs { get; set; }
		public DbSet<Balance> Balances { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ChangeLog> ChangeLogs { get; set; }
		public DbSet<Cluster> Clusters { get; set; }
		public DbSet<DirectoryUpdate> DirectoryUpdates { get; set; }
		public DbSet<DirectoryUpdateStatu> DirectoryUpdateStatus { get; set; }
		public DbSet<Disposal> Disposals { get; set; }
		public DbSet<DisposalReason> DisposalReasons { get; set; }
		public DbSet<DosageForm> DosageForms { get; set; }
		public DbSet<ErrorLog> ErrorLogs { get; set; }
		public DbSet<Exchange> Exchanges { get; set; }
		public DbSet<ExchangeType> ExchangeTypes { get; set; }
		public DbSet<GeneralInfo> GeneralInfoes { get; set; }
		public DbSet<HalfPalletLocation> HalfPalletLocations { get; set; }
		public DbSet<InternalTransfer> InternalTransfers { get; set; }
		public DbSet<IssueDoc> IssueDocs { get; set; }
		public DbSet<IssueDocDeleted> IssueDocDeleteds { get; set; }
		public DbSet<ItemManufacturer> ItemManufacturers { get; set; }
		public DbSet<ItemOwnershipType> ItemOwnershipTypes { get; set; }
		public DbSet<ItemPrefferedLocation> ItemPrefferedLocations { get; set; }
		public DbSet<ItemReceivingUnitType> ItemReceivingUnitTypes { get; set; }
		public DbSet<Item> Items { get; set; }
		public DbSet<ItemSupplier> ItemSuppliers { get; set; }
		public DbSet<ItemSupplyCategory> ItemSupplyCategories { get; set; }
		public DbSet<ItemUnit> ItemUnits { get; set; }
		public DbSet<ItemUnitCopy> ItemUnitCopies { get; set; }
		public DbSet<LoginLog> LoginLogs { get; set; }
		public DbSet<Manufacturer> Manufacturers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<OrderStatu> OrderStatus { get; set; }
		public DbSet<Pallet> Pallets { get; set; }
		public DbSet<PalletLocation> PalletLocations { get; set; }
		public DbSet<PaymentType> PaymentTypes { get; set; }
		public DbSet<PhysicalStore> PhysicalStores { get; set; }
		public DbSet<PhysicalStoreType> PhysicalStoreTypes { get; set; }
		public DbSet<PickFace> PickFaces { get; set; }
		public DbSet<PickList> PickLists { get; set; }
		public DbSet<PickListDetail> PickListDetails { get; set; }
		public DbSet<PO> POes { get; set; }
		public DbSet<PrintLog> PrintLogs { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductReceivingUnitType> ProductReceivingUnitTypes { get; set; }
		public DbSet<ProductRUOwnershipType> ProductRUOwnershipTypes { get; set; }
		public DbSet<ProductsCategory> ProductsCategories { get; set; }
		public DbSet<ProgramProduct> ProgramProducts { get; set; }
		public DbSet<Program> Programs { get; set; }
		public DbSet<RackStatu> RackStatus { get; set; }
		public DbSet<Receipt> Receipts { get; set; }
		public DbSet<ReceiptConfirmationPrintout> ReceiptConfirmationPrintouts { get; set; }
		public DbSet<ReceiptConfirmationStatu> ReceiptConfirmationStatus { get; set; }
		public DbSet<ReceiptInvoice> ReceiptInvoices { get; set; }
		public DbSet<ReceiptType> ReceiptTypes { get; set; }
		public DbSet<ReceiveDoc> ReceiveDocs { get; set; }
		public DbSet<ReceiveDocConfirmation> ReceiveDocConfirmations { get; set; }
		public DbSet<ReceiveDocDeleted> ReceiveDocDeleteds { get; set; }
		public DbSet<ReceivePallet> ReceivePallets { get; set; }
		public DbSet<ReceivingUnit> ReceivingUnits { get; set; }
		public DbSet<ReceivingUnitType> ReceivingUnitTypes { get; set; }
		public DbSet<Region> Regions { get; set; }
		public DbSet<Route> Routes { get; set; }
		public DbSet<RUOwnershipType> RUOwnershipTypes { get; set; }
		public DbSet<SchemaScript> SchemaScripts { get; set; }
		public DbSet<Shelf> Shelves { get; set; }
		public DbSet<ShelfRowColumn> ShelfRowColumns { get; set; }
		public DbSet<ShortageReason> ShortageReasons { get; set; }
		public DbSet<SoftwareSetting> SoftwareSettings { get; set; }
		public DbSet<StorageType> StorageTypes { get; set; }
		public DbSet<StoreGroup> StoreGroups { get; set; }
		public DbSet<StoreGroupDivision> StoreGroupDivisions { get; set; }
		public DbSet<StoreItem> StoreItems { get; set; }
		public DbSet<Store> Stores { get; set; }
		public DbSet<StoreType> StoreTypes { get; set; }
		public DbSet<STVLog> STVLogs { get; set; }
		public DbSet<SubCategory> SubCategories { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<SupplyCategory> SupplyCategories { get; set; }
		public DbSet<Transfer> Transfers { get; set; }
		public DbSet<TransferType> TransferTypes { get; set; }
		public DbSet<Type> Types { get; set; }
		public DbSet<Unit> Units { get; set; }
		public DbSet<UnitofIssue> UnitofIssues { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserPaymentType> UserPaymentTypes { get; set; }
		public DbSet<UserPhysicalStore> UserPhysicalStores { get; set; }
		public DbSet<UserStore> UserStores { get; set; }
		public DbSet<UserType> UserTypes { get; set; }
		public DbSet<VEN> VENs { get; set; }
		public DbSet<WeightedAverageLog> WeightedAverageLogs { get; set; }
		public DbSet<Woreda> Woredas { get; set; }
		public DbSet<YearEnd> YearEnds { get; set; }
		public DbSet<Zone> Zones { get; set; }
		public DbSet<vwAccount> vwAccounts { get; set; }
		public DbSet<vwAccountTree> vwAccountTrees { get; set; }
		public DbSet<vwAccountTreeByUser> vwAccountTreeByUsers { get; set; }
		public DbSet<vwGetAdjustment> vwGetAdjustments { get; set; }
		public DbSet<vwGetAllItem> vwGetAllItems { get; set; }
		public DbSet<vwGetCategory> vwGetCategories { get; set; }
		public DbSet<vwGetIssuedItemsByBatch> vwGetIssuedItemsByBatches { get; set; }
		public DbSet<vwGetIssue> vwGetIssues { get; set; }
		public DbSet<vwGetItemBalance> vwGetItemBalances { get; set; }
		public DbSet<vwGetItemProgram> vwGetItemPrograms { get; set; }
		public DbSet<vwGetItem> vwGetItems { get; set; }
		public DbSet<vwGetItemsByCategory> vwGetItemsByCategories { get; set; }
		public DbSet<vwGetItemSupplier> vwGetItemSuppliers { get; set; }
		public DbSet<vwGetLoss> vwGetLosses { get; set; }
		public DbSet<vwGetReceivedItemsByBatch> vwGetReceivedItemsByBatches { get; set; }
		public DbSet<vwGetShelfStore> vwGetShelfStores { get; set; }
		public DbSet<vwGetSupply> vwGetSupplies { get; set; }
		public DbSet<vwGetSupplyByCategory> vwGetSupplyByCategories { get; set; }
		public DbSet<vwGetSupplyProgram> vwGetSupplyPrograms { get; set; }
		public DbSet<vwGetUser> vwGetUsers { get; set; }
		public DbSet<vwIssueDoc> vwIssueDocs { get; set; }
		public DbSet<vwItemOnPalletLocation> vwItemOnPalletLocations { get; set; }
		public DbSet<vwItemsReadyForDispatch> vwItemsReadyForDispatches { get; set; }
		public DbSet<vwPallet> vwPallets { get; set; }
		public DbSet<vwPalletLocation> vwPalletLocations { get; set; }
		public DbSet<vwPhysicalStoreForItem> vwPhysicalStoreForItems { get; set; }
		public DbSet<vwReceiptPallet> vwReceiptPallets { get; set; }
		public DbSet<vwReceivedDoc> vwReceivedDocs { get; set; }
		public DbSet<vwTree> vwTrees { get; set; }
        public DbSet<Ledger> LedgerLites { get; set; }
        public DbSet<JournalLite> JournalLites { get; set; }
        public DbSet<TempLedger> Ledgers { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
            
			modelBuilder.Configurations.Add(new BalanceMap());
			modelBuilder.Configurations.Add(new CategoryMap());
			modelBuilder.Configurations.Add(new ChangeLogMap());
			modelBuilder.Configurations.Add(new ClusterMap());
			modelBuilder.Configurations.Add(new DirectoryUpdateMap());
			modelBuilder.Configurations.Add(new DirectoryUpdateStatuMap());
			modelBuilder.Configurations.Add(new DisposalMap());
			modelBuilder.Configurations.Add(new DisposalReasonMap());
			modelBuilder.Configurations.Add(new DosageFormMap());
			modelBuilder.Configurations.Add(new ErrorLogMap());
			modelBuilder.Configurations.Add(new ExchangeMap());
			modelBuilder.Configurations.Add(new ExchangeTypeMap());
			modelBuilder.Configurations.Add(new GeneralInfoMap());
			modelBuilder.Configurations.Add(new HalfPalletLocationMap());
			modelBuilder.Configurations.Add(new InternalTransferMap());
			modelBuilder.Configurations.Add(new IssueDocMap());
			modelBuilder.Configurations.Add(new IssueDocDeletedMap());
			modelBuilder.Configurations.Add(new ItemManufacturerMap());
			modelBuilder.Configurations.Add(new ItemOwnershipTypeMap());
			modelBuilder.Configurations.Add(new ItemPrefferedLocationMap());
			modelBuilder.Configurations.Add(new ItemReceivingUnitTypeMap());
			modelBuilder.Configurations.Add(new ItemMap());
			modelBuilder.Configurations.Add(new ItemSupplierMap());
			modelBuilder.Configurations.Add(new ItemSupplyCategoryMap());
			modelBuilder.Configurations.Add(new ItemUnitMap());
			modelBuilder.Configurations.Add(new ItemUnitCopyMap());
			modelBuilder.Configurations.Add(new LoginLogMap());
			modelBuilder.Configurations.Add(new ManufacturerMap());
			modelBuilder.Configurations.Add(new OrderMap());
			modelBuilder.Configurations.Add(new OrderDetailMap());
			modelBuilder.Configurations.Add(new OrderStatuMap());
			modelBuilder.Configurations.Add(new PalletMap());
			modelBuilder.Configurations.Add(new PalletLocationMap());
			modelBuilder.Configurations.Add(new PaymentTypeMap());
			modelBuilder.Configurations.Add(new PhysicalStoreMap());
			modelBuilder.Configurations.Add(new PhysicalStoreTypeMap());
			modelBuilder.Configurations.Add(new PickFaceMap());
			modelBuilder.Configurations.Add(new PickListMap());
			modelBuilder.Configurations.Add(new PickListDetailMap());
			modelBuilder.Configurations.Add(new POMap());
			modelBuilder.Configurations.Add(new PrintLogMap());
			modelBuilder.Configurations.Add(new ProductMap());
			modelBuilder.Configurations.Add(new ProductReceivingUnitTypeMap());
			modelBuilder.Configurations.Add(new ProductRUOwnershipTypeMap());
			modelBuilder.Configurations.Add(new ProductsCategoryMap());
			modelBuilder.Configurations.Add(new ProgramProductMap());
			modelBuilder.Configurations.Add(new ProgramMap());
			modelBuilder.Configurations.Add(new RackStatuMap());
			modelBuilder.Configurations.Add(new ReceiptMap());
			modelBuilder.Configurations.Add(new ReceiptConfirmationPrintoutMap());
			modelBuilder.Configurations.Add(new ReceiptConfirmationStatuMap());
			modelBuilder.Configurations.Add(new ReceiptInvoiceMap());
			modelBuilder.Configurations.Add(new ReceiptTypeMap());
			modelBuilder.Configurations.Add(new ReceiveDocMap());
			modelBuilder.Configurations.Add(new ReceiveDocConfirmationMap());
			modelBuilder.Configurations.Add(new ReceiveDocDeletedMap());
			modelBuilder.Configurations.Add(new ReceivePalletMap());
			modelBuilder.Configurations.Add(new ReceivingUnitMap());
			modelBuilder.Configurations.Add(new ReceivingUnitTypeMap());
			modelBuilder.Configurations.Add(new RegionMap());
			modelBuilder.Configurations.Add(new RouteMap());
			modelBuilder.Configurations.Add(new RUOwnershipTypeMap());
			modelBuilder.Configurations.Add(new SchemaScriptMap());
			modelBuilder.Configurations.Add(new ShelfMap());
			modelBuilder.Configurations.Add(new ShelfRowColumnMap());
			modelBuilder.Configurations.Add(new ShortageReasonMap());
			modelBuilder.Configurations.Add(new SoftwareSettingMap());
			modelBuilder.Configurations.Add(new StorageTypeMap());
			modelBuilder.Configurations.Add(new StoreGroupMap());
			modelBuilder.Configurations.Add(new StoreGroupDivisionMap());
			modelBuilder.Configurations.Add(new StoreItemMap());
			modelBuilder.Configurations.Add(new StoreMap());
			modelBuilder.Configurations.Add(new StoreTypeMap());
			modelBuilder.Configurations.Add(new STVLogMap());
			modelBuilder.Configurations.Add(new SubCategoryMap());
			modelBuilder.Configurations.Add(new SupplierMap());
			modelBuilder.Configurations.Add(new SupplyCategoryMap());
			modelBuilder.Configurations.Add(new TransferMap());
			modelBuilder.Configurations.Add(new TransferTypeMap());
			modelBuilder.Configurations.Add(new TypeMap());
			modelBuilder.Configurations.Add(new UnitMap());
			modelBuilder.Configurations.Add(new UnitofIssueMap());
			modelBuilder.Configurations.Add(new UserMap());
			modelBuilder.Configurations.Add(new UserPaymentTypeMap());
			modelBuilder.Configurations.Add(new UserPhysicalStoreMap());
			modelBuilder.Configurations.Add(new UserStoreMap());
			modelBuilder.Configurations.Add(new UserTypeMap());
			modelBuilder.Configurations.Add(new VENMap());
			modelBuilder.Configurations.Add(new WeightedAverageLogMap());
			modelBuilder.Configurations.Add(new WoredaMap());
			modelBuilder.Configurations.Add(new YearEndMap());
			modelBuilder.Configurations.Add(new ZoneMap());
			modelBuilder.Configurations.Add(new vwAccountMap());
			modelBuilder.Configurations.Add(new vwAccountTreeMap());
			modelBuilder.Configurations.Add(new vwAccountTreeByUserMap());
			modelBuilder.Configurations.Add(new vwGetAdjustmentMap());
			modelBuilder.Configurations.Add(new vwGetAllItemMap());
			modelBuilder.Configurations.Add(new vwGetCategoryMap());
			modelBuilder.Configurations.Add(new vwGetIssuedItemsByBatchMap());
			modelBuilder.Configurations.Add(new vwGetIssueMap());
			modelBuilder.Configurations.Add(new vwGetItemBalanceMap());
			modelBuilder.Configurations.Add(new vwGetItemProgramMap());
			modelBuilder.Configurations.Add(new vwGetItemMap());
			modelBuilder.Configurations.Add(new vwGetItemsByCategoryMap());
			modelBuilder.Configurations.Add(new vwGetItemSupplierMap());
			modelBuilder.Configurations.Add(new vwGetLossMap());
			modelBuilder.Configurations.Add(new vwGetReceivedItemsByBatchMap());
			modelBuilder.Configurations.Add(new vwGetShelfStoreMap());
			modelBuilder.Configurations.Add(new vwGetSupplyMap());
			modelBuilder.Configurations.Add(new vwGetSupplyByCategoryMap());
			modelBuilder.Configurations.Add(new vwGetSupplyProgramMap());
			modelBuilder.Configurations.Add(new vwGetUserMap());
			modelBuilder.Configurations.Add(new vwIssueDocMap());
			modelBuilder.Configurations.Add(new vwItemOnPalletLocationMap());
			modelBuilder.Configurations.Add(new vwItemsReadyForDispatchMap());
			modelBuilder.Configurations.Add(new vwPalletMap());
			modelBuilder.Configurations.Add(new vwPalletLocationMap());
			modelBuilder.Configurations.Add(new vwPhysicalStoreForItemMap());
			modelBuilder.Configurations.Add(new vwReceiptPalletMap());
			modelBuilder.Configurations.Add(new vwReceivedDocMap());
			modelBuilder.Configurations.Add(new vwTreeMap());

		}
	}
}
