using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class vwGetUserMap : EntityTypeConfiguration<vwGetUser>
    {
        public vwGetUserMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Type)
                .HasMaxLength(50);

            this.Property(t => t.Mobile)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(50);

            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FullName)
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .HasMaxLength(50);

            this.Property(t => t.UserName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vwGetUsers");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.FullName).HasColumnName("FullName");
            this.Property(t => t.UserType).HasColumnName("UserType");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
