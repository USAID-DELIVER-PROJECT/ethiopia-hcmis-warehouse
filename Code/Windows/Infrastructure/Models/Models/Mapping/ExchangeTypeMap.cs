using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ExchangeTypeMap : EntityTypeConfiguration<ExchangeType>
    {
        public ExchangeTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Type)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ExchangeType");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
