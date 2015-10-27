using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class GeneralInfoMap : EntityTypeConfiguration<GeneralInfo>
    {
        public GeneralInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.HospitalName)
                .HasMaxLength(50);

            this.Property(t => t.Telephone)
                .HasMaxLength(50);

            this.Property(t => t.HospitalContact)
                .HasMaxLength(50);

            this.Property(t => t.Logo)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("GeneralInfo");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.HospitalName).HasColumnName("HospitalName");
            this.Property(t => t.Woreda).HasColumnName("Woreda");
            this.Property(t => t.Zone).HasColumnName("Zone");
            this.Property(t => t.Region).HasColumnName("Region");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.HospitalContact).HasColumnName("HospitalContact");
            this.Property(t => t.LeadTime).HasColumnName("LeadTime");
            this.Property(t => t.Min).HasColumnName("Min");
            this.Property(t => t.Max).HasColumnName("Max");
            this.Property(t => t.SafteyStock).HasColumnName("SafteyStock");
            this.Property(t => t.AMCRange).HasColumnName("AMCRange");
            this.Property(t => t.ReviewPeriod).HasColumnName("ReviewPeriod");
            this.Property(t => t.EOP).HasColumnName("EOP");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.IsEven).HasColumnName("IsEven");
            this.Property(t => t.Logo).HasColumnName("Logo");
            this.Property(t => t.DUMin).HasColumnName("DUMin");
            this.Property(t => t.DUMax).HasColumnName("DUMax");
            this.Property(t => t.DUAMCRange).HasColumnName("DUAMCRange");
            this.Property(t => t.LastBackUp).HasColumnName("LastBackUp");
            this.Property(t => t.FacilityID).HasColumnName("FacilityID");
        }
    }
}
