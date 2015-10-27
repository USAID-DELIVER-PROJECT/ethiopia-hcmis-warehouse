using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class OrderStatuMap : EntityTypeConfiguration<OrderStatu>
    {
        public OrderStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.OrderStatus)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("OrderStatus");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.OrderStatus).HasColumnName("OrderStatus");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
