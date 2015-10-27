using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class UserStoreMap : EntityTypeConfiguration<UserStore>
    {
        public UserStoreMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("UserStore");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.CanAccess).HasColumnName("CanAccess");
            this.Property(t => t.IsDefault).HasColumnName("IsDefault");

            // Relationships
            this.HasOptional(t => t.Store)
                .WithMany(t => t.UserStores)
                .HasForeignKey(d => d.StoreID);
            this.HasOptional(t => t.User)
                .WithMany(t => t.UserStores)
                .HasForeignKey(d => d.UserID);

        }
    }
}
