using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class vwPalletMap : EntityTypeConfiguration<vwPallet>
    {
        public vwPalletMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PalletLocationID, t.PhyicalStoreID, t.WarehouseID, t.ClusterID });

            // Properties
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

            // Table & Column Mappings
            this.ToTable("vwPallet");
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
        }
    }
}
