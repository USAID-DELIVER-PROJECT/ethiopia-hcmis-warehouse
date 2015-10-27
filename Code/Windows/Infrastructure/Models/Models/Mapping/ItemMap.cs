using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ItemMap : EntityTypeConfiguration<Item>
    {
        public ItemMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.StockCode)
                .HasMaxLength(50);

            this.Property(t => t.Strength)
                .HasMaxLength(1500);

            this.Property(t => t.Code)
                .HasMaxLength(50);

            this.Property(t => t.StockCodeDACA)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Items");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.StockCode).HasColumnName("StockCode");
            this.Property(t => t.Strength).HasColumnName("Strength");
            this.Property(t => t.DosageFormID).HasColumnName("DosageFormID");
            this.Property(t => t.UnitID).HasColumnName("UnitID");
            this.Property(t => t.VEN).HasColumnName("VEN");
            this.Property(t => t.ABC).HasColumnName("ABC");
            this.Property(t => t.IsFree).HasColumnName("IsFree");
            this.Property(t => t.IsDiscontinued).HasColumnName("IsDiscontinued");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.EDL).HasColumnName("EDL");
            this.Property(t => t.Refrigeratored).HasColumnName("Refrigeratored");
            this.Property(t => t.Pediatric).HasColumnName("Pediatric");
            this.Property(t => t.IINID).HasColumnName("IINID");
            this.Property(t => t.IsInHospitalList).HasColumnName("IsInHospitalList");
            this.Property(t => t.NeedExpiryBatch).HasColumnName("NeedExpiryBatch");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.StockCodeDACA).HasColumnName("StockCodeDACA");
            this.Property(t => t.NearExpiryTrigger).HasColumnName("NearExpiryTrigger");
            this.Property(t => t.StorageTypeID).HasColumnName("StorageTypeID");
            this.Property(t => t.IsStackStored).HasColumnName("IsStackStored");

            // Relationships
            this.HasOptional(t => t.StorageType)
                .WithMany(t => t.Items)
                .HasForeignKey(d => d.StorageTypeID);
            this.HasRequired(t => t.Unit)
                .WithMany(t => t.Items)
                .HasForeignKey(d => d.UnitID);
            this.HasOptional(t => t.VEN1)
                .WithMany(t => t.Items)
                .HasForeignKey(d => d.VEN);

        }
    }
}
