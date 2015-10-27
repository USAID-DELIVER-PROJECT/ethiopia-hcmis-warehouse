using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class UserTypeMap : EntityTypeConfiguration<UserType>
    {
        public UserTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Type)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("UserType");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Type).HasColumnName("Type");
        }
    }
}
