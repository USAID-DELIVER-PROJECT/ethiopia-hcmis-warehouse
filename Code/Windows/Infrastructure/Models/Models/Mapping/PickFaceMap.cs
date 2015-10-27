using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class PickFaceMap : EntityTypeConfiguration<PickFace>
    {
        public PickFaceMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("PickFace");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.PalletLocationID).HasColumnName("PalletLocationID");
            this.Property(t => t.DesignatedItem).HasColumnName("DesignatedItem");
            this.Property(t => t.Balance).HasColumnName("Balance");
            this.Property(t => t.LogicalStore).HasColumnName("LogicalStore");

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.PickFaces)
                .HasForeignKey(d => d.DesignatedItem);
            this.HasOptional(t => t.PalletLocation)
                .WithMany(t => t.PickFaces)
                .HasForeignKey(d => d.PalletLocationID);

        }
    }
}
