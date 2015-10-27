using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ItemOwnershipTypeMap : EntityTypeConfiguration<ItemOwnershipType>
    {
        public ItemOwnershipTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ItemOwnershipType");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.RUOwnershipTypeID).HasColumnName("RUOwnershipTypeID");
            this.Property(t => t.AllowFully).HasColumnName("AllowFully");
            this.Property(t => t.Warning).HasColumnName("Warning");
            this.Property(t => t.Restriction).HasColumnName("Restriction");
            this.Property(t => t.MaxIssueQty).HasColumnName("MaxIssueQty");
            this.Property(t => t.MaxIssueQtyGapDays).HasColumnName("MaxIssueQtyGapDays");

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.ItemOwnershipTypes)
                .HasForeignKey(d => d.ItemID);
            this.HasOptional(t => t.RUOwnershipType)
                .WithMany(t => t.ItemOwnershipTypes)
                .HasForeignKey(d => d.RUOwnershipTypeID);

        }
    }
}
