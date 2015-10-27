using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ItemReceivingUnitTypeMap : EntityTypeConfiguration<ItemReceivingUnitType>
    {
        public ItemReceivingUnitTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ItemReceivingUnitType");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.ReceivingUnitTypeID).HasColumnName("ReceivingUnitTypeID");
            this.Property(t => t.AllowFully).HasColumnName("AllowFully");
            this.Property(t => t.Warning).HasColumnName("Warning");
            this.Property(t => t.Restriction).HasColumnName("Restriction");
            this.Property(t => t.MaxIssueQty).HasColumnName("MaxIssueQty");
            this.Property(t => t.MaxIssueQtyGapDays).HasColumnName("MaxIssueQtyGapDays");

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.ItemReceivingUnitTypes)
                .HasForeignKey(d => d.ItemID);
            this.HasOptional(t => t.ReceivingUnitType)
                .WithMany(t => t.ItemReceivingUnitTypes)
                .HasForeignKey(d => d.ReceivingUnitTypeID);

        }
    }
}
