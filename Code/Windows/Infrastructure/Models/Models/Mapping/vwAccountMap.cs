using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class vwAccountMap : EntityTypeConfiguration<vwAccount>
    {
        public vwAccountMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ActivityID, t.AccountID });

            // Properties
            this.Property(t => t.ActivityID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ActivityName)
                .HasMaxLength(50);

            this.Property(t => t.SubAccountName)
                .HasMaxLength(50);

            this.Property(t => t.AccountID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AccountName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vwAccounts");
            this.Property(t => t.ActivityID).HasColumnName("ActivityID");
            this.Property(t => t.ActivityName).HasColumnName("ActivityName");
            this.Property(t => t.SubAccountID).HasColumnName("SubAccountID");
            this.Property(t => t.SubAccountName).HasColumnName("SubAccountName");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.AccountName).HasColumnName("AccountName");
            this.Property(t => t.ModeID).HasColumnName("ModeID");
        }
    }
}
