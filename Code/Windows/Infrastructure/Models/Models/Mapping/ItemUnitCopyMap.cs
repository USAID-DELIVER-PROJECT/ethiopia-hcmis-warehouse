using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ItemUnitCopyMap : EntityTypeConfiguration<ItemUnitCopy>
    {
        public ItemUnitCopyMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.ItemID, t.QtyPerUnit, t.Text });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ItemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.QtyPerUnit)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Text)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ItemUnitCopy");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.QtyPerUnit).HasColumnName("QtyPerUnit");
            this.Property(t => t.Text).HasColumnName("Text");
        }
    }
}
