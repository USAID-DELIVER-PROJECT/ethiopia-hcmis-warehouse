using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class RouteMap : EntityTypeConfiguration<Route>
    {
        public RouteMap()
        {
            // Primary Key
            this.HasKey(t => t.RouteID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Route");
            this.Property(t => t.RouteID).HasColumnName("RouteID");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
