using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ErrorLogMap : EntityTypeConfiguration<ErrorLog>
    {
        public ErrorLogMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.StatusCode)
                .HasMaxLength(50);

            this.Property(t => t.Type)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ErrorLog");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.StatusCode).HasColumnName("StatusCode");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Time).HasColumnName("Time");
            this.Property(t => t.Details).HasColumnName("Details");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.ErrorLogs)
                .HasForeignKey(d => d.UserID);

        }
    }
}
