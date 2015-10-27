using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class PhysicalStoreTypeMap : EntityTypeConfiguration<PhysicalStoreType>
    {
        public PhysicalStoreTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PhysicalStoreType");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ClusterID).HasColumnName("ClusterID");

            // Relationships
            this.HasOptional(t => t.Cluster)
                .WithMany(t => t.PhysicalStoreTypes)
                .HasForeignKey(d => d.ClusterID);

        }
    }
}
