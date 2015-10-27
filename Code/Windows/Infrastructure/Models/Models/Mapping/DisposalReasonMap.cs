using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class DisposalReasonMap : EntityTypeConfiguration<DisposalReason>
    {
        public DisposalReasonMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("DisposalReasons");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Reason).HasColumnName("Reason");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
