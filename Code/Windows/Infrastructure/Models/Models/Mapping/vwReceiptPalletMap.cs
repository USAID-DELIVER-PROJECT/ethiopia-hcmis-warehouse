using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class vwReceiptPalletMap : EntityTypeConfiguration<vwReceiptPallet>
    {
        public vwReceiptPalletMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.FullItemName, t.PalletLocationID, t.PhyicalStoreID, t.WarehouseID, t.ClusterID, t.ManufacturerID, t.ItemUnitID, t.ItemUnitName, t.ActivityID, t.AccountID });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FullItemName)
                .IsRequired()
                .HasMaxLength(3056);

            this.Property(t => t.PalletLocationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Label)
                .HasMaxLength(50);

            this.Property(t => t.PhysicalStoreName)
                .HasMaxLength(50);

            this.Property(t => t.WarehouseName)
                .HasMaxLength(50);

            this.Property(t => t.ClusterName)
                .HasMaxLength(50);

            this.Property(t => t.PhyicalStoreID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.WarehouseID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ClusterID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ManufacturerID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ManufacturerName)
                .HasMaxLength(50);

            this.Property(t => t.ItemUnitID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ItemUnitName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ActivityID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ActivityName)
                .HasMaxLength(50);

            this.Property(t => t.SubAccountName)
                .HasMaxLength(50);

            this.Property(t => t.AccountID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AccountName)
                .HasMaxLength(50);

            this.Property(t => t.CommodityTypeName)
                .HasMaxLength(50);

            this.Property(t => t.StockCode)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vwReceiptPallet");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ReceiveDocID).HasColumnName("ReceiveDocID");
            this.Property(t => t.BalanceBU).HasColumnName("BalanceBU");
            this.Property(t => t.ReceivedQuantityBU).HasColumnName("ReceivedQuantityBU");
            this.Property(t => t.QtyPerPack).HasColumnName("QtyPerPack");
            this.Property(t => t.ReceivedPacks).HasColumnName("ReceivedPacks");
            this.Property(t => t.Packs).HasColumnName("Packs");
            this.Property(t => t.ExpiryDate).HasColumnName("ExpiryDate");
            this.Property(t => t.FullItemName).HasColumnName("FullItemName");
            this.Property(t => t.PalletID).HasColumnName("PalletID");
            this.Property(t => t.PalletLocationID).HasColumnName("PalletLocationID");
            this.Property(t => t.Label).HasColumnName("Label");
            this.Property(t => t.PhysicalStoreName).HasColumnName("PhysicalStoreName");
            this.Property(t => t.WarehouseName).HasColumnName("WarehouseName");
            this.Property(t => t.ClusterName).HasColumnName("ClusterName");
            this.Property(t => t.PhyicalStoreID).HasColumnName("PhyicalStoreID");
            this.Property(t => t.WarehouseID).HasColumnName("WarehouseID");
            this.Property(t => t.ClusterID).HasColumnName("ClusterID");
            this.Property(t => t.StorageTypeID).HasColumnName("StorageTypeID");
            this.Property(t => t.ManufacturerID).HasColumnName("ManufacturerID");
            this.Property(t => t.ManufacturerName).HasColumnName("ManufacturerName");
            this.Property(t => t.ItemUnitID).HasColumnName("ItemUnitID");
            this.Property(t => t.ItemUnitName).HasColumnName("ItemUnitName");
            this.Property(t => t.ActivityID).HasColumnName("ActivityID");
            this.Property(t => t.ActivityName).HasColumnName("ActivityName");
            this.Property(t => t.SubAccountID).HasColumnName("SubAccountID");
            this.Property(t => t.SubAccountName).HasColumnName("SubAccountName");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.AccountName).HasColumnName("AccountName");
            this.Property(t => t.ModeID).HasColumnName("ModeID");
            this.Property(t => t.CommodityTypeID).HasColumnName("CommodityTypeID");
            this.Property(t => t.CommodityTypeName).HasColumnName("CommodityTypeName");
            this.Property(t => t.StockCode).HasColumnName("StockCode");
        }
    }
}
