using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class LoginLogMap : EntityTypeConfiguration<LoginLog>
    {
        public LoginLogMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.HostName)
                .HasMaxLength(50);

            this.Property(t => t.IPAddress)
                .HasMaxLength(50);

            this.Property(t => t.MACAddress)
                .HasMaxLength(50);

            this.Property(t => t.UnknownUserName)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.ApplicationVersion)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("LoginLog");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.LoginTime).HasColumnName("LoginTime");
            this.Property(t => t.SuccesfulLogin).HasColumnName("SuccesfulLogin");
            this.Property(t => t.LogOffTime).HasColumnName("LogOffTime");
            this.Property(t => t.HostName).HasColumnName("HostName");
            this.Property(t => t.IPAddress).HasColumnName("IPAddress");
            this.Property(t => t.MACAddress).HasColumnName("MACAddress");
            this.Property(t => t.UnknownUser).HasColumnName("UnknownUser");
            this.Property(t => t.UnknownUserName).HasColumnName("UnknownUserName");
            this.Property(t => t.ApplicationVersion).HasColumnName("ApplicationVersion");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.LoginLogs)
                .HasForeignKey(d => d.UserID);

        }
    }
}
