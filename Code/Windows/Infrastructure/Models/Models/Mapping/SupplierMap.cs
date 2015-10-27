using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class SupplierMap : EntityTypeConfiguration<Supplier>
    {
        public SupplierMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CompanyName)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(50);

            this.Property(t => t.Telephone)
                .HasMaxLength(50);

            this.Property(t => t.ContactPerson)
                .HasMaxLength(50);

            this.Property(t => t.Mobile)
                .HasMaxLength(50);

            this.Property(t => t.CompanyInfo)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Supplier");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.ContactPerson).HasColumnName("ContactPerson");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.CompanyInfo).HasColumnName("CompanyInfo");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.Email).HasColumnName("Email");
        }
    }
}
