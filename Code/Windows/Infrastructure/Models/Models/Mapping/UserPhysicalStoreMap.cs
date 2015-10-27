using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class UserPhysicalStoreMap : EntityTypeConfiguration<UserPhysicalStore>
    {
        public UserPhysicalStoreMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("UserPhysicalStore");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.PhysicalStoreID).HasColumnName("PhysicalStoreID");
            this.Property(t => t.CanAccess).HasColumnName("CanAccess");
            this.Property(t => t.IsDefault).HasColumnName("IsDefault");

            // Relationships
            this.HasOptional(t => t.PhysicalStore)
                .WithMany(t => t.UserPhysicalStores)
                .HasForeignKey(d => d.PhysicalStoreID);
            this.HasOptional(t => t.User)
                .WithMany(t => t.UserPhysicalStores)
                .HasForeignKey(d => d.UserID);

        }
    }
}
