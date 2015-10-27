using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Item
    {
        public Item()
        {
            this.Balances = new List<Balance>();
            this.Disposals = new List<Disposal>();
            this.IssueDocs = new List<IssueDoc>();
            this.ItemManufacturers = new List<ItemManufacturer>();
            this.ItemOwnershipTypes = new List<ItemOwnershipType>();
            this.ItemPrefferedLocations = new List<ItemPrefferedLocation>();
            this.ItemReceivingUnitTypes = new List<ItemReceivingUnitType>();
            this.ItemSuppliers = new List<ItemSupplier>();
            this.ItemSupplyCategories = new List<ItemSupplyCategory>();
            this.OrderDetails = new List<OrderDetail>();
            this.OrderDetails1 = new List<OrderDetail>();
            this.PickFaces = new List<PickFace>();
            this.PickListDetails = new List<PickListDetail>();
            this.ProductsCategories = new List<ProductsCategory>();
            this.ProgramProducts = new List<ProgramProduct>();
            this.ReceiveDocs = new List<ReceiveDoc>();
            this.StoreItems = new List<StoreItem>();
            this.YearEnds = new List<YearEnd>();
        }

        public int ID { get; set; }
        public string StockCode { get; set; }
        public string Strength { get; set; }
        public Nullable<int> DosageFormID { get; set; }
        public int UnitID { get; set; }
        public Nullable<int> VEN { get; set; }
        public Nullable<int> ABC { get; set; }
        public Nullable<bool> IsFree { get; set; }
        public Nullable<bool> IsDiscontinued { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<bool> EDL { get; set; }
        public Nullable<bool> Refrigeratored { get; set; }
        public Nullable<bool> Pediatric { get; set; }
        public Nullable<int> IINID { get; set; }
        public Nullable<bool> IsInHospitalList { get; set; }
        public Nullable<bool> NeedExpiryBatch { get; set; }
        public string Code { get; set; }
        public string StockCodeDACA { get; set; }
        public Nullable<double> NearExpiryTrigger { get; set; }
        public Nullable<int> StorageTypeID { get; set; }
        public Nullable<bool> IsStackStored { get; set; }
        public virtual ICollection<Balance> Balances { get; set; }
        public virtual ICollection<Disposal> Disposals { get; set; }
        public virtual ICollection<IssueDoc> IssueDocs { get; set; }
        public virtual ICollection<ItemManufacturer> ItemManufacturers { get; set; }
        public virtual ICollection<ItemOwnershipType> ItemOwnershipTypes { get; set; }
        public virtual ICollection<ItemPrefferedLocation> ItemPrefferedLocations { get; set; }
        public virtual ICollection<ItemReceivingUnitType> ItemReceivingUnitTypes { get; set; }
        public virtual StorageType StorageType { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual VEN VEN1 { get; set; }
        public virtual ICollection<ItemSupplier> ItemSuppliers { get; set; }
        public virtual ICollection<ItemSupplyCategory> ItemSupplyCategories { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails1 { get; set; }
        public virtual ICollection<PickFace> PickFaces { get; set; }
        public virtual ICollection<PickListDetail> PickListDetails { get; set; }
        public virtual ICollection<ProductsCategory> ProductsCategories { get; set; }
        public virtual ICollection<ProgramProduct> ProgramProducts { get; set; }
        public virtual ICollection<ReceiveDoc> ReceiveDocs { get; set; }
        public virtual ICollection<StoreItem> StoreItems { get; set; }
        public virtual ICollection<YearEnd> YearEnds { get; set; }
    }
}
