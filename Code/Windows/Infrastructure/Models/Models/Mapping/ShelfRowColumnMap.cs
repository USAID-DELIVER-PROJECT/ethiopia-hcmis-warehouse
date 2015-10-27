using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ShelfRowColumnMap : EntityTypeConfiguration<ShelfRowColumn>
    {
        public ShelfRowColumnMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Label)
                .HasMaxLength(50);

            this.Property(t => t.Type)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ShelfRowColumn");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Label).HasColumnName("Label");
            this.Property(t => t.ShelfID).HasColumnName("ShelfID");
            this.Property(t => t.Index).HasColumnName("Index");
            this.Property(t => t.Dimension).HasColumnName("Dimension");
            this.Property(t => t.Type).HasColumnName("Type");

            // Relationships
            this.HasOptional(t => t.Shelf)
                .WithMany(t => t.ShelfRowColumns)
                .HasForeignKey(d => d.ShelfID);

        }
    }
}
