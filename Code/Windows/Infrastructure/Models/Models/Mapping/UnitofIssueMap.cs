using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class UnitofIssueMap : EntityTypeConfiguration<UnitofIssue>
    {
        public UnitofIssueMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Text)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("UnitofIssue");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.QtyPerUnit).HasColumnName("QtyPerUnit");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
