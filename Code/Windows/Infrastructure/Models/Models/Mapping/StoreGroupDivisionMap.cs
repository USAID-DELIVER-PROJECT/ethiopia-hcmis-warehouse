using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class StoreGroupDivisionMap : EntityTypeConfiguration<StoreGroupDivision>
    {
        public StoreGroupDivisionMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Descriptiont)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("StoreGroupDivision");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Descriptiont).HasColumnName("Descriptiont");
            this.Property(t => t.StoreGroupID).HasColumnName("StoreGroupID");

            // Relationships
            this.HasOptional(t => t.StoreGroup)
                .WithMany(t => t.StoreGroupDivisions)
                .HasForeignKey(d => d.StoreGroupID);

        }
    }
}
