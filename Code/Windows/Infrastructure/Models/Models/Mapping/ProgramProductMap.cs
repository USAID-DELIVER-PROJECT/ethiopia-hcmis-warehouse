using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ProgramProductMap : EntityTypeConfiguration<ProgramProduct>
    {
        public ProgramProductMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ProgramProduct");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ProgramID).HasColumnName("ProgramID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.ProgramProducts)
                .HasForeignKey(d => d.ItemID);
            this.HasOptional(t => t.Program)
                .WithMany(t => t.ProgramProducts)
                .HasForeignKey(d => d.ProgramID);

        }
    }
}
